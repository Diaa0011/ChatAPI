using Microsoft.AspNetCore.Identity;

namespace ChatApp.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string ProfilePhotoUrl { get; set; }
    public DateTime CreatedOn { get; set; }
}