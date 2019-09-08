using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class OutAuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<OutPhraseDTO> Phrases { get; set; }
    }
}
