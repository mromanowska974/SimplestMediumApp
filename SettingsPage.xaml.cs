using Microsoft.Win32;
using MyLoginPanel.DB;
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

namespace MyLoginPanel
{
    public partial class SettingsPage : Page
    {
        User currentlyLoggedUser;
        Window rootWindow;
        public SettingsPage(User user, Window window)
        {
            InitializeComponent();
            lb_userDataIntroduction.Content = $"Dane użytkownika {user.Login}";
            lb_emailInfo.Content = user.Email;
            lb_loginInfo.Content = user.Login;
            lb_genderInfo.Content = user.Gender;
            lb_birthDateInfo.Content = user.BirthDate;
            currentlyLoggedUser = user;
            rootWindow = window;
        }
        /* PLACEHOLDER
        public SettingsPage()
        {
            InitializeComponent();
            currentlyLoggedUser = new User();
            currentlyLoggedUser.Login = "Admin";
            currentlyLoggedUser.Email = "admin1@admin.com";
            currentlyLoggedUser.Gender = "Other/Not mentioned";
            currentlyLoggedUser.BirthDate = "2100-13-32 00:00";
            currentlyLoggedUser.Password = "Admin2000!";
            currentlyLoggedUser.BirthDateChangesCounter = 0;
            lb_userDataIntroduction.Content = $"Dane użytkownika {currentlyLoggedUser.Login}";
            lb_emailInfo.Content = currentlyLoggedUser.Email;
            lb_loginInfo.Content = currentlyLoggedUser.Login;
            lb_genderInfo.Content = currentlyLoggedUser.Gender;
            lb_birthDateInfo.Content = currentlyLoggedUser.BirthDate;
        }
        */
        private void changeEmailOrLogin(object sender, RoutedEventArgs e)
        {
            string clickedButton = (sender as Button).Name;
            string info = "";

            if (clickedButton == "btn_changeEmail")
            {
                info = "Podaj nowy email. Musi być w formacie nazwa@email.com";
            }
            else if (clickedButton == "btn_changeLogin")
            {
                info = "Podaj nowy login. Musi zawierać min 6 znaków, \nmin. jedną wielką literę i jedną cyfrę.";
            }

            ChangeData cd = new ChangeData(currentlyLoggedUser, info, clickedButton, rootWindow);
            cd.Show();
        }
        private void ChangeTemplate(object sender)
        {
            string state = (sender as Button).Name;
            ChangeData cd = new ChangeData(currentlyLoggedUser, state, rootWindow);
            cd.Show();
        }

        private void changePassword(object sender, RoutedEventArgs e)
        {
            ChangeTemplate(sender);
        }

        private void changeGender(object sender, RoutedEventArgs e)
        {
            ChangeTemplate(sender);
        }

        private void changeBirthDate(object sender, RoutedEventArgs e)
        {
            ChangeTemplate(sender);
        }

        private void deleteAccount(object sender, RoutedEventArgs e)
        {
            ChangeTemplate(sender);
        }

        private void changeAvatar(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
        }
    }
}
