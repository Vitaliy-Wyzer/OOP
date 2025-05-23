﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Student> Students { get; set;}

        public MainWindow()
        {
            InitializeComponent();
            Students = new List<Student> {
                new Student(){FirstName = "Jan", SurName = "Kowalski", Faculty="WIMII", StudentNo=1010},
                new Student(){FirstName = "Michal", SurName = "Nowak", Faculty="WIMII", StudentNo=1011},
                new Student(){FirstName = "Jacek", SurName = "Makieta", Faculty="WIMII", StudentNo=1012},
            };
            DataGridStudents.Columns.Add(new DataGridTextColumn() { Header = "First name", Binding = new Binding("FirstName") });   
            DataGridStudents.Columns.Add(new DataGridTextColumn() { Header = "Sur name", Binding = new Binding("SurName") });   
            DataGridStudents.Columns.Add(new DataGridTextColumn() { Header = "Faculty", Binding = new Binding("Faculty") });   
            DataGridStudents.Columns.Add(new DataGridTextColumn() { Header = "Student No.", Binding = new Binding("StudentNo") });
            DataGridStudents.Columns.Add(new DataGridTextColumn() { Header = "Grades", Binding = new Binding("JoinedGrades") });
            DataGridStudents.AutoGenerateColumns = false;
            DataGridStudents.ItemsSource = Students;
        }

        private void ButtonDeleteStudent_Click(object sender, RoutedEventArgs e) {
            if (DataGridStudents.SelectedItem is Student studentToRemove) {
                Students.Remove(studentToRemove);
                DataGridStudents.Items.Refresh();  
            }
        }

        private void ButtonAddStudent_Click(object sender, RoutedEventArgs e) {
            AddStudentWindow addStudentWindow = new AddStudentWindow();

            bool? result = addStudentWindow.ShowDialog();
            if (result == true) {
                Student newStudent = addStudentWindow.Student;
                if (newStudent != null) { 
                    Students.Add(newStudent);
                    DataGridStudents.Items.Refresh();
                }
            }
        }

        private void ButtonAddGrade_Click(object sender, RoutedEventArgs e) {
            AddGradeWindow addGradeWindow = new AddGradeWindow();
            bool? result = addGradeWindow.ShowDialog();

            if (DataGridStudents.SelectedItem is Student studentToAddGrade)
            {
                if (result == true)
                {
                    Grade newGrade = addGradeWindow.Grade;
                    if (newGrade != null) { 
                        studentToAddGrade.Grades.Add(newGrade);
                        DataGridStudents.Items.Refresh();
                    }
                }

            }
        }
    }
}