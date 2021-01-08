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
    public class ZetServiceTests
    {
        [TestMethod()]
        public async Task GetZetByIdTestMetMockRepositorySuccesvol()
        {
            var testResult = new Zet {Id=1, BeginVeld=32, EindVeld=28, PartijId=1 };
            //arrange
            var mockUnitOfWork = new Mock<IZetRepository>();
            mockUnitOfWork.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(testResult).Verifiable();
            var service = new ZetService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetZetById(1) as Zet;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(32, result.BeginVeld);
            Assert.AreEqual(28, result.EindVeld);
            Assert.AreEqual(1, result.PartijId);
        }
    }
}