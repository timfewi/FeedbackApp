using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FeedbackApp.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
    }
}
