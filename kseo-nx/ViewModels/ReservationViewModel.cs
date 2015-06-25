using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ReservationViewModel :Screen
    {

        private BindingList<String> _organizationalUnits;
        private BindingList<String> _officers;
        private BindingList<String> _obtainingTargets; 
        
        public BindingList<string> OrganizationalUnits
        {
            get { return _organizationalUnits; }
            set
            {
                _organizationalUnits = value;
                NotifyOfPropertyChange(() => OrganizationalUnits);
            }
        }

        public BindingList<string> Officers
        {
            get { return _officers; }
            set
            {
                _officers = value;
                NotifyOfPropertyChange(() => Officers);
            }
        }

        public BindingList<string> ObtainingTargets
        {
            get { return _obtainingTargets; }
            set
            {
                _obtainingTargets = value;
                NotifyOfPropertyChange(() => ObtainingTargets);
            }
        }
    }
}
