using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Model
{
    public abstract class Entity
    {
        private DomainObjectState _objectState = DomainObjectState.Active;
        
        public Guid Id { get; set; }
        public DateTime CreationTime { get; protected set; }
        public string Creator { get; protected set; }

        public DomainObjectState ObjectState
        {
            get { return _objectState; }
            private set { _objectState = value; }
        }
    }
}
