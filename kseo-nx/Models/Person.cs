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
        }

        public Person(PersonDTO personData) 
        {
            Reservations = new HashSet<Reservation>();
            Addresses = new HashSet<Address>();
            Workplaces = new List<Workplace>();

            Mapper.CreateMap<PersonDTO, Person>();
            this = Mapper.Map<PersonDTO>(personData);
            var p = personData;
            Pesel = p.Pesel;
            FamilyName = p.FamilyName;
            FirstName = p.FirstName;
            MiddleName = p.MiddleName;
            PreviousName = p.PreviousName;
            DateOfBirth = p.DateOfBirth;
            PlaceOfBirth = p.PlaceOfBirth;


        }





        public Reservation Reserve(string registrationCardNo, string purpose, string startDate, string plannedEndDate,
            string notes)
        {
            if (ReservationStatus == "ZAB") 
                throw new InvalidOperationException("Próba zabezpieczenia zabezpieczonej osoby!");

            return new Reservation(){Id=new Guid(),CreationTime = DateTime.Now,Creator = Environment.UserName,
                RegistrationCardNo = registrationCardNo,
                Purpose = purpose,
                StartDate = startDate,
                PlannedEndDate = plannedEndDate};
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
