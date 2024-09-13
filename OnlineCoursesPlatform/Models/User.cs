using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public enum Roles
    {
        student,
        admin
    }
    public enum Statuses
    {
        Pupil,
        Student,
        Worker,
        Unemployed,
        none
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
        public Statuses? Status {  get; set; }
        public string? Organisation {  get; set; }
        public ICollection<Course>? Courses { get; set; } = new ObservableCollection<Course>();
        public ICollection<Permission>? Permissions { get; set; }
       
        //public int? FinishedCoursesId { get; set; }
        //[ForeignKey("FinishedCoursesId")]
        //public Course FinishedCourses { get; set; }
        public ICollection<TestScore>? TestScores { get; set; } = new List<TestScore>();
        public ICollection<CourseProgress>? CourseProgresses { get; set; } = new List<CourseProgress>();

        public User(string username, string password, Roles role) 
        {
            UserName = username;
            Password = password;
            Role = role;
        }

        public User() { }
    }
}
