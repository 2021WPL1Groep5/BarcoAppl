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

    public static class Utils 
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DAO dao;
        private ErrorHandling errorHandling = new ErrorHandling();

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

                dao.addTestDivision("EMC");
            }
            if (cbEnviromental.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbEnviromental1, cbEnviromental2,
                    cbEnviromental3, cbEnviromental4, cbEnviromental5, cbEnviromental6);


                dao.addTestDivision("ENV");
            }
            if (cbReliability.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbReliability1, cbReliability2,
                    cbReliability3, cbReliability4, cbReliability5, cbReliability6);

                dao.addTestDivision("REL");
            }
            if (cbProductSafety.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbProductSafety1, cbProductSafety2,
                    cbProductSafety3, cbProductSafety4, cbProductSafety5, cbProductSafety6);

                dao.addTestDivision("SAF");
            }
            if (cbGreenCompilance.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, DateEut2.SelectedDate, DateEut3.SelectedDate,
                    DateEut4.SelectedDate, DateEut5.SelectedDate,
                    DateEut6.SelectedDate, cbGreenCompilance1, cbGreenCompilance2,
                    cbGreenCompilance3, cbGreenCompilance4, cbGreenCompilance5, cbGreenCompilance6);

                dao.addTestDivision("ECO");
            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            dao.addingOptionalInput(txtLinkToTestplan.Text, txtSpecialRemarks.Text);
        }

        
        //toggleCheckbox
        public void toggleCheckboxes(string checkboxName, string exceptions ,bool toggle)
        {
            foreach (CheckBox checkBox in Utils.FindVisualChildren<CheckBox>(this))
            {
                if( checkBox.Name.Contains(checkboxName)) {
                    if (!exceptions.Contains(checkBox.Name))
                    {
                        checkBox.IsEnabled = toggle;
                    }
                }
            }
        }

        public void toggle_click(CheckBox name, string cbname)
        {
            if (name.IsChecked == true)
            {
                toggleCheckboxes(cbname, name.Name, true);
            }
            else
            {
                toggleCheckboxes(cbname, name.Name, false);
            }
        }
        private void cbEmcEut_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbEmcEut, "cbEmcEut");
        }
        private void cbEnviromental_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbEnviromental, "cbEnviromental");
        }
        private void cbReliability_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbReliability, "cbReliability");
        }
        private void cbProductSafety_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbProductSafety, "cbProductSafety");
        }
        private void cbPackaging_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbPackaging, "cbPackaging");
        }
        private void cbGreenCompilance_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbGreenCompilance, "cbGreenCompilance");
        }        
    }
}

