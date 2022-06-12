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
    public class PetServiceTests
    {
        private Mock<VetCenterContext> _context = new Mock<VetCenterContext>();
        private Mock<DbSet<Owner>> _owners = new Mock<DbSet<Owner>>();
        private Mock<DbSet<Pet>> _pets = new Mock<DbSet<Pet>>();

        [TestMethod]
        public void GetPetsTest()
        {
            var service = GetService();

            var result = service.GetPets();

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void AddPetsTest()
        {
            var service = GetService();

            var result = service.AddPet(new Pet { Name = "C", OwnerId = 1 });

            Assert.IsTrue(result);
            _pets.Verify(o => o.Add(It.IsAny<Pet>()), Times.Once);
            _context.Verify(o => o.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddInvalidPetsTest()
        {
            var service = GetService();

            var result = service.AddPet(new Pet { Name = "C" });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetPetTest()
        {
            var service = GetService();

            var result = service.GetPet(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PetId);
            Assert.AreEqual("A", result.Name);
        }

        [TestMethod]
        public void DeletePetTest()
        {
            var service = GetService();

            var result = service.DeletePet(1);

            Assert.IsTrue(result);
            _context.Verify(c => c.Remove(It.IsAny<Pet>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteInvalidPetTest()
        {
            var service = GetService();

            var result = service.DeletePet(5);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EditPetTest()
        {
            var service = GetService();

            var result = service.EditPet(1, new Pet { Name = "newA" });
            var pet = service.GetPet(1);
            Assert.IsTrue(result);
            Assert.AreEqual("newA", pet.Name);
        }

        private IPetService GetService()
        {
            var pets = new List<Pet>
            {
                new Pet {PetId = 1, Name = "A"},
                new Pet {PetId = 2, Name = "B"},
                new Pet {PetId = 3, Name = "C"}
            };
            var owners = new List<Owner>
            {
                new Owner {OwnerId = 1, FirstName = "A", LastName = "A"},
                new Owner {OwnerId = 2, FirstName = "B", LastName = "B"}
            };
            _owners.AddData(owners);
            _pets.AddData(pets);
            _context.Setup(c => c.Owners).Returns(_owners.Object);
            _context.Setup(c => c.Pets).Returns(_pets.Object);
            return new PetService(_context.Object);
        }
    }
}
