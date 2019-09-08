using EquixAPI.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
