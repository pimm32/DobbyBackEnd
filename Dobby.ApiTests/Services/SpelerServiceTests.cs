using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Moq;

namespace Dobby.Services.Tests
{
    [TestClass()]
    public class SpelerServiceTests
    {
        [TestMethod()]
        public async Task GetSpelerByIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new Speler { Id = 1, KleurSpeler="Wit", PartijId=1, GebruikerId=1  };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Spelers.GetSpelerBySpelerId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new SpelerService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetSpelerById(1) as Speler;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreNotEqual("Zwart", result.KleurSpeler);
            Assert.AreEqual(1, result.PartijId);
            Assert.AreEqual(1, result.GebruikerId);
        }
    }
}