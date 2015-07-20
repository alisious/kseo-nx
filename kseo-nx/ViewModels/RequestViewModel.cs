using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using kseo_nx.Models;

namespace kseo_nx.ViewModels
{
    public class RequestViewModel :Screen
    {
        private string _author;
        private DateTime _creationTime;
        private RequestType _requestType;
        private string _sourceDocumentNo;
        private Screen _requestContent;

        public RequestViewModel(string author,RequestType requestType,string sourceDocumentNo="")
        {
            Author = author;
            RequestType = requestType;
            CreationTime = DateTime.Now;
            SourceDocumentNo = sourceDocumentNo;
            RequestContent = new PersonViewModel();
        }
        
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                NotifyOfPropertyChange(()=>Author);
            }
        }

        public DateTime CreationTime
        {
            get { return _creationTime; }
            set
            {
                _creationTime = value;
                NotifyOfPropertyChange(()=>CreationTime);
            }
        }

        public RequestType RequestType
        {
            get { return _requestType; }
            set
            {
                _requestType = value;
                NotifyOfPropertyChange(()=>RequestType);
            }
        }

        #region Buttons guards
        public bool CanExecute 
        {
            get { return true; }
        }

        public Screen RequestContent
        {
            get { return _requestContent; }
            set
            {
                _requestContent = value;
                NotifyOfPropertyChange(()=>RequestContent);
            }
        }

        public string SourceDocumentNo
        {
            get { return _sourceDocumentNo; }
            set
            {
                _sourceDocumentNo = value;
                NotifyOfPropertyChange(()=>SourceDocumentNo);
            }
        }

        #endregion



        #region Buttons

        public void Execute()
        {
            CreationTime = DateTime.Now;
        }

        public void Cancel()
        {
            TryClose(false);
        }


        #endregion
    }
}
