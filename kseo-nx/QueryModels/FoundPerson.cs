using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.QueryModels
{
    public class FoundPerson
    {
        public Guid Id { get; set; }
        public string Pesel { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string DateOfBirth { get; set; }
        public string NameOfFather { get; set; }

    }
}
