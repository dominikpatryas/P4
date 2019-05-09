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
    using System.Reflection;
    using System.Runtime.Remoting.Channels;

    using Kino.Models;
    using Kino.windows;
    using MahApps.Metro.Controls;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Sql databaseSql = new Sql();

        public Klient klient;
        private int selectedIndex;

        public MainWindow()
        {
            InitializeComponent();
            grid1.Visibility = Visibility.Visible;
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            grid2.Visibility = Visibility.Hidden;
            // hello_label.Visibility = Visibility.Hidden;
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                    "C:/Users/domin/Pictures/cinema1.jpg"));
            myBrush.ImageSource = image.Source;
            grid2.Background = myBrush;
        }

        // LOGOWANIE
        private void Button_login_Click(object sender, RoutedEventArgs e)
        {

            var textbox_login_input = TEXTBOX_login1.Text; 
            var textbox_password_input = TEXTBOX_password1.Text;

            if (loginCheckbox.IsChecked.Value)
            {
                databaseSql.Login_sprzedawca(textbox_login_input, textbox_password_input);

                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Visible;

                loadMovies();
            }
            

            if (!loginCheckbox.IsChecked.Value)
            {
                var res = databaseSql.Login(textbox_login_input, textbox_password_input);

                if (res != null)
                {
                    grid1.Visibility = Visibility.Hidden;
                    grid2.Visibility = Visibility.Visible;
                    ButtonAddFilm.Visibility = Visibility.Hidden;
                    klient = res;
                    loadMovies();
                }
            }
          
        }

        

        private void loadMovies()
        {
            if (grid2.Visibility == Visibility.Visible)
            {
                var res = databaseSql;

                McDataGrid.AutoGenerateColumns = false;
                DataGridTextColumn IDcol = new DataGridTextColumn();
                DataGridTextColumn Nazwacol = new DataGridTextColumn();
                DataGridTextColumn Gatunekcol = new DataGridTextColumn();
                DataGridTextColumn Rokcol = new DataGridTextColumn();

                Binding b =  new Binding("ID");
                IDcol.Binding = b;
                IDcol.Header = "ID";
                McDataGrid.Columns.Add(IDcol);

                b = new Binding("NazwaFilmu");
                Nazwacol.Binding = b;
                Nazwacol.Header = "Nazwa Filmu";
                McDataGrid.ColumnWidth = 250;
                McDataGrid.Columns.Add(Nazwacol);

                b = new Binding("GatunekFilmu");
                Gatunekcol.Binding = b;
                Gatunekcol.Header = "Gatunek Filmu";
                McDataGrid.ColumnWidth = 200;
                McDataGrid.Columns.Add(Gatunekcol);

                b = new Binding("RokProdukcji");
                Rokcol.Binding = b;
                Rokcol.Header = "Rok Produkcji";
                McDataGrid.ColumnWidth = 100;
                McDataGrid.Columns.Add(Rokcol);

                McDataGrid.ItemsSource = databaseSql.sqlloadMovies();
                McDataGrid.MaxColumnWidth = 298;
                McDataGrid.IsReadOnly = true;
                hello_label.Visibility = Visibility.Hidden;

            }
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

        private void loginCheckbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void button_register_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void McDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        

        private void loginCheckbox_Click(object sender, RoutedEventArgs e)
        {
        }

        private void McDataGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    DataGridRow dgr = grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem) as DataGridRow;
                    Film obj = dgr.Item as Film;
                    this.selectedIndex = grid.SelectedIndex;
                    int id = obj.ID;
                    string name = obj.NazwaFilmu;
                    RezerwacjaMiejsca(obj);
                    _4 x = new _4(obj, klient, databaseSql);
                    x.Show();
                }
            }

            
        }

        private void RezerwacjaMiejsca(Film film)
        {
            // MessageBox.Show(film.NazwaFilmu);
        }

        private void ButtonAddFilm_Click(object sender, RoutedEventArgs e)
        {
            DodajFilm df = new DodajFilm();
            df.Show();
        }

        private void RefreshFilm_Click(object sender, RoutedEventArgs e)
        {
            McDataGrid.ItemsSource = null;
            loadMovies();
        }

        
    }



}
