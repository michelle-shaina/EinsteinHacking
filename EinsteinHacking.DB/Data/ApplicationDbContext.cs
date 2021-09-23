using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EinsteinHacking.Models;

namespace EinsteinHacking.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Hint> Hints { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<UserProgress> UserProgress { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Challenge guessing = new Challenge()
            {
                ChallengeID = 1,
                Name = "Challenge 1",
                Description = "Basic combination safety (The password is a combination of 4 numbers)",
                PointsOnCompletion = 3,
                CreatedAt = DateTime.Now,
            };
            Challenge passwordList = new Challenge()
            {
                ChallengeID = 2,
                Name = "Challenge 2",
                Description = "Basic password safety",
                PointsOnCompletion = 4,
                PointsRemovedPerHintUsed = 1,
                CreatedAt = DateTime.Now,
            };
            Challenge f12 = new Challenge()
            {
                ChallengeID = 3,
                Name = "Challenge 3",
                Description = "Basic Website Safety",
                PointsOnCompletion = 8,
                PointsRemovedPerHintUsed = 2,
                CreatedAt = DateTime.Now,
            };
            Challenge console = new Challenge()
            {
                ChallengeID = 4,
                Name = "Challenge 4",
                Description = "Cookies",
                PointsOnCompletion = 10,
                PointsRemovedPerHintUsed = 3,
                CreatedAt = DateTime.Now,
            };
            Challenge bruteforce = new Challenge()
            {
                ChallengeID = 5,
                Name = "Challenge 5",
                Description = "Try every combination there is (The password is a combination of 8 lowercase letter in the english alphabet)",
                PointsOnCompletion = 15,
                PointsRemovedPerHintUsed = 4,
                CreatedAt = DateTime.Now,
            };
            Challenge sqlinjection = new Challenge()
            {
                ChallengeID = 6,
                Name = "Challenge 6",
                Description = "Social Engineering",
                PointsOnCompletion = 20,
                PointsRemovedPerHintUsed = 5,
                CreatedAt = DateTime.Now,
            };
            Challenge socialengineering = new Challenge()
            {
                ChallengeID = 7,
                Name = "Challenge 7",
                Description = "SQL ",
                PointsOnCompletion = 25,
                PointsRemovedPerHintUsed = 6,
                CreatedAt = DateTime.Now,
            };
            Challenge encryption = new Challenge()
            {
                ChallengeID = 8,
                Name = "Challenge 8",
                Description = "Encryption",
                PointsOnCompletion = 20,
                PointsRemovedPerHintUsed = 5,
                CreatedAt = DateTime.Now,
            };
            Challenge steganographic = new Challenge()
            {
                ChallengeID = 9,
                Name = "Challenge 9",
                Description = "Steganografie",
                PointsOnCompletion = 25,
                PointsRemovedPerHintUsed = 16,
                CreatedAt = DateTime.Now,
            };
            Challenge certificate = new Challenge()
            {
                ChallengeID = 10,
                Name = "Challenge 10",
                Description = "Certificate fun",
                PointsOnCompletion = 30,
                PointsRemovedPerHintUsed = 7,
                CreatedAt = DateTime.Now,
            };

            
            base.OnModelCreating(builder);
            //builder.Entity<Challenge>()
            //    .HasData(
            //        new Challenge {}
            //    )
            builder.Entity<Challenge>()
                .HasData(
                    guessing,
                    passwordList,
                    f12,
                    console,
                    bruteforce,
                    sqlinjection,
                    socialengineering,
                    encryption,
                    steganographic,
                    certificate
                );

        }
    }
}
