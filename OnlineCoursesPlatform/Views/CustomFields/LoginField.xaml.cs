using OnlineCoursesPlatform.Globals.ViewModels;
using OnlineCoursesPlatform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для LoginField.xaml
    /// </summary>
    public partial class LoginField : UserControl
    {
        public LoginField()
        {
            InitializeComponent();
            DataContext = ViewModelsService.GetLoginVM();
        }
    }
}
