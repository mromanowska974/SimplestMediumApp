using Microsoft.EntityFrameworkCore;
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
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public Login(string message)
        {
            InitializeComponent();
            lb_welcomeMessage.Content = message;
        }

        private void LoginToService(object sender, RoutedEventArgs e)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;

            string loginOrEmail = txt_loginOrEmail.Text;

            using(var db = new MyDbContext(options))
            {
                List<string> allLogins = new List<string>();
                List<string> allEmails = new List<string>();
                allEmails = db.Users.Select(x => x.Email).ToList();
                allLogins = db.Users.Select(x => x.Login).ToList();

                if(!allEmails.Contains(loginOrEmail) && !allLogins.Contains(loginOrEmail))
                {
                    lb_LoginError.Content = "Użytkownik o podanym e-mailu lub loginie nie istnieje w bazie.";
                }
                else
                {
                    User user = new User();
                    user = db.Users.FirstOrDefault(x => x.Email == loginOrEmail || x.Login == loginOrEmail);

                    if(user.Password != txt_password.Password)
                    {
                        lb_LoginError.Content = "Podano nieprawidłowe hasło. Proszę podać inne hasło.";
                    }
                    else
                    {
                        MainPage mp = new MainPage(user);
                        mp.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
