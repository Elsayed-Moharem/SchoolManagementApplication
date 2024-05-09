using SchoolApplication.Command;
using SchoolApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolApplication.ViewModel
{
    public class TeacherViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Teacher> _teachers;

        
        public ObservableCollection<Teacher> Teachers
        {
            get { return _teachers; }
            set { 
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

        public ICommand T_add_Click { get; set; }
        public ICommand T_removing_Click { get; set; }

        public int TI_ID { get; set; }
        public string TI_name { get; set; }
        public int TI_Salary { get; set; }
        public string TI_Mail { get; set; }
        public string TI_Pass { get; set; }
        public int T_Evaluation { get; set; }


        //public Teacher SelectedTeacher { get; set; }
        private Teacher _selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }

        public string T_course { get; set; }

        public bool MathChecked { get; set; }
        public bool ArabicChecked { get; set; }
        public bool EnglishChecked { get; set; }
        public bool ScienceChecked { get; set; }
        public bool ComputerScienceChecked { get; set; }
        public bool IslamicEducationChecked { get; set; }



        public TeacherViewModel()
        {
            _teachers = new ObservableCollection<Teacher>(context.Teacher.ToList());
            T_add_Click = new MyCommand(CanAdd, Add);
            T_removing_Click = new MyCommand(CanRemove, Remove);
            //this.ItemsSource = _teachers;
           



        }

        private void Add(object obj)
        {
            if (string.IsNullOrEmpty(TI_name) || string.IsNullOrEmpty(TI_Mail))
            {
                MessageBox.Show("Please enter valid data for name and email.");
                return;
            }

            int userID = TI_ID;
            string userName = TI_name;
            int userSalary = TI_Salary;
            string userMail = TI_Mail;
            string userPass = TI_Pass;
            //string userCourse = T_course;
            //int userEvaluation = T_Evaluation;
            //_teachers.Add(new TeacherData() { T_ID = userID, T_Name = userName, T_Salary = userSalary, Email = userMail, T_Pass = userPass, CRS_Name = GetSelectedCourse() });


            //TI_ID = 0;
            //TI_name = string.Empty;
            //TI_Salary = 0;
            //TI_Mail = string.Empty;
            //TI_Pass = string.Empty;
            //T_course = "Math";
            //MathChecked = ArabicChecked = EnglishChecked = ScienceChecked = ComputerScienceChecked = IslamicEducationChecked = false;
            /////////////////////////////////

            Teacher newTeacher = new Teacher()
            {
                T_ID = userID,
                T_Name = userName,
                T_Salary = userSalary,
                Email = userMail,
                T_Pass = userPass,
                //T_Evaluation = userEvaluation,
                //CRS_Name = GetSelectedCourse()
            };

            // Add the new teacher to the ObservableCollection
            _teachers.Add(newTeacher);

            // Add the new teacher to the database context
            context.Teacher.Add(newTeacher);

            // Save changes to the database
            context.SaveChanges();

            // Reset the input fields
            //TI_ID = 0;
            //TI_name = string.Empty;
            //TI_Salary = 0;
            //TI_Mail = string.Empty;
            //TI_Pass = string.Empty;
            //T_course = "Math";
            //T_Evaluation = 0;
            //MathChecked = ArabicChecked = EnglishChecked = ScienceChecked = ComputerScienceChecked = IslamicEducationChecked = false;




        }

        private bool CanAdd(object obj)
        {
            return true;
        }

        private void Remove(object obj)
        {
            Teacher selectedTeacher = obj as Teacher;

            if (selectedTeacher != null)
            {
                _teachers.Remove(selectedTeacher);
                context.Teacher.Remove(selectedTeacher);
                context.SaveChanges();

            }
            else
            {
                MessageBox.Show("Please select a teacher to remove.");
            }
        }

        private bool CanRemove(object obj)
        {
            return true;
        }

        private string GetSelectedCourse()
        {
            if (MathChecked)
            {
                return "Math";
            }
            else if (ArabicChecked)
            {
                return "Arabic";
            }
            else if (EnglishChecked)
            {
                return "English";
            }
            else if (ScienceChecked)
            {
                return "Science";
            }
            else if (ComputerScienceChecked)
            {
                return "Computer Science";
            }
            else if (IslamicEducationChecked)
            {
                return "Islamic Education";
            }

           
            return "Math";
        }





    }
}
