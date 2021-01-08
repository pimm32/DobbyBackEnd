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
    public class BerichtServiceTests
    {
        
        [TestMethod()]
        public async Task GetBerichtByIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new Bericht{Id=1, Tekst="blabla"};
            //arrange
            var mockUnitOfWork = new Mock<IBerichtRepository>();
            mockUnitOfWork.Setup(x => x.GetBerichtByBerichtId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new BerichtService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetBerichtById(1) as Bericht;
            Console.WriteLine(result);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("blabla", result.Tekst);
        }
        
        [TestMethod()]
        public async Task GetBerichtenFromChatByChatIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new List<Bericht> { new Bericht { Id = 1, Tekst = "blabla" }, new Bericht { Id = 2, Tekst = "blabla2", AfzenderId = 1 } };
            //arrange
            var mockUnitOfWork = new Mock<IBerichtRepository>();
            mockUnitOfWork.Setup(x => x.GetAllBerichtenWithChatByChatId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new BerichtService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetBerichtenFromChatByChatId(1) as IEnumerable<Bericht>;
            var _result = result as List<Bericht>;
            Console.WriteLine(result);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, _result.Count);
            Assert.AreEqual("blabla2", _result[1].Tekst);
        }
    }
}