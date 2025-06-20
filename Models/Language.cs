public class Language
{
    public int LanguageId { get; set; }
    public string? Name { get; set; }
    public string? Level { get; set; }

    // Foreign Key + Navigation
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
