
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
                //открытие шоу диалога для выбора файла
                OpenFileDialog MDialog = new OpenFileDialog();
                if (MDialog.ShowDialog() == true)
                {
                    //MessageBox.Show(MDialog.FileName);
                    filepath = MDialog.FileName;
                }
                
            }
            catch(Exception ex)//исключения
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("Данное изображения не подходит по размеру или расширению");
            }

            BitmapImage myBitmapImage1 = new BitmapImage();
            myBitmapImage1.BeginInit();
            if (filepath != null)
            {
                myBitmapImage1.UriSource = new Uri(filepath);//
            }
            else
            {
                //myBitmapImage1.
            }
            myBitmapImage1.EndInit();

            Image1.Source = myBitmapImage1;
        }
        private void grayButton_Click(object sender, EventArgs e)
        {
            if (Image1.Source != null) // если изображение в pictureBox1 имеется
            {
                // создаём Bitmap из изображения, находящегося в pictureBox1
                BitmapImage input = new BitmapImage(Image1.Source);
                // создаём Bitmap для черно-белого изображения
                BitmapImage output = new BitmapImage(input.Width, input.Height);
                // перебираем в циклах все пиксели исходного изображения
                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        // получаем (i, j) пиксель
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        // получаем компоненты цветов пикселя
                        float R = (float)((pixel & 0x00FF0000) >> 16); // красный
                        float G = (float)((pixel & 0x0000FF00) >> 8); // зеленый
                        float B = (float)(pixel & 0x000000FF); // синий
                                                               // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                        R = G = B = (R + G + B) / 3.0f;
                        // собираем новый пиксель по частям (по каналам)
                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                        // добавляем его в Bitmap нового изображения
                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                    }
                // выводим черно-белый Bitmap в pictureBox2
                pictureBox2.Image = output;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ImageLoad(sender, e);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
