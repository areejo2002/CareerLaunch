using System;
using System.Collections.Generic;
using CareerLaunchpad.DTO;

namespace CareerLaunchpad.Models
{
    public class DashboardViewModel
    {
        // مجموعيات عامة
        public int TotalUsers { get; set; }
        public int TotalResumes { get; set; }
        public int TotalPortfolios { get; set; }

        public List<Person> Users { get; set; }

        // بيانات شهرية للرسم البياني
        public Dictionary<string, int> ResumesPerMonth { get; set; }
        public Dictionary<string, int> PortfoliosPerMonth { get; set; }

        // آخر الأنشطة لجدول Recent Activity
        public List<RecentResumeDto> RecentResumes { get; set; }
        public List<RecentPortfolioDto> RecentPortfolios { get; set; }
    }

    // DTO خفيف ليعرض في الجدول


    
}
