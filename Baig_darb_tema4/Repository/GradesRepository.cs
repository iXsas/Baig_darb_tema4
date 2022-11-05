using Baig_darb_tema4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;


namespace Baig_darb_tema4.Repository
{
    internal class GradesRepository//internal
    {
        public List<Grade> GradeList { get; private set; }//
        public GradesRepository()
        {
            GradeList = new List<Grade>();
            int[] grades = { 6, 9, 9, 10, 7, 10 }; int[] grades2 = { 7, 7, 6, 5, 10, 7 };
            int[] grades3 = { 5, 5, 6, 6, 8, 6 }; int[] grades4 = { 7, 7, 8, 7, 7, 9 };
            int[] grades5 = { 10, 10, 9, 9, 7, 9 }; int[] grades6 = { 8, 6, 7, 10, 6, 6 };
            int[] grades7 = { 7, 7, 8, 8, 9, 10 }; int[] grades8 = { 7, 8, 8, 9, 8, 6 };
            int[] grades9 = { 4, 2, 4, 5, 4, 6 }; int[] grades10 = { 9, 5, 10, 8, 7, 10 };
            //trimesterNo 1
            GradeList.Add(new Grade("GR22A", 1, 1, grades));
            GradeList.Add(new Grade("GR22A", 2, 1, grades2));
            GradeList.Add(new Grade("GR22A", 3, 1, grades3));
            GradeList.Add(new Grade("GR22A", 4, 1, grades4));
            GradeList.Add(new Grade("GR22A", 5, 1, grades5));
            GradeList.Add(new Grade("GR22B", 1, 1, grades6));
            GradeList.Add(new Grade("GR22B", 2, 1, grades7));
            GradeList.Add(new Grade("GR22B", 3, 1, grades8));
            GradeList.Add(new Grade("GR22B", 4, 1, grades9));
            GradeList.Add(new Grade("GR22B", 5, 1, grades10));
            //trimesterNo 2
            GradeList.Add(new Grade("GR22A", 1, 2, grades));
            GradeList.Add(new Grade("GR22A", 2, 2, grades2));
            GradeList.Add(new Grade("GR22A", 3, 2, grades3));
            GradeList.Add(new Grade("GR22A", 4, 2, grades4));
            GradeList.Add(new Grade("GR22A", 5, 2, grades5));
            GradeList.Add(new Grade("GR22B", 1, 2, grades6));
            GradeList.Add(new Grade("GR22B", 2, 2, grades7));
            GradeList.Add(new Grade("GR22B", 3, 2, grades8));
            GradeList.Add(new Grade("GR22B", 4, 2, grades9));
            GradeList.Add(new Grade("GR22B", 5, 2, grades10));
            //trimesterNo 3
            GradeList.Add(new Grade("GR22A", 1, 3, grades));
            GradeList.Add(new Grade("GR22A", 2, 3, grades2));
            GradeList.Add(new Grade("GR22A", 3, 3, grades3));
            GradeList.Add(new Grade("GR22A", 4, 3, grades4));
            GradeList.Add(new Grade("GR22A", 5, 3, grades5));
            GradeList.Add(new Grade("GR22B", 1, 3, grades6));
            GradeList.Add(new Grade("GR22B", 2, 3, grades7));
            GradeList.Add(new Grade("GR22B", 3, 3, grades8));
            GradeList.Add(new Grade("GR22B", 4, 3, grades9));
            GradeList.Add(new Grade("GR22B", 5, 3, grades10));
        }
        public List<Grade> Retrieve()
        {
            return GradeList;
        }
        public int CountTrimtAvg(int[] pazymiu_masyvas)
        {        
           return (int)Math.Round(pazymiu_masyvas.Average(), MidpointRounding.AwayFromZero);
        }
        public bool DidPassTrim(int[] pazymiu_masyvas)
        { bool ArIslaikeTrim = false;
            if (pazymiu_masyvas.Average() > 4) { ArIslaikeTrim = true; }
            return ArIslaikeTrim;
        }
        public bool DidPassYear(int trimestru_vidurkis)
        {
            bool ArIslaikeYear = false;
            if (trimestru_vidurkis > 4) { ArIslaikeYear = true; }
            return ArIslaikeYear;
        }
        public void PrintGrades(int[] toPrint)
        {
            foreach (int x in toPrint)
            {
                Console.Write($" {x}");
            }
        }
        public string ReturnGradesInString(int[] toPrint)
        {
            string[] result = toPrint.Select(i => i.ToString()).ToArray();
            
            return String.Join(", ", result);
        }
    }
}
