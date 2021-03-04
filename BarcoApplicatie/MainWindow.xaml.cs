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

        private void txtRequesterInitials_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRequesterInitials.Text.All(chr => char.IsLetter(chr)));

            Console.WriteLine(txtRequesterInitials.Text.ToUpper()); 
        }

        private void txtProjectName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtProjectName.Text.All(chr => char.IsLetter(chr)));
        }

        private void txtLinkToTestplan_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtLinkToTestplan.Text = string.Concat(txtLinkToTestplan.Text.Where(char.IsLetterOrDigit));
        }
    }
}
