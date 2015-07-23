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
    public class PersonFileViewModel :Screen
    {
        public PersonFileViewModel(Guid personId)
        {
            Context = new KseoNxDataContext();
            CurrentPerson = (personId == Guid.Empty)
                ? new Person()
                : Context.GetPersonFile(personId);
            if (CurrentPerson != null && CurrentPerson.Id == Guid.Empty)
            {
                CurrentPerson.Id = Guid.NewGuid();
                Context.Persons.Add(CurrentPerson);
            }

            NotifyOfPropertyChange(()=>PersonFullName);
            PersonEditVm = new PersonEditViewModel(Context,CurrentPerson);
            PersonReservationsVm = new PersonReservationsViewModel(Context,CurrentPerson);        
        }


        public KseoNxDataContext Context { get; protected set; }
        public Person CurrentPerson { get; private set; }
        public PersonEditViewModel PersonEditVm { get; private set; }
        public PersonReservationsViewModel PersonReservationsVm { get; protected set; }

        public string PersonFullName {
            get { return String.Format("{0} {1}", CurrentPerson.FirstName, CurrentPerson.FamilyName); }
        }

        #region Buttons

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Cancel()
        {
            TryClose(false);
        }

        #endregion

    }
}
