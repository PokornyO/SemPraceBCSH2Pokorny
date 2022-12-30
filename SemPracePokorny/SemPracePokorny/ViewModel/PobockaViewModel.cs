using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        [NotifyCanExecuteChangedFor(nameof(ShowBooksCommand))]
        [NotifyCanExecuteChangedFor(nameof(ShowCustomersCommand))]
        private Pobocka? _vybranaPobocka;
        [ObservableProperty]
        public ObservableCollection<Pobocka> pobocky;
        private string fileName = "Library.db";
        public PobockaViewModel()
        {
            pobocky = new ObservableCollection<Pobocka>();
            Load();
        }

       

        [RelayCommand]
        private void Add()
        {
            Pobocka pobocka = new Pobocka("Nová pobočka", "Nová pobočka", 0, 0);
            pobocky.Add(pobocka);
            _vybranaPobocka = pobocka;
            OnPropertyChanged("VybranaPobocka");
            RemoveCommand.NotifyCanExecuteChanged();
            ShowCustomersCommand.NotifyCanExecuteChanged();
            ShowBooksCommand.NotifyCanExecuteChanged();
            


        }

        [RelayCommand(CanExecute = "IsSelected")]
        private void Remove()
        {
            if (_vybranaPobocka != null)
            {
                pobocky.Remove(_vybranaPobocka);
                _vybranaPobocka = null;
                
            }
        }

        private bool IsSelected() => _vybranaPobocka != null;

        [RelayCommand]
        private void Save()
        {
            SerializerDeserializer serializerDeserializerser = new SerializerDeserializer(pobocky, fileName);
            serializerDeserializerser.Save();
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
        [RelayCommand(CanExecute = "IsSelected")]
        private void ShowBooks()
        {
            if(_vybranaPobocka!=null)
            {
                KnihaViewModel knihaVM = new KnihaViewModel(_vybranaPobocka.Knihy, _vybranaPobocka.Zakaznici);
                KnihaView knihaV = new KnihaView();
                knihaV.DataContext = knihaVM;
                knihaV.ShowDialog();
                
            }
        }
        [RelayCommand(CanExecute = "IsSelected")]
        private void ShowCustomers()
        {
            if (_vybranaPobocka != null)
            {
                ZakaznikViewModel knihaVM = new ZakaznikViewModel(_vybranaPobocka.Zakaznici, _vybranaPobocka.Knihy);
                ZakaznikView zakaznikV = new ZakaznikView();
                zakaznikV.DataContext = knihaVM;
                zakaznikV.ShowDialog();

            }
        }
        private void Load()
        {
            SerializerDeserializer serializerDeserializer = new SerializerDeserializer(pobocky, "Library.db");
            serializerDeserializer.Load();
            int maxPobockaId = 0;
            int maxZakaznikId = 0;
            int maxKnihaId = 0;
            foreach(Pobocka p in pobocky) {
                if(p.Id > maxPobockaId)
                {
                    maxPobockaId = p.Id;
                }
                foreach(Kniha k in p.Knihy)
                {
                    if(k.Id > maxKnihaId)
                    {
                        maxKnihaId = k.Id;
                    }
                }
                foreach (Zakaznik z in p.Zakaznici)
                {
                    if (z.Id > maxZakaznikId)
                    {
                        maxZakaznikId = z.Id;
                    }
                }
            }
            Pobocka pob = new Pobocka(++maxPobockaId, "", "", 0, 0);
            Zakaznik zak = new Zakaznik(++maxZakaznikId, "", "", "", "");
            Kniha kni = new Kniha(++maxKnihaId, "", "", "", Zanr.Drama);
            
        }
    }
}
