using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.Model
{
    internal class Kniha : INotifyPropertyChanged
    {
        private int id;
        private string jmeno;
        private string jmenoAutora;
        private string prijmeniAutora;
        private Zanr zanr;
        private DateOnly datumVydani;
        private Zakaznik? zakaznik;
        private static int idCount = 0;

        public Kniha(string jmeno, string jmenoAutora, string prijmeniAutora, Zanr zanr, DateOnly date)
        {
            this.jmeno = jmeno;
            this.jmenoAutora = jmenoAutora;
            this.prijmeniAutora = prijmeniAutora;
            this.zanr = zanr;
            this.datumVydani = date;
            this.id = idCount++;
        }
        public Kniha(int fileId, string jmeno, string jmenoAutora, string prijmeniAutora, Zanr zanr, DateOnly date)
        {
            this.jmeno = jmeno;
            this.jmenoAutora = jmenoAutora;
            this.prijmeniAutora = prijmeniAutora;
            this.zanr = zanr;
            this.datumVydani = date;
            this.id = fileId;
            idCount = fileId++;
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
        public string JmenoAutora
        {
            get { return jmenoAutora; }
            set
            {
                if (jmenoAutora != value)
                {
                    jmenoAutora = value;
                    RaisePropertyChanged("JmenoAutora");
                }
            }
        }
        public string PrijmeniAutora
        {
            get { return prijmeniAutora; }
            set
            {
                if (prijmeniAutora != value)
                {
                    prijmeniAutora  = value;
                    RaisePropertyChanged("PrijmeniAutora");
                }
            }
        }
        public Zanr Zanr
        {
            get { return zanr; }
            set
            {
                if (zanr != value)
                {
                    zanr = value;
                    RaisePropertyChanged("Zanr");
                }
            }
        }
        public DateOnly DatumVydani
        {
            get { return datumVydani; }
            set
            {
                if (datumVydani != value)
                {
                    datumVydani = value;
                    RaisePropertyChanged("DatumVydani");
                }
            }
        }
        public Zakaznik Zakaznik
        {
            get { return zakaznik; }
            set
            {
                if (zakaznik != value)
                {
                    zakaznik = value;
                    RaisePropertyChanged("Zakaznik");
                }
            }
        }


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
