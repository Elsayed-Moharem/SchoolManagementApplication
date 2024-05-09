using SchoolApplication.Command;
using SchoolApplication.Model;
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
    public class StudentViewModel : INotifyPropertyChanged
    {
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

        private MySchool_DBEntities context = new MySchool_DBEntities();

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ST_add_Click { get; set; }
        public ICommand ST_removing_Click { get; set; }

        public int STI_ID { get; set; }
        public string STI_name { get; set; }
        public int STI_Age { get; set; }
        public string STI_Mail { get; set; }
        public string STI_Pass { get; set; }
        //public string STI_Course { get; set; }
        //public int STI_Grade { get; set; }
        //public string STI_Acadimic_Year { get; set; }



        private Student _selectedStudent;

        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }



        


        public StudentViewModel()
        {
            _students = new ObservableCollection<Student>(context.Student.ToList());

            ST_add_Click = new MyCommand(CanAdd, Add);
            ST_removing_Click = new MyCommand(CanRemove, Remove);
            



        }

        private void Add(object obj)
        {
            //if (string.IsNullOrEmpty(TI_name) || string.IsNullOrEmpty(TI_Mail))
            //{
            //    MessageBox.Show("Please enter valid data for name and email.");
            //    return;
            //}

            int userID = STI_ID;
            string userName = STI_name;
            int userAge = STI_Age;
            string userMail = STI_Mail;
            string userPass = STI_Pass;
            //string userCourse = STI_Course;
            //int userGrade = STI_Grade;
            //string userAY = STI_Acadimic_Year;
            //_teachers.Add(new TeacherData() { T_ID = userID, T_Name = userName, T_Salary = userSalary, Email = userMail, T_Pass = userPass, CRS_Name = GetSelectedCourse() });


            //TI_ID = 0;
            //TI_name = string.Empty;
            //TI_Salary = 0;
            //TI_Mail = string.Empty;
            //TI_Pass = string.Empty;
            //T_course = "Math";
            //MathChecked = ArabicChecked = EnglishChecked = ScienceChecked = ComputerScienceChecked = IslamicEducationChecked = false;
            /////////////////////////////////

            Student newStudent = new Student()
            {
                ST_ID = userID,
                ST_Name = userName,
                ST_Age = userAge,
                Email = userMail,
                ST_Pass = userPass,
                //CRS_Name = userCourse,
                ////ST_Grade = userGrade,
                //AY_Name = userAY,

               
            };

            // Add the new teacher to the ObservableCollection
            _students.Add(newStudent);

            // Add the new teacher to the database context
            context.Student.Add(newStudent);

            // Save changes to the database
            context.SaveChanges();

            // Reset the input fields
            STI_ID = 0;
            STI_name = string.Empty;
            STI_Age = 0;
            STI_Mail = string.Empty;
            STI_Pass = string.Empty;
            //STI_Course = string.Empty;
            //STI_Grade = 0;
            
           



        }

        private bool CanAdd(object obj)
        {
            return true;
        }

        private void Remove(object obj)
        {
            Student SelectedStudent = obj as Student;

           

            if (SelectedStudent != null)
            {
                _students.Remove(SelectedStudent);
                context.Student.Remove(SelectedStudent);
                context.SaveChanges();

            }
            else
            {
                MessageBox.Show("Please select a Student to remove.");
            }
        }

        private bool CanRemove(object obj)
        {
            return true;
        }

        





    }




}

