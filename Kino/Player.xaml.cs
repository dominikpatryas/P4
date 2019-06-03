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
            }
        }
        
    }
}
