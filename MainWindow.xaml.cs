using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using Microsoft.Win32;

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

        private void ButtonSaveTxt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);

                foreach (Student s in Students)
                {
                    sw.WriteLine(s.TxtFormat());
                }

                sw.Close();
            }
        }

        private void ButtonLoadTxt_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("data.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            List<Student> students = new List<Student>();
            Student student = null;

            while(!sr.EndOfStream)
            {
                var ln = sr.ReadLine();
                if (ln == "[[Student]]")
                {
                    student = new Student();
                }
                if (ln == "[FirstName]")
                {
                    student.FirstName = sr.ReadLine();
                }
                if (ln == "[SurName]")
                {
                    student.SurName = sr.ReadLine();
                }
                if (ln == "[Faculty]")
                {
                    student.Faculty = sr.ReadLine();
                }
                if (ln == "[StudentNo]")
                {
                    student.StudentNo = int.Parse(sr.ReadLine());
                }
                if (ln == "[[]]")
                {
                    students.Add(student);
                    student = null;
                }
            }

            Students = students;
            DataGridStudents.ItemsSource = Students; 
            DataGridStudents.Items.Refresh();
            sr.Close();
        }

        private void ButtonSaveXml_Click(object sender, RoutedEventArgs e)
        {
            using var fileStream = new FileStream("data.xml", FileMode.OpenOrCreate);
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            xmlSerializer.Serialize(fileStream, Students);
        }

        private void ButtonLoadXml_Click(object sender, RoutedEventArgs e)
        {
            using var fileStream = new FileStream("data.xml", FileMode.OpenOrCreate);
            var xmlSerializer = new XmlSerializer(typeof(List<Student>));
            if (xmlSerializer.Deserialize(fileStream) is List<Student> students && students.Count > 0 )
            {
                Students = students;
                DataGridStudents.ItemsSource = Students;
                DataGridStudents.Items.Refresh();
            }
        }

        private void ButtonSaveJson_Click(object sender, RoutedEventArgs e)
        {
            string jsonStr = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("data.json", jsonStr);
        }

        private void ButtonLoadJson_Click(object sender, RoutedEventArgs e)
        {
            string jsonStr = File.ReadAllText("data.json");
            Students = JsonSerializer.Deserialize<List<Student>>(jsonStr);
            DataGridStudents.ItemsSource = Students;
            DataGridStudents.Items.Refresh();
        }
    }
}