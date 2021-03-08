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
    /// Interaction logic for OverviewJobrequests.xaml
    /// </summary>
    public partial class OverviewJobrequests : Window
    {
        public OverviewJobrequests()
        {
            InitializeComponent();
            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }
    }
}
