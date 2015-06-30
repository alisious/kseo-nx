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
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_zarejestrować_osoby_bez_nazwiska()
        {
            _personDto.FamilyName = String.Empty;
            var p = Person.Register(_personDto);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_zarejestrować_osoby_bez_imienia()
        {
            _personDto.FirstName = String.Empty;
            var p = Person.Register(_personDto);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_zarejestrować_osoby_bez_imienia_ojca_jeśli_brak_PESEL()
        {
            _personDto.Pesel = String.Empty;
            _personDto.NameOfFather = "JAN";//String.Empty;

            var p = Person.Register(_personDto);

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
