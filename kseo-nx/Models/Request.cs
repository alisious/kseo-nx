using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace kseo_nx.Models
{
    public class Request<T> :Entity where T :Entity
    {
        public RequestType RequestType { get; protected set; }
        public RequestState RequestState { get; protected set; }
        public string SourceDocumentNo { get; protected set; }
        public Guid ObjectId { get; protected set; }
        public DateTime? ExecutionTime { get; protected set; }
        public T Content { get; protected set; }
        
        public Request(string creator,RequestType requestType)
        {
            Creator = creator;
            CreationTime = DateTime.Now;
            RequestType = requestType;
            RequestState = Models.RequestState.Draft;
        }

        public void Execute()
        {
            if (RequestState!=Models.RequestState.Draft) throw new InvalidOperationException();
            try
            {
                Process();
                RequestState = Models.RequestState.Confirmed;
            }
            catch (Exception)
            {
                RequestState = RequestState.Rejected;
            }
            ExecutionTime = DateTime.Now;

        }

        protected virtual void Process()
        {
            //TODO: wykonanie zlecenia
            throw new NotImplementedException();
        }


    }
}
