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
    public class EditCourseVM : ViewModel
    {
        private Course currentCourse;
        private string header = "Edit";
        public string Header
        {
            get => header;
            set => Set(ref header, value);
        }
        private string newName;
        public string NewName
        {
            get => newName;
            set => Set(ref newName, value);
        }
        private Complexity newComplexity;
        public Complexity NewComplexity
        {
            get => newComplexity;
            set => Set(ref newComplexity, value);
        }
        private CourseCategory newCategory;
        public CourseCategory NewCategory
        {
            get => newCategory; 
            set => Set(ref newCategory, value);
        }
        private string addingCategory;
        public string AddingCategory
        {
            get => addingCategory;
            set => Set(ref addingCategory, value);
        }
        private string newPreview;
        public string NewPreview
        {
            get => newPreview;
            set => Set(ref newPreview, value);
        }
        private string newDescription;
        public string NewDescription
        {
            get => newDescription;
            set => Set(ref newDescription, value);
        }
        private DateTime startDate;
        public DateTime StartDate
        {
            get => startDate;
            set => Set(ref startDate, value);
        }
        private DateTime finishDate;
        public DateTime FinishDate
        {
            get => finishDate; 
            set => Set(ref finishDate, value);
        }
        private ObservableCollection<CourseSteps> newSteps;
        public ObservableCollection<CourseSteps> NewSteps
        {
            get => newSteps;
            set => Set(ref newSteps, value);
        }
        private string newStepName;
        public string NewStepName
        {
            get => newStepName;
            set => Set(ref newStepName, value);
        }
        private string newStepDescription;
        public string NewStepDescription
        {
            get => newStepDescription;
            set => Set(ref newStepDescription, value);
        }
        private int stepNumber { get; set; }
        public Complexity[] ComplexityValues => (Complexity[])Enum.GetValues(typeof(Complexity));
        private ObservableCollection<CourseCategory> availableCategories;
        public ObservableCollection<CourseCategory> AvailableCategories
        {
            get => availableCategories;
            set => Set(ref availableCategories, value);
        }
        private bool isAddingCategory = false;
        public bool IsAddingCategory
        {
            get => isAddingCategory;
            set => Set(ref isAddingCategory, value);
        }
        private string addingCategoryText;
        public string AddingCategoryText
        {
            get => addingCategoryText;
            set => Set(ref addingCategoryText, value);
        }
        private CourseSteps stepsSelectedItem;
        public CourseSteps StepsSelectedItem
        {
            get => stepsSelectedItem;
            set => Set(ref stepsSelectedItem, value);
        }
        private string addingLectionSourse;
        public string AddingLectionSourse
        {
            get => addingLectionSourse;
            set => Set(ref addingLectionSourse, value);

        }

        private void OnLoadNewPreview(object p)
        {
            MessageBox.Show("prev");

            string courseName = currentCourse.Name;
            string appFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // Создание папки для сохранения файлов
            string courseFolderPath = Path.Combine(appFolderPath,"Resourses", courseName);
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

                    currentCourse.PreviewPath = newFilePath;
                    NewPreview = newFilePath;
                    
                    //db.SaveChanges();

                    MessageBox.Show("Preview succesfully loaded");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wops.. Something went wrong: " + ex.Message);
                }
            }
        }
        private void OnAddCategory(object p)
        {
            IsAddingCategory = !IsAddingCategory;
        }
        private void OnAddCategoryToList(object p)
        {
            if (AddingCategoryText.Trim() != string.Empty)
            {
                if (!Regex.IsMatch(AddingCategoryText.Trim(), @"^[а-яА-ЯёЁa-zA-Z\s]+$"))
                {
                    MessageBox.Show("Invalid category name");
                }
                else if (!db.Categories.Any(c => c.Name == AddingCategoryText))
                {
                    var newCat = new CourseCategory() { Name = AddingCategoryText };
                    if (!AvailableCategories.Any(c => c.Name == newCat.Name)) AvailableCategories.Add(newCat);
                    AddingCategoryText = string.Empty;
                }
                else MessageBox.Show("Such category already exists");
            }
                    
            //db.SaveChanges();
        }
        private void OnDeleteStep(object p)
        {
            if(StepsSelectedItem != null)
            {
                NewSteps.Remove(StepsSelectedItem);
                int i = 1;
                foreach(var step in NewSteps)
                {
                    step.StepNumber = i;
                    i++;
                }
                stepNumber = i;
                //db.SaveChanges();
            }
        }
        private void OnAddNewVideo(object p)
        {
            string courseName = currentCourse.Name;
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
                    string newFileName = courseName + "Lesson" + (stepNumber - 1).ToString() + "_" + fileExtension;

                    // Формирование нового пути к файлу с новым именем
                    string newFilePath = Path.Combine(courseFolderPath, newFileName);

                    // Переименование и сохранение файла
                    File.Copy(sourceFilePath, newFilePath, overwrite: true);

                    NewSteps[stepNumber - 2].LectionSourse = newFilePath;
                   // db.SaveChanges();

                    MessageBox.Show("Video succesfully loaded.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wops..Something went wrong: " + ex.Message);
                }
            }
        }
        private void OnAddNewStep(object p)
        {
            if(NewStepName.Trim() != string.Empty && NewStepDescription.Trim() != string.Empty)
            {
                if(NewStepName.Length > 40)
                {
                    MessageBox.Show("Step name cannot be such long ((.. Please enter a name of less than 40 characters");
                }
                else
                {
                    var step = new CourseSteps()
                    {
                        StepName = NewStepName,
                        LectionText = NewStepDescription,
                        CourseId = currentCourse.Id,
                        StepNumber = stepNumber,
                        LectionSourse = AddingLectionSourse != null ? AddingLectionSourse : string.Empty,
                    };
                    NewSteps.Add(step);
                }
                
            }
            
            //db.SaveChanges() ;

        }

        private void OnSelectDate(object p)
        {
            var dateWindow = new SelectDateWindow();
            dateWindow.DataContext = this;
            dateWindow.ShowDialog();
        }
        private void OnCloseFormCommand(object p)
        {
            var activeWindow = Application.Current.Windows.OfType<Window>().FirstOrDefault(window => window.IsActive);
            activeWindow?.Close();
        }

        private void OnAddDateToCourse(object p)
        {
/*            try { db.Courses.Attach(currentCourse); } catch { }
*/          currentCourse.StartDate = StartDate;
            currentCourse.FinishDate = FinishDate;
           // db.SaveChanges();
            OnCloseFormCommand(null);
        }
        private void OnSaveChanges(object p)
        {   
            try
            {
                try { db.Courses.Attach(currentCourse); } catch { };
                var ch = db.Courses.FirstOrDefault(c => c.Id == currentCourse.Id);
                if (ch != null)
                {
                    ch.PreviewPath = NewPreview;
                    ch.Name = NewName;
                    ch.Description = NewDescription;
                    ch.Steps = NewSteps;
                    ch.StartDate = StartDate;
                    ch.FinishDate = FinishDate;
                    ch.Category = db.Categories.FirstOrDefault(c => c.Name == NewCategory.Name);
                    ch.Complexity = NewComplexity;

                    var res = db.SaveChanges();
                    MessageBox.Show("Succesfully");
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }

        private SelectedCourseProps prop;
        private Action<object> navigate;
        private void OnNavigate(object p)
        {
            prop = new SelectedCourseProps(p.ToString(), currentCourse, 0);
            navigate?.Invoke(prop);
        }
        public BCommand LoadNewPreviewCommand { get; }
        public BCommand AddCategoryCommand { get; }
        public BCommand AddCategoryToListCommand { get; }
        public BCommand DeleteStep {  get; }
        public BCommand AddNewVideoCommand {  get; }
        public BCommand AddNewStepCommand {  get; }
        public BCommand ChangeDateCommand { get; }
        public BCommand SaveChangesCommand { get; }
        public BCommand AddDateToCourseCommand {  get; }

        public BCommand Navigate { get; }
        public EditCourseVM(Action<object> navigate, Course course)
        {
            db = new();

            this.navigate = navigate;
            currentCourse = course;

            db.Courses.Include(c => c.Steps).Load();

            Navigate = new(OnNavigate, (o) => true);

            NewName = course.Name;
            NewDescription = course.Description;
            if (course.PreviewPath != null || course.PreviewPath != string.Empty)
                NewPreview = course.PreviewPath;
            StartDate = course.StartDate == null? DateTime.Today : (DateTime)course.StartDate;
            FinishDate = course.FinishDate == null ? DateTime.Today : (DateTime)course.FinishDate;
            NewCategory = course.Category;
            NewComplexity = course.Complexity;

            db.Courses.Include(c => c.Steps).Load();

            var st = db.Courses.FirstOrDefault(c => c.Id == course.Id).Steps;
            NewSteps = st != null? new ObservableCollection<CourseSteps>(st.ToList()) : new ObservableCollection<CourseSteps>();
            stepNumber = NewSteps == null? 1 : NewSteps.Count();
            if (stepNumber == 0) stepNumber++;

            db.Categories.Load();
            AvailableCategories = db.Categories.Local.ToObservableCollection();

            LoadNewPreviewCommand = new(OnLoadNewPreview, (o) => true);
            AddCategoryCommand = new(OnAddCategory, (o) => true);
            AddCategoryToListCommand = new(OnAddCategoryToList, (o) => AddingCategoryText != null && AddingCategoryText != string.Empty);
            DeleteStep = new(OnDeleteStep, (o) => StepsSelectedItem != null);
            AddNewVideoCommand = new(OnAddNewVideo, (o)=> true);
            AddNewStepCommand = new(OnAddNewStep, (o)=> NewStepName != null && NewStepDescription != null);
            ChangeDateCommand = new(OnSelectDate, (o) => true);
            AddDateToCourseCommand = new(OnAddDateToCourse, (o) => StartDate != null && FinishDate != null && FinishDate > StartDate);
            SaveChangesCommand = new(OnSaveChanges, (o ) => true);

        }
    }
}
