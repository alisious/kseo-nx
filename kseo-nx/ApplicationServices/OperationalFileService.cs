using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kseo_nx.DataAccess;
using kseo_nx.DTO;
using kseo_nx.Models;

namespace kseo_nx.ApplicationServices
{
    public class OperationalFileService
    {
        public static bool ReserveNewPerson(PersonDTO personData,ReservationDTO reservationData)
        {

            using (var context = new KseoNxDataContext())
            {
                var newPerson = Person.CreateInEO(personData);
                newPerson.Reserve(reservationData);
                context.Persons.Add(newPerson);
                context.SaveChanges();
            }
            
            
            return true;
        }

        public bool ReserveRegisteredPerson(PersonDTO personData, ReservationDTO reservationData)
        {
            throw new NotImplementedException();
        }
    }
}
