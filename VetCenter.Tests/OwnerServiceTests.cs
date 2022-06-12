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
    public class OwnerServiceTests
    {
        private Mock<VetCenterContext> _context = new Mock<VetCenterContext>();
        private Mock<DbSet<Owner>> _owners = new Mock<DbSet<Owner>>();

        [TestMethod]
        public void GetOwnersTest()
        {
            var service = GetService();

            var result = service.GetOwners();

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void AddOwnersTest()
        {
            var service = GetService();

            service.AddOwner(new Owner { FirstName = "C", LastName = "C" });

            _owners.Verify(o => o.Add(It.IsAny<Owner>()), Times.Once);
            _context.Verify(o => o.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetOwnerTest()
        {
            var service = GetService();

            var result = service.GetOwner(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.OwnerId);
            Assert.AreEqual("A", result.FirstName);
            Assert.AreEqual("A", result.LastName);
        }

        [TestMethod]
        public void EditOwnerTest()
        {
            var service = GetService();

            var result = service.EditOwner(1, new Owner { FirstName = "newA", LastName = "newA" });
            var owner = service.GetOwner(1);
            Assert.IsTrue(result);
            Assert.AreEqual("newA", owner.FirstName);
            Assert.AreEqual("newA", owner.LastName);
        }

        [TestMethod]
        public void EditInvlidOwnerTest()
        {
            var service = GetService();

            var result = service.EditOwner(8, new Owner { FirstName = "newA", LastName = "newA" });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void DeleteOwnerTest()
        {
            var service = GetService();

            var result = service.DeleteOwner(1);

            Assert.IsTrue(result);
            _context.Verify(c => c.Remove(It.IsAny<Owner>()), Times.Once);
            _context.Verify(c => c.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteInvalidOwnerTest()
        {
            var service = GetService();

            var result = service.DeleteOwner(5);

            Assert.IsFalse(result);
        }



        private IOwnerService GetService()
        {
            var owners = new List<Owner>
            {
                new Owner {OwnerId = 1, FirstName = "A", LastName = "A"},
                new Owner {OwnerId = 2, FirstName = "B", LastName = "B"}
            };
            _owners.AddData(owners);

            _context.Setup(c => c.Owners).Returns(_owners.Object);

            return new OwnerService(_context.Object);
        }
    }
}
