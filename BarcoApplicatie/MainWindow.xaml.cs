﻿using BarcoApplicatie.NewBibModels;
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
using System.Collections;


namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        private DAO dao;

        public MainWindow()
        {
            InitializeComponent();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

            dao = DAO.Instance();

            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();
        }

        //Koen
        private void insertDivisionIntoComboBox()
        {
            List<RqBarcoDivision> divisions = dao.getAllDivisions();

            foreach (RqBarcoDivision division in divisions)
            {
                cmbDivision.Items.Add(division.Afkorting);
            }
        }

        //Koen
        private void insertJobNatureIntoComboBox()
        {
            List<RqJobNature> jobNatures = dao.getAllJobNatures();

            foreach (RqJobNature jobNature in jobNatures)
            {
                cmbJobNature.Items.Add(jobNature.Nature);
            }
        }

        //Koen
        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            dao.Request(txtRequesterInitials.Text, cmbDivision.Text, cmbJobNature.Text,
               txtProjectName.Text,
               "part1: " + txtEutPartnumber1.Text + "; " +
               "part2: " + txtEutPartnumber2.Text + "; " +
               "part3: " + txtEutPartnumber3.Text + "; " +
               "part4: " + txtEutPartnumber4.Text + "; " +
               "part5: " + txtEutPartnumber5.Text + "; ",
               ExpectedEndDate.SelectedDate,
               "Gross1: " + txtGrossWeight1.Text + "; " +
               "Gross2: " + txtGrossWeight2.Text + "; " +
               "Gross3: " + txtGrossWeight3.Text + "; " +
               "Gross4: " + txtGrossWeight4.Text + "; " +
               "Gross5: " + txtGrossWeight4.Text + "; ",
               "Net1: " + txtNetWeight1.Text + "; " +
               "Net2: " + txtNetWeight2.Text + "; " +
               "Net3: " + txtNetWeight3.Text + "; " +
               "Net4: " + txtNetWeight4.Text + "; " +
               "Net5: " + txtNetWeight5.Text + "; ",
               Checkbox_Yes);

            dao.addingOptionalInput(txtLinkToTestplan.Text, txtSpecialRemarks.Text);
        }


        /*
        public void RequesterInitials(string txtrequesterinitials)
        {
              txtRequesterInitials.Text = txtrequesterinitials.ToUpper();
            
            if (System.Text.RegularExpressions.Regex.IsMatch(txtrequesterinitials, "[^A-Z-a-z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtrequesterinitials = txtrequesterinitials.Remove(txtrequesterinitials.Length - 1);
                txtRequesterInitials.Text = txtrequesterinitials.ToUpper();
            }
        }
        */
        public void EutPartnumber(string txteutpartnr)
        {
            txteutpartnr = txtEutPartnumber1.Text;
            if (System.Text.RegularExpressions.Regex.IsMatch(txteutpartnr, "[^0-9-A-Z-.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txteutpartnr = txteutpartnr.Remove(txteutpartnr.Length - 1);
            }
        }

        public void ChangeWeight(string changeweight)
        {
            txtNetWeight1.Text = changeweight;
            txtGrossWeight2.Text = changeweight;
            if (System.Text.RegularExpressions.Regex.IsMatch(changeweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                changeweight = changeweight.Remove(changeweight.Length - 1);
            }
        }

        private void txtRequesterInitials_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (System.Text.RegularExpressions.Regex.IsMatch(txtRequesterInitials.Text, "[^A-Z-a-z]"))
            {
                MessageBox.Show("Please enter only letters.");
                txtRequesterInitials.Text = txtRequesterInitials.Text.Remove(txtRequesterInitials.Text.Length - 1);
            }
            txtRequesterInitials.Text.ToUpper();
        }
    }
}
