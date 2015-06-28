using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Helpers;

namespace kseo_nx.ViewModels
{
    public class ConductingUnitViewModel :Screen
    {
        private string _organizationalUnit = string.Empty;
        private BindableCollection<string> _organizationlaUnitList;

        public ConductingUnitViewModel()
        {
            OrganizationlaUnitList = new BindableCollection<string>(Database.OrganizationalUnits);
        }
        
        public string OrganizationalUnit
        {
            get { return _organizationalUnit; }
            set
            {
                _organizationalUnit = value;
                NotifyOfPropertyChange(() => OrganizationalUnit);
            }
        }

        public BindableCollection<string> OrganizationlaUnitList
        {
            get { return _organizationlaUnitList; }
            set
            {
                _organizationlaUnitList = value;
                NotifyOfPropertyChange(()=>OrganizationlaUnitList);
            }
        }

        public void Remove()
        {
            var itemsViewModel = Parent as ConductingUnitsViewModel;
            if (itemsViewModel != null) itemsViewModel.RemoveItem(this);
        }
    }
}
