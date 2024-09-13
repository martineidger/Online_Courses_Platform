using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

namespace OnlineCoursesPlatform.Views.CustomFields
{
    /// <summary>
    /// Логика взаимодействия для CoursesCatalogField.xaml
    /// </summary>
    public partial class CoursesCatalogField : UserControl
    {
        public CoursesCatalogField()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("u");
        }

        private void CatalogListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#FF7EB4EA");
            SolidColorBrush brush = new SolidColorBrush(color);
            //CategoryBorder.BorderBrush = brush;
        }

        private void CategoryBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            
            Color color = (Color)ColorConverter.ConvertFromString("#C3E6FF");
            SolidColorBrush brush = new SolidColorBrush(color);
            //CategoryBorder.BorderBrush = brush;
        }

        private void NameCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //NameComboText.VerticalAlignment = VerticalAlignment.Top;
            NameComboText.HorizontalAlignment = HorizontalAlignment.Right;
            NameComboText.FontSize = 10;
        }

        private void DifficultyCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DifficultyComboText.HorizontalAlignment = HorizontalAlignment.Right;
            DifficultyComboText.FontSize = 10;
        }

        private void CategoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategoryComboText.HorizontalAlignment = HorizontalAlignment.Right;
            CategoryComboText.FontSize = 10;
        }
    }
}
