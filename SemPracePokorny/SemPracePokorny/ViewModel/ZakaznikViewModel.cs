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
        [NotifyCanExecuteChangedFor(nameof(ShowBooksCommand))]
        private Zakaznik? _vybranyZakaznik;
        [ObservableProperty]
        public ObservableCollection<Zakaznik> zakaznici;
        private ObservableCollection<Kniha> knihy;
        public ZakaznikViewModel(ObservableCollection<Zakaznik> zakazniciPobocky, ObservableCollection<Kniha> knihy)
        {
            zakaznici = zakazniciPobocky;
            this.knihy = knihy;
        }



        [RelayCommand]
        private void Add()
        {
            Zakaznik zakaznik = new Zakaznik("Nový", "Zákazník", "0", "0");
            zakaznici.Add(zakaznik);
            _vybranyZakaznik = zakaznik;
            OnPropertyChanged("VybranyZakaznik");
            RemoveCommand.NotifyCanExecuteChanged();
            ShowBooksCommand.NotifyCanExecuteChanged();


        }

        [RelayCommand(CanExecute = "IsCustomerSelected")]
        private void Remove()
        {
            if (_vybranyZakaznik != null)
            {
                zakaznici.Remove(_vybranyZakaznik);
                _vybranyZakaznik = null;

            }
        }

        private bool IsCustomerSelected() => _vybranyZakaznik != null;

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

        [RelayCommand(CanExecute = "IsCustomerSelected")]
        private void ShowBooks()
        {
            if(_vybranyZakaznik != null)
            {
                ObservableCollection<Kniha> vypKnihy = new ObservableCollection<Kniha>();
                foreach(Kniha kniha in knihy)
                {
                    if(kniha.Zakaznik?.Id == _vybranyZakaznik.Id)
                    {
                        vypKnihy.Add(kniha);
                    }
                }
                VypKnihyViewModel vypKnihyVm = new VypKnihyViewModel(vypKnihy);
                VypujceneKnihyView vypKnihyV = new VypujceneKnihyView();
                vypKnihyV.DataContext = vypKnihyVm;
                vypKnihyV.ShowDialog();
            }
        }
    }
}
