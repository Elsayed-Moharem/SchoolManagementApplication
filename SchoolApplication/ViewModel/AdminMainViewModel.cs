using System.Windows.Input;
using System.Windows;
using SchoolApplication.Command;
using System.ComponentModel;
using System.Windows.Controls;
using SchoolApplication.View;

namespace SchoolApplication.ViewModel
{
    public class AdminMainViewModel : INotifyPropertyChanged
    {
        private Window window;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }

        private ICommand _ButtonSchool;
        private ICommand _ButtonTeacher;
        private ICommand _ButtonStudent;
        private UserControl _SelectedView;


        public ICommand ButtonSchool => _ButtonSchool;
        public ICommand ButtonTeacher => _ButtonTeacher;
        public ICommand ButtonStudent => _ButtonStudent;

        public UserControl SelectedView
        {
            get { return _SelectedView; }
            set
            {
                if (_SelectedView != value)
                {
                    _SelectedView = value;
                    OnPropertyChanged(nameof(SelectedView));
                }
            }
        }




        public AdminMainViewModel(Window window)
        {
            this.window = window;
            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);


            _ButtonSchool = new MyCommand(CanMini , SchoolClicked);
            _ButtonTeacher = new MyCommand(CanMini, TeacherClicked);
            _ButtonStudent = new MyCommand(CanMini, StudentClicked);



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

        private void SchoolClicked(object parameter)
        {
            // Load and set the view for Button 1
            SelectedView = new SchoolView();
        }

        private void TeacherClicked(object parameter)
        {
            // Load and set the view for Button 2
            SelectedView = new TeacherView(); 
        } 
        
        private void StudentClicked(object parameter)
        {
            // Load and set the view for Button 2
            SelectedView = new StudentView();
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
