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
using System.Windows.Shapes;

namespace Kino.windows
{
    using Kino.Models;

    /// <summary>
    /// Interaction logic for _4.xaml
    public partial class _4 : Window
    {
        public static Random rnd = new Random();

        protected int OneTicketValue = 5;

        protected int TotalValue = 0;

        protected Button[] list_buttons = new Button[30];

        protected Image[] List_image = new Image[5];

        protected Film _film;

        protected Klient _klient;

        protected Sql _databaseSql;

        public int currentSeat;

        public _4(Film film, Klient klient, Sql databaseSql)
        {
            InitializeComponent();
            _film = film;
            _klient = klient;
            _databaseSql = databaseSql;
            nazwaFilmu_label.Content = _film.NazwaFilmu;
            Image_grid.DataContext = _film;
            Lb1.FontStyle = FontStyles.Italic;
            Lb1.FontSize = 20;
            for (ushort i = 0; i < 30; i++)
            {
                Button temp = new Button();
                list_buttons[i] = Buttons_grid.Children[i] as Button;
            }

            for (ushort j = 0; j < 7; j++)
            {
                int temp = rnd.Next(0, 30);
                //list_but[temp].IsEnabled = false;
                list_buttons[temp].Background = Brushes.Red;
            }
        }

        private void Rezerwacja()
        {
            // MessageBox.Show($"klient: {_klient}");
            // MessageBox.Show($"film: {_film}");
            
            MessageBox.Show( _film.ID.ToString()+" "+ _klient.Login);


            _databaseSql.ReserveMovie(_klient,_film, currentSeat);


        }

        private void Bt1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var temp = sender as Button;
            if (temp.Background != Brushes.Red && temp.Background != Close_button.Background)
            {
                temp.Background = Close_button.Background;
                TotalValue -= OneTicketValue;
                Lb1.Content = $"{TotalValue} $";
            }
        }

        private void Bt1_Click(object sender, RoutedEventArgs e)
        {
            var temp = sender as Button;
            if (temp.Background != Brushes.Green && temp.Background != Brushes.Red
                                                 && temp.Background == Close_button.Background)
            {   
                temp.Background = Brushes.Green;
                TotalValue += OneTicketValue;
                Lb1.Content = $"{TotalValue} $";
                currentSeat = Convert.ToInt32(temp.Content);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoveLeft();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           Rezerwacja();
        }

        private void MoveLeft()
        {

        }

        private void MoveRight()
        {

        }
    }
}
