using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    internal class Zakaznik : INotifyPropertyChanged
    {
        private int id;
        private string jmeno;
        private string prijmeni;
        private int rodneCislo;
        private int telefon;
        private static int idCount = 0;

        public Zakaznik(string jmeno, string prijmeni, int rodneCislo, int telefon)
        {
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.rodneCislo = rodneCislo;
            this.telefon = telefon;
            id = idCount++;
            this.VypujceneKnihy = new List<Kniha>();
        }
        public Zakaznik(int fileID, string jmeno, string prijmeni, int rodneCislo, int telefon)
        {
            this.jmeno = jmeno;
            this.prijmeni = prijmeni;
            this.rodneCislo = rodneCislo;
            this.telefon = telefon;
            id = fileID;
            idCount = fileID + 1;
            this.VypujceneKnihy = new List<Kniha>();
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
        public string Jmeno
        {
            get { return jmeno; }
            set
            {
                if (jmeno != value)
                {
                    jmeno = value;
                    RaisePropertyChanged("Jmeno");
                }
            }
        }
        public string Prijmeni
        {
            get { return prijmeni; }
            set
            {
                if (prijmeni != value)
                {
                    prijmeni = value;
                    RaisePropertyChanged("Prijmeni");
                }
            }
        }
        public int RodneCislo
        {
            get { return rodneCislo; }
            set
            {
                if (rodneCislo != value)
                {
                    rodneCislo = value;
                    RaisePropertyChanged("RodneCislo");
                }
            }
        }
        public int Telefon
        {
            get { return telefon; }
            set
            {
                if (telefon != value)
                {
                    telefon = value;
                    RaisePropertyChanged("Telefon");
                }
            }
        }
        
        public List<Kniha> VypujceneKnihy { get; set; }


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
