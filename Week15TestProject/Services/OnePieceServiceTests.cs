using AutoFixture;
using AutoFixture.NUnit3;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week15Playground.Data.Interfaces;
using Week15Playground.Models;
using Week15Playground.Services;

namespace Week15TestProject.Services
{
    [TestFixture]
    [Category("Unit Tests")]
    public class OnePieceServiceTests
    {
        [Test]
        [AutoData]
        public async Task GetChaptersReturnsChaptersAsync(IFixture fixture)
        {
            var faker = new Faker();

            var chapters = fixture.Create<List<ChapterResponse>>();
            var onePieceData = Mock.Of<IOnePieceData>(x => x.GetChapters() == Task.FromResult(chapters));
            var onePieceService = CreateOnePieceService(onePieceData);
            var result = await onePieceService.GetChapters();
            Assert.Multiple(() =>
            {
                Mock.Get(onePieceData).Verify(x => x.GetChapters());
                Assert.That(chapters, Is.EqualTo(result));
            });
        }

        [Test]
        [AutoData]
        public async Task GetCharactersByCrewNameReturnsCharactersAsync(IFixture fixture)
        {
            var faker = new Faker();
            var crewName = faker.Random.Word();
            var crew = fixture.Create<CrewResponse>();
            crew.Name = crewName;
            var characters = fixture.Create<List<CharacterResponse>>();
            var charactersInCrew = new List<CharacterResponse>();
            for(int i = 0; i < characters.Count; i+=2) 
            {
                characters[i].Crew = crew;
                charactersInCrew.Add(characters[i]);
            }
            var crews = fixture.Create<List<CrewResponse>>();
            crews.Add(crew);
            
            var onePieceData = Mock.Of<IOnePieceData>(x => x.GetCrews() == Task.FromResult(crews) && x.GetCharactersByCrewId(It.IsAny<int>()) == Task.FromResult(charactersInCrew));
            var onePieceService = CreateOnePieceService(onePieceData);
            var result = await onePieceService.GetCharactersByCrewName(crew.Name);
            Assert.Multiple(() =>
            {
                Mock.Get(onePieceData).Verify(x => x.GetCrews());
                Mock.Get(onePieceData).Verify(x => x.GetCharactersByCrewId(It.IsAny<int>()));
                Assert.That(charactersInCrew, Is.EqualTo(result));
            });
        }
        private static OnePieceService CreateOnePieceService(IOnePieceData? onePieceData = null)
        {
            return new(onePieceData ?? Mock.Of<IOnePieceData>());
        }
    }
}
