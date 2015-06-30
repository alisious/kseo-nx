﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AutoMapper;
using kseo_nx.DTO;


namespace kseo_nx.Models
{
    public class Person :Entity,IAggregate
    {
        public string Pesel { get; protected set; }
        public string FamilyName { get; protected set; }
        public string FirstName { get; protected set; }
        public string MiddleName { get; protected set; }
        public string PreviousName { get; protected set; }
        public string DateOfBirth { get; protected set; }
        public string PlaceOfBirth { get; protected set; }
        public string NameOfFather { get; protected set; }
        public string NameOfMother { get; protected set; }
        public string MotherMaidenName { get; protected set; }
        public string Sex { get; protected set; }
        public string Nationality { get; protected set; }
        public string Citizenships { get; protected set; }
        public string Notes { get; protected set; }
        public string RegistrationStatus { get; protected set; }

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
             
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(newPersonData.FamilyName),"Nie można zarejestrować osoby bez podania nazwiska.");
            Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(newPersonData.FirstName), "Nie można zarejestrować osoby bez podania imienia.");
            Contract.Requires<ArgumentException>((!String.IsNullOrWhiteSpace(newPersonData.Pesel)||!String.IsNullOrWhiteSpace(newPersonData.NameOfFather)), "Nie można zarejestrować osoby bez podania imienia ojca jeśli nie podano PESEL i odwrotnie.");
            Mapper.CreateMap<PersonDTO,Person>();
            var p = Mapper.Map<Person>(newPersonData);
            p.Id = Guid.NewGuid();
            p.CreationTime = DateTime.Now;
            p.Creator = Environment.UserName;
            return p;
        }
    }
}
