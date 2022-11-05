using Baig_darb_tema4.Models;
using Baig_darb_tema4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Services
{
    internal class ReportGenerator
    {
        GradesRepository gradesRepository;
        StudentRepository studentRepository;
        public ReportGenerator(GradesRepository gradesRepo, StudentRepository studentRepo)
        {
            //gradesRepository = gradesRepo;
            //studentRepository = studentRepo;
            //ReportItem = reportItem;
        }

        public ReportGenerator()
        {           
            

        }

        //public List<ReportItem> ReportList = new List<ReportItem>();

        //public void AddItem(ReportItem x)
        //{
        //    ReportList.Add(x);
        //}

        //public List<ReportItem> Retrieve()
        //{
        //    return ReportList;//atiduodu visa ataskaitos sarasa
        //}


    }
}