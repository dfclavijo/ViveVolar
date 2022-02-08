using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(u=> u.Id);
            entityBuilder.HasIndex(u=> u.Id);
            entityBuilder.Property(u=> u.Id).ValueGeneratedOnAdd();
            entityBuilder.Property(u=> u.FirstName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(u=> u.LastName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(u=> u.Email).IsRequired().HasMaxLength(100);
            entityBuilder.Property(u=> u.DateOfBirth).IsRequired();
            
        }
    }
}