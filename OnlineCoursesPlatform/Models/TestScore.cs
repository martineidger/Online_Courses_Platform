using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class TestScore
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }
    }
}
