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
        public static class Utils
        {
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

            internal static IEnumerable<T> FindVisualChildren<T>(ErrorHandling errorHandling)
            {
                throw new NotImplementedException();
            }
        }

        //toggleCheckbox
        public void toggleCheckboxes(string checkboxName, string exceptions, bool toggle)
        {
            foreach (CheckBox checkBox in Utils.FindVisualChildren<CheckBox>(this))
            {
                if (checkBox.Name.Contains(checkboxName))
                {
                    if (!exceptions.Contains(checkBox.Name))
                    {
                        checkBox.IsEnabled = toggle;
                    }
                }
            }
        }

        public void toggle_click(CheckBox name, string cbname)
        {
            if (name.IsChecked == true)
            {
                toggleCheckboxes(cbname, name.Name, true);
            }
            else
            {
                toggleCheckboxes(cbname, name.Name, false);
            }
        }
    }
}