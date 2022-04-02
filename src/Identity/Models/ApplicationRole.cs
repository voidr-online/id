using Microsoft.AspNetCore.Identity;

namespace VoidR.ID.Identity.Models;

public class ApplicationRole : IdentityRole<Guid>
{
    public ApplicationRole() { }

    public ApplicationRole(string roleName) : base(roleName) { }
}
