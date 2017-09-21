﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Model
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Profile { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}