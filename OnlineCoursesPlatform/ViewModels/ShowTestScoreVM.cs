using Microsoft.EntityFrameworkCore;
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
    public class ShowTestScoreVM : ViewModel
    {
        private string scoreText;
        public string ScoreText
        {
            get => scoreText;
            set => Set(ref scoreText, value);
        }
        private int scoreNumber;
        public int ScoreNumber
        {
            get => scoreNumber;
            set => Set(ref scoreNumber, value);
        }
        private string courseName;
        public string CourseName
        {
            get => courseName;
            set => Set(ref courseName, value);
        }
        public string AngleLeft { get; set; } = "< ";
        SelectedCourseProps props;
        private void OnNavigate(object p)
        {
            var progr = db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id);

            string direction = p.ToString();
            int step = 0;
            if (direction == "FinalTest") step = (progr.CurrentStepNumber);
            props = new(direction, currentCourse, step);
            navigate?.Invoke(props);
        }

        private Course currentCourse;
        private Action<object> navigate;

        public BCommand Navigate { get; }
        public ShowTestScoreVM(Action<object> navigate, Course course)
        {
            db = new();

            this.navigate = navigate;
            currentCourse = course;
            
            CourseName = currentCourse.Name;

            db.Courses.Include(c => c.CourseProgresses).Load();
            db.Courses.Include(c => c.Test).ThenInclude(t => t.TestScores).ThenInclude(s => s.User).Load();

            var _user = db.Users.FirstOrDefault(u => u.Id == GlobalInstanses.CurrentUser.Id);
            var _course = db.Courses.FirstOrDefault(c => c.Id == currentCourse.Id);

            ScoreNumber = _course.Test.TestScores
                .Where(s => s.Test.Id == _course.Test.Id && s.User.Id == _user.Id).OrderBy(c => c.Id)
                .Last().Score;

            ScoreText = ScoreNumber.ToString() + "%";

            Navigate = new(OnNavigate, (o) => true);
        }
    }
}
