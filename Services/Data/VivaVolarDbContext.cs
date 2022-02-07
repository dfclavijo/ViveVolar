using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;


namespace Services.Data
{
    public class VivaVolarDbContext : IdentityDbContext
    {
        public virtual DbSet<User> Users {get;set;}
        public VivaVolarDbContext(DbContextOptions<VivaVolarDbContext> options) : base(options)
        {
            
        }
        
    }
}