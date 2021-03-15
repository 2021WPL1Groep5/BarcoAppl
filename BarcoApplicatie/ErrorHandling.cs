using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BarcoApplicatie
{
    class ErrorHandling
    {
        public string txtRequesterInitials { get; set; }
        public string txtProjectNumber { get; set; }
        public string txtEutPartnumber1 { get; set; }
        public string txtNetWeight1 { get; set; }
        public string txtGrossWeight1 { get; set; }

            //public void EutPartnumber(string txteutpartnr)
            //{
            //    txtEutPartnumber1 = txteutpartnr;
            //    if (System.Text.RegularExpressions.Regex.IsMatch(txteutpartnr, "[^0-9-A-Z-.]"))
            //    {
            //        throw new NotImplementedException();
            //    }
            //}
        public void ControlInput(string canBe, TextBox box, Label label, string content)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(box.Text, canBe))
            {
                label.Content = content;
                box.Text = box.Text.Remove(box.Text.Length - 1);
            }
        }

        //Check if checkbox is empty for datePicker
        public void dateEmpty(DatePicker DateEut, CheckBox cbEmcEut, CheckBox cbEnviromental, CheckBox cbReliability, CheckBox cbProductSafety, CheckBox cbPackaging, CheckBox cbGreenCompilance)
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
    }
}