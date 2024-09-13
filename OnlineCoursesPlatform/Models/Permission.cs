using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Models
{
    public enum PermissionState
    {
        open,
        requested,
        close
    }
    public class Permission
    {
        public int Id { get; set; }
        public PermissionState State { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
