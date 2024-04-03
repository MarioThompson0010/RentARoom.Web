using AuthenticationTest.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentARoom.Models;

namespace AuthenticationTest.Data;

public class BlazorContext : IdentityDbContext<IdentityUser>
{
    public BlazorContext(DbContextOptions<BlazorContext> options)
        : base(options)
    {
        if (options.ContextType == typeof(BlazorContext))
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
