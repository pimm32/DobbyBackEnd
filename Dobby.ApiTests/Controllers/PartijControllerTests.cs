using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dobby.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using Dobby.Core.Models;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using Dobby.Api.Resources;

namespace Dobby.Api.Controllers.Tests
{
    [TestClass()]
    public class PartijControllerTests
    {

        [TestMethod()]
        public async Task GetAllPartijenTestMetMockServiceSuccesvol()
        {
            var testResult = new PartijenCollectie(new List<Partij> { new Partij { Id = 1 }, new Partij { Id = 2 } }, new List<Partij> { new Partij { Id = 3 }, new Partij { Id = 4 } });
            //arrange
            var mockService = new Mock<IPartijService>();
            mockService.Setup(x => x.GetAllPartijen()).ReturnsAsync(testResult).Verifiable();
            var controller = new PartijController(mockService.Object, null);

            //Act
            var result = await controller.GetAllPartijen() as OkObjectResult;
            var _result = result.Value as PartijenCollectie;
            Console.WriteLine(result);
            //Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, _result.PartijenDieAfgelopenZijn.Count);
            Assert.AreEqual(2, _result.PartijenDieNogBezigZijn.Count);
        }
        [TestMethod()]
        public async Task GetAllPartijenFromGebruikerByGebruikerIdTestMetMockServiceSuccesvol()
        {
            var testResult = new PartijenCollectie(new List<Partij> { new Partij { Id = 1 }, new Partij { Id = 2 } }, new List<Partij> { new Partij { Id = 3 }, new Partij { Id = 4 } });
            //arrange
            var mockService = new Mock<IPartijService>();
            mockService.Setup(x => x.GetPartijenFromGebruikerByGebruikerId(1)).ReturnsAsync(testResult).Verifiable();
            var controller = new PartijController(mockService.Object, null);

            //Act
            var result = await controller.GetAllPartijenFromGebruikerByGebruikerId(1) as ObjectResult;
            var result2 = await controller.GetAllPartijenFromGebruikerByGebruikerId(2) as ObjectResult;
            var _result = result.Value as PartijenCollectie;
            var _result2 = result2.Value as PartijenCollectie;
            Console.WriteLine(result);
            //Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(200, result2.StatusCode);
            Assert.IsNotNull(_result);
            Assert.IsNull(_result2);
            Assert.AreEqual(2, _result.PartijenDieAfgelopenZijn.Count);
            Assert.AreEqual(2, _result.PartijenDieNogBezigZijn.Count);
            var testpartij = new Partij { Id = 1 };
            IList<Partij> iList = _result.PartijenDieAfgelopenZijn as IList<Partij>;
            Assert.AreEqual(testpartij.Id, iList[0].Id);
        }

        [TestMethod()]
        public async Task GetPartijByIdTestMetMockServiceSuccesvol()
        {
            var testResult = new Partij{ Id = 1, SpeeltempoMinuten = 60, SpeeltempoFisherSeconden = 60 };
            //arrange
            var mockService = new Mock<IPartijService>();
            mockService.Setup(x => x.GetPartijById(1)).ReturnsAsync(testResult).Verifiable();
            var controller = new PartijController(mockService.Object, null);

            //Act
            var result = await controller.GetPartijById(1) as OkObjectResult;
            var _result = result.Value as Partij;
            Console.WriteLine(result);
            //Assert
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(1, _result.Id);
            Assert.IsNull(_result.Uitslag);
            Assert.AreEqual(60, _result.SpeeltempoMinuten);
            Assert.AreEqual(60, _result.SpeeltempoFisherSeconden);
        }
        
    }
}//