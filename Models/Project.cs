namespace CareerLaunchpad.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string? ProjectName { get; set; } = string.Empty;
        public string? Description { get; set; }


        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string?ProjectAttachments { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;


        public string? ProjectLink { get; set; }

        public int PortfolioId { get; set; }

        public Portfolio Portfolio { get; set; }
    }
}
