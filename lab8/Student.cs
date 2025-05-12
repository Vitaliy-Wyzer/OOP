﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1 {
    public class Student {
        public string FirstName { get; set; }
        public string SurName {  get; set; }
        public string Faculty {  get; set; }
        public int StudentNo { get; set; }
        public List<Grade> Grades { get; set; } = new List<Grade>();
        public string JoinedGrades => String.Join("; ", Grades);
    }
}
