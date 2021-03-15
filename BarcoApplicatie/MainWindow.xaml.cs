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
        private ErrorHandling errorHandling = new ErrorHandling();
        HomeScreen HomeScreen = new HomeScreen();


        public MainWindow()
        {
            InitializeComponent();
            dao = DAO.Instance();

            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;
        }
        ///////////////////////////////////////////Checkbox YesorNo///////////////////////////////////////////
        public void yesOrNo()
        {
            if (Checkbox_No.IsChecked == true)
            {
                Checkbox_Yes.IsChecked = false;
            }

            else if (Checkbox_Yes.IsChecked == true)
            {
                Checkbox_No.IsChecked = false;
            }
        }

        private void Checkbox_No_Click(object sender, RoutedEventArgs e)
        {
            yesOrNo();
        }

        private void Checkbox_Yes_Click(object sender, RoutedEventArgs e)
        {
            yesOrNo();
        }

        ///////////////////////////////////////////functionNoEmptyData///////////////////////////////////////////

        public void checkFilled()
        {
            if (txtRequesterInitials.Text.Length > 0 && 
                cmbDivision.SelectedIndex > -1 && 
                cmbJobNature.SelectedIndex > -1 && 
                txtProjectNumber.Text.Length > 0 && 
                txtProjectName.Text.Length > 0 && 
                txtEutPartnumber1.Text.Length > 0 && 
                txtNetWeight1.Text.Length > 0 && 
                txtGrossWeight1.Text.Length > 0 && 
                ExpectedEndDate.Text.Length > 0 && 
                txtLinkToTestplan.Text.Length > 0)
            {

            }
            else
            {
                MessageBox.Show("Fill in all fields please.");
            }
        }

        ///////////////////////////////////////////loadDataIntoGUI///////////////////////////////////////////
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
        ///////////////////////////////////////////buttonSendToDB///////////////////////////////////////////
        //Koen
        private void openViewJobRequestScreen()
        {
            ViewJobrequest viewJR = new ViewJobrequest();
            viewJR.Show();
        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {

            checkFilled();

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
               Checkbox_Yes, DateEut1.SelectedDate, cbEmcEut1, txtLinkToTestplan.Text, txtSpecialRemarks.Text);

            openViewJobRequestScreen();
            

        }
        ///////////////////////////////////////////logoHomeScreen///////////////////////////////////////////
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen.Show();
        }

        ///////////////////////////////////////////boolCheckbox///////////////////////////////////////////
        public class Utils
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
        public void boolCheckboxes(string checkboxName, string exceptions ,bool toggle)
        {
            foreach (CheckBox checkBox in Utils.FindVisualChildren<CheckBox>(this))
            {
                if( checkBox.Name.Contains(checkboxName)) {
                    if (!exceptions.Contains(checkBox.Name))
                    {
                        checkBox.IsEnabled = toggle;
                        if (checkBox.IsEnabled == false)
                        {
                            checkBox.IsChecked = false;
                        }
                    }
                }
            }
        }
        public void toggle_click(CheckBox name, string cbname)
        {
            if (name.IsChecked == true)
            {
                boolCheckboxes(cbname, name.Name, true);
            }
            else
            {
                boolCheckboxes(cbname, name.Name, false);
            }
        }
        
        //Nature of tests to perform
        private void cbEmcEut_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbEmcEut, "cbEmcEut");
            dateColumEmpty();
        }
        private void cbEnviromental_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbEnviromental, "cbEnviromental");
            dateColumEmpty();
        }
        private void cbReliability_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbReliability, "cbReliability");
            dateColumEmpty();
        }
        private void cbProductSafety_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbProductSafety, "cbProductSafety");
            dateColumEmpty();
        }
        private void cbPackaging_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbPackaging, "cbPackaging");
            dateColumEmpty();
        }
        private void cbGreenCompilance_Click(object sender, RoutedEventArgs e)
        {
            toggle_click(cbGreenCompilance, "cbGreenCompilance");
            dateColumEmpty();
        }

        //Checks every colum if there empty
        private void dateColumEmpty()
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        //EUT1 checkbox
        private void cbEmcEut1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbEnviromental1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbReliability1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbProductSafety1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbPackaging1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbGreenCompilance1_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        //EUT2 checkbox
        private void cbEmcEut2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbEnviromental2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbReliability2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbProductSafety2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbPackaging2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbGreenCompilance2_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        //EUT3 checkbox
        private void cbEmcEut3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbEnviromental3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbReliability3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbProductSafety3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbPackaging3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbGreenCompilance3_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        //EUT4 checkbox
        private void cbEmcEut4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbEnviromental4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbReliability4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbProductSafety4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbPackaging4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbGreenCompilance4_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        //EUT5 checkbox
        private void cbEmcEut5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbEnviromental5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbReliability5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbProductSafety5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbPackaging5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbGreenCompilance5_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        //EUT6 checkbox
        private void cbEmcEut6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbEnviromental6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbReliability6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbProductSafety6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbPackaging6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbGreenCompilance6_Click(object sender, RoutedEventArgs e)
        {
            errorHandling.dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }

        ///////////////////////////////////////////errorHandling///////////////////////////////////////////

        // elk tekstvak de input met de functie controleren en aanpassen
        private void txtRequesterInitials_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^A-Z-a-z]", txtRequesterInitials, initialsErrorLabel, "Please enter letters only.");
            txtRequesterInitials.Text.ToUpper();
        }
        
        //deze functie toepassen op de verschillende inputvelden
        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^A-Z-a-z-0-9]", txtProjectNumber , projectNumberErrorLabel, "Please enter numbers and letters only.");
        }
        
        private void txtEutPartnumber1_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtEutPartnumber1, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber2_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtEutPartnumber2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber3_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtEutPartnumber3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber4_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtEutPartnumber4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtEutPartnumber5_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtEutPartnumber5, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtNetWeight1, numbersErrorLabel, "Please enter numbers only."); 
        }

        private void txtNetWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtNetWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtNetWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtNetWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtNetWeight5, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtGrossWeight1, numbersErrorLabel, "Please enter numbers only.");        
        }

        private void txtGrossWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtGrossWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtGrossWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtGrossWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            errorHandling.ControlInput("[^0-9]", txtGrossWeight5, numbersErrorLabel, "Please enter numbers only.");
        }

    }
}

