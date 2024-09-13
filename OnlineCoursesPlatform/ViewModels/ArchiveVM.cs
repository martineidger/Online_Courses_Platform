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

namespace OnlineCoursesPlatform.ViewModels
{
    public class ArchiveVM:ViewModel
    {
        private string _text = "Archive";
        public string Text
        {
            get => _text;
            set => Set(ref _text, value);
        }
        private ObservableCollection<Course> _coursesCatalogDT = new ObservableCollection<Course>();
        public ObservableCollection<Course> CoursesCatalogDT
        {
            get => _coursesCatalogDT;
            set => Set(ref _coursesCatalogDT, value);
        }

        private void ToSelectedCourse(object p)
        {
            //ViewModelsService.GetMainVM().CurrentField = ViewModelsService.GetMainVM().selectedCourseField;
        }
        public BCommand ToSelectedCourseCommand { get; }

        /* public CoursesCatalogVM()
         {
             ToSelectedCourseCommand = new(ToSelectedCourse, (o) => true);

             db.Courses.Add(new Course("Machine Learning", "IT"));
             db.Courses.Add(new Course("Artificial Inteligence", "IT"));
             db.Courses.Add(new Course("Chemistry", "nature"));
             db.Courses.Add(new Course("Math", "nature"));
             db.Courses.Add(new Course("UI/UX Design", "IT"));
             db.Courses.Add(new Course("C# .NET", "IT"));
             CoursesCatalogDT = db.Courses.Local.ToObservableCollection();

         }*/

        private readonly Action<object> navigate;

        public BCommand Navigate { get; set; }

        private SelectedCourseProps prop;
        private void OnNavigate(object obj)
        {
            prop = new SelectedCourseProps("SelCourse", obj as Course, 0);
            navigate.Invoke(prop);
        }

        public ArchiveVM(Action<object> navigate)
        {
            db = new();

            Navigate = new(OnNavigate, (o) => true);
            this.navigate = navigate;

            db.Users.Include(u => u.Courses).Load();
            db.Progresses.Include(u => u.User).Load();
            db.Progresses.Include(u => u.Course).Load();
            //db.Users.Include(u => u.ArchivedCourses).Load();

            db.Courses.Include((c) => c.Comments).Load();
            db.Courses.Include(c => c.Steps).Load();
            db.Courses.Include(c => c.Test)
                .ThenInclude(t => t.Questions)
                .Load();

            
            var _us = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            var progr = db.Progresses.Where(p => p.UserId == GlobalInstanses.CurrentUser.Id);
            CoursesCatalogDT = new ObservableCollection<Course>();
            if (progr != null)
            {
                foreach (var p in progr)
                {
                    if (p.CurrentStepNumber >= p.Course.Steps.Count)
                        CoursesCatalogDT.Add(p.Course);
                }

            }

            ToSelectedCourseCommand = new(ToSelectedCourse, (o) => true);

        }
    }
}
