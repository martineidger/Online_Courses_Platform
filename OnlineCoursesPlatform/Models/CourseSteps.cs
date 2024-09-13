using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class CourseSteps
    {
        public int Id {  get; set; }
        public string StepName { get; set; }
        public int? CourseId { get; set; }
        public Course Course {  get; set; }
        public int StepNumber { get; set; }
        public string? LectionSourse { get; set; }
        public string LectionText {  get; set; }

        public CourseSteps( Course course, int stepNumber, string name,  string? lectionSourse, string lectionText)
        {
            Course = course;
            StepNumber = stepNumber;
            StepName = name;
            LectionSourse = lectionSourse;
            LectionText = lectionText;
        }

        public CourseSteps() { }

    }
}
