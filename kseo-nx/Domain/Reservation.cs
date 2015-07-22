using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kseo_nx.DTO;

namespace kseo_nx.Domain
{
    public class Reservation :Entity
    {

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
        
        public void Finish(string endReason, string endDate, string endNotes, string endRegistrationCardNo)
        {
            throw new NotImplementedException();
        }

        protected Reservation()
        {
            CreationTime = DateTime.Today;
            Creator = Environment.UserName;
        }

        public static Reservation Register(ReservationDTO reservationData)
        {
            Mapper.CreateMap<ReservationDTO, Reservation>();
            var r = Mapper.Map<Reservation>(reservationData);
            r.CreationTime = DateTime.Now;
            r.Id = Guid.NewGuid();
            return r;
        }

        public bool Update(ReservationDTO reservationData)
        {
            //porównanie pól obiektu
            //zapisanie różnic do logu 
            throw new NotImplementedException();

        }



    }
}
