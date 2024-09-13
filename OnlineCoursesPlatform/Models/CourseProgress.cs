﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public class CourseProgress
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public int CurrentStepNumber { get; set; } = 0;

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
        
    }
}
