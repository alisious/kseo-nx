﻿using System;
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
        
        public void AddAddress()
        {
            Items.Add(new AddressViewModel(){Parent = this});
        }

        public void RemoveAddress(AddressViewModel removedAddress)
        {
            Items.Remove(removedAddress);
        }
    }
}
