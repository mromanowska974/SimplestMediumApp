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

        private void backToMainPage(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage(currentlyLoggedUser);
            mainPage.Show();
            this.Close();
        }
    }
}
