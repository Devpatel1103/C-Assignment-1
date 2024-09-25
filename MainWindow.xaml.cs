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
            //messagesTextBox = string.Empty;

            messagesTextBox.Focus();

        }

        /// <summary>
        /// This button is insert input from user to text box as data of that day
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {

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
    }
}