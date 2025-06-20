public class Education
{
    public int EducationId { get; set; }
    public string? CollageName { get; set; }
    public string? DegreeType { get; set; }
    public string? Major { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public double? GPA { get; set; }

    // Foreign Key + Navigation
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
