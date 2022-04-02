using Microsoft.AspNetCore.Identity;

namespace VoidR.ID.Identity.Models;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = default!;
}
