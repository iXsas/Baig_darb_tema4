using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Models
{
    public class DiaryItem
    {
        public string Group { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentNo { get; set; }
        public int TrimestNo { get; set; }
        public int[] TrimestGrades { get; set;}
        public int TrimestAVG { get; set; }
        public bool TrimestPass { get; set; }
        public int YearGrade { get; set; }
        public bool YearPass { get; set; }

        public DiaryItem(string group, string name,
        string surname, int studentNo, int trimestNo,
        int[] trimestGrades, bool trimestPass)
        {
            Group = group;
            Name = name;
            Surname = surname;
            StudentNo = studentNo;
            TrimestNo = trimestNo;
            TrimestGrades = trimestGrades;
            TrimestAVG = 0;
            TrimestPass = trimestPass;
            YearGrade = 0;
            YearPass = false;
        }
        public DiaryItem()
        {
        }

        //public DiaryItem(string group, string name, string surname, int studentNo, int v1, int[] grades, bool didPassTrim, bool v2)
        //{
        //    Group = group;
        //    Name = name;
        //    Surname = surname;
        //    StudentNo = studentNo;
        //}
    }
}
