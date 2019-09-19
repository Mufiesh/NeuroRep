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

namespace NeuroTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void ImageLoad(object sender, RoutedEventArgs e)
        {
            Image i = new Image();
            BitmapImage src = new BitmapImage();
            src.BeginInit();
            src.UriSource = new Uri("picture.jpg", UriKind.Relative);
            src.EndInit();
            i.Source = src;
            i.Stretch = Stretch.Uniform;
            //int q = src.PixelHeight;        // Image loads here
            sp.Children.Add(i);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageLoad(sender, e);
        }
    }
}
