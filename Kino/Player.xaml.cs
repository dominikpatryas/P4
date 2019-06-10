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
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : Window
    {
        public Player()
        {
            InitializeComponent();
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(
                new Uri(
                    "C:/Users/domin/Desktop/cinemawatch.jpg"));
            myBrush.ImageSource = image.Source;
            gridplayer.Background = myBrush;
        }

        public void watchTrailer(int _IDFilmu, string _NazwaFilmu)
        {
            switch (_IDFilmu)
            {
                case 1:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/interstellar_Trim.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 2:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/themartian.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 3:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Nietykalni zwiastun trailer pl.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 4:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Jestem Bogiem - oficjalny polski zwiastun.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 5:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Deadpool  Red Band Trailer [HD]  20th Century FOX.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 6:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Igrzyska śmierci - zwiastun PL.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 7:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Niezgodna - zwiastun.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 8:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Avengers Koniec gry - zwiastun 2 [dubbing].mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 9:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Marvel Studios Captain Marvel - Trailer 2.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 10:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Jak wytresować smoka 3 – zwiastun.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 11:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Alita Battle Angel  Official Trailer [HD]  20th Century FOX.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 12:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Dark Phoenix  Final Trailer [HD]  20th Century FOX.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 13:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Bohemian Rhapsody  Official Trailer [HD]  20th Century FOX.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 14:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Green Book - Official Trailer [HD].mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 15:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/Avengers Wojna bez granic - zwiastun [dubbing].mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 16:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/NARODZINY GWIAZDY - oficjalny zwiastun 1 PL.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 17:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/KLER - oficjalny zwiastun nowego filmu Wojtka Smarzowskiego  .mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;
                case 18:
                    mediaplayer.Source = new Uri("C:/Users/domin/Desktop/Projekty VS/Kino/Kino/ZIMNA WOJNA - oficjalny zwiastun filmu.mp4");
                    nazwa_trailer.Content = _NazwaFilmu;
                    break;

            }
        }
        
    }
}
