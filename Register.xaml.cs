﻿using MyLoginPanel.DB;
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
        public Register()
        {
            InitializeComponent();
        }

        private void CreateNewAccount(object sender, RoutedEventArgs e)
        {
            /* WALIDACJA */
            bool canBeRegistered = true;

            //1. Walidacja e-maila
            string emailRegex = @"[\w]@[\w]+\.[\w]";
            if(!Regex.IsMatch(txt_email.Text.ToString(), emailRegex))
            {
                if (txt_email.Text.ToString().Length == 0) lb_emailError.Content = "Nie podano żadnego e-maila. Proszę podać e-mail.";
                else lb_emailError.Content = "Nieprawidłowy e-mail! Musi mieć format nazwa@email.com.";
                canBeRegistered = false;
            }
            else lb_emailError.Content = "";

            //2. Walidacja loginu
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimumLength = new Regex(@".{6,}");

            var validatedLogin = hasNumber.IsMatch(txt_login.Text.ToString()) && hasUpperChar.IsMatch(txt_login.Text.ToString()) && hasMinimumLength.IsMatch(txt_login.Text.ToString());
            if (!validatedLogin)
            {
                if (txt_login.Text.ToString().Length == 0) lb_loginError.Content = "Nie podano loginu. Proszę podać login.";
                else if (!hasMinimumLength.IsMatch(txt_login.Text.ToString())) lb_loginError.Content = "Login jest za krótki. Musi mieć min 6 znaków.";
                else if(!hasUpperChar.IsMatch(txt_login.Text.ToString()) || !hasNumber.IsMatch(txt_login.Text.ToString())) lb_loginError.Content = "Login musi zawierać min 1 dużą literę i min 1 cyfrę.";
                canBeRegistered = false;
            }
            else lb_loginError.Content = "";

            //3. Walidacja hasła
            hasMinimumLength = new Regex(@".{10,}");
            var validatedPassword = hasNumber.IsMatch(txt_password.Password.ToString()) && hasUpperChar.IsMatch(txt_password.Password.ToString()) && hasMinimumLength.IsMatch(txt_password.Password.ToString());
            if (!validatedPassword)
            {
                if (txt_password.Password.ToString().Length == 0) lb_passwordError.Content = "Nie podano hasła. Proszę podać hasło.";
                else if (!hasMinimumLength.IsMatch(txt_password.Password.ToString())) lb_passwordError.Content = "Hasło jest za krótkie. Musi mieć min 10 znaków.";
                else if (!hasUpperChar.IsMatch(txt_password.Password.ToString()) || !hasNumber.IsMatch(txt_password.Password.ToString())) lb_passwordError.Content = "Hasło musi zawierać min 1 dużą literę i min 1 cyfrę.";
                canBeRegistered=false;
            }
            else lb_passwordError.Content = "";

            //4. Walidacja powtórzenia hasła
            if (!txt_password.Password.Equals(txt_repeatPassword.Password))
            {
                if (txt_repeatPassword.Password.Length == 0) lb_repeatedError.Content = "Nie powtórzono hasła. Proszę powtórzyć hasło.";
                else lb_repeatedError.Content = "Hasła nie są takie same. Proszę powtórzyć hasło.";
                canBeRegistered = false;
            }
            else lb_repeatedError.Content = "";

            //5. Walidacja podania płci i daty
            if (radio_female.IsChecked == false && radio_male.IsChecked == false && radio_other.IsChecked == false)
            {
                lb_genderError.Content = "Proszę wybrać płeć.";
                canBeRegistered = false;
            }
            else lb_genderError.Content = "";

            if (dp_birthday.ToString().Equals(""))
            {
                lb_birthdayDateError.Content = "Proszę podać datę urodzenia.";
                canBeRegistered = false;
            }
            else lb_birthdayDateError.Content = "";

            /* ŁĄCZENIE Z BAZĄ I TWORZENIE NOWEGO UŻYTKOWNIKA */
            if (canBeRegistered)
            {
                lb_registeredSuccessfully.Content = "Gdy powstanie baza, użytkownik zostanie pomyślnie zalogowany.";
            }
        }
    }
}