using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Models
{
    internal class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public int StudentNo { get; set; }

        public Student(string name, string surname, string group, int studentNo)
        {
            Name = name;
            Surname = surname;
            Group = group;
            StudentNo = studentNo;
        }
    }
}
