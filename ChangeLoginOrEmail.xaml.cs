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
    public partial class ChangeLoginOrEmail : Page
    {
        User currentlyLoggedUser;
        string state;
        Frame rootFrame;
        Window rootWindow;
        Window parentWindow;
        public ChangeLoginOrEmail(User user, string info, string state, Frame frame, Window window, Window window2)
        {
            InitializeComponent();
            currentlyLoggedUser = user;
            this.state = state;
            lb_info.Content = info;
            rootFrame = frame;
            rootWindow = window;
            parentWindow = window2;
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
                rootFrame.Content = new ConfirmPage(currentlyLoggedUser, state, txt_newData.Text, rootWindow, parentWindow);
            }
        }
    }
}
