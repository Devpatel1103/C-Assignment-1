//Name: Patel Dev(100934719) 
//Assignment: Assignment 1 
//Date created: 23 september 2024
// Date last modified: 28 september 2024 
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
    /// This is mainWindow class
    /// </summary>
    public partial class MainWindow : Window

    {
        // define variable to store value
        int dayCounter = 0;
        int messageStore = 0;

        /// <summary>
        /// initialize MainWindow here
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            //  Acess key for button
            // this access key i took help of ChatGpt to understand the way to write acess key in c# here, because in pyhton we have direct properties for AccessKey.
            enterBtn.Content = new AccessText { Text = "_Enter" };
            resetBtn.Content = new AccessText { Text = "_Reset" };
            exitBtn.Content = new AccessText { Text = "E_xit" };
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

            // reset the day counter and messages store so it can store value again
            dayCounter = 0;
            messageStore = 0;
            
            // after reset values i enabled both properties
            enterBtn.IsEnabled = true;
            messagesTextBox.IsEnabled = true;

            // after reset values focus to messageTextBox
            messagesTextBox.Focus();

        }

        /// <summary>
        /// This button is insert input from user to text box as messages of that day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterBtn_Click(object sender, RoutedEventArgs e)

        {
            // deine constants 
            const int minValue = 0;
            const int maxValue = 10000;
            const int maxNumberOfDays = 7;


            // deine variable and assign valuw of message TextBox
            string userInput = messagesTextBox.Text;

            // exception handling to save from crash
            try
            {
                // check condition for input
                if (isInputNotBlank(userInput))
                {
                    // check condition of input is int
                    if (isValidInteger(userInput))
                    {
                        int userInputInteger =  int.Parse(userInput);

                        // checkc condition for input is in range
                        if (isValidRange(minValue, maxValue, userInputInteger))
                        {
                            // if user enter valid value then display in newLine
                            if (hasTxtBoxAnyValues(displayMessagesTextBox))
                            {
                                displayMessagesTextBox.Text += Environment.NewLine + userInputInteger.ToString();
                            }

                            else
                            {
                                displayMessagesTextBox.Text = userInputInteger.ToString();
                            }

                            // check condition if the days are in range.
                            if (!isCrossMaxDays(maxNumberOfDays, dayCounter))
                            {
                                dayCounter += 1;
                                messageStore += userInputInteger;
                                dayLbl.Content = "Day " + (dayCounter + 1).ToString();
                            }
                            else
                            {
                                // if input values of days out of 1 week so disble textbox
                                enterBtn.IsEnabled = false;
                                messagesTextBox.IsEnabled = false;
                                double countResult = averageGradeds(maxNumberOfDays, messageStore);
                                dailyAverageMessagesTextBox.Text = countResult.ToString();
                                resetBtn.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Input Should be in Range of 0 to 10000");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Input must be Integer");

                    }
                }
                else
                {
                    MessageBox.Show("Input should not be null ");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("There is error ocuured please try Again");
            }

            finally {
                messagesTextBox.Text = string.Empty;
                messagesTextBox.Focus();
            }
            
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
        /// This function to check the input is null or empty
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
        private bool isValidInteger(string input)
        {

            if (int.TryParse(input, out int result)) { return true; }
            return false;
        }

        /// <summary>
        /// check the value is in valide range
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool isValidRange(int minValue, int maxValue, int input) {

            if (input >= minValue && input <= maxValue) {

                return true; }

            return false;
        
        
        }

        /// <summary>
        /// This function returns true if textbox values is not empty
        /// </summary>
        /// <param name="displayMessagesTextBox"> this tetxbox display perday messages</param>
        /// <returns></returns>
        private bool hasTxtBoxAnyValues(TextBox displayMessagesTextBox)
        {
            if (!string.IsNullOrEmpty(displayMessagesTextBox.Text)) {

                return true;
            }

            return false;

        }

        /// <summary>
        /// Check the Days limit
        /// </summary>
        /// <param name="maxNumberOfDays"></param>
        /// <param name="dayNumber"></param>
        /// <returns></returns>
        private bool isCrossMaxDays(int maxNumberOfDays, int dayNumber) {

            if (dayNumber + 1 >= maxNumberOfDays) { 
                return true;
            }

            return false ;
        }


        /// <summary>
        /// to calcultae average messages
        /// </summary>
        /// <param name="numberOfDays"> value of total week days</param>
        /// <param name="messageStore"> message store as value</param>
        /// <returns></returns>
        private int averageGradeds(int numberOfDays, int messageStore) {


            int averages = messageStore / numberOfDays;

            return averages;
                
        }
    }

}
