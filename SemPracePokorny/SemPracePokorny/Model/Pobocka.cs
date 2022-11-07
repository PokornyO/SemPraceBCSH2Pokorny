using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    internal class Pobocka : INotifyPropertyChanged
    {
        private int id;
        private string mesto;
        private string ulice;
        private int cisloPopisne;
        private int psc;
        private static int idCount = 0;
        
        public Pobocka(string mesto, string ulice, int cisloPopisne, int psc)
        {
            this.mesto = mesto;
            this.ulice = ulice;
            this.cisloPopisne = cisloPopisne;
            this.psc = psc;
            this.id = idCount++;
            this.Zakaznici = new List<Zakaznik>();
            this.Knihy = new List<Kniha>();
        }
        public Pobocka(int fileId, string mesto, string ulice, int cisloPopisne, int psc)
        {
            this.mesto = mesto;
            this.ulice = ulice;
            this.cisloPopisne = cisloPopisne;
            this.psc = psc;
            this.id = fileId;
            idCount = fileId++;
            this.Zakaznici = new List<Zakaznik>();
            this.Knihy = new List<Kniha>();
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }
        public string Mesto
        {
            get { return mesto; }
            set
            {
                if (mesto != value)
                {
                    mesto = value;
                    RaisePropertyChanged("Mesto");
                }
            }
        }
        public string Ulice
        {
            get { return ulice; }
            set
            {
                if (ulice != value)
                {
                    ulice = value;
                    RaisePropertyChanged("Ulice");
                }
            }
        }
        public int CisloPopisne
        {
            get { return cisloPopisne; }
            set
            {
                if (cisloPopisne != value)
                {
                    cisloPopisne = value;
                    RaisePropertyChanged("CisloPopisne");
                }
            }
        }
        public int Psc
        {
            get { return psc; }
            set
            {
                if (psc != value)
                {
                    psc = value;
                    RaisePropertyChanged("Psc");
                }
            }
        }
        public List<Zakaznik> Zakaznici { get; set; }
        public List<Kniha> Knihy { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
