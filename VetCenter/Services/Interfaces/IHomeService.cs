using VetCenter.Models;

namespace VetCenter.Services.Interfaces
{
    /// <summary>
    /// Interface serwisu strony głównej
    /// </summary>
    public interface IHomeService
    {
        HomeModel GetHomeModel();
    }
}
