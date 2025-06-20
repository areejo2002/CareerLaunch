using CareerLaunchpad.Models;

public class Resume
{

    public int ResumeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Bio { get; set; }
    public EndUser? EndUser { get; set; }
    public string EndUserId { get; set; }

    // Navigation Properties
    public ICollection<Education> Educations { get; set; } = new List<Education>();
    public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
    public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    public ICollection<Skill> Skills { get; set; } = new List<Skill>();
    public ICollection<Language> Languages { get; set; } = new List<Language>();

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
