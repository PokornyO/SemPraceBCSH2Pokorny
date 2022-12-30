﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class KnihaViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RemoveCommand))]
        [NotifyCanExecuteChangedFor(nameof(BorrowCommand))]
        [NotifyCanExecuteChangedFor(nameof(ReturnCommand))]
        private Kniha? _vybranaKniha;
        [ObservableProperty]
        public ObservableCollection<Kniha> knihy;
        [ObservableProperty]
        private Zanr? zanrFiltr;
        private ObservableCollection<Zakaznik> zakaznici;


        public KnihaViewModel(ObservableCollection<Kniha> knihyPobocky, ObservableCollection<Zakaznik> zakazniciPobocky)
        {
            knihy= knihyPobocky;
            zakaznici = zakazniciPobocky;
            Kniha kniha = new Kniha("Harry Potter", "J.K.", "Rowling", Zanr.Fantasy);
            knihy.Add(kniha);
            OnPropertyChanged("Knihy");
        }
        




        [RelayCommand]
        private void Add()
        {
            Kniha kniha = new Kniha("Nová kniha", "Nová kniha", "Nová kniha", Zanr.Ostatní);
            knihy.Add(kniha);
            OnPropertyChanged("Knihy");
            _vybranaKniha = kniha;
            OnPropertyChanged("VybranaKniha");
            RemoveCommand.NotifyCanExecuteChanged();
            BorrowCommand.NotifyCanExecuteChanged();
            ReturnCommand.NotifyCanExecuteChanged();


        }

        [RelayCommand(CanExecute = "IsBookSelected")]
        private void Remove()
        {
            if (_vybranaKniha != null)
            {
                knihy.Remove(_vybranaKniha);
                _vybranaKniha = null;
                OnPropertyChanged("Knihy");
            }
        }

        private bool IsBookSelected() => _vybranaKniha != null;

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
        [RelayCommand(CanExecute = "IsBookSelected")]
        private void Borrow()
        {
            if(_vybranaKniha!= null && _vybranaKniha.Zakaznik == null)
            {
                VypujceniViewModel vypujceniVM = new VypujceniViewModel(zakaznici, _vybranaKniha);
                VypujceniView vypujceniV = new VypujceniView();
                vypujceniV.DataContext = vypujceniVM;
                vypujceniV.ShowDialog();
                _vybranaKniha = null;
                OnPropertyChanged("VybranaKniha");
                OnPropertyChanged("Kniy");
                
               
            }
        }
        [RelayCommand(CanExecute = "IsBookSelected")]
        private void Return()
        {
            if(_vybranaKniha!= null)
            {
                _vybranaKniha.Zakaznik = null;
                OnPropertyChanged("VybranaKniha");
                OnPropertyChanged("Kniy");
            }
        }
    }
}
