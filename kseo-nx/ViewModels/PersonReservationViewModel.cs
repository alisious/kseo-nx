using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.DataAccess;
using kseo_nx.Helpers;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class PersonReservationViewModel :Screen
    {
        private BindingList<DictItem> _purposes;
        private ConductingUnitsViewModel _conductingUnits;
        private ConductingOfficersViewModel _conductingOfficers;
        private ReservationEndViewModel _reservationEnd;
        private string _reservationEndVisibility;
        private List<DictItem> _endReasons;

        public IKseoNxDataContext Context { get; private set; }
        public Reservation CurrentReservation { get; private set; }

        public PersonReservationViewModel(IKseoNxDataContext context, Reservation currentReservation)
        {
            Context = context;
            CurrentReservation = currentReservation;
            Purposes = new BindingList<DictItem>(Database.ReservationPurposes);
            EndReasons = new List<DictItem>(Database.ReservationEndReasons);
            NotifyOfPropertyChange(() => ReservationEndVisibility);
        }

        #region Public properties
       
        

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
                NotifyOfPropertyChange(() => ReservationEnd);
            }
        }

        
        public string StartDate
        {
            get { return CurrentReservation.StartDate; }
            set
            {
                CurrentReservation.StartDate = value;
                NotifyOfPropertyChange(() => StartDate);
            }
        }

        public string PlannedEndDate
        {
            get { return CurrentReservation.PlannedEndDate; }
            set
            {
                CurrentReservation.PlannedEndDate = value;
                NotifyOfPropertyChange(() => PlannedEndDate);
            }
        }

        public string Purpose
        {
            get { return CurrentReservation.Purpose; }
            set
            {
                CurrentReservation.Purpose = value;
                NotifyOfPropertyChange(() => Purpose);
            }
        }

        public string ReservationEndVisibility
        {
            get { return IsTerminated ? "Visible" : "Collapsed"; }
        }

        public bool IsTerminated
        {
            get { return (CurrentReservation.ReservationState==ReservationState.Terminated); }
            set
            {
                if (value == true)
                {
                    CurrentReservation.ReservationState = ReservationState.Terminated;
                   
                }
                else
                {
                    CurrentReservation.ReservationState = ReservationState.Active;
                   
                }
                NotifyOfPropertyChange(() => IsTerminated);
                NotifyOfPropertyChange(()=>ReservationEndVisibility);
            }
        }

        public string RegistrationCardNo
        {
            get { return CurrentReservation.RegistrationCardNo; }
            set
            {
                CurrentReservation.RegistrationCardNo = value;
                NotifyOfPropertyChange(() => RegistrationCardNo);
            }
        }


        public string EndRegistrationUserName
        {
            get { return CurrentReservation.EndRegistrationUserName; }
            set
            {
                CurrentReservation.EndRegistrationUserName = value;
                NotifyOfPropertyChange(()=>EndRegistrationUserName);
            }
        }

        public string EndRegistrationDate
        {
            get { return CurrentReservation.EndRegistrationDate; }
            set
            {
                CurrentReservation.EndRegistrationDate = value;
                NotifyOfPropertyChange(()=>EndRegistrationDate);
            }
        }

        public string EndRegistrationCardNo
        {
            get { return CurrentReservation.EndRegistrationCardNo; }
            set
            {
                CurrentReservation.EndRegistrationCardNo = value;
                NotifyOfPropertyChange(()=>EndRegistrationCardNo);
            }
        }

        public string EndDate
        {
            get { return CurrentReservation.EndDate; }
            set
            {
                CurrentReservation.EndDate = value;
                NotifyOfPropertyChange(()=>EndDate);
            }
        }

        public string EndReason
        {
            get { return CurrentReservation.EndReason; }
            set
            {
                CurrentReservation.EndReason = value;
                NotifyOfPropertyChange(()=>EndReason);
            }
        }

        public string EndNotes
        {
            get { return CurrentReservation.EndNotes; }
            set
            {
                CurrentReservation.EndNotes = value;
                NotifyOfPropertyChange(()=>EndNotes);
            }
        }

        public List<DictItem> EndReasons
        {
            get { return _endReasons; }
            set
            {
                _endReasons = value;
                NotifyOfPropertyChange(() => EndReasons);
            }
        }

      

        #endregion


        public void Remove()
        {
            var vm = Parent as PersonReservationsViewModel;
            if (vm != null) vm.RemoveReservation(this);
        }

    }
}
