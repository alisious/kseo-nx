using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace kseo_nx.Model
{
    public class Reservation :Entity
    {

        private ReservationState _reservationState = ReservationState.Active;

        public string RegistrationCardNo { get; set; }
        public string Purpose { get; set; }
        public string StartDate { get; set; }
        public string PlannedEndDate { get; set; }
        public string Notes { get; set; }
        public string EndRegistrationUserName { get; set; }
        public string EndRegistrationDate { get; set; }
        public string EndRegistrationCardNo { get; set; }
        public string EndDate { get; set; }
        public string EndReason { get; set; }
        public string EndNotes { get; set; }

        public ReservationState ReservationState
        {
            get { return _reservationState; }
            set { _reservationState = value; }
        }


        
        public Reservation()
        {
            CreationTime = DateTime.Today;
            Creator = Environment.UserName;
        }

       

       


    }
}
