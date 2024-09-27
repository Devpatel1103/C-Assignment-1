//Name: Patel Dev(100934719) 
//Assignment: Assignment 1 
//Date created: 23 september 2024
// Date last modified:  september 2024 
// Description: This program will store messages of all day of week -->

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {

        int dayCounter = 0;
        double totalDays = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is used for reset all values to default
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetBtn_Click(object sender, RoutedEventArgs e)

        {

            // Reset all values to Zero
            messagesTextBox.Text = string.Empty;
            dayLbl.Content = "Day 1";
            displayMessagesTextBox.Text = string.Empty;

            dailyAverageMessagesTextBox.Text = string.Empty;



            messagesTextBox.Focus();

        }

        /// <summary>
        /// This button is insert input from user to text box as data of that day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterBtn_Click(object sender, RoutedEventArgs e)

        {
            const int minValue = 0;
            const int maxValue = 10000;
            const int maxNumberOfDays = 7;


            //
            string userInput = messagesTextBox.Text;

            //check blkanks 
            if (isInputNotBlank(userInput)) 
            {

                if (isValidDouble(userInput)) {
                    double userInputDouble = Convert.ToDouble(userInput);


                    if (isValidRange(minValue, maxValue, userInputDouble)) {

                        if (hasTxtBoxAnyValues(displayMessagesTextBox)) {
                            displayMessagesTextBox.Text += Environment.NewLine + userInputDouble.ToString();
                            
                        }
                        
                        else {

                            displayMessagesTextBox.Text = userInputDouble.ToString();
                        }

                        if (!isCrossMaxDays(maxNumberOfDays, dayCounter))
                        {
                            dayCounter += 1;
                            totalDays += userInputDouble;
                            dayLbl.Content = "Day " + (dayCounter + 1).ToString();
                        }
                        else { 
                        
                            enterBtn.IsEnabled = false;
                            double countResult = averageGradeds(maxNumberOfDays, totalDays);
                            dailyAverageMessagesTextBox.Text = countResult.ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("INPUT IS NOT WITHING RANGE");
                    }
                }
                else
                {
                    MessageBox.Show("Input must be double");

                }
            }
            else
            {
                MessageBox.Show("input should not be null ");
            }

            messagesTextBox.Text = string.Empty;
            messagesTextBox.Focus();
        }

        
        /// <summary>
        /// This will exit the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        /// <summary>
        /// This function will
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool isInputNotBlank(string input) { 
        
            if (string.IsNullOrEmpty(input)) { return false ; }

            return true;
        }

        /// <summary>
        /// This function
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool isValidDouble(string input)
        {

            if (double.TryParse(input, out double result)) { return true; }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool isValidRange(int minValue, int maxValue, double input) {

            if (input >= minValue && input <= maxValue) {

                return true; }

            return false;
        
        
        }

        private bool hasTxtBoxAnyValues(TextBox displayMessagesTextBox)
        {
            if (!string.IsNullOrEmpty(displayMessagesTextBox.Text)) {

                return true;
            }

            return false;

        }

        private bool isCrossMaxDays(int maxNumberOfDays, int dayNumber) {

            if (dayNumber + 1 >= maxNumberOfDays) { 
                return true;
            }

            return false ;
        }


        private double averageGradeds(int numberOfDays, double totalDays) { 
        
            return totalDays / numberOfDays;
        }
    }

}