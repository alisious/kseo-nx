using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kseo_nx.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string Creator { get; set; }
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
        public string Citizenships { get; set; }
        public string Notes { get; set; }
        public string ReservationStatus { get; set; }
    }
}
