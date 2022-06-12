using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VetCenter.Data;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Services
{
    /// <summary>
    /// Serwis właściciela
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly VetCenterContext _context;

        public OwnerService(VetCenterContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Dodaj właściciela
        /// </summary>
        /// <param name="owner"></param>

        public void AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Usuń właściciela
        /// </summary>
        /// <param name="ownerId"></param>
        /// <returns></returns>

        public bool DeleteOwner(int ownerId)
        {
            var owner = GetOwner(ownerId);
            if (owner == null)
            {
                return false;
            }
            if (owner.Pets != null)
            {
                foreach (var pet in owner.Pets)
                {
                    _context.Remove(pet);
                }
            }
            _context.Remove(owner);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Edytuj właściciela
        /// </summary>
        /// <param name="ownerId"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool EditOwner(int ownerId, Owner owner)
        {
            var old = GetOwner(ownerId);
            if (old == null)
            {
                return false;
            }
            old.FirstName = owner.FirstName;
            old.LastName = owner.LastName;
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Pobierz właściciela
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Owner GetOwner(int id)
        {
            var owner = _context
                .Owners
                .Include(o => o.Pets)
                .SingleOrDefault(o => o.OwnerId == id);
            return owner;
        }
        /// <summary>
        /// Pobierz listę właścicieli
        /// </summary>
        /// <returns></returns>

        public List<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }
    }
}
