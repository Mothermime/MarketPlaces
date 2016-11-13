﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MarketPlaces.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {//make a reference to the class here as a DbSet to allow migration.  As classes are added to the project they are added as DbSets.  As they are added, a migration is added to update the database 

        public DbSet<Market> Markets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //When there is more than one foreigh=n key which could cause multiple cascade paths, fluent API is used to 
       //This disables one of the cascade paths
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                //each attendance has a required market
                .HasRequired(a => a.Market)
                //each market can have many attendances
                .WithMany()
                //turn off cascade on delete
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>()
               .HasMany(u => u.Followees)
               .WithRequired(f => f.Follower)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}