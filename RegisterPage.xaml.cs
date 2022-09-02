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
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        Frame rootFrame;
        Window rootWindow;
        public RegisterPage(Frame frame, Window window)
        {
            InitializeComponent();
            rootFrame = frame;
            rootWindow = window;
        }

        private void CreateNewAccount(object sender, RoutedEventArgs e)
        {
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

                using (var db = new MyDbContext(GlobalVariables.Options))
                {
                    db.Database.EnsureCreated();
                    db.Users.Add(user);
                    db.SaveChanges();
                }

                rootFrame.Content = new LoginPage("Dziękujemy za zarejestrowanie.\n Teraz możesz się zarejestrować w serwisie SimplestMedium.", rootWindow);
            }
        }
    }
}
