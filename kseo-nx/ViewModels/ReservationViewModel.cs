using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Helpers;
using kseo_nx.Models;

namespace kseo_nx.ViewModels
{
    public class ReservationViewModel :Screen
    {

        #region Fields
        private string _registrationUserName = string.Empty;
        private string _registrationDate = string.Empty;
        private string _registrationNo;
        private string _purpose = string.Empty;
        private string _startDate;
        private string _plannedEndDate;

        private BindingList<DictItem> _purposes;
        private ConductingUnitsViewModel _conductingUnits;
        private ConductingOfficersViewModel _conductingOfficers; 
        private ReservationEndViewModel _reservationEnd;
        private string _reservationEndVisibility;
        private bool _isEnded = false;
        
        #endregion

        #region Public properties
        public string RegistrationUserName
        {
            get { return _registrationUserName; }
            set
            {
                _registrationUserName = value;
                NotifyOfPropertyChange(() => RegistrationUserName);
            }
        }

        public string RegistrationDate
        {
            get { return _registrationDate; }
            set
            {
                _registrationDate = value;
                NotifyOfPropertyChange(() => RegistrationDate);
            }
        }
        
        public ConductingUnitsViewModel ConductingUnits
        {
            get { return _conductingUnits; }
            set
            {
                _conductingUnits = value;
                NotifyOfPropertyChange(() => ConductingUnits);
            }
        }

        public ConductingOfficersViewModel ConductingOfficers
        {
            get { return _conductingOfficers; }
            set
            {
                _conductingOfficers = value;
                NotifyOfPropertyChange(() => ConductingOfficers);
            }
        }

        public BindingList<DictItem> Purposes
        {
            get { return _purposes; }
            set
            {
                _purposes = value;
                NotifyOfPropertyChange(() => Purposes);
            }
        }

       public ReservationEndViewModel ReservationEnd
        {
            get { return _reservationEnd; }
            set
            {
                _reservationEnd = value;
                NotifyOfPropertyChange(()=>ReservationEnd);
            }
        }

       

        public string RegistrationNo
        {
            get { return _registrationNo; }
            set
            {
                _registrationNo = value;
                NotifyOfPropertyChange(() => RegistrationNo);
            }
        }

        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                NotifyOfPropertyChange(() => StartDate);
            }
        }

        public string PlannedEndDate
        {
            get { return _plannedEndDate; }
            set
            {
                _plannedEndDate = value;
                NotifyOfPropertyChange(() => PlannedEndDate);
            }
        }

        public string Purpose
        {
            get { return _purpose; }
            set
            {
                _purpose = value;
                NotifyOfPropertyChange(()=>Purpose);
            }
        }

        public string ReservationEndVisibility
        {
            get { return _reservationEndVisibility; }
            set
            {
                _reservationEndVisibility = value;
                NotifyOfPropertyChange(()=>ReservationEndVisibility);
            }
        }

        public bool IsEnded
        {
            get { return _isEnded; }
            set
            {
                _isEnded = value;
                ReservationEndVisibility = _isEnded ? "Visible" : "Collapsed";
                NotifyOfPropertyChange(()=>IsEnded);
            }
        }

        #endregion

        public ReservationViewModel()
        {
            RegistrationUserName = Environment.UserName;
            RegistrationDate = DateTime.Today.ToShortDateString();
            IsEnded = false;
            ReservationEnd = new ReservationEndViewModel();
            ConductingUnits = new ConductingUnitsViewModel();
            ConductingOfficers = new ConductingOfficersViewModel();
            Purposes = new BindingList<DictItem>(Database.ReservationPurposes);
        }
    }
}
