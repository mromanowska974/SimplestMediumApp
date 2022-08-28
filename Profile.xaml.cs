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
using System.Windows.Shapes;

namespace MyLoginPanel
{
    /// <summary>
    /// Logika interakcji dla klasy Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {
        User currentlyLoggedUser;
        public Profile(User user)
        {
            InitializeComponent();
            lb_userDataIntroduction.Content = $"Dane użytkownika {user.Login}";
            lb_emailInfo.Content = user.Email;
            lb_loginInfo.Content = user.Login;
            lb_genderInfo.Content = user.Gender;
            lb_birthDateInfo.Content = user.BirthDate;
            currentlyLoggedUser = user;
        }
        /*
        public Profile()
        {
            InitializeComponent();
            currentlyLoggedUser = new User();
            currentlyLoggedUser.Login = "Admin";
            currentlyLoggedUser.Email = "admin1@admin.com";
            currentlyLoggedUser.Gender = "Other/Not mentioned";
            currentlyLoggedUser.BirthDate = "2100-13-32 00:00";
            currentlyLoggedUser.Password = "Admin2000!";
            lb_userDataIntroduction.Content = $"Dane użytkownika {currentlyLoggedUser.Login}";
            lb_emailInfo.Content = currentlyLoggedUser.Email;
            lb_loginInfo.Content = currentlyLoggedUser.Login;
            lb_genderInfo.Content = currentlyLoggedUser.Gender;
            lb_birthDateInfo.Content = currentlyLoggedUser.BirthDate;
        }
        */

        private void backToMainPage(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(currentlyLoggedUser);
            mainPage.Show();
            this.Close();
        }

        private void changeEmailOrLogin(object sender, RoutedEventArgs e)
        {
            string clickedButton = (sender as Button).Name;
            string info = "";

            if (clickedButton == "btn_changeEmail")
            {
                info = "Podaj nowy email. Musi być w formacie nazwa@email.com";
            }
            else if(clickedButton == "btn_changeLogin")
            {
                info = "Podaj nowy login. Musi zawierać min 6 znaków, \nmin. jedną wielką literę i jedną cyfrę.";
            }

            ChangeData cd = new ChangeData(currentlyLoggedUser, info, clickedButton, this);
            cd.Show();
        }

        private void changePassword(object sender, RoutedEventArgs e)
        {
            string state = (sender as Button).Name;
            ChangePassword cp = new ChangePassword(currentlyLoggedUser, state, this);
            cp.Show();
        }

        private void changeGender(object sender, RoutedEventArgs e)
        {
            string state = (sender as Button).Name;
            ChangeGender cg = new ChangeGender(currentlyLoggedUser, state, this);
            cg.Show();
        }

        private void changeBirthDate(object sender, RoutedEventArgs e)
        {
            string state = (sender as Button).Name;
            ChangeBirthDate cbd = new ChangeBirthDate(currentlyLoggedUser, state, this);
            cbd.Show();
        }

        private void deleteAccount(object sender, RoutedEventArgs e)
        {
            string state = (sender as Button).Name;
            Confirm c = new Confirm(currentlyLoggedUser, state, this);
            c.Show();
        }
    }
}
