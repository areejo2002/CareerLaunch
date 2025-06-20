using CareerLaunchpad.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CareerLaunchpad.Interfaces
{
    public interface IPortfolioRepository
    {
        Task CreateAsync(Portfolio portfolio);
        Task<List<Portfolio>> GetAllForUserAsync(string endUserId);
        Task<Portfolio?> GetByIdAsync(int id);
        Task<Portfolio?> GetPortfolioWithDetailsAsync(int id);

        Task UpdateAsync(Portfolio portfolio);
        Task DeleteAsync(int id);
        Task<List<Portfolio>> GetAllAsync();

    }
}
