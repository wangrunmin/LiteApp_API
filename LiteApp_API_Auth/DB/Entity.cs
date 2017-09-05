using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LiteApp_API_Auth.DB
{
    public class SessionContext : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }
    }
    public class Session
    {
        [Key]
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}