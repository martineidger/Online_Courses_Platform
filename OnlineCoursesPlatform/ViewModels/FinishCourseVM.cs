using Microsoft.Identity.Client;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.Infrastructure.Commands;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.ViewModels
{
    public class FinishCourseVM : ViewModel
    {
        private void OnNavigate(object p)
        {
            var progr = db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id);

            string direction = p.ToString();
            int step = 0;
            props = new(direction, currentCourse, step);
            navigate?.Invoke(props);
        }
        public string AngleLeft { get; set; } = "< ";
        SelectedCourseProps props;
        private Course currentCourse;
        private Action<object> navigate;

        public BCommand Navigate { get; }
        public FinishCourseVM(Action<object> toPage, Course course)
        {
            db = new();
            navigate = toPage;
            currentCourse = course;
            Navigate = new(OnNavigate, (o) => true);
        }

        
    }
}
