using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ProvisionWizardViewModel :Conductor<Screen>.Collection.OneActive
    {
        private int _activeItemIndex = 0;
        
        public ProvisionWizardViewModel()
        {
            Items.Add(new PersonSearchViewModel());
            Items.Add(new RegistrationCardViewModel());
            Items.Add(new PersonViewModel());
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            ActivateItem(Items[_activeItemIndex]);
        }

        public bool CanGoNext
        {
            get { return (_activeItemIndex < Items.Count - 1)
                            && ((Items[0] as PersonSearchViewModel).SelectedItem!=null); }
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
        }

        public void GoPrevious()
        {
            if (_activeItemIndex <= 0) return;
            ActivateItem(Items[--_activeItemIndex]);
            NotifyOfPropertyChange(() => CanGoNext);
            NotifyOfPropertyChange(() => CanGoPrevious);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        public void Finish()
        {
            //TODO Utrwalenie obiektu 
            TryClose(true);
        }

    }
}
