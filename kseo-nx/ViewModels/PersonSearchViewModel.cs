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
    public class PersonSearchViewModel:Screen
    {
        private bool _canSearchFindAutomatically;
        private int _peselLengthTrigger = 3;
        private int _familyNameTrigger = 3;
        private string _pesel;
        private string _firstName;
        private string _middleName;
        private string _familyName;
        private string _dateOfBirth;
        private string _nameOfFather;
        private int _counterResults = 0;
        private BindableCollection<FoundPerson> _items;
        private FoundPerson _selectedItem;
        
        public bool CanSearchFindAutomatically
        {
            get { return _canSearchFindAutomatically; }
            set
            {
                _canSearchFindAutomatically = value;
                NotifyOfPropertyChange(()=>CanSearchFindAutomatically);
            }
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
                NotifyOfPropertyChange(() => CanSelect);
            }
        }

        public bool CanSelect
        {
            get { return SelectedItem!=null; }
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
            if (!CanSearchFindAutomatically) return;
            if ((Pesel.Length>=PeselLengthTrigger) || (FamilyName.Length>=FamilyNameTrigger))
                Search();
        }

        public void Search()
        {

        }

        public void Select()
        {
            if (!CanSelect) return;
            TryClose(true);
        }

        public void Cancel()
        {
            TryClose(false);
        }

        public void ComposeNewPerson()
        {
            SelectedItem = new FoundPerson()
            {   
                Id = Guid.Empty, 
                Pesel = Pesel,
                DateOfBirth = DateOfBirth,
                FamilyName = FamilyName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                NameOfFather = NameOfFather
            };

            TryClose(true);
        }
    }
}
