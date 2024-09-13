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

namespace OnlineCoursesPlatform.Views.CustomFields
{
    /// <summary>
    /// Логика взаимодействия для FinalTestField.xaml
    /// </summary>
    public partial class FinalTestField : UserControl
    {
        public FinalTestField()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if(AnswerText.Text != string.Empty || AnswerText.Text != null)
            {
                TbBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DD006A"));
                
            }*/
        }
    }
}
