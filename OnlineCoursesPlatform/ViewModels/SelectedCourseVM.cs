using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic.ApplicationServices;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using OnlineCoursesPlatform.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace OnlineCoursesPlatform.ViewModels
{
    public class SelectedCourseVM : ViewModel
    {
        private Course _currentCourse;
        public Course CurrentCourse
        {
            get => _currentCourse;
            set => Set(ref _currentCourse, value);
        }
        private User _curUser = GlobalInstanses.CurrentUser;
        public User CurUser
        {
            get => _curUser;
            set => Set(ref _curUser, value);
        }
        private string _text;
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
        private string stepsCount;
        public string StepsCount
        {
            get => stepsCount;
            set => Set(ref stepsCount, value);
        }

        private string _commentText = string.Empty;
        public string CommentText
        {
            get => _commentText;
            set => Set(ref _commentText, value);
        }
        private string buttonText = "Learn";
        public string ButtonText
        {
            get => buttonText;
            set => Set(ref buttonText, value);
        }
        private bool isAddedTBChecked;
        public bool IsAddedTBChecked
        {
            get => isAddedTBChecked;
            set => Set(ref  isAddedTBChecked, value);
        }

        private string replyText = string.Empty ;
        public string ReplyText
        {
            get => replyText;
            set => Set(ref replyText, value);
        }

        private ObservableCollection<Comment> _comments;
        public ObservableCollection<Comment> Comments
        {
            get => _comments;
            set => Set(ref _comments, value);   
        }

        private void OnAddToMyCourses(object p)
        {
            Course course; User user;
            /* var _us = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
             var _cour = db.Courses.FirstOrDefault(c => c.Id == CurrentCourse.Id);

             try { db.Users.Attach(_us); } catch { }
             try { db.Courses.Attach(_cour); } catch { }*/
            course = db.Courses.SingleOrDefault(c => c.Id == CurrentCourse.Id);
            user = db.Users.SingleOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);

            if ((bool)p)
            {
                //GlobalInstanses.CurrentUser.Courses.Add(CurrentCourse);

                
                user.Courses.Add(course);
                
            }
            else
            {
                user.Courses.Remove(course);

            }
            db.SaveChanges();

        }

        private void OnAddCommentCommand(object p)
        {
            var _cour = db.Courses.FirstOrDefault(c => c.Id == CurrentCourse.Id);
            for (int i = 0; i < IsStarChecked.Count; i++)
            {
                IsStarChecked[i] = false;
            }
            ratings.Add(currentRange);
            _cour.Rating = ratings.Average();

            var currentUser = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            //db.Courses.Include(c => c.Comments).ThenInclude(cs => cs.User).Load();

            (_cour.Comments ??= new ObservableCollection<Comment>()).Add(new Comment()
            {
                User = currentUser,
                CommentText = this.CommentText
            });
            try
            {
                var res = db.SaveChanges();
                MessageBox.Show(res.ToString());

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            db.Courses.Update(_cour);
            Comments = _cour.Comments;
            db.Courses.Include((c) => c.Comments).Load();
            OnPropertyChanged(nameof(_cour));
            OnPropertyChanged(nameof(_cour.Comments));
            foreach (var c in CurrentCourse.Comments)
            {
                OnPropertyChanged(nameof(c.User));
            }

            CommentText = string.Empty;
        }
        private User commentUser;
        public User CommentUser
        {
            get => commentUser; 
            set => Set(ref  commentUser, value);
        }
        private Comment selectedComment;
        public Comment SelectedComment
        {
            get => selectedComment;
            set => Set(ref selectedComment, value);
        }
        private Comment replyingComment = new();
        public Comment ReplyingComment
        {
            get => replyingComment;
            set => Set(ref replyingComment, value);
        }

        private bool isRepying = false;
        public bool IsReplying
        {
            get => isRepying;
            set => Set(ref  isRepying, value);
        }
        private void OnAddAnswerToComment(object p)
        {
            ReplyingComment = p as Comment;
            ReplyingComment.HasReplies = true;
            IsReplying = true;
            OnPropertyChanged(nameof(ReplyingComment.HasReplies));

            db.SaveChanges();

        }
        
        private void OnCloseCommand(object p)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.IsActive);
            activeWindow?.Close();
        }

        private void OnAddReplyText(object p)
        {
            var _cour = db.Courses.FirstOrDefault(c => c.Id == CurrentCourse.Id);
            var _us = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            var _replComment = _cour.Comments.FirstOrDefault(c => c.Id == ReplyingComment.Id);

            _replComment.Replies.Add(new Comment()
            {
                CommentText = ReplyText,
                User = _us,
            });
            db.SaveChanges();
            IsReplying = false;
            
        }

      
        private void OnDeleteCourseCommand(object p)
        {
            if (CurUser.Role is Roles.admin)
            {
                var res = MessageBox.Show("Do you really want to delete course?", "Delete course", MessageBoxButtons.YesNoCancel);
                if(res == DialogResult.Yes)
                {
                    try { db.Courses.Attach(CurrentCourse); }
                    catch { }
                    string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Создание папки для сохранения файлов
                    string courseFolderPath = Path.Combine(appFolderPath, "Resourses", CurrentCourse.Name);
                    if (Directory.Exists(courseFolderPath))
                    {
                        try
                        {
                            Directory.Delete(courseFolderPath, true); // true - удаляет все файлы и папки внутри
                            //Console.WriteLine($"Папка '{folderName}' успешно удалена.");
                        }
                        catch (IOException ex)
                        {
                            //Console.WriteLine($"Ошибка при удалении папки '{courseFolderPath}': {ex.Message}");
                        }
                    }
                    //File.Delete()

                    db.Courses.Remove(CurrentCourse);
                    db.SaveChanges();
                    navigate?.Invoke(new SelectedCourseProps("AllCourses", null, 0));
                }
               
            }
        }
        private ObservableCollection<User> subscribersList = new();
        public ObservableCollection<User> SubscribersList
        {
            get => subscribersList;
            set => Set(ref subscribersList, value);
        }


        private readonly Action<object> navigate;
        private SelectedCourseProps prop;
        
        private List<int> ratings = new List<int>();
        private ObservableCollection<bool> isStarChecked;
        public ObservableCollection<bool> IsStarChecked
        {
            get => isStarChecked;
            set => Set(ref isStarChecked, value);
        }
        private int currentRange = 0;
        private void OnStarCommand(object p)
        {
            int selectedStar = Convert.ToInt32(p);
            currentRange = selectedStar;

            for (int i = 0; i < IsStarChecked.Count; i++)
            {
                IsStarChecked[i] = (i < selectedStar);
            }
        }
        private void ToAllCourses(object p)
        {
            prop = new SelectedCourseProps("AllCourses", CurrentCourse, 0);
            navigate.Invoke(prop);
        }

        private string courseAuthor;
        public string CourseAuthor
        {
            get => courseAuthor;
            set => Set(ref courseAuthor, value);
        }
        public string DateText { get; set; }

        private void OnNavigate(object obj)
        {
            int pr = 0;
            string message;
            Course course; User user;
            string direction = obj.ToString();
            Permission permission = db.Permissions.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == CurrentCourse.Id);

            switch (direction)
            {
                case "AllCourses":
                    prop = new SelectedCourseProps(direction, CurrentCourse, pr);
                    navigate.Invoke(prop);
                    break;
                case "Edit":
                    prop = new SelectedCourseProps(direction + "Course", CurrentCourse, pr);
                    navigate.Invoke(prop);
                    break;
                case "Sign up":
                    ButtonText = "Requested";
                    course = db.Courses.SingleOrDefault(c => c.Id == CurrentCourse.Id);
                    user = db.Users.SingleOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
                    user.Courses.Add(course);
                    db.SaveChanges();
                    try { db.Permissions.Attach(permission); } catch { }
                    permission.State = PermissionState.requested;
                    db.SaveChanges();
                    break;
                case "Soon":
                    if (CurrentCourse.Steps.Count == 0)
                        message = "Sorry, the author apparently didn't add lessons to this course. Soon we'll fix that!";
                    else
                        message = $"Acces to the course will open {((DateTime)CurrentCourse.StartDate).ToString("d")} and will be closed {((DateTime)CurrentCourse.FinishDate).ToString("d")}";
                    MessageBox.Show(message);
                    break;
                case "Block":
                    message = "You have been blocked by the administration of this course";
                    MessageBox.Show(message);
                    break;
                case "Requested":
                    Permission currentPermission = db.Permissions.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == CurrentCourse.Id);
                    message = "The course will be available after your request is approved. Do you want to cancel the request?";
                    var res = MessageBox.Show(message, "Request send", MessageBoxButtons.YesNoCancel);
                    if(res == DialogResult.Yes)
                    {
                        currentPermission.State = PermissionState.close;
                        ButtonText = "Sign up";
                        db.SaveChanges();
                    }
                    break;
                case "Learn":
                    string innerDir = "Steps";
                    GlobalInstanses.LastCourse = CurrentCourse;
                    course = db.Courses.SingleOrDefault(c => c.Id == CurrentCourse.Id);
                    user = db.Users.SingleOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
                    user.Courses.Add(course);
                    db.SaveChanges();
                    //try { db.Courses.Attach(GlobalInstanses.LastCourse); } catch { }
                    var progr = db.Progresses.FirstOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id);
                    if (progr == null)
                    {
                        db.Progresses.Add(new CourseProgress()
                        {
                            CourseId = GlobalInstanses.LastCourse.Id,
                            UserId = GlobalInstanses.CurrentUser.Id,
                        });
                        db.SaveChanges();
                        progr = db.Progresses.FirstOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id);
                    }
                    
                    
                    if(progr.CurrentStepNumber >= CurrentCourse.Steps.Count)
                    //if(user.FinishedCourses.Any(c => c.Id == CurrentCourse.Id))
                    {
                        if(CurrentCourse.Test == null)
                        {
                            message = "You have already passed this test. Do you want to go through it again?";
                            DialogResult result = MessageBox.Show(message, "Re-learn course", MessageBoxButtons.YesNoCancel);
                            if (result == DialogResult.Yes)
                            {
                                progr.CurrentStepNumber = 0;
                                //user.FinishedCourses.Remove(course);
                            }
                            else return;
                        }
                        else
                        {
                            message = "You have already passed this test. Do you want to retake the course or just the test?\n(Y - course, N - just test)";
                            DialogResult result = MessageBox.Show(message, "Re-learn course", MessageBoxButtons.YesNoCancel);
                            if(result == DialogResult.Yes)
                            {
                                progr.CurrentStepNumber = 0;
                                //user.FinishedCourses.Remove(course);
                            }
                            else if(result == DialogResult.No)
                            {
                                innerDir = "FinalTest";
                                progr.CurrentStepNumber--;
                            }
                            else return ;
                        }
                    }
                    db.SaveChanges();
                    pr = db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber;
                    //pr = progr.CurrentStepNumber;

                    prop = new SelectedCourseProps(innerDir, CurrentCourse, pr);
                    navigate.Invoke(prop);
                    break;
            }
        }


        public BCommand StarCommand { get; }
        public BCommand Navigate { get; set; }
        public BCommand AddCommentCommand { get; }
        public BCommand DeleteCourseCommand { get; }
        public BCommand AddToMyCoursesCommand {  get; }
        public BCommand AddAnswerToComment { get; }
        public BCommand CloseCommand { get; }
        public BCommand SendReplyCommand { get; }
        public BCommand ToAllCoursesCommand { get; }
        public BCommand AddReplyTextCommand {  get; }
        public SelectedCourseVM(Action<object> navigate, Course course)
        {
            db = new();

            this.navigate = navigate;
            CurrentCourse = course;

            db.Courses.Include(c => c.Comments)
                      .ThenInclude(cm => cm.User)
                      .Load();

            db.Courses.Include(c => c.Comments)
                      .ThenInclude(cm => cm.Replies)
                      .Load();

            db.Courses.Include(c => c.Steps)
                      .Load();
            db.Courses.Include(c => c.Users)
                .ThenInclude(s => s.Courses)
                .Load();
            db.Users.Include(u => u.Courses).Load();
            db.Permissions.Include(p => p.User).Include(p => p.Course).Load();

           
            StepsCount = CurrentCourse.Steps == null || CurrentCourse.Steps.Count == 0? "No" : CurrentCourse.Steps.Count.ToString();
            CourseAuthor = CurrentCourse.Author;
            if (CurrentCourse.StartDate != null)
            {
                DateTime start = (DateTime)CurrentCourse.StartDate;
                DateTime finish = (DateTime)CurrentCourse.FinishDate;
                DateText = start.ToString("d") + " - " + finish.ToString("d"); ;
            }
            else DateText = "no date limits";
            #region Access button

            Permission currentPermission = db.Permissions.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == CurrentCourse.Id);
            if (GlobalInstanses.CurrentUser.Role is Roles.admin)
            {
               if(CurrentCourse.Steps == null || CurrentCourse.Steps.Count == 0)
                    ButtonText = "Soon";
               else ButtonText = "Learn";
            }
            else
            {
                
                if (currentPermission.State is PermissionState.close && !CurrentCourse.IsOpen)
                    ButtonText = "Sign up";
                if (currentPermission.State is PermissionState.close && CurrentCourse.IsOpen)
                    ButtonText = "Close";
                if (currentPermission.State is PermissionState.requested)
                    ButtonText = "Requested";
                if (CurrentCourse.StartDate != null || CurrentCourse.Steps == null || CurrentCourse.Steps.Count == 0)
                    ButtonText = "Soon";
                if (currentPermission.State is PermissionState.open || 
                    currentPermission.State is PermissionState.open && CurrentCourse.StartDate<=DateTime.Now && CurrentCourse.FinishDate >= DateTime.Now)
                    ButtonText = "Learn";

            }

            #endregion

            AddCommentCommand = new(OnAddCommentCommand, (o) => CommentText.Trim() != string.Empty);
            Navigate = new BCommand(OnNavigate, (o)=>true);
            ToAllCoursesCommand = new(ToAllCourses, (o) => true);
            DeleteCourseCommand = new(OnDeleteCourseCommand, (o) => CurUser.Role is Roles.admin);
            AddToMyCoursesCommand = new(OnAddToMyCourses, (o) => true);
            CloseCommand = new(OnCloseCommand, (o) => true);
            AddAnswerToComment = new(OnAddAnswerToComment, (o) => CurUser.Role is Roles.admin);
            AddReplyTextCommand = new(OnAddReplyText, (o)=> ReplyText != null && ReplyText != string.Empty);
            //SendReplyCommand = new(OnSendReplyCommand, (o) => ReplyText.Trim() != string.Empty) ;

            SubscribersList = new ObservableCollection<User>(db.Users.Include(u => u.Courses).Where(u => u.Courses.Any(c => c.Id == CurrentCourse.Id)));

            Text = CurrentCourse.Name;

            SubscribersList = new ObservableCollection<User>(db.Users.Include(u => u.Courses).Where(u => u.Courses.Any(c => c.Id == CurrentCourse.Id)));

            IsStarChecked = new(new bool[5]);
            StarCommand = new(OnStarCommand, (o) => GlobalInstanses.CurrentUser.Role is Roles.student && CurrentCourse.Steps != null || GlobalInstanses.CurrentUser.Role is Roles.admin);

            
            Comments = db.Courses.FirstOrDefault(c => c.Id ==CurrentCourse.Id).Comments;
            /*foreach(var c in Comments)
            {
                c.HasReplies = false;
            }*/
            
            var _us = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            var _cour = db.Courses.FirstOrDefault(c => c.Id == CurrentCourse.Id);
            IsAddedTBChecked = _cour.Users.Any(s => s.Id == _us.Id) || _us.Courses.Any(c => c.Id == _cour.Id);
        }

    }
}
