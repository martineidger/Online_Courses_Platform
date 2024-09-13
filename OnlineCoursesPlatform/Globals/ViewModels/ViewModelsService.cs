using OnlineCoursesPlatform.Infrastructure.Services;
using OnlineCoursesPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Globals.ViewModels
{
    public static class ViewModelsService
    {
        private static LoginVM loginVM;
        private static MainWindowVM mainWindowVM;
        public static MainWindowVM GetMainVM()
        {
            if (mainWindowVM == null)
                mainWindowVM = new MainWindowVM();
            return mainWindowVM;
        }

        //public static MainWindowViewModel GetMainViewModel()
        //{
        //    if (mainWindowViewModel == null)
        //        mainWindowViewModel = new MainWindowViewModel();
        //    return mainWindowViewModel;
        //}

        public static LoginVM GetLoginVM()
        {
            loginVM ??= new LoginVM();
            return loginVM;
        }
    }
}
