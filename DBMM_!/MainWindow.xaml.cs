using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DBMM_1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void summaryButton_Click(object sender, RoutedEventArgs e)
        {

           
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //check to ensure that the customer name and phone number text boxes are not empty before saving the data
            if (customerNameTextBox.Text == "" || phoneTextBox.Text == "")
            {
                summaryTextBlock.Text = "Please fill in all required fields.";
                return;
            }
            //disable the customer name and phone number text boxes after saving the data
            customerNameTextBox.IsEnabled = false;

            phoneTextBox.IsEnabled = false;
            //focus the vehicle price text box after saving the data
            vehiclePriceTextBox.Focus(FocusState.Programmatic);
            //visual display to indicate that the customer name and phone number have been saved
            summaryTextBlock.Text = "Saved name and number";


        }

        private void resetButton_Click(object sender, RoutedEventArgs e)

        {

            phoneTextBox.Text = "";

            customerNameTextBox.Text = "";

            vehiclePriceTextBox.Text = "";

            tradeInTextBox.Text = "";

            subAmountTextBox.Text = "";

            gstAmountTextBox.Text = "";

            finalAmountTextBox.Text = "";

            phoneTextBox.IsEnabled = true;

            customerNameTextBox.IsEnabled = true;

            customerNameTextBox.Focus(FocusState.Programmatic);


        }

    }
}
