using System.Threading.Tasks;
using CareerLaunchpad.DTO;
using CareerLaunchpad.Models;

namespace CareerLaunchpad.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalResumesAsync();
        Task<int> GetTotalPortfoliosAsync();
        Task<int> GetTotalProjectsAsync();

        Task<Dictionary<string, int>> GetResumesPerMonthAsync(int monthsBack);
        Task<Dictionary<string, int>> GetPortfoliosPerMonthAsync(int monthsBack);

        //  الدالة الجديدة لجلب أحدث السير الذاتية
        Task<List<RecentResumeDto>> GetRecentResumesAsync(int count);
    }
}