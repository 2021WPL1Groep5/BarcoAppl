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
                "Net1: " + txtNetWeight1.Text + "; "+
                "Net2: " + txtNetWeight2.Text + "; " +
                "Net3: " + txtNetWeight3.Text + "; " +
                "Net4: " + txtNetWeight4.Text + "; " +
                "Net5: " + txtNetWeight5.Text + "; ",
                Checkbox_Yes);

            dao.addingOptionalInput(txtLinkToTestplan.Text, txtSpecialRemarks.Text);
        }
    }
}
