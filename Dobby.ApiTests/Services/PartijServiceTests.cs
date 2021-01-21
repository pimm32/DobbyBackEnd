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
        Mock<IPartijRepository> mockPartijRepository;
        Mock<IGebruikerRepository> mockGebruikerRepository;
        Mock<ISpelerRepository> mockSpelerRepository;
        Mock<IBerichtRepository> mockBerichtRepository;


        [TestInitialize]
        public void Initialize()
        {
            mockPartijRepository = new Mock<IPartijRepository>();
            mockGebruikerRepository = new Mock<IGebruikerRepository>();
            mockSpelerRepository = new Mock<ISpelerRepository>();
            mockBerichtRepository = new Mock<IBerichtRepository>();
        }
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

            mockPartijRepository.Setup(x => x.GetAllWithZettenAsync()).ReturnsAsync(testResultPartijenOpvragen).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);

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
            var testResultPartij2 =
                new Partij
                {
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
                    Spelers = new List<Speler>{
                        new Speler {
                            Id = 2,
                            GebruikerId = 2,
                            KleurSpeler = "Wit",
                            RatingAanBeginVanWedstrijd = 1250 },
                        new Speler{
                            Id=1,
                            GebruikerId=1,
                            KleurSpeler="Zwart",
                            RatingAanBeginVanWedstrijd=1150 }} as ICollection<Speler>
                };
            var gebruiker1 = new Gebruiker { Id = 1, Gebruikersnaam = "pimm32", Rating = 1500 };
            var gebruiker2 = new Gebruiker { Id = 2, Gebruikersnaam = "Karbonkel", Rating = 1350 };
            //arrange
            var mockSpelerRepository = new Mock<ISpelerRepository>();
            var mockPartijRepository = new Mock<IPartijRepository>();
            var mockGebruikerRepository = new Mock<IGebruikerRepository>();
            mockSpelerRepository.Setup(x => x.GetAllSpelersByGebruikerId(1)).ReturnsAsync(testResultSpelersOpvragen).Verifiable();

            mockPartijRepository.Setup(x => x.GetWithZettenByIdAsync(1)).ReturnsAsync(testResultPartij1).Verifiable();
            mockPartijRepository.Setup(x => x.GetWithZettenByIdAsync(2)).ReturnsAsync(testResultPartij2).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);


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
            var mockPartijRepository = new Mock<IPartijRepository>();
            var mockGebruikerRepository = new Mock<IGebruikerRepository>();
            mockPartijRepository.Setup(x => x.GetWithZettenByIdAsync(1)).ReturnsAsync(testResultPartijenOpvragen).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(1)).ReturnsAsync(gebruiker1).Verifiable();
            mockGebruikerRepository.Setup(x => x.GetGebruikerByGebruikerId(2)).ReturnsAsync(gebruiker2).Verifiable();
            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);


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

        [TestMethod()]
        public void AllePartijenDieAfZijnSorterenTest()
        {
            //arrange 
            var testpartij1 = new Partij { Id = 1, Uitslag = "0" };
            var testpartij2 = new Partij { Id = 2, Uitslag = "0-2" };
            var testpartij3 = new Partij { Id = 3, Uitslag = "0" };
            var testpartij4 = new Partij { Id = 4, Uitslag = "1-1" };
            var testpartij5 = new Partij { Id = 5, Uitslag = "0" };

            var partijen = new List<Partij> { testpartij1, testpartij2, testpartij3, testpartij4, testpartij5 };

            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);
            
            var result = service.AllePartijenDieAfZijn(partijen) as List<Partij>;

            Assert.IsNotNull(service);
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod()]
        public void BerekenRatingVerschilTest()
        {
            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);

            var res1 = service.BerekenRatingVerschil(1200, 1500, "2-0", "wit");
            Assert.AreEqual(6, res1);

            var res2 = service.BerekenRatingVerschil(100, 2000, "1-1", "wit");
            Assert.AreEqual(20, res2);

            var res3 = service.BerekenRatingVerschil(100, 2000, "1-1", "zwart");
            Assert.AreEqual(-20, res3);
        }

        [TestMethod()]
        public void AllePartijenDieWelOfNietAfZijnTest()
        {
            var collectie = new List<Partij>{new Partij { Id = 1, Uitslag = "0" },
                new Partij { Id = 2, Uitslag = "0-2" },
                new Partij { Id = 3, Uitslag = "0" },
                new Partij { Id = 4, Uitslag = "1-1" },
                new Partij { Id = 5, Uitslag = "0" } };
            var service = new PartijService(mockPartijRepository.Object, mockSpelerRepository.Object, mockGebruikerRepository.Object, mockBerichtRepository.Object);

            Assert.AreEqual(3, service.AllePartijenDieNietAfZijn(collectie).Count);
            Assert.AreEqual(2, service.AllePartijenDieAfZijn(collectie).Count);

        }

        
    }
}