using BarcoApplicatie.BibModels;
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

            string sDate = Convert.ToString(rqRequest.RequestDate);
            string sNature = Convert.ToString(rqRequest.JobNature);
            string sProjectName = Convert.ToString(rqRequest.EutProjectname);
            string sEndDate = Convert.ToString(rqRequest.ExpectedEnddate);

            string sOutput = sDate + sNature + sProjectName + sEndDate;

            lbViewRequest.Items.Add(sOutput);
        }
    }
}
