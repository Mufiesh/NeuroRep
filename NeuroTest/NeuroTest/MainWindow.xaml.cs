
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace NeuroTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        string filepath;
        public MainWindow()
        {

            InitializeComponent();
        }

        private void ImageLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog MDialog = new OpenFileDialog();
                if (MDialog.ShowDialog() == true)
                {
                    MessageBox.Show(MDialog.FileName);
                    filepath = MDialog.FileName;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BitmapImage myBitmapImage1 = new BitmapImage();
            myBitmapImage1.BeginInit();
            myBitmapImage1.UriSource = new Uri(filepath, UriKind.Absolute);
            myBitmapImage1.EndInit();

            Image.Source = myBitmapImage1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageLoad(sender, e);
        }
    }
}
