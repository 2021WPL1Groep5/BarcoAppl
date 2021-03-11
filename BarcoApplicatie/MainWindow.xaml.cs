using BarcoApplicatie.BibModels;
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
                txtProjectName.Text, txtEutPartnumber1.Text, ExpectedEndDate.SelectedDate, 
                txtGrossWeight1.Text, txtNetWeight1.Text, Checkbox_Yes);

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

        public void ChangeWeight(string changeweight)
        {
            txtNetWeight1.Text = changeweight;
            txtGrossWeight2.Text = changeweight;
            if (System.Text.RegularExpressions.Regex.IsMatch(changeweight, "[^0-9*,]"))
            {
                WeightErrorLabel.Content = "Please enter numbers only.";
                changeweight = changeweight.Remove(changeweight.Length - 1);
            }
        }

        public void EutPartnumber1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEutPartnumber1.Text, "[^A-Z-a-z]"))
            {
                MessageBox.Show("Please enter only numbers.");
                //txtEutPartnumber1.Text.Remove(txtEutPartnumber1.Length - 1);
            }
        }




        // functie om de input te controleren
        public void ControlInput(string canBe, TextBox box, Label label, string content)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, canBe))
            {
                label.Content = content;
                box.Text = box.Text.Remove(box.Text.Length - 1);
            }
            
        }

        // elk tekstvak de input met de functie controleren en aanpassen
        private void txtRequesterInitials_TextChanged (object sender, TextChangedEventArgs e)
        {
            ControlInput("[^A-Z-a-z]", txtRequesterInitials, InitialErrorLabel, "Please enter letters only.");

            txtRequesterInitials.Text.ToUpper();
        }

        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtProjectNumber, ProjectNumberErrorLabel, "Please enter numbers only.");
        }

        private void txtProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^A-Z-a-z-0-9]", txtProjectNumber, ProjectNumberErrorLabel, "Please enter letters and numbers only.");

            if (System.Text.RegularExpressions.Regex.IsMatch(txtProjectNumber.Text, "[^0-9]"))
            {
                ProjectNumberErrorLabel.Content = "Please enter numbers only.";
                txtProjectNumber.Text = txtProjectNumber.Text.Remove(txtProjectNumber.Text.Length - 1);
            }
        }

    }
}
