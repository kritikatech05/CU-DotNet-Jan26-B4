using Vegabond.MVC.Models;

namespace Vegabond.MVC.Services
{
    public interface IDestinationService
    {
        Task<IEnumerable<Destination>> GetAllAsync();
        Task AddAsync(Destination destination);
        Task DeleteAsync(int id);
        Task<Destination> GetByIdAsync(int id);
        Task UpdateAsync(Destination destination);
    }
}
