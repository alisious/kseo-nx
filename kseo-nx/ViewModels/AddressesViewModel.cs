using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class AddressesViewModel :Conductor<AddressViewModel>.Collection.AllActive
    {

        public int Count { get { return Items.Count; } }

        public void AddAddress()
        {
            Items.Insert(0,new AddressViewModel(){Parent = this,IsCurrent = true});
        }

        public void RemoveAddress(AddressViewModel removedAddress)
        {
            Items.Remove(removedAddress);
        }
    }
}
