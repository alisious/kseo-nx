using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class PersonWorkplacesViewModel :Conductor<PersonWorkplaceViewModel>.Collection.AllActive
    {
        public Person CurrentPerson { get; set; }


        public PersonWorkplacesViewModel()
        {
        }

        public PersonWorkplacesViewModel(Person currentPerson)
        {
            CurrentPerson = currentPerson;
            foreach (var workplace in CurrentPerson.Workplaces)
            {
                Items.Add(new PersonWorkplaceViewModel(workplace));
            }
        }

        public void AddWorkplace()
        {
            var workplace = new Workplace();
            CurrentPerson.Workplaces.Add(workplace);
            Items.Add(new PersonWorkplaceViewModel(workplace) { Parent = this });
        }

        public void RemoveWorkplace(PersonWorkplaceViewModel removedWorkplace)
        {
            CurrentPerson.Workplaces.Remove(removedWorkplace.CurrentWorkplace);
            Items.Remove(removedWorkplace);
        }
    }
}
