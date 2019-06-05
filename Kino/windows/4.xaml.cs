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
    using System.Collections;

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

        public int []currentSeat;

        public ArrayList arrayList = new ArrayList();

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

            // int []tab = _databaseSql.RedSeatsMovie(film.ID);
            ArrayList seats = _databaseSql.RedRealSeatsMovie(film.ID);

            var countOfUsers = _databaseSql.getCountOfRows(film.ID);
            
            foreach (int i in seats)
            {
                int temp = i -1;
                list_buttons[temp].Background = Brushes.Red;

            }
            // int temp = seats[i] -1;
            //list_but[temp].IsEnabled = false;
        }

        private void Rezerwacja()
        {
            // MessageBox.Show($"klient: {_klient}");
            // MessageBox.Show($"film: {_film}");
            if (_klient != null)
            {

                // MessageBox.Show(_film.ID.ToString() + " " + _klient.Login);



                _databaseSql.ReserveMovie(_klient, _film, arrayList);
                score.FontSize = 25;
                score.Foreground = Brushes.Green;
                score.Content = "Udało Ci się zarezerwować miejsce.";
            }
            else
            {
                score.FontSize = 25;
                score.Foreground = Brushes.Red;
                score.Margin = new Thickness(20, 0, -14.8, 0);
                score.Content = "Nie udało Ci się zarezerwować miejsca.";
            }
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
            ArrayList arr = new ArrayList();
            if (temp.Background != Brushes.Green && temp.Background != Brushes.Red
                                                 && temp.Background == Close_button.Background)
            {
                temp.Background = Brushes.Green;
                var x = temp.Content;
                
                arrayList.Add(x);
                // arr.Add(Convert.ToInt32(temp.Content));

            }

        }



        // DZIALA
        // private void Bt1_Click(object sender, RoutedEventArgs e)
        // {
        //     var temp = sender as Button;
        //     ArrayList arr = new ArrayList();
        //     if (temp.Background != Brushes.Green && temp.Background != Brushes.Red
        //                                          && temp.Background == Close_button.Background)
        //     {
        //         temp.Background = Brushes.Green;
        //         arr.Add(Convert.ToInt32(temp.Content));
        //
        //         for (int i = 0; i < arr.Count; i++)
        //         {
        //
        //         }
        //
        //         int j = 0;
        //         currentSeat = new[] { 2 };
        //
        //         foreach (var i in arr)
        //         {
        //             currentSeat[j] = Convert.ToInt32(i);
        //             j++;
        //
        //         }
        //     }
        // }

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

        private void Trailer_Click(object sender, RoutedEventArgs e)
        {
            
            Player player = new Player();
            player.Show();
            player.watchTrailer(_film.ID, _film.NazwaFilmu);
        }
    }
}
