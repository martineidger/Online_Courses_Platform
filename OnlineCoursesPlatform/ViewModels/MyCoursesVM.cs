using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineCoursesPlatform.ViewModels
{
    public class MyCoursesVM : ViewModel
    {
        private string _text = "My courses";
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
        private ObservableCollection<Course> _coursesCatalogDT;
        public ObservableCollection<Course> CoursesCatalogDT
        {
            get => _coursesCatalogDT;
            set => Set(ref _coursesCatalogDT, value);
        }
        private List<CourseCategory> categorySearchList;
        public List<CourseCategory> CategorySearchList
        {
            get => categorySearchList;
            set => Set(ref categorySearchList, value);
        }
        private List<string> nameSearchList;
        public List<string> NameSearchList
        {
            get => nameSearchList;
            set => Set(ref nameSearchList, value);
        }
        private string nameSelectedItem;
        public string NameSelectedItem
        {
            get => nameSelectedItem;
            set => Set(ref nameSelectedItem, value);
        }
        private string complexitySelectedItem;
        public string ComplexitySelectedItem
        {
            get => complexitySelectedItem;
            set => Set(ref complexitySelectedItem, value);
        }
        private CourseCategory categorySelectedItem;
        public CourseCategory CategorySelectedItem
        {
            get => categorySelectedItem;
            set => Set(ref categorySelectedItem, value);
        }

        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set
            {
                Set(ref searchText, value);
                var temp = db.Courses.Include(u => u.Users).Where(u => u.Users.Any(c => c.Id == GlobalInstanses.CurrentUser.Id)) as ObservableCollection<Course>;
                var searchRes = temp.Where(c => c.Name.ToLower().Contains(SearchText.ToLower())).ToList();
                CoursesCatalogDT.Clear();
                foreach (var c in searchRes)
                {
                    CoursesCatalogDT.Add(c);
                }
            }
        }

        private bool isSearchVisible = false;
        public bool IsSearchVisible
        {
            get => isSearchVisible;
            set => Set(ref isSearchVisible, value);
        }

        private void OnSetVisibleSearch(object p)
        {
            IsSearchVisible = !IsSearchVisible;
        }
        private void OnCategorySeCh(object p)
        {
            var temp = db.Courses.Include(u => u.Users).Where(u => u.Users.Any(c => c.Id == GlobalInstanses.CurrentUser.Id)) as ObservableCollection<Course>;
            if (CategorySelectedItem == null)
            {
                CoursesCatalogDT = new ObservableCollection<Course>(temp);
            }
            else
                CoursesCatalogDT = new ObservableCollection<Course>(temp.Where(c => c.Category == CategorySelectedItem));
        }
        private void OnNameSelCh(object p)
        {
            var temp = db.Courses.Include(u => u.Users).Where(u => u.Users.Any(c => c.Id == GlobalInstanses.CurrentUser.Id)) as ObservableCollection<Course>;
            switch (NameSelectedItem)
            {
                case "Ascending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(temp.OrderBy(c => c.Name));
                    break;
                case "Descending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(temp.OrderByDescending(c => c.Name));
                    break;

            }
        }
        private void OnComplSelCh(object p)
        {
            var temp = db.Courses.Include(u => u.Users).Where(u => u.Users.Any(c => c.Id == GlobalInstanses.CurrentUser.Id)) as ObservableCollection<Course>;
            switch (ComplexitySelectedItem)
            {
                case "Ascending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(temp.OrderBy(c => c.Complexity));
                    break;
                case "Descending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(temp.OrderByDescending(c => c.Complexity));
                    break;

            }
        }

        private void ToSelectedCourse(object p)
        {
            //ViewModelsService.GetMainVM().CurrentField = ViewModelsService.GetMainVM().selectedCourseField;
        }
        public BCommand ToSelectedCourseCommand { get; }


        private readonly Action<object> navigate;

        public BCommand Navigate { get; set; }
        public BCommand ComplexitySelChCommand { get; }
        public BCommand NameSelChCommand { get; }
        public BCommand CategorySelChCommand { get; }
        public BCommand SetVisibleSearchCommand { get; }
        public BCommand ShowCategorySortList { get; }

        private SelectedCourseProps prop;
        private void OnNavigate(object obj)
        {
            prop = new SelectedCourseProps("SelCourse", obj as Course, 0);
            navigate.Invoke(prop);
        }

        public MyCoursesVM(Action<object> navigate)
        {
            db = new();

            Navigate = new(OnNavigate, (o) => true);
            this.navigate = navigate;

            
            db.Users.Include(u => u.Courses).Load();

            db.Courses.Include((c) => c.Comments).Load();
            db.Courses.Include(c => c.Steps).Load();
            db.Courses.Include(c => c.Test)
                .ThenInclude(t => t.Questions)
                .Load();

            db.Courses.Include(c => c.Users)
                .Load();

            SetVisibleSearchCommand = new(OnSetVisibleSearch, (o) => true);
            CategorySelChCommand = new(OnCategorySeCh, (o) => true);
            NameSelChCommand = new(OnNameSelCh, (o) => true);
            ComplexitySelChCommand = new(OnComplSelCh, (o) => true);
            db.Categories.Load();
            CategorySearchList = db.Categories.Local.ToList();
            NameSearchList = new List<string>() { "Ascending", "Descending" };

            //MessageBox.Show(db.Courses.First().Subscribers.First().Id.ToString());

            //MessageBox.Show(GlobalInstanses.CurrentUser.Courses.First().Name);

            CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.Include(u => u.Users).Where(u => u.Users.Any(c => c.Id == GlobalInstanses.CurrentUser.Id)));
            //CoursesCatalogDT = db.Courses.Where(c => c.Users.Any(s => s.Id == GlobalInstanses.CurrentUser.Id)) as ObservableCollection<Course>;

            ToSelectedCourseCommand = new(ToSelectedCourse, (o) => true);

        }
    }
}
