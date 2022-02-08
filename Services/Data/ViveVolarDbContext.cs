using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using DataAccess.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Services.Data
{
    public class ViveVolarDbContext : IdentityDbContext
    {
        public DbSet<User> Users {get;set;}
        public ViveVolarDbContext(DbContextOptions<ViveVolarDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Database schema
            builder.HasDefaultSchema("public");

            base.OnModelCreating(builder);

            //Model Contraints
            ModelConfig(builder);
            builder.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

        }


        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<User>());
        }
        
    }
}