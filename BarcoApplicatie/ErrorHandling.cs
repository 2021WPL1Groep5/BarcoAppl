using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace BarcoApplicatie
{
    class ErrorHandling
    {
        public void errorhandling()
        {

        }

        public string txtRequesterInitials { get; set; }
        public string txtProjectNumber { get; set; }
        public string txtEutPartnumber1 { get; set; }
        public string txtNetWeight1 { get; set; }
        public string txtGrossWeight1 { get; set; }
        /*
        public void RequesterInitials(string txtrequesterinitials)
        {
            txtRequesterInitials = txtrequesterinitials.ToUpper();
            if (System.Text.RegularExpressions.Regex.IsMatch(txtrequesterinitials, "[^A-Z]"))
            {
                MessageBox.Show("Please enter only letters.");
                //txtrequesterinitials = txtrequesterinitials.Remove(txtrequesterinitials.Length - 1);
                
            }
        }
        */
        public void EutPartnumber(string txteutpartnr)
        {
            txtEutPartnumber1 = txteutpartnr;
            if (System.Text.RegularExpressions.Regex.IsMatch(txteutpartnr, "[^0-9-A-Z-.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txteutpartnr = txteutpartnr.Remove(txteutpartnr.Length - 1);
            }
        }

        public void NummerProject(string txtprojectnr)
        {
            txtProjectNumber = txtprojectnr;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtprojectnr, "[^0-9-E-.]"))
            {
                MessageBox.Show("Please enter only numbers or E.");
                txtprojectnr = txtprojectnr.Remove(txtprojectnr.Length - 1);
            }
        }

        public void ChangeWeight(string changeweight)
        {
            txtNetWeight1 = changeweight;
            txtGrossWeight1 = changeweight;
            if (System.Text.RegularExpressions.Regex.IsMatch(changeweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                changeweight = changeweight.Remove(changeweight.Length - 1);
            }
        }
    }
}
