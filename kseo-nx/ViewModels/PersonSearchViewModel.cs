using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Caliburn.Micro;
using kseo_nx.QueryModels;

namespace kseo_nx.ViewModels
{
    public class PersonSearchViewModel:Screen,IWizardScreen
    {
        private bool _canSearchAutomatically;
        private int _peselLengthTrigger = 3;
        private int _familyNameTrigger = 3;
        private string _pesel=String.Empty;
        private string _firstName = String.Empty;
        private string _middleName = String.Empty;
        private string _familyName = String.Empty;
        private string _dateOfBirth = String.Empty;
        private string _nameOfFather = String.Empty;
        private int _counterResults = 0;
        private BindableCollection<FoundPerson> _items;
        private FoundPerson _selectedItem;
        private bool _canComposeNewPerson;


        public PersonSearchViewModel()
        {
            CanSearchAutomatically = true;
            CanComposeNewPerson = false;
            Items = new BindableCollection<FoundPerson>();
        }

        public bool CanSearchAutomatically
        {
            get { return _canSearchAutomatically; }
            set
            {
                _canSearchAutomatically = value;
                NotifyOfPropertyChange(()=>CanSearchAutomatically);
                NotifyOfPropertyChange(()=>CanSearch);
            }
        }

        public bool CanSearch
        {
            get { return !CanSearchAutomatically; }
        }

        public string Pesel
        {
            get { return _pesel; }
            set
            {
                _pesel = value;
                NotifyOfPropertyChange(()=>Pesel);
                SearchAutomatically();
            }
        }

        public int PeselLengthTrigger
        {
            get { return _peselLengthTrigger; }
            set { _peselLengthTrigger = value; }
        }

        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                _familyName = value;
                NotifyOfPropertyChange(()=>FamilyName);
                SearchAutomatically();
            }
        }

        public int FamilyNameTrigger
        {
            get { return _familyNameTrigger; }
            set
            {
                _familyNameTrigger = value;
                
            }
        }

        public BindableCollection<FoundPerson>  Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyOfPropertyChange(()=>Items);
            }
        }

        public FoundPerson SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                NotifyOfPropertyChange(()=>SelectedItem);
                CheckIfCanGoNext();
            }
        }

        

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(()=>FirstName);
            }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                NotifyOfPropertyChange(()=>MiddleName);
            }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                NotifyOfPropertyChange(()=>DateOfBirth);
            }
        }

        public string NameOfFather
        {
            get { return _nameOfFather; }
            set
            {
                _nameOfFather = value;
                NotifyOfPropertyChange(()=>NameOfFather);
            }
        }

        public int CounterResults
        {
            get { return _counterResults; }
            set
            {
                _counterResults = value;
                NotifyOfPropertyChange(()=>CounterResults);
            }
        }

        public void SearchAutomatically()
        {
            if (!CanSearchAutomatically) return;
            if ((Pesel.Length>=PeselLengthTrigger) || (FamilyName.Length>=FamilyNameTrigger))
                Search();
            
        }

        public void Search()
        {
            Items.Add(new FoundPerson(){Pesel = "73020916558",FamilyName = "KORPUSIK",FirstName = "JACEK"});
            Items.Add(new FoundPerson() { Pesel = "73020916558", FamilyName = "KORPUSIK", FirstName = "JACEK" });

        }


        public bool CanComposeNewPerson
        {
            get { return _canComposeNewPerson; }
            set
            {
                _canComposeNewPerson = value;
                NotifyOfPropertyChange(()=>CanComposeNewPerson);
                CheckIfCanGoNext();
            }
        }


        public void CheckIfCanGoNext()
        {
            if (Parent != null)
            {
                (Parent as ReservationWizardViewModel).CheckIfCanGoNext();
            }
        }

       
        public bool CanGoNext()
        {
            return (SelectedItem != null) || CanComposeNewPerson;
        }
    }
}
