using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Model
{
    public class Session
    {
        [Key]
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
