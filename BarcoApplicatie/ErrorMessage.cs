using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;


namespace BarcoApplicatie
{
     class ErrorMessage
    {
        public string txtProjectNumber { get; set; }
        public string txtNetWeight { get; set; }
        public string txtGrossWeight { get; set; }

        public NummerProject(string txtprojectnr )
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtprojectnr, "[^0-9-E-.]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtprojectnr = txtprojectnr.Remove(txtprojectnr.Length - 1);
            }
        }

        public netWeight(string txtnetweight)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtnetweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtnetweight = txtnetweight.Remove(txtnetweight.Length - 1);
            }
        }

        public grossWeight(string txtgrossweight)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtgrossweight, "[^0-9-,]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txtgrossweight = txtgrossweight.Remove(txtgrossweight.Length - 1);
            }
        }

    }
}
