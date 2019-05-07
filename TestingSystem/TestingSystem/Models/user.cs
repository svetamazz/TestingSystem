using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Models
{
    public class user
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<passing> passings { get; set; }
    }
}
