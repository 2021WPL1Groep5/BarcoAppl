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

namespace BarcoApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        private static BarcoDBContext context = new BarcoDBContext();

        public MainWindow()
        {
            InitializeComponent();
            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();
        }

        private void insertDivisionIntoComboBox()
        {
            var divisions = context.RqBarcoDivision.ToList();

            foreach (RqBarcoDivision division in divisions)
            {
                cmbDivision.Items.Add(division.Afkorting);
            }
        }

        private void insertJobNatureIntoComboBox()
        {
            var jobNatures = context.RqJobNature.ToList();

            foreach (RqJobNature jobNature in jobNatures)
            {
                cmbJobNature.Items.Add(jobNature.Nature);
            }
        }

        private void Request()
        {
            RqRequest request = new RqRequest();
            request.JrNumber = "0002";
            request.Requester = txtRequesterInitials.Text;
            request.BarcoDivision = cmbDivision.Text;
            request.JobNature = cmbJobNature.Text;
            request.EutProjectname = txtProjectName.Text;
            request.EutPartnumbers = txtEutPartnumber1.Text;
            request.ExpectedEnddate = ExpectedEndDate.SelectedDate;
            request.InternRequest = false;
            request.GrossWeight = Convert.ToInt16(txtGrossWeight1.Text);
            request.NetWeight = Convert.ToInt16(txtNetWeight1.Text);

            if (Checkbox_Yes.IsChecked == true)
            {
                request.Battery = true;
            }

            context.Add(request);
            context.SaveChanges();            
        }
        
        private void txtNetWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNetWeight1.Text, "[^0-9-.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtNetWeight1.Text = txtNetWeight1.Text.Remove(txtNetWeight1.Text.Length - 1);
            }
            */
        }

        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            if (System.Text.RegularExpressions.Regex.IsMatch(txtProjectNumber.Text, "[^0-9-E]"))
            {
                MessageBox.Show("Please enter only numbers or a E.");
                txtProjectNumber.Text = txtProjectNumber.Text.Remove(txtProjectNumber.Text.Length - 1);
            }
            */
        }

        private void cmbDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Checkbox_Yes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox_No_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            Request();
        }

        private void cmbJobNature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
