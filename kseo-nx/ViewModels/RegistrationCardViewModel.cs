using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class RegistrationCardViewModel :Screen, IWizardScreen
    {
        private string _regNum = String.Empty;

        public string RegNum
        {
            get { return _regNum; }
            set
            {
                _regNum = value;
                NotifyOfPropertyChange(() => RegNum);
                if (Parent != null)
                    (Parent as ReservationWizardViewModel).CheckIfCanGoNext();
                
            }
        }

        public bool CanGoNext()
        {
           return !String.IsNullOrWhiteSpace(RegNum);
        }
    }
}
