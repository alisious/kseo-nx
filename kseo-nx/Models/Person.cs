using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kseo_nx.DTO;


namespace kseo_nx.Models
{
    public class Person :Entity,IAggregate
    {
        public string Pesel { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PreviousName { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string NameOfFather { get; set; }
        public string NameOfMother { get; set; }
        public string MotherMaidenName { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Citizenships { get; set; }
        public string Notes { get; set; }
        public string ReservationStatus { get; set; }

        public HashSet<Reservation> Reservations { get; protected set; }
        public HashSet<Address> Addresses { get; protected set; }
        public List<Workplace> Workplaces { get; protected set; }
        
        public Person()
        {
            Reservations = new HashSet<Reservation>();
            Addresses = new HashSet<Address>();
            Workplaces = new List<Workplace>();
            CreationTime = DateTime.Today;
            Creator = Environment.UserName;

        }

        





        public Reservation Reserve(ReservationDTO reservationData)
        {
            
            if (ReservationStatus == "ZAB") 
                throw new InvalidOperationException("Próba zabezpieczenia zabezpieczonej osoby!");

            var newReservation = new Reservation();
            Mapper.CreateMap<ReservationDTO, Reservation>();
            Mapper.Map(reservationData, newReservation);
            Reservations.Add(newReservation);
            ReservationStatus = "ZAB";
            return new Reservation();

        }





        public Address AddAddress(bool isValid,string city,string street,string streetNo,string placeNo,string postalCode)
        {
            var a = new Address()
            {
                IsValid = isValid,
                City = city,
                Street = street,
                StreetNo = streetNo,
                PlaceNo = placeNo,
                PostalCode = postalCode
            };
            var r = Addresses.Add(a);
            return r ? a : null;
        }

        public Address UpdateAddress(bool isValid, string city, string street, string streetNo, string placeNo, string postalCode)
        {
            var a = new Address()
            {
                IsValid = isValid,
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
