using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1 {
    public class Grade {
        public string subject { get; set; }
        public float grade {  get; set; }

        public override string ToString() {
            return $"{subject}: {grade}";
        }
    }
}
