using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VetCenter.Data;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Services
{
    /// <summary>
    /// Serwis zwierząt
    /// </summary>
    public class PetService : IPetService
    {
        private readonly VetCenterContext _context;

        public PetService(VetCenterContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dodaj zwierzę
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>

        public bool AddPet(Pet pet)
        {
            if (!_context.Owners.Any(o => o.OwnerId == pet.OwnerId))
            {
                return false;
            }
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Pobierz zwierzę
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Pet GetPet(int id)
        {
            var pet = _context
                .Pets
                .Include(p => p.Owner)
                .Include(p => p.Visits)
                .SingleOrDefault(p => p.PetId == id);
            return pet;
        }
        /// <summary>
        /// Usuń zwierzę
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>

        public bool DeletePet(int petId)
        {
            var pet = GetPet(petId);
            if (pet == null)
            {
                return false;
            }
            _context.Remove(pet);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Pobierz listę zwierząt
        /// </summary>
        /// <returns></returns>
        public List<Pet> GetPets()
        {
            return _context
                .Pets
                .Include(p => p.Owner)
                .ToList();
        }
        /// <summary>
        /// Edytuj zwierzę
        /// </summary>
        /// <param name="petId"></param>
        /// <param name="pet"></param>
        /// <returns></returns>

        public bool EditPet(int petId, Pet pet)
        {
            var old = GetPet(petId);
            if (old == null)
            {
                return false;
            }
            old.Name = pet.Name;
            old.Species = pet.Species;
            old.Breed = pet.Breed;
            old.BirthDate = pet.BirthDate;

            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Dodaj wizytę
        /// </summary>
        /// <param name="petId"></param>
        /// <param name="visit"></param>
        /// <returns></returns>
        public bool AddVisit(int petId, Visit visit)
        {
            var pet = GetPet(petId);
            if (pet == null)
            {
                return false;
            }
            visit.Time = DateTime.Now;
            pet.Visits.Add(visit);
            _context.SaveChanges();
            return true;
        }
    }
}
