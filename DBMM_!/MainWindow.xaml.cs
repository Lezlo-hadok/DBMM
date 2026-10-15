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

            const decimal GST_RATE = 0.1m;

            decimal subAmount;

            decimal gstAmount;

            decimal finalAmount;



            subAmount = decimal.Parse(vehiclePriceTextBox.Text) - decimal.Parse(tradeInTextBox.Text);

            subAmountTextBox.Text = subAmount.ToString("C");



            gstAmount = subAmount * GST_RATE;

            gstAmountTextBox.Text = gstAmount.ToString("C");



            finalAmount = subAmount + gstAmount;

            finalAmountTextBox.Text = finalAmount.ToString("C");



            summaryTextBlock.Text = "Summary data displayed here";

        }
        private void saveButton_Click(object sender, RoutedEventArgs e)

        {

            phoneTextBox.IsEnabled = false;

            customerNameTextBox.IsEnabled = false;

            vehiclePriceTextBox.Focus(FocusState.Programmatic);

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
