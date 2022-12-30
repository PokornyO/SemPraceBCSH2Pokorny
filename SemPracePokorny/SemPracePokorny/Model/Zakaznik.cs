using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    public class Zakaznik 
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string RodneCislo { get; set; }
        public string Telefon { get; set; }

        private static int idCount = 0;

        public Zakaznik(string jmeno, string prijmeni, string rodneCislo, string telefon)
        {
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.RodneCislo = rodneCislo;
            this.Telefon = telefon;
            Id = idCount++;
            
        }
        public Zakaznik(int fileID, string jmeno, string prijmeni, string rodneCislo, string telefon)
        {
            this.Jmeno = jmeno;
            this.Prijmeni = prijmeni;
            this.RodneCislo = rodneCislo;
            this.Telefon = telefon;
            Id = fileID;
            idCount = fileID + 1;
            
        }

        public override string? ToString()
        {
            return Jmeno + " " + Prijmeni + ", " + RodneCislo + ", " + Telefon;
        }
    }
}
