using CareerLaunchpad.Models;

namespace CareerLaunchpad.DTO
{
    public class RecentResumeDto
    {
        public string UserName { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EndUserId { get; set; }

        // التنقلية للمستخدم
        public EndUser EndUser { get; set; }
    }
}
