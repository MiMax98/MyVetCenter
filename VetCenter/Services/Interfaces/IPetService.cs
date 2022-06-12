using System.Collections.Generic;
using VetCenter.Models;

namespace VetCenter.Services.Interfaces
{
    /// <summary>
    /// Interface serwisu zwierzęcia
    /// </summary>
    public interface IPetService
    {
        List<Pet> GetPets();
        bool AddPet(Pet pet);
        Pet GetPet(int id);
        bool DeletePet(int petId);
        bool EditPet(int petId, Pet pet);
        bool AddVisit(int petId, Visit visit);
    }
}
