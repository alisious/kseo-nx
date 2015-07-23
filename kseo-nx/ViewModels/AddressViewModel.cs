using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class AddressViewModel :Screen
    {
       
        public Address CurrentAddress { get; set; }

        public AddressViewModel()
        {

        }

        public AddressViewModel(Address address)
        {
            CurrentAddress = address;
        }



        #region Public properties
        public bool IsCurrent
        {
            get { return CurrentAddress.IsCurrent; }
            set
            {
                CurrentAddress.IsCurrent = value;
                NotifyOfPropertyChange(() => IsCurrent);
            }
        }

        public string City
        {
            get { return CurrentAddress.City; }
            set
            {
                CurrentAddress.City = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get { return CurrentAddress.Street; }
            set
            {
                CurrentAddress.Street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string StreetNo
        {
            get { return CurrentAddress.StreetNo; }
            set
            {
                CurrentAddress.StreetNo = value;
                NotifyOfPropertyChange(() => StreetNo);
            }
        }

        public string PlaceNo
        {
            get { return CurrentAddress.PlaceNo; }
            set
            {
                CurrentAddress.PlaceNo = value;
                NotifyOfPropertyChange(() => PlaceNo);
            }
        }

        public string PostalCode
        {
            get { return CurrentAddress.PostalCode; }
            set
            {
                CurrentAddress.PostalCode = value;
                NotifyOfPropertyChange(() => PostalCode);
            }
        } 
        #endregion

       
        public void Remove()
        {
            var addressesViewModel = Parent as AddressesViewModel;
            if (addressesViewModel != null) addressesViewModel.RemoveAddress(this);
        }
    }
}
