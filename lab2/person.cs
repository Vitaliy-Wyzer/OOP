using System;
using System.Collections.Generic;

namespace P {
	class Person {
		protected string _firstName;
        protected string _lastName;
        protected DateTime _dateOfBirth;

		public string FirstName 
		{ 
			get { return _firstName;  }
			set { _firstName = value; } 
		}
        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime DateOfBirth {
            get { return DateOfBirth; }
            set { DateOfBirth = value; }
        }
        public Person() {
			_firstName = "";
			_lastName = "";
			_dateOfBirth = DateTime.MinValue;
		}
		public Person(string firstName, string lastName, DateTime dateOfBirth) {
			_firstName = firstName;
			_lastName = lastName;
			_dateOfBirth = dateOfBirth;
		}

		public override string ToString() { 
			return $"Person | Name: {_firstName} {_lastName}, Date of birth: {_dateOfBirth}";
		}

        virtual public void Details() {
            Console.WriteLine(this.ToString());
        }

    }
}