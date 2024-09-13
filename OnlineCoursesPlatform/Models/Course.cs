using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public enum Complexity
    {
        easy,
        medium,
        high
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CourseCategory? Category { get; set; }
        public string? PreviewPath { get; set; }
        public string? LogoPath { get; set; } = @"D:\coursWPF\OnlineCoursesPlatform\OnlineCoursesPlatform\Resourses\course_logo_base.png";
        public int CategoryId { get; set; }
        public bool IsOpen { get; set; } = true;
        public ICollection<Permission>? Permissions { get; set; }
        public double? Rating {  get; set; }
        public Complexity Complexity { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public ICollection<CourseSteps>? Steps { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? FinishDate { get; set; } 
        public ICollection<User>? Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<Comment>? Comments { get; set; }
        public Test? Test { get; set; }
        public ICollection<CourseProgress> CourseProgresses { get; set; }
        


        public Course(string name, CourseCategory category, Complexity complexity,  string description, string author)
        {
            Name = name;
            Category = category;
            Complexity = complexity;
            Description = description;
            Author = author;
        }
        public Course() { }
    }
}
