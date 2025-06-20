namespace CareerLaunchpad.Models
{
    public class PersonalInfo
    {
        public int PersonalInfoId { get; set; }
        public string? FirstName { get; set; }
        public string?SeconedName { get; set; }
        public string?ThirdName { get; set; }
        public string? LastName { get; set; }

        public string? Email { get; set; }
        public string?PhoneNumber { get; set; }

        public string?LinkedInLink { get; set; }
        public string?FacebookLink { get; set; }
        public string?InstagramLink { get; set; }

        public string? GithubLink { get; set; }

        public string?Adress { get; set; }

        public DateOnly?DateOfBirth { get; set; }
        public string? Bio { get; set; }

        public string?Title { get; set; }
    }
}
