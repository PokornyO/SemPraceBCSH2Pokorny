using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemPracePokorny.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SemPracePokorny.ViewModel
{
    public partial class VypujceniViewModel : ObservableObject
    {
        [ObservableProperty]
        public Zakaznik? _vybranyZakaznik;
        [ObservableProperty]
        private ObservableCollection<Zakaznik> zakaznici;
        private Kniha vypujcenaKniha;

        public VypujceniViewModel(ObservableCollection<Zakaznik> zakaznici, Kniha kniha)
        {
            this.zakaznici = zakaznici;
            vypujcenaKniha = kniha;
        }
        [RelayCommand]
        public void Close(Window window)
        {
            if(_vybranyZakaznik != null)
            {
                vypujcenaKniha.Zakaznik = _vybranyZakaznik;
            }
            window.Close();
        }
    }
}
