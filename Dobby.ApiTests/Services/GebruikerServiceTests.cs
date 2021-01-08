using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dobby.Core.Models;
using Moq;
using Dobby.Core.Repositories;

namespace Dobby.Services.Tests
{
    [TestClass()]
    public class GebruikerServiceTests
    {
        
        
        [TestMethod()]
        public async Task GetAllGebruikersTestMetMockRepositorySuccesvol()
        {
            var testResult = new List<Gebruiker> { new Gebruiker { Id = 1, Gebruikersnaam = "pimm32", Rating = 1750 }, new Gebruiker { Id = 2, Gebruikersnaam = "karbonkel", Rating = 1952 } };
            //arrange
            var mockUnitOfWork = new Mock<IGebruikerRepository>();
            mockUnitOfWork.Setup(x => x.GetAllGebruikers()).ReturnsAsync(testResult).Verifiable();
            var service = new GebruikerService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetAllGebruikers() as List<Gebruiker>;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("karbonkel", result[1].Gebruikersnaam);
            Assert.AreEqual(1, result[0].Id);
        }
        
        [TestMethod()]
        public async Task GetGebruikerByIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new Gebruiker { Id = 1, Gebruikersnaam="pimm32", Rating=1500 };
            //arrange
            var mockUnitOfWork = new Mock<IGebruikerRepository>();
            mockUnitOfWork.Setup(x => x.GetGebruikerByGebruikerId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new GebruikerService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetGebruikerById(1) as Gebruiker;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("pimm32", result.Gebruikersnaam);
            Assert.AreEqual(1500, result.Rating);
        }
    }
}