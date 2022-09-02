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
    /// Logika interakcji dla klasy ChangeData.xaml
    /// </summary>
    public partial class ChangeData : Window
    {
        Window parentWindow;
        public ChangeData(User user, string info, string state, Window window)
        {
            InitializeComponent();
            parentWindow = window;
            Main.Content = new ChangeLoginOrEmail(user, info, state, Main, this, parentWindow);            
        }

        public ChangeData(User user, string state, Window window)
        {
            InitializeComponent();
            parentWindow = window;
            if (state == "btn_changePassword")
            {
                this.Height = 300;
                Main.Content = new ChangePassword(user, state, Main, this, parentWindow);
            }
            else if (state == "btn_changeGender")
            {
                this.Height = 250;
                Main.Content = new ChangeGender(user, state, Main, this, parentWindow);
            }
            else if (state == "btn_changeBirthDate")
            {
                this.Width = 300;
                Main.Content = new ChangeBirthDate(user, state, Main, this, parentWindow);
            }
            else if (state == "btn_deleteAccount") Main.Content = new ConfirmPage(user, state, this, parentWindow);
        }
    }
}
