using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    public class Kniha
    {
        public int Id { get; set; }
        
        public string Nazev { get; set; }
        public string JmenoAutora { get; set; }
        public string PrijmeniAutora { get; set; }
        
        public Zanr Zanr { get; set; }
        
        public Zakaznik? Zakaznik { get; set; }
        private static int idCount = 0;

        public Kniha(string jmeno, string jmenoAutora, string prijmeniAutora, Zanr zanr)
        {
            this.Nazev = jmeno;
            this.JmenoAutora = jmenoAutora;
            this.PrijmeniAutora = prijmeniAutora;
            this.Zanr = zanr;
            this.Id = idCount++;
        }
        public Kniha(int fileId, string jmeno, string jmenoAutora, string prijmeniAutora, Zanr zanr)
        {
            this.Nazev = jmeno;
            this.JmenoAutora = jmenoAutora;
            this.PrijmeniAutora = prijmeniAutora;
            this.Zanr = zanr;
            this.Id = fileId;
            idCount = fileId++;
        }

        
    }
}
