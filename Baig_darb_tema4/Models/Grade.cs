using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Models
{
    internal class Grade
    {
        public string Group { get; set; }
        public int StudentNo { get; set; }
        public int TrimesterNo { get; set; }
        public int[] Grades { get; set; }
        public Grade(string group, int studentNo, int trimesterNo, int[] grades)
        {
            Group = group;
            StudentNo = studentNo;
            TrimesterNo = trimesterNo;
            Grades = grades;
        }         
    }
}
