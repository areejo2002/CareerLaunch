public class Skill
{
    public int SkillId { get; set; }
    public string? SkillType { get; set; }
    public string? SkillName { get; set; }

    // Foreign Key + Navigation
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
