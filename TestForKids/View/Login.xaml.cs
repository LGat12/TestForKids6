using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestForKids.Model;
using TestForKids.ViewModel;

namespace TestForKids.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private SharedViewModel _sharedViewModel;
        // private UserViewModel _userViewModel;
        public Login(SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;
        }
       

        private void UsrTxtBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text when the TextBox gets focus
            UsrTxtBox.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the entered email and password 
                string enteredEmail = UsrTxtBox.Text;
                string enteredPassword = PwdBox.Password;

                // Search for a match in the list
                User matchedUser = null;
               // if (_sharedViewModel != null && _sharedViewModel.UsersList != null)
                //{
                    foreach (User user in _sharedViewModel.UsersList)
                    {
                        if (user.Email == enteredEmail && user.Password == enteredPassword)
                        {
                            matchedUser = user;
                            break; // Found a match, exit the loop
                        }
                    }
                //}

                // Check if a match was found and load the main page
                if (matchedUser != null)
                {
                    // show the main page
                    EnterGame game = new EnterGame(_sharedViewModel, matchedUser.FirstName, matchedUser.LastName);

                    NavigationService.Navigate(game);
                    MainPage mainPage = new MainPage(_sharedViewModel);

                }
                else
                {
                    // No match found, display an error message
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
