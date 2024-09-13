using Microsoft.EntityFrameworkCore;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineCoursesPlatform.ViewModels
{
    public class CourseStepVM : ViewModel
    {
        private Course currentCourse;
        public Course CurrentCourse
        {
            get => currentCourse;
            set => Set(ref currentCourse, value);
        }
        private readonly Action<object> navigate;
        private SelectedCourseProps prop;


        private string stepText;
        public string StepText
        {
            get => stepText;
            set => Set(ref  stepText, value);
        }
        private string buttonText = ">";
        public string ButtonText
        {
            get => buttonText;
            set => Set(ref buttonText, value);
        }
        private int courseStep;
        public int CourseStep
        {
            get => courseStep;
            set => Set(ref courseStep, value);
        }
        private bool isStepCompleted;
        public bool IsStepCompleted
        {
            get => isStepCompleted;
            set
            {
                Set(ref isStepCompleted, value);
            }
        }
        public string VideoLectionSourse { get; set; }
        private string loadedVideo;
        public string LoadedVideo
        {
            get => loadedVideo;
            set => Set(ref loadedVideo, value);
        }

        private void OnNextStep()
        {
            //currentStep++;
            if(db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber <= currentCourse.Steps.Count)
                db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber++;
            db.SaveChanges();
        }

        private void OnNavigate(object obj)
        {
            OnNextStep();
            int curentStepNumber = db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber;
            prop = new SelectedCourseProps(obj.ToString(), currentCourse, curentStepNumber);
            navigate.Invoke(prop);
        }
        private void ToTestPage(object p)
        {
            OnNextStep();
            prop = new SelectedCourseProps("FinalTest", currentCourse, CourseStep);
            navigate.Invoke(prop);
        }
        private void ToFinishCourse(object p)
        {

            /*var _user = db.Users.FirstOrDefault(x => x.Id == GlobalInstanses.CurrentUser.Id);
            _user.FinishedCourses.Add(CurrentCourse);
            db.SaveChanges();
            prop = new SelectedCourseProps("FinishCourse", currentCourse, CourseStep);
            navigate.Invoke(prop);*/

            /*var userId = GlobalInstanses.CurrentUser.Id;
            var user = db.Users.Local.FirstOrDefault(u => u.Id == userId) ?? db.Users.Find(userId);

            if (user != null)
            {
                db.Users.Update(user);
                user.FinishedCourses.Add(CurrentCourse);
                db.SaveChanges();
            }*/
            OnNextStep();
            prop = new SelectedCourseProps("FinishCourse", currentCourse, CourseStep);
            navigate.Invoke(prop);
        }

        public BCommand Navigate { get; set; }
        public CourseStepVM(Action<object> nav, Course course )
        {
            db = new();
            navigate = nav;
            currentCourse = course;

            /* db.Courses.Include((c) => c.Steps).Load();*/
            db.Progresses.Load();
            db.Courses.Include(c => c.Steps).Load();
            CourseStep = db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber +1 ;

            if(CourseStep == currentCourse.Steps.Count + 1)
            {
                CourseStep = currentCourse.Steps.Count;
                IsStepCompleted = true;
            }
           /* else
            {
                prop = new SelectedCourseProps("FinishCourse", currentCourse, CourseStep);
                navigate.Invoke(prop);

            }*/

            StepText = currentCourse.Steps.SingleOrDefault((s) => s.StepNumber == CourseStep)?.LectionText;
            //VideoLectionSourse = currentCourse.Steps.SingleOrDefault((s) => s.StepNumber == CourseStep).LectionSourse ?? string.Empty;
            if (currentCourse.Steps.SingleOrDefault((s) => s.StepNumber == CourseStep).LectionSourse != null)
                LoadedVideo = currentCourse.Steps.SingleOrDefault((s) => s.StepNumber == CourseStep).LectionSourse;

            if (CourseStep >= currentCourse.Steps.Count)
            {
                if (currentCourse.Test != null)
                {
                    ButtonText = "Final test";
                    Navigate = new BCommand(ToTestPage, (o) => currentCourse.Test != null && CourseStep == currentCourse.Steps.Count && IsStepCompleted);
                }
                else
                {
                    ButtonText = "Finish course";
                    Navigate = new BCommand(ToFinishCourse, (o) => currentCourse.Test == null && CourseStep == currentCourse.Steps.Count && IsStepCompleted);
                }

            }
            else
            {
                Navigate = new BCommand(OnNavigate, (o) => CourseStep < currentCourse.Steps.Count && IsStepCompleted);
            }
        }
    }
}
