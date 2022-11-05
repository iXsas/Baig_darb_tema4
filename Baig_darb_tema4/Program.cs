using Baig_darb_tema4.Models;
using Baig_darb_tema4.Repository;
using Baig_darb_tema4.Service;
using Baig_darb_tema4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using System.CodeDom.Compiler;

namespace Baig_darb_tema4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Studentu dienynas");
            StudentRepository _StudentRepo = new StudentRepository();
            List<Student> students = new List<Student>(); students = _StudentRepo.Retrieve();

            GradesRepository _GradesRepo = new GradesRepository();
            List<Grade> grades = new List<Grade>(); grades = _GradesRepo.Retrieve();

            //  GradesService _GradesService = new GradesService();
            DiaryRepository _DiaryRepo = new DiaryRepository();
            ReportGenerator _ReportRepo = new ReportGenerator();
            //  ReportItem _ReportItem = new ReportItem();
            //for (double i = 0.1; i < 9.98; i += 0.1)
            //{
            //    Console.WriteLine(" {0} = {1} , {2} ",i, Math.Round(i,MidpointRounding.ToEven), Math.Round(i,MidpointRounding.AwayFromZero));
            //}

            CreateDiary();

            while (true)
            {
                Console.WriteLine("Norint pridėti nauja irasa spauskite:  + ");
                Console.WriteLine("Norint pasalinti irasa spauskite:  - ");
                Console.WriteLine("Norint suformuoti ataskaita spauskite:  g ");
                Console.WriteLine("Norint išsaugoti suformuota ataskaita spauskite:  s ");
                string opera = Console.ReadLine();
                switch (opera)
                {
                    case "+":
                        AddItemManual();
                        break;
                    case "g":
                        GenerateReport();
                        break;
                    case "s":
                        DateTime now = DateTime.Now;
                        Console.WriteLine($"Saugomas ataskaitos failas...{now}");
                        Thread.Sleep(1000); Console.Write($"******"); Thread.Sleep(100); Console.Write($"******"); Thread.Sleep(100);
                        if (File.Exists("ataskaita.txt")) { File.Delete("ataskaita.txt"); }
                        var StudList = _DiaryRepo.Retrieve();
                     //   File.AppendAllText("ataskaita.txt", $"Ataskaita buvo sugeneruota {now} \n");
                        Console.WriteLine("0----5---10---15---20---25---30---35---40---45---50---55---60---65---70---75---80---85---90---95--100 Liniuotė" + "\n");
                        String data = String.Format("{0,-3} {1,-6} {2,-13} {3,-15} {4,-10} {5,-10} {6,-20} {7,-10} {8,-10} {9,-10} {10,-10}\n\n",
                        "Nr.", "Grupe", "Vardas", "Pavarde", "Stud. Nr.", "Trim Nr.", "Trim paz.", "Trim Avg", "Trim Pass", "Year Grade", "Year Pass");
                        int j = 1;
                        for (int i = 0; i < StudList.Count; i++)
                        {
                            string trimgr = _GradesRepo.ReturnGradesInString(StudList[i].TrimestGrades);
                            string metpaz, metPASS;
                            if (j == 3) { metpaz = StudList[i].YearGrade.ToString(); metPASS = StudList[i].YearPass.ToString(); j = 1; }
                            else { metpaz = " "; metPASS = ""; j++; }

                            data += String.Format("{0,-3} {1,-6} {2,-13} {3, -15} {4,-10} {5,-10} {6,-20} {7,-10} {8,-10} {9,-10} {10,-10}",
                            i, StudList[i].Group, StudList[i].Name, StudList[i].Surname, StudList[i].StudentNo, StudList[i].TrimestNo,
                            trimgr, StudList[i].TrimestAVG, StudList[i].TrimestPass, metpaz, metPASS);
                            Console.WriteLine($"{data}");
                            File.AppendAllText("ataskaita.txt", $" {data}\n"); data = "";                           
                        }
                        Console.WriteLine($"Ataskaita buvo issaugota");
                        break;
                    case "/":
                        Console.WriteLine($"empty");
                        break;
                }

                Console.WriteLine("\nAr norite testi y/n");
                if (Console.ReadLine() == "y")
                {
                    continue;
                }

                else { Console.WriteLine("Dienynas uždaromas viso gero..."); Console.Write($"\n******");
                    Thread.Sleep(1500); Console.Write($"******");Thread.Sleep(1500); Console.Write($"******"); Thread.Sleep(1500); break; }
            }


            void CreateDiary()
            {
                for (int i = 0; i < students.Count; i++)//studentu skaiciaus skaitiklis
                {
                    double total = 0;
                    for (int j = 0; j < 3; j++) // trimestru skaitiklis
                    {
                        Student x = students[i];
                        bool didPassTrim = _GradesRepo.DidPassTrim(grades[j * 10 + i].Grades);
                        int[] grade_array = grades[j * 10 + i].Grades; 
                        DiaryItem NewItem = new DiaryItem(x.Group, x.Name, x.Surname, x.StudentNo, j + 1, grade_array,
                        didPassTrim); NewItem.TrimestAVG = _GradesRepo.CountTrimtAvg(grade_array);
                        total += NewItem.TrimestAVG;
                        if (j == 2)
                        {
                            NewItem.YearGrade = Convert.ToInt32(Math.Round((total / 3), MidpointRounding.AwayFromZero));
                            NewItem.YearPass = _GradesRepo.DidPassYear(NewItem.YearGrade);
                        }
                        
                        _DiaryRepo.AddItem(NewItem);
                    }
                }
            }

            void GenerateReport() 
            {
                var StudList = _DiaryRepo.Retrieve();

                Console.WriteLine("0----5---10---15---20---25---30---35---40---45---50---55---60---65---70---75---80---85---90---95--100 Liniuotė" + "\n");
                String data = String.Format("{0,-3} {1,-6} {2,-13} {3,-15} {4,-10} {5,-10} {6,-20} {7,-10} {8,-10} {9,-10} {10,-10} \n\n",
                "Nr.", "Grupe", "Vardas", "Pavarde", "Stud. Nr.", "Trim Nr.", "Trim paz.", "Trim Avg", "Trim Pass", "Year Grade", "Year Pass");
                int j = 1;
                for (int i = 0; i < StudList.Count; i++)
                {
                    string trimgr = _GradesRepo.ReturnGradesInString(StudList[i].TrimestGrades);
                  //  string avg = StudList[i].TrimestAVG.ToString();
                    string metpaz , metPASS ;
                    if (j == 3) { metpaz = StudList[i].YearGrade.ToString(); metPASS = StudList[i].YearPass.ToString(); j = 1; }
                    else { metpaz = " "; metPASS = ""; j++; }

                    data += String.Format("{0,-3} {1,-6} {2,-13} {3, -15} {4,-10} {5,-10} {6,-20} {7,-10} {8,-10} {9,-10} {10,-10}",
                    i, StudList[i].Group, StudList[i].Name, StudList[i].Surname, StudList[i].StudentNo, StudList[i].TrimestNo,
                    trimgr, StudList[i].TrimestAVG, StudList[i].TrimestPass, metpaz, metPASS);
                    Console.WriteLine($"{data}"); data = "";
                
                }
               
            }

            void AddItemManual() 
            {
                Console.WriteLine($"Iveskite studento grupe ir spauskite enter");
                string grupe = Console.ReadLine();
                Console.WriteLine($"Iveskite studento varda ir spauskite enter");
                string vardas = Console.ReadLine();
                Console.WriteLine($"Iveskite studento pavarde ir spauskite enter");
                string pavarde = Console.ReadLine();
                Console.Write($"Iveskite studento saraso numeri ir spauskite enter");
                int SarasoNo = Convert.ToInt32(Console.ReadLine());
                Console.Write($"\nIveskite studento trimestro numeri ir spauskite enter");
                int TrimestNo = Convert.ToInt32(Console.ReadLine());
                Console.Write($"\nIveskite studento pazymiu {TrimestNo} trimestro kieki ir spauskite enter");
                int kiekis = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Iveskite studento pazymius  ir spauskite enter, pazymius veskite skaičius su tarpais\n");
                int[] pazymiu_mas = new int[kiekis];
                for (int i = 0; i < kiekis; i++)
                {
                    Console.Write("Iveskite {0} pazymy : ", i + 1);
                    pazymiu_mas[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine($"Ivesto studento grupe {grupe} vardas {vardas} pavarde {pavarde} ir saraso numeris {SarasoNo}");
                Console.Write($" {TrimestNo} trimestro ivesti pazymiai: "); _GradesRepo.PrintGrades(pazymiu_mas);

                DiaryItem NewItem = new DiaryItem(grupe, vardas, pavarde, SarasoNo, TrimestNo, pazymiu_mas,
               _GradesRepo.DidPassTrim(pazymiu_mas)); NewItem.TrimestAVG = _GradesRepo.CountTrimtAvg(pazymiu_mas);
                _DiaryRepo.AddItem(NewItem);
            }
        }
    }
}
