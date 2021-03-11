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

            //insertDivisionIntoComboBox();
            //insertJobNatureIntoComboBox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

        }
        /*
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
        */
        //Koen
        /*
        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            ViewJobrequest ViewJobrequest = new ViewJobrequest();
            ViewJobrequest.Show();

            dao.Request(txtRequesterInitials1.Text, cmbDivision.Text, cmbJobNature.Text,
                txtProjectName1.Text, txtEutPartnumber6.Text, ExpectedEndDate.SelectedDate,
                txtGrossWeight6.Text, txtNetWeight6.Text, Checkbox_Yes);
        }
        */    

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            dao.addingOptionalInput(txtLinkToTestplan1.Text, txtSpecialRemarks1.Text);
        }

        //move to errorhandling
        /*
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
        */

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


        public void ControlInput(string canBe, TextBox box, Label label, string content)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, canBe))
            {
                label.Content = content;
                box.Text = box.Text.Remove(box.Text.Length - 1);
            }

        }

        // elk tekstvak de input met de functie controleren en aanpassen
        private void txtRequesterInitials_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^A-Z-a-z]", txtRequesterInitials1, InitialErrorLabel, "Please enter letters only.");

            txtRequesterInitials1.Text.ToUpper();
        }
        
        
        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtProjectNumber, ProjectNumberErrorLabel, "Please enter numbers only.");
        }

       
      

       

        private void txtProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-A-Z-a-z]", txtProjectName, ProjectNameErrorLabel, "Please enter letters and numbers only.");
        }
       
        
        private void txtEutPartnumber1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtEutPartnumber1, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtEutPartnumber2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtEutPartnumber3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtEutPartnumber4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtEutPartnumber5, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtNetWeight1, numbersErrorLabel, "Please enter numbers or , . only.");
            
        }

        private void txtNetWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtNetWeight2, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtNetWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtNetWeight3, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtNetWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtNetWeight4, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtNetWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtNetWeight5, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtGrossWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtGrossWeight1, numbersErrorLabel, "Please enter numbers or , . only.");
            
        }

        private void txtGrossWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtGrossWeight2, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtGrossWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtGrossWeight3, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtGrossWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtGrossWeight4, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void txtGrossWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,-.]", txtGrossWeight5, numbersErrorLabel, "Please enter numbers or , . only.");
        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtProjectName_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
