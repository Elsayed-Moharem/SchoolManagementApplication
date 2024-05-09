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
    public class TotalLoginViewModel
    {
        private Window window;
        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }
        public ICommand AdminLogin { get; set; }
        public ICommand TeacherLogin { get; set; }
        public ICommand StudentLogin { get; set; }



        public TotalLoginViewModel(Window window)
        {
            this.window = window;
            //Window_MouseDown = new MyCommand(CanMove, (obj) => Move(obj));
            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);
            AdminLogin = new MyCommand(CanStart, Start_ADmin);
            TeacherLogin = new MyCommand(CanStart, Start_T);
            StudentLogin = new MyCommand(CanStart, Start_ST);



        }
        private void Close(object obj)
        {
            Application.Current.Shutdown();
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

        private void Start_ADmin(object obj)
        {
            AdminLoginView adminLoginView = new AdminLoginView();
            adminLoginView.Show();
            

        }
        private void Start_T(object obj)
        {
            TeacherLoginView teacherLoginView = new TeacherLoginView();
            teacherLoginView.Show();
            

        }
        private void Start_ST(object obj)
        {
            StudentLoginView studentLoginView = new StudentLoginView();
            studentLoginView.Show();
            

        }

        private bool CanStart(object obj)
        {
            return true;
        }



    }
}
