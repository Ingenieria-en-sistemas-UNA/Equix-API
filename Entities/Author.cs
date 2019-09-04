using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string name { get; set; }

        public List<Phrase> phrases { get; set; }
    }
}
