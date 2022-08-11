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
using UserDatabaseGUIApp.Models;

namespace UserDatabaseGUIApp
{
    public partial class MainWindow : Window
    {
        User currentSelectedUser;

        public MainWindow()
        {
            InitializeComponent();
            GiveDataToGrid();
        }

        private void GiveDataToGrid()
        {
            using (var context = new UserDB())
            {
                var query = from user in context.Users select user;
                UserDataGrid.ItemsSource = query.ToList();
            }
        }

        private void UserDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentSelectedUser = (User)UserDataGrid.SelectedItem;

                IDTextBox.Text = currentSelectedUser.ID.ToString();
                UsernameTextBox.Text = currentSelectedUser.Username;
                PasswordTextBox.Text = currentSelectedUser.Password;
            }
            catch (Exception ex)
            {
                IDTextBox.Text = "";
                UsernameTextBox.Text = "";
                PasswordTextBox.Text = "";
            }
        }

        private void AddUserButton(object sender, RoutedEventArgs e)
        {

            if(String.IsNullOrEmpty(UsernameTextBox.Text) || String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                return;
            }
            else
            {
                using (var context = new UserDB())
                {
                    var user = new User();
                    user.Username = UsernameTextBox.Text;
                    user.Password = PasswordTextBox.Text;

                    context.Add(user);

                    context.SaveChanges();

                    GiveDataToGrid();
                }
            }
        }

        private void UpdateUserButton(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveUserButton(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
