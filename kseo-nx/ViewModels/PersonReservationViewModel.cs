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
    public class PersonReservationViewModel :Screen
    {
        public IKseoNxDataContext Context { get; private set; }
        public Reservation CurrentReservation { get; private set; }

        public PersonReservationViewModel(IKseoNxDataContext context, Reservation currentReservation)
        {
            Context = context;
            CurrentReservation = currentReservation;
        }

        public void Remove()
        {
            var vm = Parent as PersonReservationsViewModel;
            if (vm != null) vm.RemoveReservation(this);
        }

    }
}
