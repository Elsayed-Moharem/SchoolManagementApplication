using SchoolApplication.Command;
using SchoolApplication.Model;
using SchoolApplication.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SchoolApplication.ViewModel
{
    public class StudentLoginViewModel : INotifyPropertyChanged
    {

        private Window window;


        public ICommand btnMinimize_Click { get; set; }
        public ICommand btnClose_Click { get; set; }
        public ICommand btnLogin_Click { get; set; }
        /// -----------------------------------------------------/
        public string Myusername { get; set; }
        public string Mypassword { get; set; }

        public string Cource { get; set; }
        public int Grade { get; set; }


        /// //////////////////////////////////////////////// #
        private ObservableCollection<Student> _students;


        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged(nameof(Students));
            }
        }


        private ObservableCollection<StudentData> _studentsData;


        public ObservableCollection<StudentData> StudentsData
        {
            get { return _studentsData; }
            set
            {
                _studentsData = value;
                OnPropertyChanged(nameof(StudentsData));
            }
        }

        private StudentData _selectedUser;

        public StudentData SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
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
        

        public Student SelectedTeacher { get; set; }


        




        public StudentLoginViewModel(Window window)
        {
            this.window = window;

            btnMinimize_Click = new MyCommand(CanMini, Mini);
            btnClose_Click = new MyCommand(CanClose, Close);
            btnLogin_Click = new MyCommand(CanLogin, Login);


            _students = new ObservableCollection<Student>(context.Student.ToList());

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




            var user1 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "Arabic");
            var user2 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "Computer science");
            var user3 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "English");
            var user4 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "Islamic Education");
            var user5 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "Math");
            var user6 = context.StudentData.FirstOrDefault(u => u.ST_Name == username && u.ST_Pass == password && u.CRS_Name == "Science");


            Arabic_Grade = user1.ST_Grade;
            Computer_Grade = user2.ST_Grade;
            English_Grade = user3.ST_Grade;
            Islamic_Grade = user4.ST_Grade;
            Math_Grade = user5.ST_Grade;
            Science_Grade = user6.ST_Grade;




            if (user1 != null || user2 != null || user3 != null || user4 != null || user5 != null || user6 != null )
            {

                StudentsData = new ObservableCollection<StudentData>
        {
            new StudentData { ST_Grade = user1?.ST_Grade ?? 0},
            new StudentData { ST_Grade = user2?.ST_Grade ?? 0},
            new StudentData { ST_Grade = user3?.ST_Grade ?? 0},
            new StudentData { ST_Grade = user4?.ST_Grade ?? 0},
            new StudentData { ST_Grade = user5?.ST_Grade ?? 0},
            new StudentData { ST_Grade = user6?.ST_Grade ?? 0},
            
        };



                StudentMainView StudentMainView = new StudentMainView();
                StudentMainView.Show();
                window.Close();


                //List<int> studentGrades = GetStudentGrades(username);


                
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        public int Arabic_Grade { get; set; }
        public int Computer_Grade { get; set; }
        public int English_Grade { get; set; }
        public int Islamic_Grade { get; set; }
        public int Math_Grade { get; set; }
        public int Science_Grade { get; set; }


    }
}

