using OnlineCoursesPlatform.Globals.NavigationServ;
using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.Infrastructure.EF;
using OnlineCoursesPlatform.Infrastructure.Services;
using OnlineCoursesPlatform.Models;
using OnlineCoursesPlatform.ViewModels;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

using System.Windows.Shapes;

namespace OnlineCoursesPlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationService = new FrameNavigationService(MainFrame);
            FrameNavigation.SetNavigation(navigationService);
            var viewModelM = ViewModelsService.GetMainVM();
            var viewModelL = ViewModelsService.GetLoginVM();

            MainFrame.Navigate(new LoginPage { DataContext = viewModelM });
            //DataContext = ViewModelsService.GetMainVM();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}