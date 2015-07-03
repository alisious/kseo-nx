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
                FamilyName = "KORPUSIK",
                FirstName = "JACEK",
                MiddleName = "TADEUSZ",
                DateOfBirth = "1973-02-09",
                PlaceOfBirth = "DZIAŁDOWO",
                NameOfFather = "JAN",
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_nazwiska()
        {
            //Given
            _personDto.FamilyName = String.Empty;
            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNull(p);
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_imienia()
        {
            //Given
            _personDto.FirstName = String.Empty;
            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNull(p);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_imienia_ojca_jeśli_brak_PESEL()
        {
            //Given
            _personDto.Pesel = String.Empty;
            _personDto.NameOfFather = String.Empty;
            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNull(p);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void nie_można_utworzyć_osoby_bez_daty_urodzenia_jeśli_brak_PESEL()
        {
            //Given
            _personDto.Pesel = String.Empty;
            _personDto.DateOfBirth = String.Empty;
            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNull(p);
        }


        [TestMethod]
        public void można_utworzyć_osobę()
        {
            //Given
            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNotNull(p);
        }


        [TestMethod]
        public void nowa_osoba_ma_autora_i_czas_utworzenia()
        {
            var p = Person.CreateInEO(_personDto);
            Assert.IsNotNull(p);
            Assert.IsTrue(p.Creator!="");
            
        }


        [TestMethod]
        public void nie_można_utworzyć_osoby_bez_adresu()
        {
            //Given

            //When
            var p = Person.CreateInEO(_personDto);
            //Then
            Assert.IsNull(p);
        }

        [TestMethod]
        public void nie_można_dodać_takiego_samego_adresu()
        {
            //Given
            var p = Person.CreateInEO(_personDto);
            p.AddAddress()
            //When
            
            //Then
            Assert.IsNull(p);
        }



    }
}
