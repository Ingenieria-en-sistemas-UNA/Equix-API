using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Entities
{
    public class Phrase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Category category { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
