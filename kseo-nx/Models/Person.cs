using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kseo_nx.Models
{
    public class Person :Entity,IAggregate
    {
        public string Pesel { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PreviousName { get; set; }
        public string DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string NameOfFather { get; set; }
        public string NameOfMother { get; set; }
        public string MotherMaidenName { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Notes { get; set; }
    }
}
