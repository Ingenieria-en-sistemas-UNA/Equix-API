using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EquixAPI.Models
{
    public class UserToken
    {
        public string Token { set; get; }
        public DateTime Expiration{ get; set; }
    }
}
