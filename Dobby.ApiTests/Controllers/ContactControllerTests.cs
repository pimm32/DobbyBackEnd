using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Dobby.Core.Models;
using Dobby.Core.Services;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dobby.Api.Controllers.Tests
{
    [TestClass()]
    public class ContactControllerTests
    {
        [TestMethod()]
        public async Task GetAllContactsFromGebruikerByGebruikerIdTestSuccesvol()
        {
            var testResult = new List<GebruikerContact> { new GebruikerContact { Id = 1 }, new GebruikerContact { Id = 2 } };
            //arrange
            var mockService = new Mock<IContactService>();
            mockService.Setup(x => x.GetAllContactsFromGebruikerByGebruikerId(1)).ReturnsAsync(testResult).Verifiable();
            var controller = new ContactController(mockService.Object, null);

            //Act
            var result = await controller.GetAllContactsFromGebruikerByGebruikerId(1) as IEnumerable<GebruikerContact>;
            var _result = result as List<GebruikerContact>;
            Console.WriteLine(result);
            //Assert
            Assert.AreEqual(2, _result.Count);
            Assert.AreEqual(1, _result[0].Id);
        }
    }
}