using System;
using System.Collections.Generic;
using System.Linq;
using VetCenter.Models;

namespace VetCenter.Data
{
    public static class DbInitializer
    {
        public static void Initialize(VetCenterContext context)
        {
            context.Database.EnsureCreated();

            if (context.Owners.Any())
            {
                return;
            }

            var owners = new List<Owner>
            {
                new Owner { FirstName = "Grażyna", LastName = "Kowalska" },
                new Owner { FirstName = "Stanisław", LastName = "Nowak" },
                new Owner { FirstName = "Małgorzata", LastName = "Potocka" }
            };

            foreach (var owner in owners)
            {
                context.Owners.Add(owner);
            }

            context.SaveChanges();

            var pets = new List<Pet>
            {
                new Pet { Name = "Sansa", Species = "Kot", Breed = "Pers", BirthDate = new DateTime(2020,3,20), OwnerId = 3 },
                new Pet { Name = "Burek", Species = "Pies", Breed = "Owczarek niemiecki", BirthDate = new DateTime(2018,7,15), OwnerId = 1 },
                new Pet { Name = "Filemon", Species = "Kot", Breed = "Europejski", BirthDate = new DateTime(2019,2,3), OwnerId = 2 },
                new Pet { Name = "Nutka", Species = "Pies", Breed = "Golden retriever", BirthDate = new DateTime(2018,7,15), OwnerId = 2 }
            };

            foreach (var pet in pets)
            {
                context.Pets.Add(pet);
            }
            context.SaveChanges();
        }
    }
}
