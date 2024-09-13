using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Globals
{
    public static class GlobalInstanses 
    {

        private static User user;
        public static User CurrentUser
        {
            get{
                if (user == null)
                {
                    user = new User("admin", "admin1", Roles.admin);
                }
                return user;
            }
            set => user = value;
        }

        private static Course lastCourse;
        public static Course LastCourse
        {
            get => lastCourse;
            set => lastCourse = value;
        }

        private static string _currentPage = "Login";
        public static string CurrentPage
        {
            get => _currentPage;
            set => _currentPage = value;
        }

    }
}
