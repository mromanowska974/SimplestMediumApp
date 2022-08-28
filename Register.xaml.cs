using Microsoft.EntityFrameworkCore;
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
    /// Logika interakcji dla klasy Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register(double width, double height)
        {
            InitializeComponent();
        }

        private void CreateNewAccount(object sender, RoutedEventArgs e)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;

            RadioButton[] GenderButtons =
            {
                radio_female,
                radio_male,
                radio_other
            };
            bool validatedEmail = Validate.Email(txt_email, lb_emailError);
            bool validatedLogin = Validate.Login(txt_login, lb_loginError);
            bool validatedPassword = Validate.Password(txt_password, lb_passwordError);
            bool validatedRepeat = Validate.RepeatedPassword(txt_password, txt_repeatPassword, lb_repeatedError);
            bool validatedGender = Validate.Gender(GenderButtons, lb_genderError);
            bool validatedBirthDate = Validate.BirthDate(dp_birthday, lb_birthdayDateError);

            bool canBeRegistered = validatedEmail && validatedLogin && validatedPassword && validatedRepeat && validatedGender && validatedBirthDate;

            if (canBeRegistered)
            {
                User user = new User();
                user.Email = txt_email.Text;
                user.Login = txt_login.Text;
                user.Password = txt_password.Password;
                user.BirthDate = dp_birthday.ToString();
                if (radio_female.IsChecked == true) user.Gender = "Female";
                else if (radio_male.IsChecked == true) user.Gender = "Male";
                else user.Gender = "Other/not mentioned";

                using(var db = new MyDbContext(options))
                {
                    db.Database.EnsureCreated();
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                Login login = new Login("Dziękujemy za zarejestrowanie.\n Teraz możesz się zarejestrować w serwisie SimplestMedium.", this.ActualWidth, this.ActualHeight);
                login.Show();
                this.Close();
            }
        }
    }
}
