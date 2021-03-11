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

    public static class Utils {
        /// <summary>
        /// Form: http://stackoverflow.com/questions/974598/find-all-controls-in-wpf-window-by-type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="depObj"></param>
        /// <returns></returns>
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

        public MainWindow()
        {
            InitializeComponent();
            dao = DAO.Instance();

            insertDivisionIntoComboBox();
            insertJobNatureIntoComboBox();

            BitmapImage bitmapImage = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../../Images/barcoLogo.png"));
            capturedPhoto.Source = bitmapImage;

            isEnabled();
            //isEnabled1(cbGreenCompilance);
            //isDisabled(cbGreenCompilance);
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
            ViewJobrequest ViewJobrequest = new ViewJobrequest();
            ViewJobrequest.Show();

            dao.Request(txtRequesterInitials1.Text, cmbDivision.Text, cmbJobNature.Text,
                txtProjectName1.Text, txtEutPartnumber6.Text, ExpectedEndDate.SelectedDate,
                txtGrossWeight6.Text, txtNetWeight6.Text, Checkbox_Yes);
        }


        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen HomeScreen = new HomeScreen();
            HomeScreen.Show();
            dao.addingOptionalInput(txtLinkToTestplan1.Text, txtSpecialRemarks1.Text);
        }

        //fixed in gui
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
           // this.toggleCheckboxes("cbEmcEut", false);
          /*  if (cbEmcEut.IsChecked == false)
            {
                cbEmcEut1.IsEnabled = false;
                cbEmcEut2.IsEnabled = false;
                cbEmcEut3.IsEnabled = false;
                cbEmcEut4.IsEnabled = false;
                cbEmcEut5.IsEnabled = false;
                cbEmcEut6.IsEnabled = false;
            }*/
        }

        public void isEnabled1(CheckBox name)
        {
            if (name.IsChecked == true)
            {
                int iNumber = 0;
                for (int i = 0; i < 6; i++)
                {
                    iNumber++;
                    string constantName = name.Name;
                    string sName = name.Name;
                    sName += Convert.ToString(iNumber);

                    name.Name = sName;
                    name.IsEnabled = true;
                    name.Name = constantName;
                }

            }
        }
        public void isDisabled(CheckBox checkBox)
        {
            this.toggleCheckboxes("cbGreen","", false);
           /* if (name.IsChecked == false)
            {
                int iNumber = 0;
                for (int i = 0; i < 6; i++)
                {
                    iNumber++;
                    string constantName = name.Name;
                    string sName = name.Name;
                    sName += Convert.ToString(iNumber);

                    name.Name = sName;
                    name.IsEnabled = false;
                    name.Name = constantName;
                }

            }*/
        }

        private void cbGreenCompilance_Checked(object sender, RoutedEventArgs e)
        {
            //isEnabled1(cbGreenCompilance);
        }

        private void cbGreenCompilance_Unchecked(object sender, RoutedEventArgs e)
        {
            toggleCheckboxes("cbGreenCompilance", ((CheckBox)sender).Name, false);
        }

        private void toggleCheckboxes(string checkboxNamePart, string exceptions ,bool toggle)
        {
            foreach (CheckBox checkBox in Utils.FindVisualChildren<CheckBox>(this))
            {
                if( checkBox.Name.Contains(checkboxNamePart)) {
                    if (!exceptions.Contains(checkBox.Name))
                    {
                        checkBox.IsChecked = toggle;
                        checkBox.IsEnabled = toggle;
                    }
                }

            }
        }
    }
}

