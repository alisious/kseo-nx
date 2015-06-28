using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class ConductingUnitsViewModel :Conductor<ConductingUnitViewModel>.Collection.AllActive
    {
        public void AddItem()
        {
            Items.Add(new ConductingUnitViewModel() { Parent = this });
        }

        public void RemoveItem(ConductingUnitViewModel removedItem)
        {
            Items.Remove(removedItem);
        }
    }
}
