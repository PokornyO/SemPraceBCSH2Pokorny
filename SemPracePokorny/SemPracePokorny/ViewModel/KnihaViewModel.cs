using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemPracePokorny.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SemPracePokorny.ViewModel
{
    public partial class KnihaViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
        private Kniha? _vybranaKniha;
        [ObservableProperty]
        public ObservableCollection<Kniha> knihy;
        [ObservableProperty]
        private Zanr? zanrFiltr;


        public KnihaViewModel(ObservableCollection<Kniha> knihyPobocky)
        {
            knihy= knihyPobocky;
            Kniha kniha = new Kniha("Harry Potter", "J.K.", "Rowling", Zanr.Fantasy);
            knihy.Add(kniha);
            OnPropertyChanged("Knihy");
        }
        




        [RelayCommand]
        private void Add()
        {
            Kniha kniha = new Kniha("Harry Potter", "J.K.", "Rowling", Zanr.Fantasy);
            knihy.Add(kniha);
            OnPropertyChanged("knihy");
            _vybranaKniha = kniha;
            OnPropertyChanged("VybranaKniha");


        }

        [RelayCommand(CanExecute = "JeVybranaKniha")]
        private void Remove()
        {
            if (_vybranaKniha != null)
            {
                knihy.Remove(_vybranaKniha);
                _vybranaKniha = null;
                OnPropertyChanged("Knihy");
            }
        }

        private bool JeVybranaKniha() => _vybranaKniha != null;

        [RelayCommand]
        private void Save()
        {

        }

        [RelayCommand]
        private void SearchLastname(string prijmeni)
        {
            var coll = CollectionViewSource.GetDefaultView(knihy);
            if (!string.IsNullOrWhiteSpace(prijmeni))
            {
                coll.Filter = c => ((Kniha)c).PrijmeniAutora.ToLower().Contains(prijmeni.ToLower());
            }        
            else
            {
                coll.Filter = null;
            }   
            OnPropertyChanged("Knihy");
        }
        [RelayCommand]
        private void SearchName(string nazev)
        {
            var coll = CollectionViewSource.GetDefaultView(knihy);
            if (!string.IsNullOrWhiteSpace(nazev))
            {
                coll.Filter = c => ((Kniha)c).Nazev.ToLower().Contains(nazev.ToLower());
            }  
            else
            {
                coll.Filter = null;
            } 
            OnPropertyChanged("Knihy");
        }
        [RelayCommand]
        private void SearchGenre(Zanr? zanr)
        {
            var coll = CollectionViewSource.GetDefaultView(knihy);
            if (zanr!=null)
            {
                coll.Filter = c => ((Kniha)c).Zanr.Equals(zanr);
            }          
            else
            {
                coll.Filter = null;
            }
            zanrFiltr = null;
            OnPropertyChanged("Knihy");
            OnPropertyChanged("ZanrFiltr");
        }
        [RelayCommand]
        private void Load(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                knihy.Add(new Kniha("Harry Potter", "J.K.", "Rowling", Zanr.Fantasy));
                OnPropertyChanged("Knihy");
            }
        }
    }
}
