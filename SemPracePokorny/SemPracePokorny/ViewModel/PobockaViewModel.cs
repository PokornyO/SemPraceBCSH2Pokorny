using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemPracePokorny.Model;
using SemPracePokorny.View;

namespace SemPracePokorny.ViewModel
{
    internal partial class PobockaViewModel : ObservableObject
    {
        

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
        private Pobocka? _vybranaPobocka;
        [ObservableProperty]
        public ObservableCollection<Pobocka> pobocky;
        public PobockaViewModel()
        {
            pobocky = new ObservableCollection<Pobocka>();
            Pobocka pobocka = new Pobocka("Pardubice", "Češkova", 1596, 53002);
            Pobocky.Add(pobocka);
        }

        

        [RelayCommand]
        private void Add()
        {
            Pobocka pobocka = new Pobocka("Pardubice", "Češkova", 1596, 53002);
            pobocky.Add(pobocka);
            _vybranaPobocka = pobocka;
            OnPropertyChanged("VybranaPobocka");
            RemoveCommand.NotifyCanExecuteChanged();
            


        }

        [RelayCommand(CanExecute = "JeVybranaPobocka")]
        private void Remove()
        {
            if (_vybranaPobocka != null)
            {
                pobocky.Remove(_vybranaPobocka);
                _vybranaPobocka = null;
                
            }
        }

        private bool JeVybranaPobocka() => _vybranaPobocka != null;

        [RelayCommand]
        private void Save()
        {
            
        }

        [RelayCommand]
        private void SearchLastname(string mesto)
        {
            var coll = CollectionViewSource.GetDefaultView(pobocky);
            if (!string.IsNullOrWhiteSpace(mesto))
            {
                coll.Filter = c => ((Pobocka)c).Mesto.ToLower().Contains(mesto.ToLower());
            } 
            else
            {
                coll.Filter = null;
            }
                
        }
        [RelayCommand]
        private void ShowBooks()
        {
            if(_vybranaPobocka!=null)
            {
                KnihaViewModel knihaVM = new KnihaViewModel(_vybranaPobocka.Knihy);
                KnihaView knihaV = new KnihaView();
                knihaV.DataContext = knihaVM;
                knihaV.Show();
                
            }
        }
        [RelayCommand]
        private void ShowCustomers()
        {
            if (_vybranaPobocka != null)
            {
                ZakaznikViewModel knihaVM = new ZakaznikViewModel(_vybranaPobocka.Zakaznici);
                ZakaznikView zakaznikV = new ZakaznikView();
                zakaznikV.DataContext = knihaVM;
                zakaznikV.Show();

            }
        }
        [RelayCommand]
        private void Load(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                pobocky.Add(new Pobocka("Pardubice", "Češkova", 1596, 53002));
                
            }
        }
    }
}
