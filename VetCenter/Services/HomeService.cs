using System.Linq;
using VetCenter.Data;
using VetCenter.Models;
using VetCenter.Services.Interfaces;

namespace VetCenter.Services
{
    /// <summary>
    /// Serwis strony głównej
    /// </summary>
    public class HomeService : IHomeService
    {
        private readonly VetCenterContext _context;

        public HomeService(VetCenterContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Pobierz model do strony głównej
        /// </summary>
        /// <returns></returns>

        public HomeModel GetHomeModel()
        {
            var model = new HomeModel
            {
                NumberOfPets = _context.Pets.Count(),
                NumberOfOwners = _context.Owners.Count()
            };

            return model;
        }
    }
}
