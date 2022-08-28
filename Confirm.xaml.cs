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
    /// Logika interakcji dla klasy Confirm.xaml
    /// </summary>
    public partial class Confirm : Window
    {
        User currentlyLoggedUser;
        string state;
        string newData;
        Profile profile;
        public Confirm(User user, string state, string newData, Profile profile)
        {            
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            this.newData = newData;
            this.profile = profile;
        }
        public Confirm(User user, string state, Profile profile)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            this.profile = profile;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            if (txt_password.Password.Equals(currentlyLoggedUser.Password))
            {
                var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;

                using (var db = new MyDbContext(options))
                {
                    var user = db.Users.Where(u => u.Email.Equals(currentlyLoggedUser.Email)).FirstOrDefault();                    
                    if (state.Equals("btn_changeEmail"))
                    {
                        user.Email = newData;
                    }
                    else if (state.Equals("btn_changeLogin"))
                    {
                        user.Login = newData;
                    }
                    else if (state.Equals("btn_changePassword"))
                    {
                        user.Password = newData;
                    }
                    else if (state.Equals("btn_changeGender"))
                    {
                        user.Gender = newData;
                    }
                    else if (state.Equals("btn_changeBirthDate"))
                    {
                        user.BirthDate = newData;
                    }
                    else if (state.Equals("btn_deleteAccount"))
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        MainWindow main = new MainWindow();
                        main.Show();
                        profile.Close();
                        this.Close();
                    }

                    if(!state.Equals("btn_deleteAccount"))
                    {
                        db.SaveChanges();
                        Profile newProfile = new Profile(user);
                        profile.Close();
                        newProfile.Show();
                    }
                }    

                this.Close();
            }
            else
            {
                if (txt_password.Password.Length == 0) lb_errorInfo.Content = "Nie podano hasła. Proszę podać hasło.";
                else lb_errorInfo.Content = "Podane hasło jest nieprawidłowe";
            }
        }
    }
}
