using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace kseo_nx.ViewModels
{
    public class PersonViewModel :Screen,IWizardScreen
    {
        private string _pesel = String.Empty;
        private string _firstName = String.Empty;
        private string _middleName = String.Empty;
        private string _familyName = String.Empty;
        private string _dateOfBirth = String.Empty;
        private string _nameOfFather = String.Empty;
        private string _placeOfBirth= String.Empty;
        private string _nameOfMother= String.Empty;
        private string _motherMaidenName= String.Empty;
        private string _sex= String.Empty;
        private string _nationality= String.Empty;
        private string _notes= String.Empty;
        private BindableCollection<string> _citizenships = new BindableCollection<string>();

        private BindableCollection<String> _countryList;
        private BindableCollection<String> _sexList; 
        

        public PersonViewModel()
        {
            CountryList = new BindableCollection<string>(Helpers.Database.Countries);
            SexList = new BindableCollection<string>(Helpers.Database.Sex);
        }

        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(()=>Pesel);
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

        public BindableCollection<string> Citizenships
        {
            get { return _citizenships; }
            set
            {
                _citizenships = value;
                NotifyOfPropertyChange(() => Citizenships);
            }
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
                NotifyOfPropertyChange(()=>SexList);
            }
        }


        public bool CanGoNext()
        {
            throw new NotImplementedException();
        }
    }
}
