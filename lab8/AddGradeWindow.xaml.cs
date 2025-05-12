using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for AddGradeWindow.xaml
    /// </summary>
    public partial class AddGradeWindow : Window {

        public Grade Grade { get; set; }

        public AddGradeWindow(Grade grade = null)
        {
            InitializeComponent();
            if (grade != null) { 
                TextBoxSubject.Text = grade.subject;
                TextBoxGrade.Text = grade.grade.ToString();
            }
            Grade = grade ?? new Grade();
        }

        private void ButtonAddGrade_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(TextBoxSubject.Text, @"^\p{L}{1,12}$"))
            {
                MessageBox.Show("Invalid input data");
                return;
            }
            Grade.subject = TextBoxSubject.Text;
            if (!float.TryParse(TextBoxGrade.Text, out float grd)) {
                MessageBox.Show("Grade is NaN");
            }
            Grade.grade = grd;
            DialogResult = true;
        }
    }
}
