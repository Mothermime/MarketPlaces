﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MarketPlaces.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Market> Markets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Market)
                .WithMany().WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}