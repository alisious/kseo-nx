using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Domain
{
    public interface IRequest
    {
        Entity Content { get; set; }
    }
}
