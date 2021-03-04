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

        private void Request()
        {
            RqRequest request = new RqRequest();
            request.Requester = txtRequesterInitials.Text;
            request.BarcoDivision = cmbDivision.Text;
            request.JobNature = cmbJobNature.Text;
            request.EutProjectname = txtProjectName.Text;
            request.EutPartnumbers = txtEutPartnumber1.Text;
            request.ExpectedEnddate = new DateTime();
            request.InternRequest = false;
            request.GrossWeight = Convert.ToInt16(txtGrossWeight1.Text);
            request.NetWeight = Convert.ToInt16(txtNetWeight1.Text);

            if (Checkbox_Yes.IsChecked == true)
            {
                request.Battery = true;
            }

            context.Add(request);
            context.SaveChanges();            
        }

        private void btnSendJob_Click(object sender, RoutedEventArgs e)
        {
            Request();
        }
    }
}
