using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Models
{
    public class Address :Place
    {

            public bool IsCurrent { get; set; }
            
            

            public override string ToString()
            {
                return String.Format("{0}{1} {2}{3}",
                        City,
                        String.IsNullOrWhiteSpace(Street) ? String.Empty : String.Concat(", ", Street),
                        StreetNo,
                        String.IsNullOrWhiteSpace(PlaceNo) ? String.Empty : String.Concat("/", PlaceNo));
            }


            public override bool Equals(object obj)
            {

                if (obj == null) return false;
                if (this.GetType() != obj.GetType()) return false;

                var other = obj as Address;

                return other.City == City
                       && other.Street == Street
                       && other.StreetNo == StreetNo
                       && other.PlaceNo == PlaceNo
                       && other.PostalCode == PostalCode;


            }

            public override int GetHashCode()
            {
                return String.Format("{0}{1}{2}{3}{4}",City,Street,StreetNo,PlaceNo,PostalCode).GetHashCode();
            }

            public static Boolean operator ==(Address v1, Address v2)
            {

                if ((object)v1 == null)
                    if ((object)v2 == null)
                        return true;
                    else
                        return false;

                return (v1.Equals(v2));
            }

            public static Boolean operator !=(Address v1, Address v2)
            {

                return !(v1 == v2);
            }


    }
}
