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
    public partial class ConfirmPage : Page
    {
        User currentlyLoggedUser;
        string state;
        string newData;
        Window rootWindow;
        Window parentWindow;
        //Frame parentWindowFrame;
        public ConfirmPage(User user, string state, string newData, Window window, Window window2/*, Frame frame*/)
        {            
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            this.newData = newData;
            rootWindow = window;
            parentWindow = window2;
            //parentWindowFrame = frame;
            rootWindow.Width = 450;
            rootWindow.Height = 200;
        }
        public ConfirmPage(User user, string state, Window window, Window window2)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            rootWindow = window;
            parentWindow = window2;
            lb_info.Content = "Proszę podać hasło w celu potwierdzenia decyzji. \nDziałania nie da się cofnąć.";
        }
        private void saveChanges(object sender, RoutedEventArgs e)
        {
            if (txt_password.Password.Equals(currentlyLoggedUser.Password))
            {
                using (var db = new MyDbContext(GlobalVariables.Options))
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
                        user.BirthDateChangesCounter++;
                        user.BirthDate = newData;
                    }
                    else if (state.Equals("btn_deleteAccount"))
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        MainWindow main = new MainWindow();
                        main.Show();
                        rootWindow.Close();
                        parentWindow.Close();
                    }

                    if(!state.Equals("btn_deleteAccount"))
                    {
                        db.SaveChanges();
                        //currentlyLoggedUser = user;
                        //parentWindowFrame.Content = new SettingsPage(currentlyLoggedUser, parentWindow);
                    }
                }    

                rootWindow.Close();
            }
            else
            {
                if (txt_password.Password.Length == 0) lb_errorInfo.Content = "Nie podano hasła. Proszę podać hasło.";
                else lb_errorInfo.Content = "Podane hasło jest nieprawidłowe";
            }
        }
    }
}
