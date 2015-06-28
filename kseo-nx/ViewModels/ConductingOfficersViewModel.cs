using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ConductingOfficersViewModel :Conductor<ConductingOfficerViewModel>.Collection.AllActive
    {
        public void AddItem()
        {
            Items.Add(new ConductingOfficerViewModel() { Parent = this });
        }

        public void RemoveItem(ConductingOfficerViewModel removedItem)
        {
            Items.Remove(removedItem);
        }
    }
}
