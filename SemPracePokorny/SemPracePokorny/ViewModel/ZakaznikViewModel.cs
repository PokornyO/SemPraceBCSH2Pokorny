using SemPracePokorny.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.ViewModel
{
    internal class ZakaznikViewModel
    {
        public MyICommand DeleteCommand { get; set; }
        private Zakaznik selectedZakaznik;
        public ObservableCollection<Zakaznik> Zakaznici { get; set; }
        public Zakaznik SelectedZakaznik
        {
            get { return selectedZakaznik; }

            set
            {
                selectedZakaznik = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public ZakaznikViewModel()
        {
            LoadZakaznici();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        private bool CanDelete()
        {
            return selectedZakaznik != null;
        }

        private void OnDelete()
        {
            Zakaznici.Remove(selectedZakaznik);
        }
        public void LoadZakaznici()
        {
            Zakaznici = new ObservableCollection<Zakaznik>();
        }
    }
}
