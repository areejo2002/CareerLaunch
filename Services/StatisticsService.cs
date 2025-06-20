using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareerLaunchpad.DTO;
using CareerLaunchpad.Interfaces;
using CareerLaunchpad.Models;
using Microsoft.EntityFrameworkCore;

namespace CareerLaunchpad.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _db;
        public StatisticsService(ApplicationDbContext db) => _db = db;

        public Task<int> GetTotalUsersAsync() =>
            _db.Users.CountAsync();   // AspNetUsers table

        public Task<int> GetTotalResumesAsync() =>
            _db.Resumes.CountAsync();

        public Task<int> GetTotalPortfoliosAsync() =>
            _db.Portfolios.CountAsync();

        public Task<int> GetTotalProjectsAsync() =>
            _db.Projects.CountAsync();

        public async Task<Dictionary<string, int>> GetResumesPerMonthAsync(int monthsBack)
        {
            var cutoff = DateTime.UtcNow.AddMonths(-monthsBack);
            var items = await _db.Resumes
                                 .Where(r => r.CreatedDate >= cutoff)
                                 .ToListAsync();
            return items
                .GroupBy(r => new { r.CreatedDate.Year, r.CreatedDate.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .ToDictionary(
                    g => $"{g.Key.Year}-{g.Key.Month:D2}",
                    g => g.Count()
                );
        }

        public async Task<Dictionary<string, int>> GetPortfoliosPerMonthAsync(int monthsBack)
        {
            var cutoff = DateTime.UtcNow.AddMonths(-monthsBack);
            var items = await _db.Portfolios
                                 .Where(p => p.CreatedDate >= cutoff)
                                 .ToListAsync();
            return items
                .GroupBy(p => new { p.CreatedDate.Year, p.CreatedDate.Month })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .ToDictionary(
                    g => $"{g.Key.Year}-{g.Key.Month:D2}",
                    g => g.Count()
                );
        }

        public async Task<List<RecentResumeDto>> GetRecentResumesAsync(int count)
        {
            return await _db.Resumes
                .Include(r => r.EndUser)
                .OrderByDescending(r => r.CreatedDate)
                .Take(count)
                .Select(r => new RecentResumeDto
                {
                    UserName = r.EndUser.UserName,
                    CreatedDate = r.CreatedDate
                })
                .ToListAsync();
        }

    }
}