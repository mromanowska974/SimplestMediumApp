using MyLoginPanel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logika interakcji dla klasy ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        User currentlyLoggedUser;
        string state;
        Profile profile;
        public ChangePassword(User user, string state, Profile profile)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            lb_info.Content = "Podaj nowe hasło. Musi mieć min 10 znaków, \njedną wielką literę i jedną cyfrę.";
            this.profile = profile;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            bool isValid = Validate.Password(txt_password, lb_errorInfo);
            bool isRepeated = Validate.RepeatedPassword(txt_password, txt_repeated, lb_errorInfo2);
            bool canBeChanged = isValid && isRepeated;

            if (canBeChanged)
            {
                Confirm confirm = new Confirm(currentlyLoggedUser, state, txt_password.Password, profile);
                confirm.Show();
                this.Close();
            }
        }
    }
}
