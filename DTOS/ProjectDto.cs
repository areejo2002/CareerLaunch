namespace CareerLaunchpad.DTOs
{
    public class ProjectDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ProjectName { get; set; }

        public string? ProjectDescription { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public string? ProjectAttachments { get; set; }

        public int ServiceIndex { get; set; }

    }
}
