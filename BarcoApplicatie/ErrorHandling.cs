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

        public static class Utils
        {
           
        }
            public void EutPartnumber(string txteutpartnr)
            {
                txtEutPartnumber1 = txteutpartnr;
                if (System.Text.RegularExpressions.Regex.IsMatch(txteutpartnr, "[^0-9-A-Z-.]"))
                {
                    throw new NotImplementedException();
                }
            }
        //public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T)
        //            {
        //                yield return (T)child;
        //            }
        //        }

        //        foreach (T childOfChild in FindVisualChildren<T>(child))
        //        {
        //            yield return childOfChild;
        //        }
        //    }
        //}


        //internal static IEnumerable<T> FindVisualChildren<T>(ErrorHandling errorHandling)
        //{
        //    public void RequesterInitials(string txtrequesterinitials)
        //    {
        //        txtRequesterInitials = txtrequesterinitials.ToUpper();
        //        if (System.Text.RegularExpressions.Regex.IsMatch(txtrequesterinitials, "[^A-Z]"))
        //        {
        //            MessageBox.Show("Please enter only letters.");
        //            //txtrequesterinitials = txtrequesterinitials.Remove(txtrequesterinitials.Length - 1);
        //        }
        //    }
        //}

        //toggleCheckbox
        //public void toggleCheckboxes(string checkboxName, string exceptions, bool toggle)
        //{
        //    foreach (CheckBox checkBox in Utils.FindVisualChildren<CheckBox>(this))
        //    {
        //        if (checkBox.Name.Contains(checkboxName))
        //        {
        //            if (!exceptions.Contains(checkBox.Name))
        //            {
        //                checkBox.IsEnabled = toggle;
        //            }
        //        }
        //    }
        //}

        //public void toggle_click(CheckBox name, string cbname)
        //{
        //    if (name.IsChecked == true)
        //    {
        //        toggleCheckboxes(cbname, name.Name, true);
        //    }
        //    else
        //    {
        //        toggleCheckboxes(cbname, name.Name, false);
        //    }
        //}
    }
}