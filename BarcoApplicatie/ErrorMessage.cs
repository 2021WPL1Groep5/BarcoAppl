using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace BarcoApplicatie
{
     class ErrorMessage: Window
    {
        public string txtRequesterInitials { get; set; }
        public string txtProjectNumber { get; set; }
        public string txtEutPartnumber { get; set; }
        public string txtNetWeight { get; set; }
        public string txtGrossWeight { get; set; }

        public void RequesterInitials(string txtrequesterinitials)
        {
            txtRequesterInitials = txtrequesterinitials.ToUpper(); 
        }

        public void EutPartnumber(string txteutpartnr)
        {
            txtEutPartnumber = txteutpartnr;
            if (System.Text.RegularExpressions.Regex.IsMatch(txteutpartnr, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txteutpartnr = txteutpartnr.Remove(txteutpartnr.Length - 1);
            }
        }

        public void NummerProject(string txtprojectnr)
        {
            txtProjectNumber = txtprojectnr ;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtprojectnr, "[^0-9-E-.]"))
            {
                MessageBox.Show("Please enter only numbers or a E.");
                txtprojectnr = txtprojectnr.Remove(txtprojectnr.Length - 1);
            }
        }

        public void netWeight(string txtnetweight)
        {
            txtNetWeight = txtnetweight;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtnetweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtnetweight = txtnetweight.Remove(txtnetweight.Length - 1);
            }
        }

        public void grossWeight(string txtgrossweight)
        {
            txtGrossWeight = txtgrossweight;
            if (System.Text.RegularExpressions.Regex.IsMatch(txtgrossweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtgrossweight = txtgrossweight.Remove(txtgrossweight.Length - 1);
            }
        }

    }
}
