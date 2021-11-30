using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COMP586.Identity
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base(options)
        {
        }
    }
}
