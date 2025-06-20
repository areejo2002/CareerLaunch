// Interfaces/IAIPortfolio.cs
using System.Threading.Tasks;
using CareerLaunchpad.Models;

namespace CareerLaunchpad.Interfaces
{
    public interface IAIPortfolio
    {
        Task<Portfolio> PortfolioParse(string input);
        Task<string> GenerateBioAsync(Portfolio portfolio);

        string BuildHtmlPreview(Portfolio portfolio);

        string BuildHtmlPreviewDark(Portfolio p);

    }
}
