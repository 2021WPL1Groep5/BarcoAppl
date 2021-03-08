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

            isFilledIn(cbEmcEut);
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

        public void isFilledIn(CheckBox item)   //cbEmcEut
        {
            if (item.IsChecked == false)        //cbEmcEut
            {
                int iNumber = 0;
                for (int i = 0; i < 6; i++)
                {
                    //string itemValue = item.content.ToString();
                    iNumber += iNumber++;

                    string sItem = item.Name;


                    string sNumber = Convert.ToString(iNumber);

                    sItem = sItem + sNumber;
                   item.IsEnabled = false;
                }
            }
        }
    }
}
