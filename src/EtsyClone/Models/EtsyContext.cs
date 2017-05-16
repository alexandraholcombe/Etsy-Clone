using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EtsyClone.Models
{
    public class EtsyContext : IdentityDbContext<ApplicationUser>
    {
        public EtsyContext()
        {

        }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public EtsyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EtsyClone;integrated security=True");
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .HasOne(e => e.UserProfile)
                .WithOne(c => c.ApplicationUser)
                .HasForeignKey<UserProfile>(b => b.Id);
            base.OnModelCreating(builder);
        }
    }
}