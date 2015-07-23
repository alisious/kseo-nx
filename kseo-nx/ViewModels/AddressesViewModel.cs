using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Caliburn.Micro;
using kseo_nx.DataAccess;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class AddressesViewModel :Conductor<AddressViewModel>.Collection.AllActive
    {

        
        public Person CurrentPerson { get; set; }
        

        public AddressesViewModel()
        {

        }

        public AddressesViewModel(Person currentPerson)
        {
            CurrentPerson = currentPerson;
            foreach (var address in CurrentPerson.Addresses)
            {
                Items.Add(new AddressViewModel(address));
            }
        }


        public int Count { get { return Items.Count; } }

        public void AddAddress()
        {
            var address = new Address();
            CurrentPerson.Addresses.Add(address);
            Items.Insert(0,new AddressViewModel(address){Parent = this,IsCurrent = true});
        }

        public void RemoveAddress(AddressViewModel removedAddress)
        {
            CurrentPerson.Addresses.Remove(removedAddress.CurrentAddress);
            Items.Remove(removedAddress);
        }


    }
}
