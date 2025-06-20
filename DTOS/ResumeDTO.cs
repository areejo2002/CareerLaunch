using System.ComponentModel.DataAnnotations;
using CareerLaunchpad.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CareerLaunchpad.DTOs
{
    public class ResumeDto
    {
        public int ResumeId { get; set; }   // مهم للعرض والتعديل والحذف

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10,15}$")]
        public string PhoneNumber { get; set; }


        [Required]
        [MinLength(10)]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Education field is required")]
        public string Educations{ get; set; }

        [Required(ErrorMessage = "Experience field is required")]
        public string Experiences{ get; set; }

        [Required(ErrorMessage = "Certificate field is required")]
        public string Certificates { get; set; }
  
    

    
        // الخصائص المحسوبة
    }
}