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
            //check to ensure that the vehicle price and trade-in text boxes are not empty before calculating the summary
            if (tradeInTextBox.Text == "")
            {
                tradeInTextBox.Text = "0";
            }
            try
            {
                //check to ensure that the vehicle price and trade-in text boxes contain valid numbers before calculating the summary
                double vehiclePrice = Convert.ToDouble(vehiclePriceTextBox.Text);
                double tradeIn = Convert.ToDouble(tradeInTextBox.Text);
                //check to ensure that the vehicle price is greater than the trade-in price before calculating the summary
                if (tradeIn > vehiclePrice)
                {
                    summaryTextBlock.Text = "Please ensure that Vehicle Price is Greater than the Trade in price";
                    return;
                }

            }
            catch (FormatException)
            {
                summaryTextBlock.Text = $"Please enter valid numbers for vehicle price and trade-in. \n Trade in Value cannot be more then the price of the vehicle";

            }
            
            try
            {
                //revalidate the vehicle price and trade-in text boxes to ensure they contain valid numbers before calculating the summary
                double vehiclePrice = Convert.ToDouble(vehiclePriceTextBox.Text);
                double tradeIn = Convert.ToDouble(tradeInTextBox.Text);
                //calculate the subtotal, GST, and final amount
                double subAmount = vehiclePrice - tradeIn;
                double gstAmount = subAmount * 0.15;
                double finalAmount = subAmount + gstAmount;
                //display the calculated values in the respective text boxes
                subAmountTextBox.Text = subAmount.ToString("C");
                gstAmountTextBox.Text = gstAmount.ToString("C");
                finalAmountTextBox.Text = finalAmount.ToString("C");
                //display the summary in the summary text block
                summaryTextBlock.Text = $"Customer Name: {customerNameTextBox.Text}\nPhone Number: {phoneTextBox.Text}\nVehicle Price: {vehiclePrice.ToString("C")}\nTrade-In: {tradeIn.ToString("C")}\nSubtotal: {subAmount.ToString("C")}\nGST: {gstAmount.ToString("C")}\nFinal Amount: {finalAmount.ToString("C")}";

            }
            catch (FormatException)
            {
                summaryTextBlock.Text = "Please enter valid numbers for vehicle price and trade-in.";
            }
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //check to ensure that the customer name and phone number text boxes are not empty before saving the data
            if (customerNameTextBox.Text == "" || phoneTextBox.Text == "")
            {
                summaryTextBlock.Text = $"Please fill in all required fields. \n   Customer name: \n   Phone Number:";
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
