using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using kseo_nx.DataAccess;
using kseo_nx.Model;

namespace kseo_nx.ViewModels
{
    public class PersonEditViewModel :ContextEditor
    {
        
        private BindableCollection<String> _countryList;
        private BindableCollection<String> _sexList;

        
        public PersonEditViewModel(KseoNxDataContext context, Person person) : base(context)
        {
            CurrentPerson = person;
            CountryList = new BindableCollection<string>(Helpers.Database.Countries);
            SexList = new BindableCollection<string>(Helpers.Database.Sex);
            PersonAddresses = new AddressesViewModel(CurrentPerson);
            PersonWorkplaces = new PersonWorkplacesViewModel(CurrentPerson);
        }

        public BindableCollection<string> CountryList
        {
            get { return _countryList; }
            set
            {
                _countryList = value;
                NotifyOfPropertyChange(() => CountryList);
            }
        }

        public BindableCollection<string> SexList
        {
            get { return _sexList; }
            set
            {
                _sexList = value;
                NotifyOfPropertyChange(() => SexList);
            }
        }

        #region Citizeships
        public string Citizenships
        {
            get { return CurrentPerson.Citizenships; }
            set
            {
                CurrentPerson.Citizenships = value;
                NotifyOfPropertyChange(() => Citizenships);
            }
        }

        public void OpenCitizenshipsDialog()
        {
            var windowManager = IoC.Get<IWindowManager>();
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.WindowStyle = WindowStyle.ToolWindow;
            var vm = new PersonCitizenshipsViewModel() { DisplayName = "Obywatelstwo..." };
            vm.AllCountries.SelectFromLine(Citizenships);
            windowManager.ShowDialog(vm, null, settings);
            Citizenships = vm.AllCountries.GetSelectedInLine();

        }

        #endregion


        public Person CurrentPerson { get; private set; }

        public string Pesel
        {
            get { return CurrentPerson.Pesel; }
            set
            {
                CurrentPerson.Pesel = value;
                NotifyOfPropertyChange(() => Pesel);
            }
        }

        public string FirstName 
        {
            get { return CurrentPerson.FirstName; }
            set
            {
                CurrentPerson.FirstName = value;
                NotifyOfPropertyChange(()=>FirstName);
            }
        }

        public string FamilyName
        {
            get { return CurrentPerson.FamilyName; }
            set
            {
                CurrentPerson.FamilyName = value;
                NotifyOfPropertyChange(() => FamilyName);
            }
        }

        public string MiddleName
        {
            get { return CurrentPerson.MiddleName; }
            set
            {
                CurrentPerson.MiddleName = value;
                NotifyOfPropertyChange(() => MiddleName);
            }
        }


        //Miejsce pracy

        public PersonWorkplacesViewModel PersonWorkplaces { get; protected set; }

        //Adres

        #region Addresses

        public AddressesViewModel PersonAddresses { get; protected set; }


        #endregion


       


    }
}
