using SSO.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO
{
    public class SSOContext : DbContext
    {
        public SSOContext() : base("SSO")
        {
        }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
