using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Window
    {
        public HomeScreen()
        {
            InitializeComponent();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }

       

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();
            MainWindow.Show();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            ViewAcceptJobrequest ViewAcceptJobrequest = new ViewAcceptJobrequest();
            ViewAcceptJobrequest.Show();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            ViewJobrequest ViewJobrequest = new ViewJobrequest();
            ViewJobrequest.Show();
        }
    }
}
