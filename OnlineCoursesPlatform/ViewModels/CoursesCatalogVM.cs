using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using OnlineCoursesPlatform.Views.CustomFields;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineCoursesPlatform.ViewModels
{
    public class CoursesCatalogVM : ViewModel
    {
        private string _text = "Catalog";
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
        private List<CourseCategory> selectedCategories = new();
        public List<CourseCategory> SelectedCategories
        {
            get => selectedCategories;
            set => Set(ref selectedCategories, value);
        }
        private string searchText = string.Empty;
        public string SearchText
        {
            get => searchText;
            set {
                Set(ref searchText, value);
                var searchRes = db.Courses.Where(c => c.Name.ToLower().Contains(SearchText.ToLower())).ToList();
                CoursesCatalogDT.Clear();
                foreach (var c in searchRes)
                {
                    CoursesCatalogDT.Add(c);
                } }
            }

        private bool isSearchVisible = false;
        public bool IsSearchVisible
        {
            get => isSearchVisible;
            set => Set(ref isSearchVisible, value);
        }

        private readonly Action<object> navigate;

        public BCommand Navigate { get; set; }
       
        private SelectedCourseProps prop; 
        private void OnNavigate(object obj)
        {
            prop = new SelectedCourseProps("SelCourse", obj as Course, 0);
            navigate.Invoke(prop);
        }
        private void OnSetVisibleSearch(object p)
        {
            IsSearchVisible = !IsSearchVisible;
        }
        private void OnCategorySeCh(object p)
        {
            if(CategorySelectedItem == null)
            {
                CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.Local);
            }else
                CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.Where(c => c.Category == CategorySelectedItem));
        }
        private void OnNameSelCh(object p)
        {
            switch(NameSelectedItem)
            {
                case "Ascending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.OrderBy(c => c.Name));
                    break;
                case "Descending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.OrderByDescending(c => c.Name));
                    break;

            }
        }
        private void OnComplSelCh(object p)
        {
            switch (ComplexitySelectedItem)
            {
                case "Ascending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.OrderBy(c => c.Complexity));
                    break;
                case "Descending":
                    //CoursesCatalogDT.Clear();
                    CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.OrderByDescending(c => c.Complexity));
                    break;

            }
        }
        private bool isSortByCategoryVisible = false;
        public bool IsSortByCategoryVisible
        {
            get => isSortByCategoryVisible;
            set => Set(ref  isSortByCategoryVisible, value);
        }
        private void OnShowCategorySortList(object p)
        {
            IsSortByCategoryVisible = !IsSortByCategoryVisible;
        }


        public BCommand ComplexitySelChCommand { get; }
        public BCommand NameSelChCommand { get; }
        public BCommand CategorySelChCommand { get; }
        public BCommand SetVisibleSearchCommand { get; }
        public BCommand ShowCategorySortList { get; }

        public CoursesCatalogVM(Action<object> navigate)
        {
            db = new();

            Navigate = new(OnNavigate, (o) => true);
            this.navigate = navigate;

            CategorySelChCommand = new(OnCategorySeCh,(o)=>true);
            NameSelChCommand = new(OnNameSelCh,(o)=>true);
            ComplexitySelChCommand = new(OnComplSelCh,(o)=>true);

            db.Courses.Include((c) => c.Comments).Load();
            db.Courses.Include(c => c.Steps).Load();
            db.Courses.Include(c => c.Test)
                .ThenInclude(t=>t.Questions)
                .Load();
            SetVisibleSearchCommand = new(OnSetVisibleSearch, (o) => true);

            db.Categories.Load();
            CategorySearchList = db.Categories.Local.ToList();
            NameSearchList = new List<string>() { "Ascending", "Descending" };


            //CoursesCatalogDT = new ObservableCollection<Course>(db.Courses.Where(c => (bool)c.Category.IsSelected));
            CoursesCatalogDT = db.Courses.Local.ToObservableCollection();
        }
    }
}
