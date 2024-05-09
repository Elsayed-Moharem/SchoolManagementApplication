using SchoolApplication.Command;
using SchoolApplication.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using SchoolApplication.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SchoolApplication.ViewModel
{
    public class TeacherLoginViewModel : INotifyPropertyChanged
    {
        private Window window;
       

        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }
        public ICommand btnLogin_Click { get; set; }
        /// -----------------------------------------------------/
        public string Myusername { get; set; }
        public string Mypassword { get; set; }


        /// //////////////////////////////////////////////// #
        private ObservableCollection<Teacher> _teachers;


        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
                OnPropertyChanged(nameof(Teachers));
            }
        }

        private MySchool_DBEntities context = new MySchool_DBEntities();

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TI_name { get; set; }

        public string TI_Pass { get; set; }

        public Teacher SelectedTeacher { get; set; }







        public TeacherLoginViewModel(Window window)
        {
            this.window = window;

            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);
            btnLogin_Click = new MyCommand(CanLogin, Login);


            _teachers = new ObservableCollection<Teacher>(context.Teacher.ToList());
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




            var user = context.Teacher.FirstOrDefault(u => u.T_Name == username && u.T_Pass == password);

            if (user != null)
            {
                TeacherMainView TeacherMainView = new TeacherMainView();
                TeacherMainView.Show();
                window.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}