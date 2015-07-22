using System;
using kseo_nx.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kseo_nx.tests.UnitTests
{
    [TestClass]
    public class PersonViewModelUnitTest
    {
        [TestMethod]
        public void można_utworzyć_widok_modelu_osoby()
        {
            //given
             
            //when
            var pvm = new PersonViewModel();
            //then
            Assert.IsNotNull(pvm);
        }

        [TestMethod]
        public void można_dodać_adres()
        {
            //given
                var pvm = new PersonViewModel();
            //when
                pvm.PersonAddresses.AddAddress();
            //then
            Assert.IsNotNull(pvm);
            Assert.IsNotNull(pvm.PersonAddresses);
            Assert.AreEqual(1,pvm.PersonAddresses.Count);
        }
    }
}
