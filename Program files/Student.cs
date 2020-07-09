using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTeachers
{
   public class Student
    {
        public string Fname { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string PersonalNum { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string FacNum { get; set; }

        public Student(string Name, string Surname, int Age, string PersonalNum, string Gender, DateTime Birthday, string FacNum)
        {
            this.Fname = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.PersonalNum = PersonalNum;
            this.Gender = Gender;
            this.Birthday = Birthday;
            this.FacNum = FacNum;
        }
        public Student()
        {
        }

        public string toString()
        {
            return Fname + " " + Surname + ", age: " + Age.ToString() + ", " + Gender + "\npersonal number: " + PersonalNum + ", birthday: " + Birthday.ToShortDateString() + ", Fac Num: " + FacNum;
        }
    }
}
