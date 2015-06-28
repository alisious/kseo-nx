
using System;
using System.Windows.Documents;
using Caliburn.Micro;
using kseo_nx.Helpers;

namespace kseo_nx.ViewModels
{
    public class PersonCitizenshipsViewModel :Screen
    {

        #region Private fields

            private CheckedList<String> _allCountries;
        
        #endregion


        #region Constructors

        public PersonCitizenshipsViewModel()
        {
            AllCountries = new CheckedList<string>(Helpers.Database.Countries);
        }

        #endregion


            public CheckedList<string> AllCountries
            {
                get { return _allCountries; }
                set
                {
                    _allCountries = value;
                    NotifyOfPropertyChange(() => AllCountries);
                }
            }

        public void Close()
        {
            TryClose(true);
        }
    }
}
