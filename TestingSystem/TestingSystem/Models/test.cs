using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestingSystem.Models
{
    public class test
    {
        public int Id { get; set; }
        public string name { get; set; }

        [Range(0, 300)]
        public int? minutes { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int allPoints
        {
            get { return questions.Sum(q => q.weight); }
            private set { }
        }
        
        public virtual ICollection<question> questions { get; set; }
        public virtual ICollection<passing> passings { get; set; }
    }
}
