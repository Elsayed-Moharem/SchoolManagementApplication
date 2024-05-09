using SchoolApplication.Command;
using SchoolApplication.View;
using System;
using System.Collections;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Schema;

namespace SchoolApplication.ViewModel
{
    public class StartingViewModel
    {
        private Window window;
        //public ICommand Window_MouseDown { get; set; }
        //<!--MouseDown="Window_MouseDown"-->
        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }
        public ICommand btnStart_Click { get; set; }
        public StartingViewModel(Window window)
        {
            this.window = window;
            //Window_MouseDown = new MyCommand(CanMove, (obj) => Move(obj));
            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);
            btnStart_Click = new MyCommand(CanStart, Start);

        }

        private void Close(object obj)
        {
            Application.Current.Shutdown();
        }

        private bool CanClose(object obj)
        {
            return true;
        }
   

        private void Start(object obj)
        {
            TotalLoginView totalLoginView = new TotalLoginView();
            totalLoginView.Show();
            window.Close();

        }

        private bool CanStart(object obj)
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

        //private void Move(object obj)
        //{
        //    if (obj is MouseEventArgs e && e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        if (window != null)
        //        {
        //            window.DragMove();
        //        }
        //    }

        //}

        //private bool CanMove(object obj)
        //{
        //    return true;
        //}

       


    }
}
