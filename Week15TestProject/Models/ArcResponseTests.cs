using AutoFixture.NUnit3;
using AutoFixture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Week15Playground.Models;
using Bogus;

namespace Week15TestProject.Models
{

    [TestFixture]
    [Category("Unit Tests")]
    public class ArcResponseTests
    {
        [Test]
        public void Always_HasArcResponseProperties()
        {
            var result = new ArcResponse();
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.TypeOf<int>());
                Assert.That(result.Title, Is.Empty);
                Assert.That(result.Description, Is.Empty);
            });
        }

        [Test]
        [AutoData]
        public void CreateArcResponseWorks()
        {
            var faker = new Faker();
            var id = faker.Random.Int();
            var title = faker.Random.String();
            var description = faker.Random.String();
            var result = new ArcResponse(id, title, description);
            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(id));
                Assert.That(result.Title, Is.EqualTo(title));
                Assert.That(result.Description, Is.EqualTo(description));
            });
        }
    }
}