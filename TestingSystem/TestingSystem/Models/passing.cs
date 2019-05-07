using System;
using System.Linq;

namespace TestingSystem.Models
{
    public class passing
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public bool passed { get; set; }

        public int userId { get; set; }
        public virtual user user { get; set; }

        public int testId { get; set; }
        public virtual test test { get; set; }
    }
}
