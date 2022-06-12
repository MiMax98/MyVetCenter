using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using VetCenter.Data;
using VetCenter.Models;
using VetCenter.Services;
using VetCenter.Services.Interfaces;

namespace VetCenter.Tests
{
    [TestClass]
    public class HomeServiceTests
    {
        [TestMethod]
        public void GetHomeModelTest()
        {
            var service = GetService();

            var result = service.GetHomeModel();

            Assert.AreEqual(2, result.NumberOfOwners);
            Assert.AreEqual(3, result.NumberOfPets);
        }

        private IHomeService GetService()
        {
            var owners = new List<Owner>
            {
                new Owner {OwnerId = 1, FirstName = "A", LastName = "A"},
                new Owner {OwnerId = 2, FirstName = "B", LastName = "B"}
            };
            var ownersSet = new Mock<DbSet<Owner>>();
            ownersSet.AddData(owners);

            var pets = new List<Pet>
            {
                new Pet {PetId = 1, Name = "A"},
                new Pet {PetId = 2, Name = "B"},
                new Pet {PetId = 3, Name = "C"},
            };
            var petSet = new Mock<DbSet<Pet>>();
            petSet.AddData(pets);

            var context = new Mock<VetCenterContext>();
            context.Setup(c => c.Owners)
                .Returns(ownersSet.Object);
            context.Setup(c => c.Pets)
                .Returns(petSet.Object);

            return new HomeService(context.Object);
        }
    }
}
