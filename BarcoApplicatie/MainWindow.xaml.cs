using BarcoApplicatie.NewBibModels;
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
            dao = DAO.Instance();

            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

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
            ViewJobrequest ViewJobrequest = new ViewJobrequest();
            ViewJobrequest.Show();

            dao.Request(txtRequesterInitials1.Text, cmbDivision.Text, cmbJobNature.Text,
                txtProjectName1.Text, txtEutPartnumber6.Text, ExpectedEndDate.SelectedDate,
                txtGrossWeight6.Text, txtNetWeight6.Text, Checkbox_Yes);
        }
            

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            dao.addingOptionalInput(txtLinkToTestplan1.Text, txtSpecialRemarks1.Text);
        }

        //move to errorhandling
        public void PVGresponsible()
        {
            //this is not available in MainWindow
            cmbPvgResposibleEmc.IsEnabled = false;
            cmbPvgResponsibleEnviromental.IsEnabled = false;
            cmbPvgRepsonsibleReliability.IsEnabled = false;
            cmbPvgResponsibleProductSafety.IsEnabled = false;
            cmbPvgResponsiblePackaging.IsEnabled = false;
            cmbPvgResponsibleGreenCompilance.IsEnabled = false;
        }

        //move to errorhandling
        public void isEnabled()
        {

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
