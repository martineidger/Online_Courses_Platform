using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Infrastructure.Commands;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineCoursesPlatform.ViewModels
{
    public class AddCourseVM : ViewModel
    {
        private string header = "Add";
        public string Header
        {
            get => header;
            set => Set(ref header, value);
        }
        public Complexity[] ComplexityValues => (Complexity[])Enum.GetValues(typeof(Complexity));
        private string courseName = string.Empty;
        public string CourseName
        {
            get => courseName;
            set => Set(ref courseName, value);
        }
        private string courseDesc = string.Empty;
        public string CourseDescription
        {
            get => courseDesc;
            set => Set(ref courseDesc, value);
        }
        private string courseCategory = string.Empty;
        public string CourseCategory
        {
            get => courseCategory;
            set => Set(ref courseCategory, value);
        }
        private Complexity courseComplexity;
        public Complexity CourseComplexity
        {
            get => courseComplexity;
            set => Set(ref courseComplexity, value);
        }
        private CourseCategory courseCategoryItem;
        public CourseCategory CourseCategoryItem
        {
            get => courseCategoryItem;
            set => Set(ref courseCategoryItem, value);
        }
        private Course addingCourse;
        private int currentStepNumber = 1;
        private ObservableCollection<CourseSteps> addingSteps = new();
        public ObservableCollection<CourseSteps> AddingSteps
        {
            get => addingSteps;
            set => Set(ref  addingSteps, value);
        }
        private string stepName = string.Empty;
        public string StepName
        {
            get => stepName;
            set => Set(ref stepName, value);
        }
        private string stepLectionText = string.Empty;
        public string StepLectionText
        {
            get => stepLectionText;
            set => Set(ref stepLectionText, value);
        }
        private bool isPrivateAcces;
        public bool IsPrivateAcces
        {
            get => isPrivateAcces;
            set => Set(ref  isPrivateAcces, value);
        }
        private void OnAddCourseCommand(object p)
        {
            if(CourseName.Trim() == string.Empty || CourseDescription.Trim() == string.Empty)
            {
                MessageBox.Show("Inputs cannot be empty");
            }
            else
            {
                addingCourse = new Course(CourseName, CourseCategoryItem, CourseComplexity, CourseDescription, GlobalInstanses.CurrentUser.UserName);
                try { db.Courses.Attach(addingCourse); } catch { }
                db.Courses.Add(addingCourse);
                db.SaveChanges();
                foreach (var u in db.Users)
                {
                    db.Permissions.Add(new Permission() { CourseId = addingCourse.Id, UserId = u.Id, State = PermissionState.open });
                }
            }
           
        }

        private void OnSaveStepsCommand(object p)
        {
            if(IsPrivateAcces)
            {
                addingCourse.IsOpen = false;
                var curPermissions = db.Permissions.Where(p => p.CourseId == addingCourse.Id);
                try
                {
                    db.Permissions.AttachRange(curPermissions);
                }
                catch { }

                foreach (var c in curPermissions)
                    c.State = PermissionState.close;
                db.SaveChanges();
            }
            try
            {
                foreach (var step in AddingSteps)
                {
                    db.Attach(step);
                }
            }
            catch { }

            // db.AddRange(steps);
            addingCourse.Steps = AddingSteps;
            //db.Courses.Single((c)=>Equals(c, addingCourse)).Steps = steps;
            db.SaveChanges();
            MessageBox.Show($"Steps to {CourseName} succesfully added");
            CourseName = string.Empty;
            CourseDescription = string.Empty;
            addingCourse = null;
        }
        private void OnAddStepCommand(object p)
        {
            if(StepName.Trim() == string.Empty || StepLectionText.Trim() == string.Empty)
            {
                MessageBox.Show("Inputs cannot be null");
            }else if(StepName.Length > 40)
            {
                MessageBox.Show("Step name cannot be such long ((.. Please enter a name of less than 40 characters");
            }
            else
            {
                var step = new CourseSteps(addingCourse, currentStepNumber, stepName, null, stepLectionText);
                AddingSteps.Add(step);
                currentStepNumber++;
                StepName = string.Empty;
                StepLectionText = string.Empty;
            }  
        }
        private void OnDeleteStep(object p)
        {
            AddingSteps.Remove(StepToDelete);
            currentStepNumber--;
            int i = 1;
            foreach(var step in AddingSteps)
            {
                step.StepNumber = i;
                i++;
            }
        }

        private Test addingTest;
        private string variantText;
        public string VariantText
        {
            get => variantText; 
            set => Set(ref variantText, value);
        }
       /* private ObservableCollection<string> answerVariants = new();
        public ObservableCollection<string> AnswerVariants
        {
            get => answerVariants; 
            set => Set(ref answerVariants, value);
        }
        private bool manyAnswers;
        public bool ManyAnswers
        {
            get => manyAnswers;
            set => Set(ref manyAnswers, value);
        }
        private bool canManyAnswers;
        public bool CanManyAnswers
        {
            get => !manyAnswers;
            set => Set(ref canManyAnswers, value);
        }*/
        /*private void OnAddAnswerVariant(object p)
        {
            answerVariants.Add(VariantText);
        }*/
        private void OnAddTestCommand(object p)
        {
            addingTest = new Test()
            {
                Name = addingCourse.Name + " Final Test"
            };
            var testForm = new CreateTestForm();
            testForm.DataContext = this;
            var result = testForm.ShowDialog();
           
           
        }

        private string questionText;
        public string QuestionText
        {
            get => questionText; 
            set => Set(ref  questionText, value);
        }
        private string answerText;
        public string AnswerText
        {
            get => answerText;
            set => Set(ref answerText, value);
        }
        private Question selectedQuestion;
        public Question SelectedQuestion
        {
            get => selectedQuestion;
            set => Set(ref selectedQuestion, value);
        }
        private ObservableCollection<Question> addingQuestions = new ObservableCollection<Question>();
        public ObservableCollection<Question> AddingQuestions
        {
            get => addingQuestions;
            set => Set(ref addingQuestions, value);
        }
        private void OnAddQuestionCommand(object p)
        {
            /*addingTest.Questions.Add(new Question()
            {
                QuestionText = this.QuestionText,
                Answer = this.AnswerText
            });
            try { db.Courses.Attach(addingCourse); } catch { }
            addingCourse.Test = addingTest;
            db.SaveChanges();*/
            if(QuestionText.Trim() != string.Empty && AnswerText.Trim() != string.Empty)
            {
                AddingQuestions.Add(new Question()
                {
                    QuestionText = this.QuestionText,
                    Answer = this.AnswerText
                });
                QuestionText = string.Empty;
                AnswerText = string.Empty;
            }
            
           /* addingTest.Questions.Add(new Question()
            {
                QuestionText = this.QuestionText,
                Answer = this.AnswerText
            });*/

        }
        private void OnDeleteQuestion(object p)
        {
            if(SelectedQuestion != null)
            {
                AddingQuestions.Remove(SelectedQuestion);
            }
        }
        private void OnSaveTest(object p)
        {
            if(AddingQuestions != null && AddingQuestions.Count != 0)
            {
                addingTest.Questions = AddingQuestions.ToList();
                try { db.Courses.Attach(addingCourse); } catch { }
                addingCourse.Test = addingTest;
                db.SaveChanges();
                OnCloseFormCommand(null);
            }
            
        }
        private void OnCloseFormCommand(object p)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.IsActive);
            activeWindow?.Close();
        }

        private void OnAddCategory(object p)
        {
            if(CourseCategory.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(CourseCategory.Trim(), @"^[а-яА-ЯёЁa-zA-Z\s]+$"))
            {
                MessageBox.Show("Invalid category name");
            }
            else if (!db.Categories.Any(c => c.Name == CourseCategory))
            {
                CourseCategory cat = new CourseCategory() { Name = CourseCategory };
                try { db.Categories.Attach(cat); } catch { }
                db.Categories.Add(cat);

            }
            else MessageBox.Show("Such category already exists");
            }
            
        }
        private ObservableCollection<CourseCategory> availableCategories;
        public ObservableCollection<CourseCategory> AvailableCategories
        {
            get => availableCategories;
            set => Set(ref availableCategories, value);
        }
        private DateTime startDate = DateTime.Today;
        public DateTime StartDate
        {
            get => startDate;
            set => Set(ref startDate, value);
        }
        private DateTime finishDate = DateTime.Today;
        public DateTime FinishDate
        {
            get => finishDate;
            set => Set(ref finishDate, value);
        }
        private CourseSteps stepToDelete;
        public CourseSteps StepToDelete
        {
            get => stepToDelete;
            set => Set(ref stepToDelete, value);
        }

     
        private void OnSelectDate(object p)
        {
            var dateWindow = new SelectDateWindow();
            dateWindow.DataContext = this;
            dateWindow.ShowDialog();
        }

        private void OnAddDateToCourse(object p)
        {
            try { db.Courses.Attach(addingCourse); } catch { }
            addingCourse.StartDate = StartDate;
            addingCourse.FinishDate = FinishDate;
            db.SaveChanges();
            OnCloseFormCommand(null);
        }
        private void OnAddPreview(object p)
        {
            string courseName = addingCourse.Name;
            string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Создание папки для сохранения файлов
            string courseFolderPath = Path.Combine(appFolderPath, "Resourses", courseName);
            Directory.CreateDirectory(courseFolderPath);

            // Показать диалоговое окно выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Получить путь к исходному файлу фото
                    string sourceFilePath = openFileDialog.FileName;

                    // Создать папку с названием курса, если она не существует
                    Directory.CreateDirectory(courseFolderPath);

                    // Получить расширение исходного файла
                    string fileExtension = Path.GetExtension(sourceFilePath);

                    // Новое имя файла
                    string newFileName = courseName + "Preview" + fileExtension;

                    // Формирование нового пути к файлу с новым именем
                    string newFilePath = Path.Combine(courseFolderPath, newFileName);

                    // Переименование и сохранение файла
                    File.Copy(sourceFilePath, newFilePath, overwrite: true);

                    addingCourse.PreviewPath = newFilePath;
                    db.SaveChanges();

                    MessageBox.Show("Preview photo succesfully loaded!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wops..Something went wrong: " + ex.Message);
                }
            }
        }
        private void OnAddVideoLection(object p)
        {
            if (StepToDelete == null)
            {
                MessageBox.Show("Please, add and SELECT step for adding video");
            }
            else
            {
                string courseName = addingCourse.Name;
                string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                // Создание папки для сохранения файлов
                string courseFolderPath = Path.Combine(appFolderPath, "Resourses", courseName);
                Directory.CreateDirectory(courseFolderPath);

                // Показать диалоговое окно выбора файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Video Files (*.mp4; *.avi; *.mkv)|*.mp4; *.avi; *.mkv";
                if (openFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        // Получить путь к исходному файлу фото
                        string sourceFilePath = openFileDialog.FileName;

                        // Создать папку с названием курса, если она не существует
                        Directory.CreateDirectory(courseFolderPath);

                        // Получить расширение исходного файла
                        string fileExtension = Path.GetExtension(sourceFilePath);

                        // Новое имя файла
                        string newFileName = courseName + "Lesson" + (StepToDelete.StepNumber).ToString() + "_" + fileExtension;

                        // Формирование нового пути к файлу с новым именем
                        string newFilePath = Path.Combine(courseFolderPath, newFileName);

                        // Переименование и сохранение файла
                        File.Copy(sourceFilePath, newFilePath, overwrite: true);

                        //AddingSteps[currentStepNumber-2].LectionSourse = newFilePath;
                        StepToDelete.LectionSourse = newFilePath;
                        db.SaveChanges();

                        MessageBox.Show("Video succesfully loaded!");
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        MessageBox.Show("Please, add step and then load the video. Thank you!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Wops..Something went wrong: " + ex.Message);
                    }
                }
            }
            
        }
        private void OnAddLogo(object p)
        {
            string courseName = addingCourse.Name;
            string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Создание папки для сохранения файлов
            string courseFolderPath = Path.Combine(appFolderPath, "Resourses", courseName);
            Directory.CreateDirectory(courseFolderPath);

            // Показать диалоговое окно выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Получить путь к исходному файлу фото
                    string sourceFilePath = openFileDialog.FileName;

                    // Создать папку с названием курса, если она не существует
                    Directory.CreateDirectory(courseFolderPath);

                    // Получить расширение исходного файла
                    string fileExtension = Path.GetExtension(sourceFilePath);

                    // Новое имя файла
                    string newFileName = courseName + "Logo" + fileExtension;

                    // Формирование нового пути к файлу с новым именем
                    string newFilePath = Path.Combine(courseFolderPath, newFileName);

                    // Переименование и сохранение файла
                    File.Copy(sourceFilePath, newFilePath, overwrite: true);

                    addingCourse.LogoPath = newFilePath;
                    db.SaveChanges();

                    MessageBox.Show("Logo succesfully loaded!");
                }
               
                catch (Exception ex)
                {
                    MessageBox.Show("Wops..Something went wrong: " + ex.Message);
                }
            }
        }

        private SelectedCourseProps prop;
        private Action<object> navigate;
        private void OnNavigate(object p)
        {
            prop = new SelectedCourseProps(p.ToString(), null, 0);
            navigate?.Invoke(prop);
        }
        public BCommand Navigate { get; }
        public BCommand AddCourseCommand {  get; }
        public BCommand SaveStepsCommand { get; }
        public BCommand AddStepCommand { get; }
        public BCommand DeleteStepCommand { get; }
        public BCommand AddTestCommand { get; }
        public BCommand CloseFormCommand { get; }
        public BCommand AddQuestionCommand { get; }
        public BCommand AddAncwerVariantCommand { get; }
        public BCommand AddCategoryCommand {  get; }
        public BCommand SelectDateCommand { get; }
        public BCommand AddDateToCourseCommand {  get; }
        public BCommand AddPreviewCommand {  get; }
        public BCommand AddVideoLessonCommand { get; }
        public BCommand AddLogoCommand {  get; }
        public BCommand SaveTestCommand { get; }
        public BCommand DeleteQuestionCommand { get; }

        public AddCourseVM(Action<object> navigate)
        {
            db = new();

            this.navigate = navigate;
            
            Navigate = new(OnNavigate, (o) => true);
            AddCourseCommand = new(OnAddCourseCommand, (o) => CourseName != string.Empty && CourseDescription != string.Empty && CourseCategoryItem != null);
            SaveStepsCommand = new(OnSaveStepsCommand, (o) => addingCourse != null && AddingSteps.Count != 0);
            AddStepCommand = new(OnAddStepCommand, (o)=>  addingCourse != null);
            AddTestCommand = new(OnAddTestCommand, (o) => addingCourse != null);
            DeleteStepCommand = new(OnDeleteStep, (o) => StepToDelete != null);
            SelectDateCommand = new(OnSelectDate, (o) => addingCourse != null);
            AddDateToCourseCommand = new(OnAddDateToCourse, (o) => StartDate != null && FinishDate != null && FinishDate > StartDate);
            AddPreviewCommand = new(OnAddPreview, (o) => addingCourse != null);
            AddVideoLessonCommand = new(OnAddVideoLection, (o) => addingCourse != null);
            AddLogoCommand = new(OnAddLogo, (o) => addingCourse != null);
            SaveTestCommand = new(OnSaveTest, (o) => true);
            DeleteQuestionCommand = new(OnDeleteQuestion, (o) => SelectedQuestion != null);

            CloseFormCommand = new(OnCloseFormCommand, (o) => true);
            AddQuestionCommand = new(OnAddQuestionCommand, (o) => true);

            AddCategoryCommand = new(OnAddCategory, (o) => true);

            db.Categories.Load();
            AvailableCategories = db.Categories.Local.ToObservableCollection();
        }

    }
}
