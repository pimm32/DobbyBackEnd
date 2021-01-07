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
    public class ContactServiceTests
    {
        
        
        [TestMethod()]
        public async Task GetAllContactsFromGebruikerByGebruikerIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new List<GebruikerContact> { new GebruikerContact { Id = 1, GebruikerId = 1, ContactId = 2 }, new GebruikerContact { Id = 1, GebruikerId = 1, ContactId = 3 } };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Contacts.GetAllContactsFromGebruikerByGebruikerId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new ContactService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetAllContactsFromGebruikerByGebruikerId(1) as List<GebruikerContact>;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result[0].ContactId);
            Assert.AreEqual(3, result[1].ContactId);
        }
        [TestMethod()]
        public async Task GetContactByIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new GebruikerContact { Id = 1, GebruikerId=1, ContactId=2 };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Contacts.GetContactById(1)).ReturnsAsync(testResult).Verifiable();
            var service = new ContactService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetContactById(1) as GebruikerContact;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.ContactId);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(1, result.GebruikerId);
        }
    }
}