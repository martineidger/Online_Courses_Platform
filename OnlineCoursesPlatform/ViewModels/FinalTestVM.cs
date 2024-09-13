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
using System.Windows.Data;

namespace OnlineCoursesPlatform.ViewModels
{
    internal class FinalTestVM : ViewModel
    {
        private Course _currentCourse;
        public Course CurrentCourse
        {
            get => _currentCourse;
            set => Set(ref _currentCourse, value);
        }

        private object questionTypeControl;
        public object QuestionTypeControl
        {
            get => questionTypeControl;
            set => Set(ref questionTypeControl, value);
        }
        private ObservableCollection<Question> questionsCollection = new();
        public ObservableCollection<Question> QuestionsCollection
        {
            get => questionsCollection;
            set => Set(ref questionsCollection, value);
        }

        private string testName;
        public string TestName 
        {
            get => testName;
            set => Set(ref testName, value);
        }
        private string questionText;
        public string QuestionText
        {
            get => questionText;
            set => Set(ref questionText, value);
        }
        private string userAnswerText;
        public string UserAnswerText
        {
            get => userAnswerText;
            set => Set(ref  userAnswerText, value);
        }
        private List<string> userAnswers;
        public List<string> UserAnswers
        {
            get => userAnswers;
            set => Set(ref userAnswers, value);
        }
        private void OnFinishTest(object p)
        {
            int rightAnswersCount = 0;
            for (int i = 0; i < CurrentCourse.Test.Questions.Count; i++)
            {
                if (QuestionsCollection[i].Answer == CurrentCourse.Test.Questions[i].Answer)
                    rightAnswersCount++;
            }
            //if(UserAnswerText == CurrentCourse.Test.Questions[0].Answer) rightAnswersCount++;
            var _user = db.Users.FirstOrDefault(x => x.Id == GlobalInstanses.CurrentUser.Id);
            int score = rightAnswersCount == 0 ? 0 : (rightAnswersCount * 100) / CurrentCourse.Test.Questions.Count;
            try { db.Users.Attach(_user); } catch { }
            try { db.Courses.Attach(CurrentCourse); } catch { }

            CurrentCourse.Test.TestScores.Add(new TestScore()
            {
                Test = CurrentCourse.Test,
                User = _user,
                Score = score,
            });

            //_user.FinishedCourses.Add(CurrentCourse);
            if (db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber <= CurrentCourse.Steps.Count)
                db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber++;
            db.SaveChanges();

            OnNavigate("TestScore");

        }
        
        private SelectedCourseProps prop;
        private Action<object> navigate;
        private void OnNavigate(object p)
        {
            prop = new SelectedCourseProps(p.ToString(), CurrentCourse, db.Progresses.SingleOrDefault(p => p.UserId == GlobalInstanses.CurrentUser.Id && p.CourseId == GlobalInstanses.LastCourse.Id).CurrentStepNumber);
            
            navigate?.Invoke(prop);
        }
        public BCommand Navigate { get; }
        public BCommand FinishTestCommand { get; }
        public FinalTestVM(Action<object> navigate, Course course)
        {
            db = new();
            this.navigate = navigate;
            CurrentCourse = course;

            TestName = course.Test.Name;
            questionText = CurrentCourse.Test.Questions.First().QuestionText;

            Navigate = new(OnNavigate, (o) => true);
            FinishTestCommand = new(OnFinishTest, (o) => QuestionsCollection.All(q => q.Answer.Trim() != string.Empty));

            foreach(var item in course.Test.Questions)
            {
                if(item.AnswerOptions.Count > 0) 
                questionsCollection.Add(new Question()
                {
                    QuestionText = item.QuestionText,
                    Answer = string.Empty,
                    AnswerOptions = item.AnswerOptions
                });
                else
                    questionsCollection.Add(new Question()
                    {
                        QuestionText = item.QuestionText,
                        Answer = string.Empty
                    });
            }

           /* #region Fill Questions collection

            foreach(var q in CurrentCourse.Test.Questions)
            {
                if(q.AnswerOptions.Count ==0)
                {
                    var oneAnswQuestion = new OneAnswerQuestion();
                    Binding questionBinding = new Binding
                    {
                        Path = new System.Windows.PropertyPath(nameof(q.QuestionText)),
                        Mode = BindingMode.OneWay,
                    };
                    BindingOperations.SetBinding(oneAnswQuestion, OneAnswerQuestion.QuestionTextProperty, questionBinding);

                    Binding answerBinding = new Binding
                    {
                        Path = new System.Windows.PropertyPath(nameof(q.Answer)),
                        Mode = BindingMode.TwoWay,
                    };
                    BindingOperations.SetBinding(oneAnswQuestion, OneAnswerQuestion.AnswerTextProperty, answerBinding);

                    QuestionsCollection.Add(oneAnswQuestion);
                }
                else
                {
                    MessageBox.Show("wops");
                }
                    
            }

            #endregion*/
        }
    }
}
