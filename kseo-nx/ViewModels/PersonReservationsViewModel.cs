using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.DataAccess;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class PersonReservationsViewModel : Conductor<PersonReservationViewModel>.Collection.AllActive
    {
        public IKseoNxDataContext Context { get; private set; }
        public Person CurrentPerson { get; set; }

        public PersonReservationsViewModel(IKseoNxDataContext context,Person currentPerson)
        {
            Context = context;
            CurrentPerson = currentPerson;
            foreach (var reservation in CurrentPerson.Reservations)
            {
                Items.Add(new PersonReservationViewModel(context,reservation));
            }
        }

        public void AddReservation()
        {
            var reservation = CurrentPerson.AddReservation();
            Items.Add(new PersonReservationViewModel(Context,reservation) { Parent = this });
        }

        public void RemoveReservation(PersonReservationViewModel removedReservation)
        {
            CurrentPerson.Reservations.Remove(removedReservation.CurrentReservation);
            Items.Remove(removedReservation);
        }

    }
}
