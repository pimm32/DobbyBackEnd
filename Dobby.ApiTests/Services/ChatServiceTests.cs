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
    public class ChatServiceTests
    {
        [TestMethod()]
        public async Task GetChatByIdTestMetMockRepositorySuccesvol()
        {
            var berichten = new List<Bericht> { new Bericht { Id = 1, Tekst = "blabla" }, new Bericht { Id = 2, Tekst = "blabla2", AfzenderId = 1 } };
            var testResult = new Chat { Id = 1, Berichten = berichten as ICollection<Bericht>  };
            //arrange
            var mockUnitOfWork = new Mock<IChatRepository>();
            mockUnitOfWork.Setup(x => x.GetChatByChatId(1)).ReturnsAsync(testResult).Verifiable();
            var service = new ChatService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetChatById(1) as Chat;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Berichten.Count);
            IList<Bericht> _berichten = result.Berichten as IList<Bericht>;
            Assert.AreEqual("blabla2", _berichten[1].Tekst);
        }
    }
}