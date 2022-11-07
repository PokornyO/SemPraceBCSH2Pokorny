using SemPracePokorny.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemPracePokorny.ViewModel
{
    internal class KnihaViewModel
    {
        public MyICommand DeleteCommand { get; set; }
        private Kniha selectedKniha;
        public ObservableCollection<Kniha> Knihy { get; set; }
        public Kniha SelectedKniha
        {
            get { return selectedKniha; }

            set
            {
                selectedKniha = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
        public KnihaViewModel()
        {
            LoadPobocky();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        private bool CanDelete()
        {
            return SelectedKniha != null;
        }

        private void OnDelete()
        {
            Knihy.Remove(selectedKniha);
        }
        public void LoadPobocky()
        {
            Knihy = new ObservableCollection<Kniha>();
        }
    }
}
