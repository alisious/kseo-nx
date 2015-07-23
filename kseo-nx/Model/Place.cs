using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Model
{
    public abstract class Place :ValueObject
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNo { get; set; }
        public string PlaceNo { get; set; }
        public string PostalCode { get; set; }
    }
}
