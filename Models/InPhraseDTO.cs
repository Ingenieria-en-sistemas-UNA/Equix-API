using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class InPhraseDTO
    {
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public InCategoryDTO InCategoryDTO { get; set; }
        public InAuthorDTO InAuthorDTO { get; set; }
    }
}
