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

        ///////////////////////////////////////////toggleCheckbox///////////////////////////////////////////
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
            //dateEmpty();
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

        private void dateEmpty(DatePicker DateEut, CheckBox cbEmcEut, CheckBox cbEnviromental, CheckBox cbReliability, CheckBox cbProductSafety, CheckBox cbPackaging, CheckBox cbGreenCompilance)
        {
            if (cbEmcEut.IsChecked == false && cbEnviromental.IsChecked == false && cbReliability.IsChecked == false && cbProductSafety.IsChecked == false && cbPackaging.IsChecked == false && cbGreenCompilance.IsChecked == false)
            {
                DateEut.IsEnabled = false;
            }
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
            txtRequesterInitials.CharacterCasing = CharacterCasing.Upper;
        }

        //deze functie toepassen op de verschillende inputvelden
        private void txtProjectNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^A-Z-a-z-0-9-,]", txtProjectNumber , projectNumberErrorLabel, "Please enter numbers and letters only.");
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
            ControlInput("[^0-9-,]", txtNetWeight1, numbersErrorLabel, "Please enter numbers only."); 
        }

        private void txtNetWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtNetWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtNetWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtNetWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtNetWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtNetWeight5, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtGrossWeight1, numbersErrorLabel, "Please enter numbers only.");        
        }

        private void txtGrossWeight2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtGrossWeight2, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight3_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtGrossWeight3, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight4_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtGrossWeight4, numbersErrorLabel, "Please enter numbers only.");
        }

        private void txtGrossWeight5_TextChanged(object sender, TextChangedEventArgs e)
        {
            ControlInput("[^0-9-,]", txtGrossWeight5, numbersErrorLabel, "Please enter numbers only.");
        }
    }
}

