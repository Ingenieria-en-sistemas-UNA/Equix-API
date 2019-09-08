using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EquixAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EquixAPI.Models
{
    public class EquixAPIContext : IdentityDbContext<ApplicationUser>
    {
        public EquixAPIContext (DbContextOptions<EquixAPIContext> options)
            : base(options)
        {

        }

        public DbSet<Phrase> Phrases { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
