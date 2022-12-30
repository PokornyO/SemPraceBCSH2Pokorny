using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemPracePokorny.Model;
using SemPracePokorny.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SemPracePokorny.ViewModel
{
    public partial class ZakaznikViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
        private Zakaznik? _vybranyZakaznik;
        [ObservableProperty]
        public ObservableCollection<Zakaznik> zakaznici;
        public ZakaznikViewModel(ObservableCollection<Zakaznik> zakazniciPobocky)
        {
            zakaznici = zakazniciPobocky;
            Zakaznik zakaznik = new Zakaznik("Ondřej", "Pokorný", 0005131234, 734795453);
            zakaznici.Add(zakaznik);
        }



        [RelayCommand]
        private void Add()
        {
            Zakaznik zakaznik = new Zakaznik("Nový", "Zákazník", 0, 0);
            zakaznici.Add(zakaznik);
            _vybranyZakaznik = zakaznik;
            OnPropertyChanged("VybranyZakaznik");
            RemoveCommand.NotifyCanExecuteChanged();


        }

        [RelayCommand(CanExecute = "JeVybranZakaznik")]
        private void Remove()
        {
            if (_vybranyZakaznik != null)
            {
                zakaznici.Remove(_vybranyZakaznik);
                _vybranyZakaznik = null;

            }
        }

        private bool JeVybranZakaznik() => _vybranyZakaznik != null;

        [RelayCommand]
        private void Save()
        {

        }

        [RelayCommand]
        private void SearchLastname(string prijmeni)
        {
            var coll = CollectionViewSource.GetDefaultView(zakaznici);
            if (!string.IsNullOrWhiteSpace(prijmeni))
            {
                coll.Filter = c => ((Zakaznik)c).Prijmeni.ToLower().Contains(prijmeni.ToLower());
            }
            else
            {
                coll.Filter = null;
            }
        }
        [RelayCommand]
        private void SearchNumber(string rodneCislo)
        {
            var coll = CollectionViewSource.GetDefaultView(zakaznici);
            if (!string.IsNullOrWhiteSpace(rodneCislo))
            {
                coll.Filter = c => ((Zakaznik)c).RodneCislo.ToString().ToLower().Contains(rodneCislo.ToLower());
            }
            else
            {
                coll.Filter = null;
            }
        }


        [RelayCommand]
        private void Load(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                zakaznici.Add(new Zakaznik("Ondřej", "Pokorný", 0005131234, 734795453));

            }
        }
    }
}
