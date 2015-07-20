using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using Caliburn.Micro;
using kseo_nx.Helpers;
using System.Dynamic;
using System.Windows;

namespace kseo_nx.ViewModels
{
    public class PersonViewModel :Screen,IWizardScreen
    {
        #region Fields
        private string _creator = string.Empty;
        private DateTime _creationTime;
        private string _pesel = String.Empty;
        private string _firstName = String.Empty;
        private string _middleName = String.Empty;
        private string _familyName = String.Empty;
        private string _dateOfBirth = String.Empty;
        private string _nameOfFather = String.Empty;
        private string _placeOfBirth = String.Empty;
        private string _nameOfMother = String.Empty;
        private string _motherMaidenName = String.Empty;
        private string _sex = String.Empty;
        private string _nationality = String.Empty;
        private string _notes = String.Empty;
        private string _citizenships = String.Empty;

        private BindableCollection<String> _countryList;
        private BindableCollection<String> _sexList;
        
        #endregion
  


        public PersonViewModel()
        {
            Creator = Environment.UserName;
            CreationTime = DateTime.Today;
            
            CountryList = new BindableCollection<string>(Helpers.Database.Countries);
            SexList = new BindableCollection<string>(Helpers.Database.Sex);

            PersonAddresses = new AddressesViewModel();
            PersonWorkplaces = new PersonWorkplacesViewModel();

        }

        #region Properties
        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(() => Pesel);
                CheckIfCanGoNext();
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                NotifyOfPropertyChange(() => MiddleName);
            }
        }

        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                _familyName = value;
                NotifyOfPropertyChange(() => FamilyName);
            }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyOfPropertyChange(() => DateOfBirth);
            }
        }

        public string NameOfFather
        {
            get { return _nameOfFather; }
            set
            {
                _nameOfFather = value;
                NotifyOfPropertyChange(() => NameOfFather);
            }
        }

        public string PlaceOfBirth
        {
            get { return _placeOfBirth; }
            set
            {
                _placeOfBirth = value;
                NotifyOfPropertyChange(() => PlaceOfBirth);
            }
        }

        public string NameOfMother
        {
            get { return _nameOfMother; }
            set
            {
                _nameOfMother = value;
                NotifyOfPropertyChange(() => NameOfMother);
            }
        }

        public string MotherMaidenName
        {
            get { return _motherMaidenName; }
            set
            {
                _motherMaidenName = value;
                NotifyOfPropertyChange(() => MotherMaidenName);
            }
        }

        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }

        public string Nationality
        {
            get { return _nationality; }
            set
            {
                _nationality = value;
                NotifyOfPropertyChange(() => Nationality);
            }
        }

        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                NotifyOfPropertyChange(() => Notes);
            }
        }

        public string Creator
        {
            get { return _creator; }
            set
            {
                _creator = value;
                NotifyOfPropertyChange(() => Creator);
            }
        }

        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
                NotifyOfPropertyChange(() => CreationTime);
            }
        }


        #endregion

        
        

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
                NotifyOfPropertyChange(()=>SexList);
            }
        }

        


        public bool CanGoNext()
        {
          return (PersonAddresses.Count>0);
        }

        public void CheckIfCanGoNext()
        {
            if (Parent != null)
                (Parent as ReservationWizardViewModel).CheckIfCanGoNext();

        }


        #region Citizeships
        public string Citizenships
        {
            get { return _citizenships; }
            set
            {
                _citizenships = value;
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
        
        //Miejsce pracy

        public PersonWorkplacesViewModel PersonWorkplaces { get; protected set; }

        //Adres

        #region Addresses
        
        public AddressesViewModel PersonAddresses { get; protected set; }

        
        #endregion



    }





}
