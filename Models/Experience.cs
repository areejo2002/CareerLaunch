public class Experience
{
    public int ExperienceId { get; set; }
    public string? Title { get; set; }
    public string? Company { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool? IsCurrent { get; set; }
    public string? Duties { get; set; }

    // Foreign Key + Navigation
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
