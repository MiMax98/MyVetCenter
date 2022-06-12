using System.Collections.Generic;
using VetCenter.Models;

namespace VetCenter.Services.Interfaces
{
    /// <summary>
    /// Interface serwisu właściciela
    /// </summary>
    public interface IOwnerService
    {
        List<Owner> GetOwners();
        void AddOwner(Owner owner);
        Owner GetOwner(int id);
        bool EditOwner(int ownerId, Owner owner);
        bool DeleteOwner(int ownerId);
    }
}
