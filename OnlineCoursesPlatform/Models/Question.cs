using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText {  get; set; }
        public string Answer { get; set; }
        public List<string>? AnswerOptions { get; set; } = new List<string>();
    }
}