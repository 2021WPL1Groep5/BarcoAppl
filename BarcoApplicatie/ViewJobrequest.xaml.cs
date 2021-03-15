using BarcoApplicatie.NewBibModels;
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
    /// Interaction logic for ViewJobrequest.xaml
    /// </summary>
    public partial class ViewJobrequest : Window
    {
        private DAO dao;
        public ViewJobrequest()
        {
            InitializeComponent();

            dao = DAO.Instance();

            insertInfoIntoList();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }

        private void insertInfoIntoList()
        {
            List<RqRequest> rqRequests = dao.getRequest();

            RqRequest rqRequest = new RqRequest();

            string sDate = rqRequest.RequestDate.ToString();
            string sNature = rqRequest.JobNature.ToString();
            string sProjectName = rqRequest.EutProjectname.ToString();
            string sEndDate = rqRequest.ExpectedEnddate.ToString();

            string sOutput = sDate +sNature + sProjectName + sEndDate;

            ListBox.Items.Add(sOutput);
        }
    }
}
