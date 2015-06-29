using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
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
        public string RegistrationStatus { get; set; }

        public HashSet<Reservation> Reservations { get; protected set; }
        public HashSet<Address> Addresses { get; protected set; }
        public List<Workplace> Workplaces { get; protected set; }
        
        protected Person()
        {
            Reservations = new HashSet<Reservation>();
            Addresses = new HashSet<Address>();
            Workplaces = new List<Workplace>();
            RegistrationStatus = Helpers.Database.cBezRoli;

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



        public Reservation Reserve(ReservationDTO reservationData)
        {

            if (RegistrationStatus != Helpers.Database.cBezRoli)
                throw new InvalidOperationException(String.Format("{0}, {1}", "Niedozowlona próba zabezpieczenia osoby!", RegistrationStatus));

            var newReservation = Reservation.Register(reservationData);
            Reservations.Add(newReservation);
            RegistrationStatus = Helpers.Database.cZabezpieczona;
            return newReservation;

        }

        public static Person Register(PersonDTO newPersonData)
        {
            Mapper.CreateMap<PersonDTO,Person>();
            var p = Mapper.Map<Person>(newPersonData);
            p.Id = Guid.NewGuid();
            p.CreationTime = DateTime.Now;
            p.Creator = Environment.UserName;
            return p;
        }
    }
}
