﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class PersonWorkplaceViewModel :Screen
    {
        private bool _isValid;
        private string _name;
        private string _position;
        private string _city;
        private string _street;
        private string _streetNo;
        private string _placeNo;
        private string _postalCode;


        #region Public properties
        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                NotifyOfPropertyChange(() => IsValid);
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }

        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
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