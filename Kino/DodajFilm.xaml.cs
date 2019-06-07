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

namespace Kino
{
    /// <summary>
    /// Interaction logic for DodajFilm.xaml
    /// </summary>
    public partial class DodajFilm : Window
    {
        Sql databaseSql = new Sql();

        public DodajFilm()
        {
            InitializeComponent();
        }

        private void Button_dodajfilm_Click(object sender, RoutedEventArgs e)
        {
            var nazwa = textbox_nazwa.Text;
            var gatunek = textbox_gatunek.Text;
            var opis = textbox_opis.Text;
            var rok = Convert.ToInt32(textbox_rok.Text);
            var time = (date_film.Text);

            databaseSql.AddMovie(nazwa,gatunek,rok,opis,time);
            dodano_label.FontSize = 25;
            dodano_label.Foreground = Brushes.Green;
            dodano_label.Content = "Dodano.";

        }
    }
}
