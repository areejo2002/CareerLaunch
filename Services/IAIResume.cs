namespace CareerLaunchpad.Services
{
    public interface IAIResume
    {
        Task<Resume> ResumeParse(string input);
        string BuildHtmlPreview(Resume resume);
        string GeneratePlainTextFromResume(Resume resume); // 🔹 أضيفي هذه
    }
}
