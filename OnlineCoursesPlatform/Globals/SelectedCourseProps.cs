using OnlineCoursesPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Globals
{
    public class SelectedCourseProps
    {
        public string Direction { get; set; }
        public Course Course { get; set; }
        public decimal Progress {  get; set; }
        public SelectedCourseProps(string dir, Course course, decimal progress)
        {
            Direction = dir;
            Course = course;
            Progress = progress;
        }
    }
}
