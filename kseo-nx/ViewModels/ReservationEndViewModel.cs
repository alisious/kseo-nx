using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Helpers;
using kseo_nx.Domain;

namespace kseo_nx.ViewModels
{
    public class ReservationEndViewModel :Screen
    {
        #region Fields
        private string _endRegistrationUserName = string.Empty;
        private string _endRegistrationDate = string.Empty;
        private string _endRegistrationCardNo = string.Empty;
        private string _endDate = string.Empty;
        private string _endReason = string.Empty;
        private string _endNotes = string.Empty;
        private List<DictItem> _endReasons;
        

        #endregion

        #region Public properties
        public string EndRegistrationUserName
        {
            get { return _endRegistrationUserName; }
            set
            {
                _endRegistrationUserName = value;
                NotifyOfPropertyChange(()=>EndRegistrationUserName);
            }
        }

        public string EndRegistrationDate
        {
            get { return _endRegistrationDate; }
            set
            {
                _endRegistrationDate = value;
                NotifyOfPropertyChange(()=>EndRegistrationDate);
            }
        }

        public string EndRegistrationCardNo
        {
            get { return _endRegistrationCardNo; }
            set
            {
                _endRegistrationCardNo = value;
                NotifyOfPropertyChange(()=>EndRegistrationCardNo);
            }
        }

        public string EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                NotifyOfPropertyChange(()=>EndDate);
            }
        }

        public string EndReason
        {
            get { return _endReason; }
            set
            {
                _endReason = value;
                NotifyOfPropertyChange(()=>EndReason);
            }
        }

        public string EndNotes
        {
            get { return _endNotes; }
            set
            {
                _endNotes = value;
                NotifyOfPropertyChange(()=>EndNotes);
            }
        }

        public List<DictItem> EndReasons
        {
            get { return _endReasons; }
            set
            {
                _endReasons = value;
                NotifyOfPropertyChange(() => EndReasons);
            }
        }

      

        #endregion

        public ReservationEndViewModel()
        {
            EndRegistrationUserName = Environment.UserName;
            EndRegistrationDate = DateTime.Today.ToShortDateString();
            EndReasons = new List<DictItem>(Database.ReservationEndReasons);
        }
    }
}
