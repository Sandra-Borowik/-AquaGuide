using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using AquaGuide.Entities;
using System.Text;
using AquaGuide2.Entities;

namespace AquaGuide.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

       public DbSet<Comment> Comments { get; set; }

       public DbSet<Post> Posts { get; set; }

       public DbSet<Parameter> Parameters { get; set; }

       public DbSet<Fish> Fishes { get; set; }
        
       public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
