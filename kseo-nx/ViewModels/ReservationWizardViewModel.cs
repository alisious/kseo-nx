using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ReservationWizardViewModel :Conductor<Screen>.Collection.OneActive
    {
        private int _activeItemIndex = 0;
        private bool _canGoNext;
        
        public ReservationWizardViewModel()
        {
            Items.Add(new PersonSearchViewModel());
            Items.Add(new RegistrationCardViewModel());
            Items.Add(new PersonViewModel());
            Items.Add(new ReservationViewModel());
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(Items[_activeItemIndex]);
        }

        public bool CanGoNext
        {
            get { return (_activeItemIndex < Items.Count - 1) && (ActiveItem as IWizardScreen).CanGoNext(); }
            set
            {
                _canGoNext = value;
                NotifyOfPropertyChange(()=>CanGoNext);
            }
        }

        public bool CanGoPrevious
        {
            get { return _activeItemIndex > 0; }
        }

        public void GoNext()
        {
            if (_activeItemIndex>=Items.Count-1) return;
            ActivateItem(Items[++_activeItemIndex]);
            NotifyOfPropertyChange(()=>CanGoNext);
            NotifyOfPropertyChange(()=>CanGoPrevious);
            NotifyOfPropertyChange(()=>CanFinish);
        }

        public void GoPrevious()
        {
            if (_activeItemIndex <= 0) return;
            ActivateItem(Items[--_activeItemIndex]);
            NotifyOfPropertyChange(() => CanGoNext);
            NotifyOfPropertyChange(() => CanGoPrevious);
            NotifyOfPropertyChange(() => CanFinish);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        public bool CanFinish
        {
            get { return (_activeItemIndex == Items.Count - 1); }
        }

        public void Finish()
        {
            //TODO Utrwalenie obiektu 
            TryClose(true);
        }

        public void CheckIfCanGoNext()
        {
            NotifyOfPropertyChange(() => CanGoNext);
        }

    }
}
