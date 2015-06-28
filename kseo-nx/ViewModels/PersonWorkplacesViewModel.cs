using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class PersonWorkplacesViewModel :Conductor<PersonWorkplaceViewModel>.Collection.AllActive
    {
        public void AddWorkplace()
        {
            Items.Add(new PersonWorkplaceViewModel() { Parent = this });
        }

        public void RemoveWorkplace(PersonWorkplaceViewModel removedWorkplace)
        {
            Items.Remove(removedWorkplace);
        }
    }
}
