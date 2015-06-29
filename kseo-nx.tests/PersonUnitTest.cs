using System;
using kseo_nx.DTO;
using kseo_nx.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kseo_nx.tests
{
    [TestClass]
    public class PersonUnitTest
    {
        private PersonDTO _personDto;

        [TestInitialize]
        public void Initialize()
        {
            _personDto = new PersonDTO()
            {
                Creator = Environment.UserName,
                CreationTime = DateTime.Today,
                Pesel = "73020916558",
                FamilyName = "KORPUSIK"

            };
        }

        [TestMethod]
        public void nowa_osoba_ma_nazwisko_i_imię()
        {

        }

        [TestMethod]
        public void nowa_osoba_ma_autora_i_czas_utworzenia()
        {
            var p = Person.Register(_personDto);
            Assert.IsNotNull(p);
            Assert.IsTrue(p.Creator!="");
            
        }


    }
}
