using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreationTime { get; protected set; }
        public string Creator { get; protected set; }
    }
}
