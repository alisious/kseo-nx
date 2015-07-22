using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using kseo_nx.DataAccess;

namespace kseo_nx.Domain
{
    public class Request<T> :Entity where T :Entity
    {
        public RequestType RequestType { get; protected set; }
        public RequestState RequestState { get; protected set; }
        public string SourceDocumentNo { get; protected set; }
        public Guid ObjectId { get; protected set; }
        public DateTime? ExecutionTime { get; protected set; }
        [NotMapped]
        public T Content { get; protected set; }

        public Request(string creator,RequestType requestType,T content)
        {
            Creator = creator;
            CreationTime = DateTime.Now;
            RequestType = requestType;
            RequestState = RequestState.Draft;
            Content = content;
        }

        public Request<T> Execute(KseoNxDataContext ctx)
        {
            if (RequestState!=RequestState.Draft) throw new InvalidOperationException();
               try
                {
                    Process();
                    ctx.Set<T>().Add(Content);
                    ctx.SaveChanges();
                    RequestState = RequestState.Confirmed;

                }
                catch (Exception)
                {
                    RequestState = RequestState.Rejected;
                   
                }
                ExecutionTime = DateTime.Now;
            

            return this;

        }

        protected virtual void Process()
        {
            //TODO: wykonanie zlecenia
           // throw new NotImplementedException();
        }

        
    }
}
