using AutoFixture;
using AutoFixture.NUnit3;
using Bogus;
using Moq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week15Playground.Controllers;
using Week15Playground.Data.Interfaces;
using Week15Playground.Services;
using Week15Playground.Services.Interfaces;
using Week15Playground.Models;
using Week15Playground.Data;

namespace Week15TestProject.Controllers
{
    [TestFixture]
    [Category("Unit Tests")]
    public class OnePieceControllerTests
    {
        [Test]
        [AutoData]
        public async Task GetChaptersWorksAsync(IFixture fixture)
        {
            var faker = new Faker();

            var chapters = fixture.Create<List<ChapterResponse>>();
            var onePieceService = Mock.Of<IOnePieceService>(x => x.GetChapters() == Task.FromResult(chapters));
            var onePieceController = CreateOnePieceController(null, onePieceService);
            var result = await onePieceController.GetChapters();
            Assert.Multiple(() =>
            {
                Mock.Get(onePieceService).Verify(x => x.GetChapters());
                Assert.That(chapters, Is.EqualTo(result));
            });
        }

        [Test]
        [AutoData]
        public async Task GetCharactersByCrewNameWorksAsync(IFixture fixture)
        {
            var faker = new Faker();
            var crewName = faker.Random.Word();
            var crew = fixture.Create<CrewResponse>();
            crew.Name = crewName;
            var characters = fixture.Create<List<CharacterResponse>>();
            var charactersInCrew = new List<CharacterResponse>();
            for (int i = 0; i < characters.Count; i += 2)
            {
                characters[i].Crew = crew;
                charactersInCrew.Add(characters[i]);
            }
            var crews = fixture.Create<List<CrewResponse>>();
            crews.Add(crew);
            var onePieceService = Mock.Of<IOnePieceService>(x => x.GetCharactersByCrewName(crewName) == Task.FromResult(charactersInCrew));
            var onePieceController = CreateOnePieceController(null, onePieceService);
            var result = await onePieceController.GetCharactersByCrewName(crew.Name);
            Assert.Multiple(() =>
            {
                Mock.Get(onePieceService).Verify(x => x.GetCharactersByCrewName(crewName));
                Assert.That(charactersInCrew, Is.EqualTo(result));
            });
        }
        private static OnePieceController CreateOnePieceController(ILogger<OnePieceController>? logger = null, IOnePieceService? onePieceService = null)
        {
            return new(logger ?? Mock.Of<ILogger<OnePieceController>>(), onePieceService ?? Mock.Of<IOnePieceService>());
        }
    }
}
