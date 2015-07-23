using System;
using System.Collections.Generic;
using AutoMapper;



namespace kseo_nx.Model
{
    public class Person :Entity,IAggregate
    {
        public string Pesel { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PreviousName { get;  set; }
        public string DateOfBirth { get;  set; }
        public string PlaceOfBirth { get;  set; }
        public string NameOfFather { get;  set; }
        public string NameOfMother { get;  set; }
        public string MotherMaidenName { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Citizenships { get; set; }
        public string Notes { get;  set; }
        public string RegistrationStatus { get; protected set; }

        public HashSet<Reservation> Reservations { get; protected set; }
        public HashSet<Address> Addresses { get; protected set; }
        public List<Workplace> Workplaces { get; protected set; }
        
        public Person()
        {
            Reservations = new HashSet<Reservation>();
            Addresses = new HashSet<Address>();
            Workplaces = new List<Workplace>();
            RegistrationStatus = Helpers.Database.cBezRoli;
            Citizenships = String.Empty;
            CreationTime = DateTime.Now;
            Creator = Environment.UserName;
        }


        public Reservation AddReservation()
        {
            var r = new Reservation {Id = Guid.NewGuid(), ReservationState = ReservationState.Active};
            return Reservations.Add(r) ? r : null;
        }


        public Address AddAddress(bool isCurrent,string city,string street,string streetNo,string placeNo,string postalCode)
        {
            var a = new Address()
            {
                IsCurrent = isCurrent,
                City = city,
                Street = street,
                StreetNo = streetNo,
                PlaceNo = placeNo,
                PostalCode = postalCode
            };
            var r = Addresses.Add(a);
            return r ? a : null;
        }



      

       


       
    }
}
