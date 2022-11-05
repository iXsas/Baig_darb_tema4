using Baig_darb_tema4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Repository
{
    internal class StudentRepository
    {
        public List<Student> StudList { get; private set; }
        public StudentRepository()
        {
            StudList = new List<Student>();
            StudList.Add(new Student("Adomas", "Adomaitis", "GR22A", 1));
            StudList.Add(new Student("Jonas", "Jonaitis", "GR22A", 2));
            StudList.Add(new Student("Agne", "Agnaite", "GR22A", 3));
            StudList.Add(new Student("Laura", "Lauraite", "GR22A", 4));
            StudList.Add(new Student("Gabija", "Gabijaite", "GR22A", 5));
            StudList.Add(new Student("Juozas", "Juozaitis", "GR22B", 1));
            StudList.Add(new Student("Domas", "Domaitis", "GR22B", 2));
            StudList.Add(new Student("Ieva", "Ievaite", "GR22B", 3));
            StudList.Add(new Student("Tomas", "Tomaitis", "GR22B", 4));
            StudList.Add(new Student("Monika", "Monikaite", "GR22B", 5));
        }
        public List<Student> Retrieve()
        {
            return StudList;
        }
    }
}
