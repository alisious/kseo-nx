using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class AddressViewModel :Screen
    {
        private bool _isCurrent;
        private string _city;
        private string _street;
        private string _streetNo;
        private string _placeNo;
        private string _postalCode;


        #region Public properties
        public bool IsCurrent
        {
            get { return _isCurrent; }
            set
            {
                _isCurrent = value;
                NotifyOfPropertyChange(() => IsCurrent);
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public string StreetNo
        {
            get { return _streetNo; }
            set
            {
                _streetNo = value;
                NotifyOfPropertyChange(() => StreetNo);
            }
        }

        public string PlaceNo
        {
            get { return _placeNo; }
            set
            {
                _placeNo = value;
                NotifyOfPropertyChange(() => PlaceNo);
            }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                _postalCode = value;
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
