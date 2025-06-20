public class Certificate
{
    public int CertificateId { get; set; }
    public string? ProviderName { get; set; }
    public string? TopicName { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public double? GPA { get; set; }

    // Foreign Key + Navigation
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
