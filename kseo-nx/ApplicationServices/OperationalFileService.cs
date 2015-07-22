using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using kseo_nx.DataAccess;
using kseo_nx.DTO;
using kseo_nx.Domain;

namespace kseo_nx.ApplicationServices
{
    public class OperationalFileService
    {

        public Request<Person> CreatePerson(string creator,PersonDTO personDto)
        {
            var p = Person.CreateInEO(personDto);
            var pr = new Request<Person>(creator, RequestType.Create, p);
            //return pr.Execute(ctx);
            return null;

        }

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
