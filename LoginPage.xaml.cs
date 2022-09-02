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
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Window rootWindow;
        public LoginPage(string message, Window window)
        {
            InitializeComponent();
            rootWindow = window;
            lb_welcomeMessage.Content = message;
        }

        private void LoginToService(object sender, RoutedEventArgs e)
        {
            string loginOrEmail = txt_loginOrEmail.Text;

            using (var db = new MyDbContext(GlobalVariables.Options))
            {
                List<string> allLogins = new List<string>();
                List<string> allEmails = new List<string>();
                allEmails = db.Users.Select(x => x.Email).ToList();
                allLogins = db.Users.Select(x => x.Login).ToList();

                if (!allEmails.Contains(loginOrEmail) && !allLogins.Contains(loginOrEmail))
                {
                    lb_LoginError.Content = "Użytkownik o podanym e-mailu lub loginie nie istnieje.";
                }
                else
                {
                    User user = new User();
                    user = db.Users.FirstOrDefault(x => x.Email == loginOrEmail || x.Login == loginOrEmail);

                    if (user.Password != txt_password.Password)
                    {
                        lb_LoginError.Content = "Podano nieprawidłowe hasło. Proszę podać inne hasło.";
                    }
                    else
                    {
                        MainLoggedPage mp = new MainLoggedPage(user);
                        mp.Show();
                        rootWindow.Close();
                    }
                }
            }
        }
    }
}
