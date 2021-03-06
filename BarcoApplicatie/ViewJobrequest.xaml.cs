﻿using BarcoApplicatie.BibModels;
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

            loadAllRequest();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
        }

        //Koen
        private void loadAllRequest()
        {
            var requests = dao.getAllRequests();

            foreach (RqRequest request in requests)
            {
                lbViewRequest.Items.Add(request.ExpectedEnddate);
            }
        }

        //Koen
        private void lbViewRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AcceptJobrequest acceptJobrequest = new AcceptJobrequest();
            acceptJobrequest.Show();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
