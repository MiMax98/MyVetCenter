using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Controllers
{
    /// <summary>
    /// Kontroler do strony domowej
    /// </summary>
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }
        /// <summary>
        /// Akcja zwracająca stronę domową
        /// </summary>
        /// <returns>Widok strony domowej</returns>
        public IActionResult Index()
        {
            var model = _homeService.GetHomeModel();
            return View(model);
        }

        /// <summary>
        /// Strona błędu
        /// </summary>
        /// <returns>Widok strony błędu</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
