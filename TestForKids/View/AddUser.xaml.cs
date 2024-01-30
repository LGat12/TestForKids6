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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private SharedViewModel _sharedViewModel;

        public AddUser(SharedViewModel sharedViewModel)
        {
            InitializeComponent();
            _sharedViewModel = sharedViewModel;

        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get data from textboxes
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
               
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                ComboBoxItem selectedGenderItem = (ComboBoxItem)GenderComboBox.SelectedItem;
                string selectedGender = selectedGenderItem.Content.ToString();

                // Create a new user
                User newUser = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    State = "",
                    Country = "",
                    Email = email,
                    Password = password,
                    Gender = selectedGender,
                    /*
                  
                        private int userId;
                        private string firstName;
                        private string lastName;
                        private string city;
                        private string state;
                        private string country;
                        private string eMail;
                        private string password;*/
                };

                _sharedViewModel.UsersList.Add(newUser);
                MessageBox.Show("User added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                // Optionally, clear the textboxes after adding the user
                ClearTextBoxes();
                Login login = new Login(_sharedViewModel);

                NavigationService.Navigate(login);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ClearTextBoxes()
        {
            // Clear the content of all textboxes
            txtFname.Clear();
            txtLname.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Login loginPage = new Login(_sharedViewModel);
                NavigationService.Navigate(loginPage);
                // Show the LoginPage

                // Close the current window
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error hh", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
