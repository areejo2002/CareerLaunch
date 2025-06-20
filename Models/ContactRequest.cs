// Models/ContactRequest.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace CareerLaunchpad.Models
{
    public class ContactRequest
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
