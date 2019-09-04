using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EquixAPI.Entities;

namespace EquixAPI.Models
{
    public class EquixAPIContext : DbContext
    {
        public EquixAPIContext (DbContextOptions<EquixAPIContext> options)
            : base(options)
        {
        }

        public DbSet<EquixAPI.Entities.Phrase> Phrase { get; set; }

        public DbSet<EquixAPI.Entities.Author> Author { get; set; }

        public DbSet<EquixAPI.Entities.Category> Category { get; set; }
    }
}
