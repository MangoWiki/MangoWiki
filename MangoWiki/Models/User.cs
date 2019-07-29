using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MangoWiki.Models
{
    [Table("users")]
    public class User
    {
        
        public int ID { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public bool IsInRole(string role)
        {
            if (Roles == null) throw new Exception("Roles not set for user.");
            return Roles.Contains(role);
        }

    }
}
