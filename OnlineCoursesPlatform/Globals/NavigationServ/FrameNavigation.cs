using OnlineCoursesPlatform.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace OnlineCoursesPlatform.Globals.NavigationServ
{
    public static class FrameNavigation
    {
        private static INavigationService? _navigationService;

        public static void SetNavigation(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public static INavigationService GetNavigation()
        {
            return _navigationService;
        }

    }
}
