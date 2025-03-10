using FeedbackApp.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FeedbackApp.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
