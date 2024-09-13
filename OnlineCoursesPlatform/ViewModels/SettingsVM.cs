using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Globals.NavigationServ;
using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineCoursesPlatform.ViewModels
{
    public class SettingsVM : ViewModel
    {
        //ApplicationContext db = GlobalInstanses.DB;
        private Action<object> navigate;

        private User curUser = GlobalInstanses.CurrentUser;
        public User CurUser
        {
            get => curUser;
            private set => curUser = value;
        }
        private string _text = "Settings";
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        #region Profile settings

        public Statuses[] StatusesValues => (Statuses[])Enum.GetValues(typeof(Statuses));
        private string organisation;
        public string Organisation
        {
            get => organisation;
            set => Set(ref  organisation, value);
        }
        private Statuses selectedStatus;
        public Statuses SelectedStatus
        {
            get => selectedStatus;
            set => Set(ref  selectedStatus, value);
        }

        #endregion

        #region Access settings

        private ObservableCollection<User> usersDT = new ObservableCollection<User>();
        public ObservableCollection<User> UsersDT
        {
            get => usersDT;
            set => Set(ref  usersDT, value);
        }
        private ObservableCollection<Course> coursesDT;
        public ObservableCollection<Course> CoursesDT
        {
            get => coursesDT;
            set => Set(ref  coursesDT, value);
        }
        private ObservableCollection<User> usersCB;
        public ObservableCollection<User> UsersCB
        {
            get => usersCB;
            set => Set(ref usersCB, value);
        }
        private ObservableCollection<Course> coursesCB;
        public ObservableCollection<Course> CoursesCB
        {
            get => coursesCB;
            set => Set(ref coursesCB, value);
        }

        private string setAccessStatusButton = "Access";
        public string SetAccessStatusButton
        {
            get => setAccessStatusButton;
            set => Set(ref  setAccessStatusButton, value);
        }
        private User selectedUser;
        public User SelectedUser
        {
            get => selectedUser;
            set => Set(ref selectedUser, value);
        }
        private Course selectedCourse;
        public Course SelectedCourse
        {
            get => selectedCourse;
            set => Set(ref selectedCourse, value);
        }
        private User selectedUserCB;
        public User SelectedUserCB
        {
            get => selectedUserCB;
            set => Set(ref selectedUserCB, value);
        }
        private Course selectedCourseCB;
        public Course SelectedCourseCB
        {
            get => selectedCourseCB;
            set => Set(ref selectedCourseCB, value);
        }

        private void OnCourseSelectionCBChanged(object p)
        {
            try
            {
                var collection = db.Users.Include(u => u.Courses).Where(u => u.Courses.Any(c => c.Id == SelectedCourseCB.Id) && u.Role != Roles.admin);
                if(collection != null)
                    UsersDT = new ObservableCollection<User>(collection.ToList());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void OnUserSelectionChanged(object p)
        {
            if(selectedUser != null)
            {
                Permission curPermission = db.Permissions.Where(p => p.UserId == SelectedUser.Id && p.CourseId == SelectedCourseCB.Id).FirstOrDefault();
                SetAccessStatusButton = curPermission.State == PermissionState.requested ? "Accept" : "Remove";
            }
            
        }
        private void OnSetAccessStatus(object p)
        {
            if (selectedUser != null)
            {
                Permission curPermission = db.Permissions.Where(p => p.UserId == SelectedUser.Id && p.CourseId == SelectedCourseCB.Id).FirstOrDefault();
                switch(SetAccessStatusButton)
                {
                    case "Accept":
                        try { db.Permissions.Attach(curPermission); } catch { }
                        curPermission.State = PermissionState.open;
                        db.SaveChanges();

                        break;
                    case "Remove":
                        try { db.Permissions.Attach(curPermission); } catch { }
                        curPermission.State = PermissionState.requested;
                        db.SaveChanges();
                        break;
                }
                SetAccessStatusButton = curPermission.State == PermissionState.requested ? "Accept" : "Remove";
            }

        }
        private void OnBlockCommand(object p)
        {
            if (selectedUser != null)
            {
                Permission curPermission = db.Permissions.Where(p => p.UserId == SelectedUser.Id && p.CourseId == SelectedCourseCB.Id).FirstOrDefault();
                try { db.Permissions.Attach(curPermission); } catch { }
                curPermission.State = PermissionState.close;
                db.SaveChanges();
            }
        }
        private void OnDeleteUser(object p)
        {
            if (selectedUser != null)
            {
                var res = MessageBox.Show("Do you really want delete this user?", "deleting usre", MessageBoxButton.YesNoCancel);
                if (res == MessageBoxResult.Yes)
                {
                    db.Users.Remove(SelectedUser);
                    db.SaveChanges();
                    UsersDT.Clear();
                    var collection = db.Users.Include(u => u.Courses).Where(u => u.Courses.Any(c => c.Id == SelectedCourseCB.Id));
                    if (collection != null)
                        UsersDT = new ObservableCollection<User>(collection.ToList());
                }
                    
            }
        }
        private void OnEditCourseCommand(object p)
        {
            if(selectedCourse != null)
            {
                prop = new("EditCourse", SelectedCourse, 0);
                navigate?.Invoke(prop);
            }
        }
        private void OnDeleteCourseCommand(object p)
        {
            if (selectedCourse != null)
            {
                var res = MessageBox.Show("Do you really want delete this course?", "deleting course", MessageBoxButton.YesNoCancel);
                if(res == MessageBoxResult.Yes)
                {
                    string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    // Создание папки для сохранения файлов
                    string courseFolderPath = Path.Combine(appFolderPath, "Resourses", SelectedCourse.Name);
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
                    db.Courses.Remove(SelectedCourse);
                    db.SaveChanges();
                    CoursesDT.Clear();
                    CoursesDT = db.Courses.Local.ToObservableCollection();
                }
             
            }
        }

        #endregion

        #region Settings profile

        private void OnLogOutCommand(object p)
        {
            //ViewModelsService.GetMainVM().Content = ViewModelsService.GetMainVM().loginField;
            FrameNavigation.GetNavigation().NavigateTo<MainWindowVM>();
            GlobalInstanses.CurrentPage = "Login";
            ViewModelsService.GetLoginVM().UsNameTB = "";
            ViewModelsService.GetLoginVM().PasswordTB = "";
            ViewModelsService.GetLoginVM().SecPasswordTB = "";
        }
        private void OnDeleteAcoountCommand(object p)
        {
            var res = MessageBox.Show("Do you really want log out?", "log out", MessageBoxButton.YesNoCancel);
            if(res == MessageBoxResult.Yes)
            {
                OnLogOutCommand(null);
                var _user = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
                try { db.Users.Attach(_user); } catch { }
                db.Users.Remove(_user);
                db.SaveChanges();
            }
            
        }

        private void OnSaveChanges(object p)
        {
            if(Organisation.Trim() != string.Empty && SelectedStatus != null)
            {
                if(!Regex.IsMatch(Organisation, @"^[а-яА-ЯёЁa-zA-Z0-9_-]+$"))
                {
                    MessageBox.Show("Invalid input format");
                }
                else
                {
                    var _user = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
                    _user.Status = SelectedStatus;
                    _user.Organisation = Organisation;
                    db.SaveChanges();
                    Organisation = string.Empty;
                }
               
            }

        }
        #endregion

        public BCommand UserSelectionChangedCommand { get; }
        public BCommand CourseCBSelectionChangedCommand { get; }
        public BCommand SetAccessStatusCommand { get; }
        public BCommand BlockCommand { get; }
        public BCommand DeleteUserCommand {  get; }
        public BCommand DeleteCourseCommand { get; }
        public BCommand EditCourseCommand { get; }
        public BCommand LogOutCommand { get; }
        public BCommand DeleteAccountCommand { get; }
        public BCommand SaveChangesCommand {  get; }


        private SelectedCourseProps prop;
        private void OnNavigate(object p)
        {
            prop = new("AddCourse", null, 0);
            navigate?.Invoke(prop);
        }
        public BCommand Navigate {  get; }
        public SettingsVM(Action<object> navigate)
        {
            db = new();
            this.navigate = navigate;
            Navigate = new(OnNavigate, (o) => CurUser.Role is Roles.admin);

            db.Courses.Include(c => c.Users).Load();
            db.Users.Include(u => u.Courses).Load();

            CoursesDT = new ObservableCollection<Course>(db.Courses.Local.ToObservableCollection());
            UsersDT = new ObservableCollection<User>();
            CoursesCB = new ObservableCollection<Course>(db.Courses.Local.ToObservableCollection());
            UsersCB = new ObservableCollection<User> (db.Users.Local.ToObservableCollection());
            SetAccessStatusCommand = new(OnSetAccessStatus, (o) => true);
            BlockCommand = new(OnBlockCommand, (o) => true);
            DeleteUserCommand = new(OnDeleteUser, (o) => true);
            EditCourseCommand = new(OnEditCourseCommand, (o) => true);
            DeleteCourseCommand = new(OnDeleteCourseCommand, (o) => true);
            DeleteAccountCommand = new(OnDeleteAcoountCommand, (o) => true);
            SaveChangesCommand = new(OnSaveChanges, (o) => true);

            var _user = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            Organisation = _user.Organisation == null ? null : _user.Organisation;
            if(_user.Status != null)
                selectedStatus = (Statuses)_user.Status;
            LogOutCommand = new(OnLogOutCommand, (o) => true);

            try
            {
                UserSelectionChangedCommand = new(OnUserSelectionChanged, (o)=>true);
                CourseCBSelectionChangedCommand = new(OnCourseSelectionCBChanged, (o)=> true);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}