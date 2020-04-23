using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoAppIdentityFW.Models;

namespace ToDoAppIdentityFW.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<ToDoStatus> ToDoStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Create a Default, new user for Identity Framework
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Rose",
                LastName = "Wiz",
                UserName = "r@r.com",
                NormalizedUserName = "R@R.COM",
                Email = "r@r.com",
                NormalizedEmail = "R@R.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };

            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            //Create shopping items 
            ToDoStatus status = new ToDoStatus
            {
                Id = 1,
                Title = "To Do"
              
            };
            modelBuilder.Entity<ToDoStatus>().HasData(status);

            modelBuilder.Entity<ToDoStatus>().HasData(
                new ToDoStatus()
                {
                    Id = 2,
                    Title = "In Progress"

                },
                new ToDoStatus()
                {
                    Id = 3,
                    Title = "Done"
  
                }

                 );

        }
    }
}

