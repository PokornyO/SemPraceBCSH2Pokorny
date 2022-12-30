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

namespace SemPracePokorny.ViewModel
{
    public partial class VypKnihyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Kniha> knihy;
        public VypKnihyViewModel(ObservableCollection<Kniha> knihy)
        {
            this.knihy = knihy;
            
        }
        [RelayCommand]
        public void Close(Window window)
        {
            window.Close();
        }
    }
}
