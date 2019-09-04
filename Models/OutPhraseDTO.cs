using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class OutPhraseDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public OutCategoryDTO OutCategoryDTO{ get; set; }
        public OutAuthorDTO OutAuthorDTO { get; set; }
    }

}
