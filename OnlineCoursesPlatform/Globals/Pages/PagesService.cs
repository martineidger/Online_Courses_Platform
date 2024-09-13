using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Globals.Pages
{
    public static class PagesService
    {
        private static  RegistrationField reg;
        private static  LoginField login;

        public static RegistrationField GetRegField()
        {
            reg ??= new RegistrationField();
            return reg;
        }

        public static LoginField GetLoginField()
        {
            login ??= new LoginField();
            return login;
        }
    }
}
