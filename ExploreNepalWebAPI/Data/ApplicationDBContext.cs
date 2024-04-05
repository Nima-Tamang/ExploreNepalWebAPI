using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

using IdentityFour.Models;
using ImagesTesting.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityFour.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
     
         public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Booking> Bookings { get; set; }

       


        public DbSet<TblProduct> TblProducts { get; set; }
        public DbSet<TblProductimage> TblProductimages { get; set; }


        public DbSet<Destination> Destinations { get; set; }
        public DbSet<DestinationImage> DestinationImages { get; set; }
      
        public DbSet<GuideInfo> GuideInfos { get; set; }
        public DbSet<GuideInfoImage> GuideInfoImages { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<ReviewImage> ReviewImages { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Destination>()
              .HasMany(d => d.DestinationImages)
              .WithOne(di => di.Destination)
              .HasForeignKey(di => di.DestinationCode)
              .OnDelete(DeleteBehavior.Cascade); // Optional: Configure cascade delete - if product is delete, files associated with is deleted


            modelBuilder.Entity<GuideInfo>()
                .HasMany(g => g.GuideInfoImages)
                .WithOne(gi => gi.GuideInfo)
                .HasForeignKey(gi => gi.GuideInfoCode)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GuideInfo>()
               .HasMany(g => g.GuideInfoImages)
               .WithOne(gi => gi.GuideInfo)
               .HasForeignKey(gi => gi.GuideInfoCode)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Booking>()
               .HasOne(b => b.UserInfo)
               .WithMany(u => u.Bookings)
               .HasForeignKey(b => b.UserInfoId);

            modelBuilder.Entity<Review>()
              .HasOne(b => b.UserInfo)
              .WithMany(u => u.Reviews)
              .HasForeignKey(b => b.UserInfoId);







            modelBuilder.Entity<Booking>()
            .Property(b => b.Price)
            .HasColumnType("decimal(18, 2)");






            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}