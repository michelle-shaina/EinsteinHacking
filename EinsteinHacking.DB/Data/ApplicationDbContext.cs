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
    }
}
