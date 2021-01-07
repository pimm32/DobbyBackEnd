using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models.Tests
{
    [TestClass()]
    public class BordTests
    {
        [TestMethod()]
        public void BordTest()
        {
            Bord bord = new Bord("W:W31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50:B1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20");

            Assert.IsNotNull(bord.velden);
        }
    }
}