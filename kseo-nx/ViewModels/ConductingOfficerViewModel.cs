using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ConductingOfficerViewModel :Screen
    {
        private string _officer = string.Empty;

        public string Officer
        {
            get { return _officer; }
            set
            {
                _officer = value;
                NotifyOfPropertyChange(()=>Officer);
            }
        }


        public void Remove()
        {
            var itemsViewModel = Parent as ConductingOfficersViewModel;
            if (itemsViewModel != null) itemsViewModel.RemoveItem(this);
        }
    }
}
