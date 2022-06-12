using Microsoft.AspNetCore.Mvc;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Controllers
{
    /// <summary>
    /// Kontroler sekcji właścicieli
    /// </summary>
    public class OwnersController : Controller
    {
        private readonly IOwnerService _ownerService;

        /// <summary>
        /// Konstruktor kontrolera
        /// </summary>
        /// <param name="ownerService">OwnerService</param>
        public OwnersController(
            IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Akcja zwracająca listę właścicieli
        /// </summary>
        /// <returns>Widok listy właścicieli</returns>
        public IActionResult Index()
        {
            var owners = _ownerService.GetOwners();
            return View("OwnerList", owners);
        }

        /// <summary>
        /// Akcja widoku dodawania właścicieli
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Akcja dodawania właścieli
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(Owner owner)
        {
            _ownerService.AddOwner(owner);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Akcja widoku formularza edycji właścicieli
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            var owner = _ownerService.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }

            return View("Create", owner);
        }
        /// <summary>
        /// Zapis edycji właścicieli
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditOwner(Owner owner)
        {
            var result = _ownerService.EditOwner(owner.OwnerId, owner);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Akcja usuwania właścicieli
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteOwner(int id)
        {
            var result = _ownerService.DeleteOwner(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Akcja szczegółów właścicieli
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var owner = _ownerService.GetOwner(id);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }
    }
}
