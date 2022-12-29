using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    internal class Pobocka
    {
        public int Id { get; set; }
        public string Mesto { get; set; }
        public string Ulice { get; set; }
        public int CisloPopisne { get; set; }
        public int Psc { get; set; }
        public ObservableCollection<Zakaznik> Zakaznici { get; set; }
        public ObservableCollection<Kniha> Knihy { get; set; }
        private static int idCount = 0;
        
        public Pobocka(string mesto, string ulice, int cisloPopisne, int psc)
        {
            this.Mesto = mesto;
            this.Ulice = ulice;
            this.CisloPopisne = cisloPopisne;
            this.Psc = psc;
            this.Id = idCount++;
            this.Zakaznici = new ObservableCollection<Zakaznik>();
            this.Knihy = new ObservableCollection<Kniha>();
        }
        public Pobocka(int fileId, string mesto, string ulice, int cisloPopisne, int psc)
        {
            this.Mesto = mesto;
            this.Ulice = ulice;
            this.CisloPopisne = cisloPopisne;
            this.Psc = psc;
            this.Id = fileId;
            idCount = fileId++;
            this.Zakaznici = new ObservableCollection<Zakaznik>();
            this.Knihy = new ObservableCollection<Kniha>();
        }

        
        

        
      
    }
}
