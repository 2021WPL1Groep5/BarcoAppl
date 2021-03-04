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

        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            addInitialsToDataBase(txtRequesterInitials.Text);
            addJobNatureToDatabase(cmbJobNature.Text);
        }

        private static void addInitialsToDataBase(string initialen)
        {
            Person person = new Person { Afkorting = initialen };
            context.Add(person);
            context.SaveChanges();
        }

        private static void addJobNatureToDatabase(string comboBoxItem)
        {
            RqJobNature jobNature = new RqJobNature { Nature = comboBoxItem };
            context.Add(jobNature);
            context.SaveChanges();
        }

    }
}
