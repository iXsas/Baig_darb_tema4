using Baig_darb_tema4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baig_darb_tema4.Repository
{
    internal class DiaryRepository
    {
        public List<DiaryItem> DiaryList = new List<DiaryItem>();

        public void AddItem(DiaryItem x)
        {
            DiaryList.Add(x);
        }
        public List<DiaryItem> Retrieve()
        {
            return DiaryList;//ivykiulist
        }
    }
}
