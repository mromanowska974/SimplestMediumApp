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
        User currentlyLoggedUser;
        string state;
        Profile profile;
        public ChangeData(User user, string info, string state, Profile profile)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            lb_info.Content = info;
            this.profile = profile;
        }

        private void saveChanges(object sender, RoutedEventArgs e)
        {
            bool canBeChanged = true;

            if (state.Equals("btn_changeEmail"))
            {
                canBeChanged = Validate.Email(txt_newData, lb_errorInfo);
            }
            else if (state.Equals("btn_changeLogin"))
            {
                canBeChanged = Validate.Login(txt_newData, lb_errorInfo);
            }

            if (canBeChanged)
            {
                Confirm confirm = new Confirm(currentlyLoggedUser, state, txt_newData.Text, profile);
                confirm.Show();
                this.Close();
            }
        }
    }
}
