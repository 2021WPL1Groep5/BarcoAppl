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
        public MainWindow()
        {
            InitializeComponent();
            //Mathias
            //Koen
            //Nikki
            //Mohamed
            //Robbe
            
        }

        private void Checkbox_Yes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox_No_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cmbDivision_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbJobNature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void txtNetWeight1_TextChanged(object sender, TextChangedEventArgs e)
        {

         if (System.Text.RegularExpressions.Regex.IsMatch(txtNetWeight1.Text, "[^0-9]" + "." + "[^0-9]"))
         {
          MessageBox.Show("Please enter only numbers.");
          txtNetWeight1.Text = txtNetWeight1.Text.Remove(txtNetWeight1.Text.Length - 1);
         }

        }
    }
}
