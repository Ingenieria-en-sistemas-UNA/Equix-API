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
        public InCategoryDTO Category { get; set; }
        public InAuthorDTO Author { get; set; }
    }
}
