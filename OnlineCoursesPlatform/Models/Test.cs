using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public ICollection<TestScore>? TestScores { get; set; } = new List<TestScore>();

    }
}
