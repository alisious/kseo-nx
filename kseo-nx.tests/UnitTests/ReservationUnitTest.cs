using System;
using kseo_nx.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kseo_nx.tests.UnitTests
{
    [TestClass]
    public class ReservationUnitTest
    {
        [TestMethod]
        public void można_utworzyć_zabezpieczenie()
        {
            var r = new Reservation();
            Assert.IsNotNull(r);
        }
    }
}
