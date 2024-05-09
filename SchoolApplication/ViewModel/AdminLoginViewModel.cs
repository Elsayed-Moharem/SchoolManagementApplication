using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using SchoolApplication.Command;
using System.Windows.Media.Animation;
using SchoolApplication.View;

namespace SchoolApplication.ViewModel
{
    public class AdminLoginViewModel
    {

        private Window window;
        
        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }
        public ICommand btnLogin_Click { get; set; }
        /// -----------------------------------------------------/
        public string Myusername { get; set; }
        public string Mypassword { get; set; }


        public AdminLoginViewModel(Window window)
        {
            this.window = window;
            
            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);
            btnLogin_Click = new MyCommand(CanLogin, Login);




        }
        private void Close(object obj)
        {
            window.Close();
        }

        private bool CanClose(object obj)
        {
            return true;
        }

        private void Mini(object obj)
        {
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private bool CanMini(object obj)
        {
            return true;
        }


        private bool CanLogin(object obj)
        {
            return true;
        }

        private void Login(object obj)

        {
            string username = Myusername;
            string password = Mypassword;
            if (username == "admin" && password == "admin") 
            { 
                AdminMainView adminMainView = new AdminMainView();
                adminMainView.Show();
                window.Close();
            }
            else
            {
                
                MessageBox.Show("Invalid username or password");
            }


        }








    }




}
