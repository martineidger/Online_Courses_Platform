using GalaSoft.MvvmLight;
using OnlineCoursesPlatform.Globals;
using OnlineCoursesPlatform.ViewModels;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OnlineCoursesPlatform.Infrastructure.Services
{
    public class FrameNavigationService : INavigationService
    {
        private readonly Frame _frame;

        public FrameNavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            var viewModel = Activator.CreateInstance<TViewModel>();
            Page view;
            if (GlobalInstanses.CurrentPage == "Login")
            {
                view = new MainPage();
                view.DataContext = viewModel;
            } 
            else view = new LoginPage();
            _frame.Navigate(view);
        }
    }
}
