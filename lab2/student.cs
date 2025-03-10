using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P;
using G;

namespace S
{
    class Student : Person {
        private int _year;
        private int _group;
        private int _indexId;
        private List<Grade> _grades = new List<Grade>();

        public int Year {
            get { return _year; }
            set { _year = value; }
        }
        public int Group {
            get { return _group; }
            set { _group = value; }
        }
        public int IndexId {
            get { return _indexId; }
            set { _indexId = value; }
        }
        public Student() : base() {
            _year = 0;
            _group = 0;
            _indexId = 0;
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, int year, int group, int indexId)
            : base(firstName, lastName, dateOfBirth) {
            _year = year;
            _group = group;
            _indexId = indexId;
        }
        public override string ToString() {
            return base.ToString() +
                $" Year: {_year}, Group: {_group}, Index ID: {_indexId}";
        }
        public override void Details() {
            Console.WriteLine(this.ToString());
            foreach (Grade grade in _grades) {
                grade.Details();
                Console.WriteLine();

            }
            Console.WriteLine();
        }
        // zadanie 2
        public void AddGrade(string subjectName, double value, DateTime date) {
            _grades.Add(new Grade(subjectName, value, date));
        }
        public void AddGrade(Grade grade) {
            _grades.Add(grade);
        }
        public void DisplayGrades() {
            foreach (Grade g in _grades) {
                Console.WriteLine(g.ToString());
            }
        }
        public void DisplayGrades(string subjectName) {
            foreach (Grade g in _grades) {
                if (g.SubjectName == subjectName) {
                    Console.WriteLine(g.ToString());
                }
            }
        }
        public void DeleteGrade(string subjectName, double value, DateTime date) {
            foreach (Grade g in _grades.ToList()) {
                if (g.Value == value && g.Date == date && g.SubjectName == subjectName) {
                    _grades.Remove(g);
                }
            }
        }
        public void DeleteGrade(Grade grade) {
            if (_grades.Contains(grade)) _grades.Remove(grade);
        }
        public void DeleteGrades() {
            _grades.Clear();
        }
        public void DeleteGrades(string subjectName) {
            foreach (Grade g in _grades.ToList()) if (g.SubjectName == subjectName) this._grades.Remove(g);
        }
    }
}
