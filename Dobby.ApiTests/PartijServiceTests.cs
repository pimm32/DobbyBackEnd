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
    public class PartijServiceTests
    {
        [TestMethod()]
        public async Task GetAllPartijenTestMetMockRepositorySuccesvol()
        {
            var testResultPartijenOpvragen = new List<Partij> {
                new Partij {
                    Id = 1,
                    SpeeltempoMinuten = 10,
                    SpeeltempoFisherSeconden = 5,
                    Uitslag = "1-1",
                    Zetten = new List<Zet> {
                        new Zet {
                            Id = 1,
                            BeginVeld = 32,
                            EindVeld = 28 },
                        new Zet {
                            Id = 2,
                            BeginVeld = 19,
                            EindVeld = 23 } } as ICollection<Zet>,
                    Spelers= new List<Speler>{
                        new Speler {
                            Id = 1,
                            GebruikerId = 1,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1200 },
                        new Speler{
                            Id=2,
                            GebruikerId=2,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1200 }} as ICollection<Speler>},
                new Partij {
                    Id = 2,
                    SpeeltempoMinuten = 60,
                    SpeeltempoFisherSeconden = 15,
                    Uitslag = "0",
                    Zetten = new List<Zet> {
                        new Zet {
                            Id = 1,
                            BeginVeld = 31,
                            EindVeld = 26 },
                        new Zet {
                            Id = 2,
                            BeginVeld = 20,
                            EindVeld = 25 } } as ICollection<Zet>,
                    Spelers= new List<Speler>{
                        new Speler {
                            Id = 1,
                            GebruikerId = 2,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1250 },
                        new Speler{
                            Id=2,
                            GebruikerId=1,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1150 }} as ICollection<Speler>}};
            var gebruiker1 = new Gebruiker { Id = 1, Gebruikersnaam = "pimm32", Rating = 1500 };
            var gebruiker2 = new Gebruiker { Id = 2, Gebruikersnaam = "Karbonkel", Rating = 1350 };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Partijen.GetAllWithZettenAsync()).ReturnsAsync(testResultPartijenOpvragen).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetAllPartijen() as PartijenCollectie;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PartijenDieAfgelopenZijn.Count);
            Assert.AreEqual(1, result.PartijenDieNogBezigZijn.Count);
            IList<Partij> testPartijList = result.PartijenDieAfgelopenZijn as IList<Partij>;
            Assert.IsNotNull(testPartijList[0].Spelers);
            IList<Speler> testSpelerList = testPartijList[0].Spelers as IList<Speler>;
            Assert.IsNotNull(testSpelerList[0].Gebruiker);
            Assert.AreEqual("pimm32", testSpelerList[0].Gebruiker.Gebruikersnaam);
            Assert.AreEqual(testSpelerList[0].GebruikerId, testSpelerList[0].Gebruiker.Id);
        }
        [TestMethod()]
        public async Task GetPartijenFromGebruikerByGebruikerIdTestMetMockRepositorySuccesvol()
        {
            var testResultSpelersOpvragen = new List<Speler> { new Speler { Id = 1, GebruikerId = 1, PartijId = 1 }, new Speler { Id = 2, GebruikerId = 1, PartijId = 2 } } as ICollection<Speler>;

            var testResultPartij1 =
                new Partij {
                    Id = 1,
                    SpeeltempoMinuten = 10,
                    SpeeltempoFisherSeconden = 5,
                    Uitslag = "1-1",
                    Zetten = new List<Zet> {
                        new Zet {
                            Id = 1,
                            BeginVeld = 32,
                            EindVeld = 28 },
                        new Zet {
                            Id = 2,
                            BeginVeld = 19,
                            EindVeld = 23 } } as ICollection<Zet>,
                    Spelers = new List<Speler>{
                        new Speler {
                            Id = 1,
                            GebruikerId = 1,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1200 },
                        new Speler{
                            Id=2,
                            GebruikerId=2,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1200 }} as ICollection<Speler> };
            var testResultPartij2 =
                new Partij {
                    Id = 2,
                    SpeeltempoMinuten = 60,
                    SpeeltempoFisherSeconden = 15,
                    Uitslag = "0",
                    Zetten = new List<Zet> {
                        new Zet {
                            Id = 1,
                            BeginVeld = 31,
                            EindVeld = 26 },
                        new Zet {
                            Id = 2,
                            BeginVeld = 20,
                            EindVeld = 25 } } as ICollection<Zet>,
                    Spelers= new List<Speler>{
                        new Speler {
                            Id = 2,
                            GebruikerId = 2,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1250 },
                        new Speler{
                            Id=1,
                            GebruikerId=1,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1150 }} as ICollection<Speler>};
            var gebruiker1 = new Gebruiker { Id = 1, Gebruikersnaam = "pimm32", Rating = 1500 };
            var gebruiker2 = new Gebruiker { Id = 2, Gebruikersnaam = "Karbonkel", Rating = 1350 };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Spelers.GetAllSpelersByGebruikerId(1)).ReturnsAsync(testResultSpelersOpvragen).Verifiable();

            mockUnitOfWork.Setup(x => x.Partijen.GetWithZettenByIdAsync(1)).ReturnsAsync(testResultPartij1).Verifiable();
            mockUnitOfWork.Setup(x => x.Partijen.GetWithZettenByIdAsync(2)).ReturnsAsync(testResultPartij2).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetPartijenFromGebruikerByGebruikerId(1) as PartijenCollectie;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PartijenDieAfgelopenZijn.Count);
            Assert.AreEqual(1, result.PartijenDieNogBezigZijn.Count);
            IList<Partij> testPartijList = result.PartijenDieAfgelopenZijn as IList<Partij>;
            Assert.IsNotNull(testPartijList[0].Spelers);
            IList<Speler> testSpelerList = testPartijList[0].Spelers as IList<Speler>;
            Assert.IsNotNull(testSpelerList[0].Gebruiker);
            Assert.AreEqual("pimm32", testSpelerList[0].Gebruiker.Gebruikersnaam);
            Assert.AreEqual(testSpelerList[0].GebruikerId, testSpelerList[0].Gebruiker.Id);
        }
        [TestMethod()]
        public async Task GetPartijByIdTestMetMockRepositorySuccesvol()
        {
             var testResultPartijenOpvragen =
                new Partij
                {
                    Id = 1,
                    SpeeltempoMinuten = 10,
                    SpeeltempoFisherSeconden = 5,
                    Uitslag = "1-1",
                    Zetten = new List<Zet> {
                        new Zet {
                            Id = 1,
                            BeginVeld = 32,
                            EindVeld = 28 },
                        new Zet {
                            Id = 2,
                            BeginVeld = 19,
                            EindVeld = 23 } } as ICollection<Zet>,
                    Spelers = new List<Speler>{
                        new Speler {
                            Id = 1,
                            GebruikerId = 1,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1200 },
                        new Speler{
                            Id=2,
                            GebruikerId=2,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1200 }} as ICollection<Speler>
                };
                
            var gebruiker1 = new Gebruiker { Id = 1, Gebruikersnaam = "pimm32", Rating = 1500 };
            var gebruiker2 = new Gebruiker { Id = 2, Gebruikersnaam = "Karbonkel", Rating = 1350 };
            //arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.Partijen.GetWithZettenByIdAsync(1)).ReturnsAsync(testResultPartijenOpvragen).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockUnitOfWork.Setup(x => x.Gebruikers.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockUnitOfWork.Object);

            //Act
            var result = await service.GetPartijById(1) as Partij;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("1-1", result.Uitslag);
            Assert.IsNotNull(result.Spelers);
            IList<Speler> testSpelerList = result.Spelers as IList<Speler>;
            Assert.IsNotNull(testSpelerList[0].Gebruiker);
            Assert.AreEqual("pimm32", testSpelerList[0].Gebruiker.Gebruikersnaam);
            Assert.AreEqual(testSpelerList[0].GebruikerId, testSpelerList[0].Gebruiker.Id);
        }

    }
}