using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemPracePokorny.Model;

namespace SemPracePokorny.ViewModel
{
    internal class PobockaViewModel
    {
        public MyICommand DeleteCommand { get; set; }
        private Pobocka selectedPobocka;
        public ObservableCollection<Pobocka> Pobocky { get; set; }
        public Pobocka SelectedPobocka
        {
            get { return selectedPobocka; }

            set
            {
                selectedPobocka = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public PobockaViewModel()
        {
            LoadPobocky();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        private bool CanDelete()
        {
            return SelectedPobocka != null;
        }

        private void OnDelete()
        {
            Pobocky.Remove(SelectedPobocka);
        }
        public void LoadPobocky()
        {
            Pobocky = new ObservableCollection<Pobocka>();
            Pobocky.Add(new Pobocka("Chotebor", "Na Chmelnici", 1596, 58301));
            Pobocky.Add(new Pobocka("Pardubice", "Na Chmelnici", 1596, 58301));
            Pobocky.Add(new Pobocka("Havličkův Brod", "Na Chmelnici", 1596, 58301));
        }
    }
}
