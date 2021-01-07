using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dobby.Core.Models;
using Dobby.Core.Services;
using Moq;
using Dobby.Api.Controllers;
using Dobby.Core.Repositories;

namespace Dobby.Data.Repositories.Tests
{
    [TestClass()]
    public class BerichtRepositoryTests
    {
       //[TestMethod()]
       // public async Task GetAllBerichtenWithChatByChatIdTestSuccesvol()
       // {
       //     var testResult = new List<Bericht> { new Bericht { Id = 1 }, new Bericht { Id = 2 } };
       //     //arrange
       //     var mockDbContext = new Mock<IBerichtRepository>();
       //     mockRepository.Setup(x => x.GetAllBerichtenWithChatByChatId(1)).ReturnsAsync(testResult).Verifiable();
       //     var repository = new BerichtRepository(mockRepository.Object, null);

       //     //Act
       //     var result = await controller.GetAllContactsFromGebruikerByGebruikerId(1) as IEnumerable<GebruikerContact>;
       //     var _result = result as List<GebruikerContact>;
       //     Console.WriteLine(result);
       //     //Assert
       //     Assert.AreEqual(2, _result.Count);
       //     Assert.AreEqual(1, _result[0].Id);
       // }

    }
}