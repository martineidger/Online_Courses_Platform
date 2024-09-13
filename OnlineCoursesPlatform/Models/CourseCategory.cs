using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class CourseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsSelected { get; set; }
        public ICollection<Course>? Courses { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
