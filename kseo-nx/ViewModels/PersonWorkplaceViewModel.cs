using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class PersonWorkplaceViewModel :Screen
    {
      

        public PersonWorkplaceViewModel()
        {
        }

        public PersonWorkplaceViewModel(Workplace currentWorkplace)
        {
            CurrentWorkplace = currentWorkplace;
        }

        public Workplace CurrentWorkplace { get; set; }

        #region Public properties
        public bool IsCurrent
        {
            get { return CurrentWorkplace.IsCurrent; }
            set
            {
                CurrentWorkplace.IsCurrent = value;
                NotifyOfPropertyChange(() => IsCurrent);
            }
        }

        public string City
        {
            get { return CurrentWorkplace.City; }
            set
            {
                CurrentWorkplace.City = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get { return CurrentWorkplace.Street; }
            set
            {
                CurrentWorkplace.Street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string StreetNo
        {
            get { return CurrentWorkplace.StreetNo; }
            set
            {
                CurrentWorkplace.StreetNo = value;
                NotifyOfPropertyChange(() => StreetNo);
            }
        }

        public string PlaceNo
        {
            get { return CurrentWorkplace.PlaceNo; }
            set
            {
                CurrentWorkplace.PlaceNo = value;
                NotifyOfPropertyChange(() => PlaceNo);
            }
        }

        public string PostalCode
        {
            get { return CurrentWorkplace.PostalCode; }
            set
            {
                CurrentWorkplace.PostalCode = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        }

        public string Name
        {
            get { return CurrentWorkplace.Name; }
            set
            {
                CurrentWorkplace.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Position
        {
            get { return CurrentWorkplace.Position; }
            set
            {
                CurrentWorkplace.Position = value;
                NotifyOfPropertyChange(() => Position);
            }
        }

        #endregion
        
        public void Remove()
        {
            var personWorkplacesViewModel = Parent as PersonWorkplacesViewModel;
            if (personWorkplacesViewModel != null) personWorkplacesViewModel.RemoveWorkplace(this);
        }
    }
}
