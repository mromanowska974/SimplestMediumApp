using Microsoft.EntityFrameworkCore;
using MyLoginPanel.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyLoginPanel
{
    public static class Validate
    {
        public static bool Email(TextBox tb, Label lb)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;
            bool isValidated = true;

            using (var db = new MyDbContext(options))
            {
                List<string> allEmails = new List<string>();
                allEmails = db.Users.Select(x => x.Email).ToList();
                if (allEmails.Contains(tb.Text))
                {
                    lb.Content = "Podany e-mail jest już w użyciu. Proszę podać inny e-mail.";
                    return false;
                }
            }

            string emailRegex = @"[\w]@[\w]+\.[\w]";
            if (!Regex.IsMatch(tb.Text.ToString(), emailRegex))
            {
                if (tb.Text.ToString().Length == 0) lb.Content = "Nie podano żadnego e-maila. Proszę podać e-mail.";
                else lb.Content = "Nieprawidłowy e-mail! Musi mieć format nazwa@email.com.";
                isValidated = false;
            }
            else lb.Content = "";

            return isValidated;
        }
        public static bool Login(TextBox tb, Label lb)
        {
            var options = new DbContextOptionsBuilder<MyDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SimplestMediumDB;Trusted_Connection=True;").Options;
            bool isValidated = true;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimumLength = new Regex(@".{6,}");
            bool isUnique = true;

            using (var db = new MyDbContext(options))
            {
                List<string> allLogins = new List<string>();
                allLogins = db.Users.Select(x => x.Login).ToList();
                if (allLogins.Contains(tb.Text)) { 
                    lb.Content = "Podany login jest już w użyciu. Proszę podać inny login.";
                    isUnique = false;
                }
            }

            var validatedLogin = hasNumber.IsMatch(tb.Text.ToString()) && hasUpperChar.IsMatch(tb.Text.ToString()) && hasMinimumLength.IsMatch(tb.Text.ToString()) && isUnique;
            if (!validatedLogin)
            {
                if (tb.Text.ToString().Length == 0) lb.Content = "Nie podano loginu. Proszę podać login.";
                else if (!hasMinimumLength.IsMatch(tb.Text.ToString())) lb.Content = "Login jest za krótki. Musi mieć min 6 znaków.";
                else if (!hasUpperChar.IsMatch(tb.Text.ToString()) || !hasNumber.IsMatch(tb.Text.ToString())) lb.Content = "Login musi zawierać min 1 dużą literę i min 1 cyfrę.";
                isValidated = false;
            }
            else lb.Content = "";

            return isValidated;
        }
        public static bool Password(PasswordBox pb, Label lb)
        {
            bool isValidated = true;

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimumLength = new Regex(@".{10,}");
            var validatedPassword = hasNumber.IsMatch(pb.Password.ToString()) && hasUpperChar.IsMatch(pb.Password.ToString()) && hasMinimumLength.IsMatch(pb.Password.ToString());
            if (!validatedPassword)
            {
                if (pb.Password.ToString().Length == 0) lb.Content = "Nie podano hasła. Proszę podać hasło.";
                else if (!hasMinimumLength.IsMatch(pb.Password.ToString())) lb.Content = "Hasło jest za krótkie. Musi mieć min 10 znaków.";
                else if (!hasUpperChar.IsMatch(pb.Password.ToString()) || !hasNumber.IsMatch(pb.Password.ToString())) lb.Content = "Hasło musi zawierać min 1 dużą literę i min 1 cyfrę.";
                isValidated = false;
            }
            else lb.Content = "";

            return isValidated;
        }
        public static bool RepeatedPassword(PasswordBox pb1, PasswordBox pb2, Label lb)
        {
            bool isValidated = true;

            if (!pb1.Password.Equals(pb2.Password))
            {
                if (pb2.Password.Length == 0) lb.Content = "Nie powtórzono hasła. Proszę powtórzyć hasło.";
                else lb.Content = "Hasła nie są takie same. Proszę powtórzyć hasło.";
                isValidated = false;
            }
            else lb.Content = "";

            return isValidated;
        }
        public static bool Gender(RadioButton[] rb,Label lb)
        {
            bool isValidated = true;

            if (rb[0].IsChecked == false && rb[1].IsChecked == false && rb[2].IsChecked == false)
            {
                lb.Content = "Proszę wybrać płeć.";
                isValidated = false;
            }
            else lb.Content = "";

            return isValidated;
        }
        public static bool BirthDate(DatePicker dp, Label lb)
        {
            bool isValidated = true;

            string givenDate = dp.ToString();
            int nowYear = DateTime.Now.Year;
            int nowMonth = DateTime.Now.Month;
            int nowDay = DateTime.Now.Day;

            if (givenDate.Equals(""))
            {
                lb.Content = "Proszę podać datę urodzenia.";
                isValidated = false;
            }
            else
            {
                int givenYear = int.Parse(givenDate.Substring(6, 4));
                int givenMonth = int.Parse(givenDate.Substring(3, 2));
                int givenDay = int.Parse((givenDate.Substring(0, 2)));

                if (nowYear-givenYear < 12)
                {
                    lb.Content = "Użytkownik musi mieć minimum 12 lat.";
                    isValidated |= false;
                }
                else if (nowYear-givenYear == 12)
                {
                    if (nowMonth < givenMonth)
                    {
                        lb.Content = "Użytkownik musi mieć minimum 12 lat.";
                        isValidated = false;
                    }
                    else if (nowMonth == givenMonth)
                    {
                        if (nowDay < givenDay)
                        {
                            lb.Content = "Użytkownik musi mieć minimum 12 lat.";
                            isValidated = false;
                        }
                        else lb.Content = "";
                    }
                    else lb.Content = "";
                }
                else lb.Content = "";
            }

            return isValidated;
        }

    }
}
