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

            if (cbEmcEut.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbEmcEut1, cbEmcEut2,
                    cbEmcEut3, cbEmcEut4, cbEmcEut5, cbEmcEut6);
            }
            if (cbEnviromental.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbEnviromental1, cbEnviromental2,
                    cbEnviromental3, cbEnviromental4, cbEnviromental5, cbEnviromental6);
            }
            if (cbReliability.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbReliability1, cbReliability2,
                    cbReliability3, cbReliability4, cbReliability5, cbReliability6);
            }
            if (cbProductSafety.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbProductSafety1, cbProductSafety2,
                    cbProductSafety3, cbProductSafety4, cbProductSafety5, cbProductSafety6);
            }
            if (cbGreenCompilance.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbGreenCompilance1, cbGreenCompilance2,
                    cbGreenCompilance3, cbGreenCompilance4, cbGreenCompilance5, cbGreenCompilance6);
            }
        }
    }
}
