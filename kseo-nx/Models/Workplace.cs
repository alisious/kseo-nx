using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.Models
{
    public class Workplace :Address
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {

            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            var other = obj as Workplace;

            return other.Name == Name
                   && other.Position == Position;


        }

        public override int GetHashCode()
        {
            return String.Format("{0}{1}", Name,Position).GetHashCode();
        }

        public static Boolean operator ==(Workplace v1, Workplace v2)
        {

            if ((object)v1 == null)
                if ((object)v2 == null)
                    return true;
                else
                    return false;

            return (v1.Equals(v2));
        }

        public static Boolean operator !=(Workplace v1, Workplace v2)
        {

            return !(v1 == v2);
        }

    }
}
