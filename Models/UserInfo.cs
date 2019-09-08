using EquixAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class UserInfo

    {
        public string Email { get; set; }
        public string Password { set; get; }
        public InAuthorDTO Author { get; set; }

    }

}
