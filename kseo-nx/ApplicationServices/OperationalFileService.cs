using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kseo_nx.DataAccess;
using kseo_nx.DTO;
using kseo_nx.Models;

namespace kseo_nx.ApplicationServices
{
    public class OperationalFileService
    {
        public bool ReserveNewPerson(PersonDTO person,ReservationDTO reservation)
        {

            using (var context = new KseoNxDataContext())
            {
                var newPerson = new Person();
                newPerson.Reserve();

                context.Persons.Add(newPerson);
            }
            
            
            return true;
        }

        public bool ReserveRegisteredPerson()
        {

        }
    }
}
