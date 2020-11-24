using Microsoft.VisualStudio.TestTools.UnitTesting;
using KUBike_REST.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using lib;
using System.Linq;

namespace KUBike_REST.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests
    {
        UsersController cmd = new UsersController();
        [TestMethod()]
        //For at testet GETALL funktionen i unittest. Vi tester dette igennem når vi tjekker for mange items der er i listen. Derfor bruger vi Assert.AreEqual, til at se om de har samme antal af items i listen. 
        public void GetTest()
        {
            Assert.AreEqual(3, cmd.Get().Count());
        }
        //Her tester vi GetId funktionen. Vi tester dette igennem en Assert.AreEqual metode og Assert.IsNotNull. Igennem disse to requests finder vi ud af om itemet exist og om den har id'et 2.
        [TestMethod()]
        public void GetIdTest()
        {
            Assert.AreEqual(2, cmd.Get(2).User_id);
            Assert.IsNotNull(cmd.Get(2));
        }

        //Her tester vi Post funktionen. Vi tester dette igennem en Assert.AreEqual metode. Men før vi benytter os af denne metode opretter vi et objekt som skal bruges i testen. I er objektet vi benytte til at tjekke og telefonnummet stå over ens med telefonnummet vi har angivet i vores objekt.              
        [TestMethod()]
        public void PostTest()
        {
            User i = new User(1, "Dummy", "dummy", "dummy", "dummy", 70707070, 1);
            cmd.Post(i);
            Assert.AreEqual(70707070, cmd.Get(1).User_mobile);

        }

    }
}