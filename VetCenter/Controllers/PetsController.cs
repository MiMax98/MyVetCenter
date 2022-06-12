using Microsoft.AspNetCore.Mvc;
using System;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Controllers
{
    /// <summary>
    /// Kontroler sekcji zwierząt
    /// </summary>
    public class PetsController : Controller
    {
        private readonly IPetService _petService;
        /// <summary>
        /// Konstruktor kontrolera
        /// </summary>
        /// <param name="petService"></param>
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        /// <summary>
        /// Akcja zwracająca listę zwierząt
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var pets = _petService.GetPets();
            return View(pets);
        }
        /// <summary>
        /// Akcja widoku dodawania zwierząt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public IActionResult Create(int id)
        {
            var pet = new Pet { OwnerId = id, BirthDate = DateTime.Today };
            return View(pet);
        }
        /// <summary>
        /// Akcja dodawania zwierząt
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Add(Pet pet)
        {
            var result = _petService.AddPet(pet);
            if (!result)
            {
                ModelState.AddModelError(nameof(Pet.OwnerId), "Właściciel o podanym ID nie istnieje");
                return View("Create", pet);
            }
            return RedirectToAction("Details", "Owners", new { id = pet.OwnerId });
        }

        /// <summary>
        /// Akcja usuwania zwierząt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public IActionResult DeletePet(int id)
        {
            var result = _petService.DeletePet(id);
            if(!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Akcja widoku formularza edycji właścicieli
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public IActionResult Edit(int id)
        {
            var pet = _petService.GetPet(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View("Create", pet);
        }

        /// <summary>
        /// Zapis edycji zwierząt
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult EditPet(Pet pet)
        {
            var result =_petService.EditPet(pet.PetId, pet);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Akcja szczegółów zwierząt
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var pet = _petService.GetPet(id);
            return View(pet);
        }
        /// <summary>
        /// Akcja widoku dodawania wizyty
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddVisit(int id)
        {
            var visit = new Visit { PetId = id };
            return View(visit);
        }
        /// <summary>
        /// Akcja dodawania wizyty
        /// </summary>
        /// <param name="visit"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult CreateVisit(Visit visit)
        {
            var result = _petService.AddVisit(visit.PetId, visit);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Details", new { id = visit.PetId });
        }
    }
}
