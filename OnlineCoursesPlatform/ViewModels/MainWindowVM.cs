using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsCore.SkiaSharpView.Extensions;
using LiveChartsCore;
using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Globals.Pages;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Infrastructure.Services;
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
using System.Windows.Input;
using System.Xml;
using GalaSoft.MvvmLight;

namespace OnlineCoursesPlatform.ViewModels
{
    public class MainWindowVM:ViewModel
    {
        public BCommand CloseAppCommand { get; } = new((o) => { Application.Current.Shutdown(); }, (o) => true);
        #region Login fields

        public LoginField loginField = PagesService.GetLoginField();
        public RegistrationField registrationF = PagesService.GetRegField();

        private object _content;
        public object Content
        {
            get => _content;
            set => Set(ref _content, value);
        }
        #endregion


        private decimal lastCourseProgress;
        public decimal LastCourseProgress
        {
            get => lastCourseProgress;
            set
            {
                Set(ref lastCourseProgress, value);
            }
        }
        public void UpdateProgress(int steps, object vm)
        {
            int n;
            if (GlobalInstanses.LastCourse.Test != null)
                n = 1;
            else n = 0;
            decimal pr = steps * 100 /( GlobalInstanses.LastCourse.Steps.Count + n);
            LastCourseProgress = pr;
            OnPropertyChanged(nameof(LastCourseProgress));

            PrText = pr.ToString();
        }
        private string _prText = "0";
        public string PrText
        {
            get => _prText;
            set => Set(ref _prText, value);
        }
        private string lastCourseName;
        public string LastCourseName
        {
            get => lastCourseName;
            set => Set(ref  lastCourseName, value);
        }

        private string _text;
        public string text
        {
            get => _text;
            set => Set(ref _text, value);
        }

        private object _currentVM;

        public object CurrentVM
        {
            get { return _currentVM; }
            set => Set(ref _currentVM, value);
        }

        private int _fieldIndex;
        public int FieldIndex
        {
            get => _fieldIndex;
            set => Set(ref _fieldIndex, value);
        }

        private int maxCourseProgress;
        public int MaxCourseProgress
        {
            get => maxCourseProgress;
            set => Set(ref maxCourseProgress, value);
        }
        private SeriesCollection progress;
        public SeriesCollection Progress
        {
            get => progress;
            set => Set(ref progress, value);
        }
        private ObservableCollection<TestScore> bestTestResults;
        public ObservableCollection<TestScore> BestTestResults
        {
            get => bestTestResults;
            set => Set(ref bestTestResults, value);
        }

        private void OnChangeField(object o)
        {
            switch (FieldIndex)
            {
                case 0:
                    CurrentVM = new CoursesCatalogVM(ToPage);
                    break;
                case 1:
                    CurrentVM = new MyCoursesVM(ToPage);
                    break;
                case 2:
                    CurrentVM = new ArchiveVM(ToPage);
                    break;
                case 3:
                    CurrentVM = new SettingsVM(ToPage);
                    break;
                default:
                    break;
            }
        }
        private void ToPage(object obj)
        {
            var param = obj as SelectedCourseProps;
            var steps = param.Progress;
           
            switch (param.Direction.ToString())
            {
                case "AllCourses":
                    CurrentVM = new CoursesCatalogVM(ToPage);
                    break;
                case "SelCourse":
                    CurrentVM = new SelectedCourseVM(ToPage, param.Course);
                    break;
                case "Steps":
                    PrText = steps.ToString();
                    UpdateLastCourseName();
                     
                    LastCourseProgress = GlobalInstanses.LastCourse.Test == null ? steps * 100 / GlobalInstanses.LastCourse.Steps.Count : steps * 100 / (GlobalInstanses.LastCourse.Steps.Count + 1);
                    CurrentVM = new CourseStepVM(ToPage, param.Course);
                    break;
                case "FinalTest":
                    PrText = steps.ToString();
                    LastCourseProgress = GlobalInstanses.LastCourse.Test == null ? steps * 100 / GlobalInstanses.LastCourse.Steps.Count : steps * 100 / (GlobalInstanses.LastCourse.Steps.Count + 1);
                    CurrentVM = new FinalTestVM(ToPage, param.Course);
                    break;
                case "EditCourse":
                    CurrentVM = new EditCourseVM(ToPage, param.Course);
                    break;
                case "AddCourse":
                    CurrentVM = new AddCourseVM(ToPage);
                    break;
                case "TestScore":
                    PrText = steps.ToString();
                    LastCourseProgress = GlobalInstanses.LastCourse.Test == null ? steps * 100 / GlobalInstanses.LastCourse.Steps.Count : steps * 100 / (GlobalInstanses.LastCourse.Steps.Count + 1);
                    UpdateBestScore();
                    CurrentVM = new ShowTestScoreVM(ToPage, param.Course);
                    break;
                case "FinishCourse":
                    LastCourseProgress = GlobalInstanses.LastCourse.Test == null ? steps * 100 / GlobalInstanses.LastCourse.Steps.Count : steps * 100 / (GlobalInstanses.LastCourse.Steps.Count + 1);
                    CurrentVM = new FinishCourseVM(ToPage, param.Course);
                    break;

            }
        }

        private void UpdateLastCourseName()
        {
            LastCourseName = GlobalInstanses.LastCourse.Name;
        }
        public void UpdateBestScore()
        {
            db.Users.Include(u => u.TestScores).ThenInclude(s => s.Test).Load();
            var allScores = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id).TestScores.ToList();
            BestTestResults = new ObservableCollection<TestScore>(allScores.GroupBy(p => p.Test)
                               .Select(g => g.OrderByDescending(p => p.Score).First())
                               .ToList());
        }
        
        public BCommand OnChangefieldCommand { get; }
        public MainWindowVM()
        {
            initCount++;
            db = new();

            db.Progresses.Include(p => p.Course).ThenInclude(c => c.Steps).Load();
            db.Progresses.Include(p => p.Course).ThenInclude(c => c.Test).Load();

            CourseProgress pr;
            var prCollection = db.Progresses.Where(c => c.UserId == GlobalInstanses.CurrentUser.Id);
            pr = prCollection.Count() != 0? prCollection.OrderBy(p => p.Id).Last() : null;
            if (pr != null)
            {
                GlobalInstanses.LastCourse = pr.Course;
                int n;
                int allSteps = pr.Course.Steps.Count();
                if (pr.Course.Test == null)
                    n = 0;
                else n = 1;
                LastCourseProgress = allSteps != 0? pr.CurrentStepNumber * 100 / (GlobalInstanses.LastCourse.Steps.Count + n) : 0;
                //if(LastCourseProgress > 100) LastCourseProgress = 100;
                db.SaveChanges();
            }
            else
            {
                GlobalInstanses.LastCourse = null;
                LastCourseProgress = 0;
            }
            LastCourseName = GlobalInstanses.LastCourse != null ? GlobalInstanses.LastCourse.Name : "No last course";


            Content = loginField;
            CurrentVM = new MyCoursesVM(ToPage);
            FieldIndex = 1;
            text = GlobalInstanses.CurrentUser.UserName;

            OnChangefieldCommand = new(OnChangeField, (o) => true);

            if (initCount > 1) UpdateBestScore();
        }
        static int initCount;
        static MainWindowVM()
        {
            initCount = 0;
        }
    }
}
