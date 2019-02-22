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
    using System.Data.SqlClient;

    using Kino.windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sql databaseSql = new Sql();

        public MainWindow()
        {
            InitializeComponent();
            RLgrid.Background = new SolidColorBrush(Color.FromArgb(50, 100, 150, 100));
            grid2.Visibility = Visibility.Hidden;
        }

        // LOGOWANIE
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {
            var textbox_login_input = TEXTBOX_login1.Text;
            var textbox_password_input = TEXTBOX_password1.Text;
            
           var res = databaseSql.Login(textbox_login_input, textbox_password_input);
            if (res == true)
            {
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("Invalid username or password!");
        }

        private void Button_movie1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var textbox_register_input = TEXTBOX_register2.Text;
            var textbox_password_input = TEXTBOX_password2.Text;

            var res = databaseSql.Register(textbox_register_input, textbox_password_input);
            if (res == true)
            {
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;
            }
            else MessageBox.Show("Invalid username or password!");
        }

        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TEXTBOX_password1_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
