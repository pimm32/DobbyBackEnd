using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dobby.Core.Models;
using Dobby.Core.Services;
using Moq;

namespace Dobby.Api.Controllers.Tests
{
    [TestClass()]
    public class GebruikerControllerTests
    {
       
        [TestMethod()]
        public async Task GetAllGebruikersTestSuccesvol()
        {
            var testResult = new List<Gebruiker> { new Gebruiker { Id = 1 }, new Gebruiker { Id = 2 } };
            //arrange
            var mockService = new Mock<IGebruikerService>();
            mockService.Setup(x => x.GetAllGebruikers()).ReturnsAsync(testResult).Verifiable();
            var controller = new GebruikerController(mockService.Object, null);

            //Act
            var result = await controller.GetAllGebruikers() as IEnumerable<Gebruiker>;
            var _result = result as List<Gebruiker>;
            Console.WriteLine(result);
            //Assert
            Assert.AreEqual(2, _result.Count);
            Assert.AreEqual(1, _result[0].Id);
        }
        
            [TestMethod()]
        public async Task GetGebruikerByIdSuccesvol()
        {
            var testResult = new Gebruiker{ Id = 1};
            //arrange
            var mockService = new Mock<IGebruikerService>();
            mockService.Setup(x => x.GetGebruikerById(1)).ReturnsAsync(testResult).Verifiable();
            var controller = new GebruikerController(mockService.Object, null);

            //Act
            var result = await controller.GetGebruikerById(1) as Gebruiker;
            Console.WriteLine(result);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

    }
}