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

namespace Kino
{
    using Kino.NewFolder1;
    using Kino.windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
                RLgrid.Background = new SolidColorBrush(Color.FromArgb(50, 100, 150, 100));
            grid2.Visibility = Visibility.Hidden;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button1_2window_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            _4 fourthwindow = new _4();
            
            
             fourthwindow.Show();
             grid1.Visibility = Visibility.Hidden;
            
        }

        private void Button_movie1_Click(object sender, RoutedEventArgs e)
        {
            _4 fourthwindow = new _4();
            fourthwindow.Show();
           

        }

        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Visible;
        }
    }
}
