using GalaSoft.MvvmLight;
using OnlineCoursesPlatform.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoursesPlatform.Infrastructure.Services
{
    public interface INavigationService
    {
        void NavigateTo<TViewModel>() where TViewModel : ViewModel;
    }
}
