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

        public MainWindow()
        {
            InitializeComponent();
            dao = DAO.Instance();

            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

        }
        ///////////////////////////////////////////loadDataIntoGUI///////////////////////////////////////////
        private void insertDivisionIntoComboBox()
        {
            List<RqBarcoDivision> divisions = dao.getAllDivisions();

            foreach (RqBarcoDivision division in divisions)
            {
                cmbDivision.Items.Add(division.Afkorting);
            }
        }

        private void insertJobNatureIntoComboBox()
        {
            List<RqJobNature> jobNatures = dao.getAllJobNatures();

            foreach (RqJobNature jobNature in jobNatures)
            {
                cmbJobNature.Items.Add(jobNature.Nature);
            }
        }

        ///////////////////////////////////////////buttonSendToDB///////////////////////////////////////////
        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            if (cbEmcEut.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, cbEmcEut1);

                dao.addTestDivision("EMC");
            }
            if (cbEnviromental.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, cbEnviromental1);


                dao.addTestDivision("ENV");
            }
            if (cbReliability.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, cbReliability1);

                dao.addTestDivision("REL");
            }
            if (cbProductSafety.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, cbProductSafety1);

                dao.addTestDivision("SAF");
            }
            if (cbGreenCompilance.IsChecked == true)
            {
                dao.addEUT(DateEut1.SelectedDate, cbGreenCompilance1);

                dao.addTestDivision("ECO");
            }

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
        ///////////////////////////////////////////logoHomeScreen///////////////////////////////////////////

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            dao.addingOptionalInput(txtLinkToTestplan.Text, txtSpecialRemarks.Text);
        }

        ///////////////////////////////////////////boolCheckbox///////////////////////////////////////////
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
        //Check if checkbox is empty for datePicker
        private void dateEmpty(DatePicker DateEut, CheckBox cbEmcEut, CheckBox cbEnviromental, CheckBox cbReliability, CheckBox cbProductSafety, CheckBox cbPackaging, CheckBox cbGreenCompilance)
        {
            if (cbEmcEut.IsChecked == false && cbEnviromental.IsChecked == false && cbReliability.IsChecked == false && cbProductSafety.IsChecked == false && cbPackaging.IsChecked == false && cbGreenCompilance.IsChecked == false)
            {
                DateEut.IsEnabled = false;
            }
            else
            {
                DateEut.IsEnabled = true;
            }
        }
        //EUT1 checkbox
        private void cbEmcEut1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbEnviromental1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbReliability1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbProductSafety1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbPackaging1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        private void cbGreenCompilance1_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut1, cbEmcEut1, cbEnviromental1, cbReliability1, cbProductSafety1, cbPackaging1, cbGreenCompilance1);
        }
        //EUT2 checkbox
        private void cbEmcEut2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbEnviromental2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbReliability2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbProductSafety2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbPackaging2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        private void cbGreenCompilance2_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut2, cbEmcEut2, cbEnviromental2, cbReliability2, cbProductSafety2, cbPackaging2, cbGreenCompilance2);
        }
        //EUT3 checkbox
        private void cbEmcEut3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbEnviromental3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbReliability3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbProductSafety3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbPackaging3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        private void cbGreenCompilance3_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut3, cbEmcEut3, cbEnviromental3, cbReliability3, cbProductSafety3, cbPackaging3, cbGreenCompilance3);
        }
        //EUT4 checkbox
        private void cbEmcEut4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbEnviromental4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbReliability4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbProductSafety4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbPackaging4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        private void cbGreenCompilance4_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut4, cbEmcEut4, cbEnviromental4, cbReliability4, cbProductSafety4, cbPackaging4, cbGreenCompilance4);
        }
        //EUT5 checkbox
        private void cbEmcEut5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbEnviromental5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbReliability5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbProductSafety5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbPackaging5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        private void cbGreenCompilance5_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut5, cbEmcEut5, cbEnviromental5, cbReliability5, cbProductSafety5, cbPackaging5, cbGreenCompilance5);
        }
        //EUT6 checkbox
        private void cbEmcEut6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbEnviromental6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbReliability6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbProductSafety6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbPackaging6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }
        private void cbGreenCompilance6_Click(object sender, RoutedEventArgs e)
        {
            dateEmpty(DateEut6, cbEmcEut6, cbEnviromental6, cbReliability6, cbProductSafety6, cbPackaging6, cbGreenCompilance6);
        }

        ///////////////////////////////////////////errorHandling///////////////////////////////////////////
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
            ControlInput("[^A-Z-a-z]", txtRequesterInitials, initialsErrorLabel, "Please enter letters only.");
            txtRequesterInitials.Text.ToUpper();
        }
        
        //deze functie toepassen op de verschillende inputvelden
        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^A-Z-a-z-0-9]", txtProjectNumber , projectNumberErrorLabel, "Please enter numbers and letters only.");
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
            ControlInput("[^0-9]", txtNetWeight1, numbersErrorLabel, "Please enter numbers only."); 
        }

        private void txtNetWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtNetWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtNetWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtNetWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtNetWeight5, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtGrossWeight1, numbersErrorLabel, "Please enter numbers only.");        
        }

        private void txtGrossWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtGrossWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtGrossWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtGrossWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9]", txtGrossWeight5, numbersErrorLabel, "Please enter numbers only.");
        }
    }
}

