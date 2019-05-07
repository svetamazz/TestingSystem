using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSystem.Models
{
    public class question
    {
        public int Id { get; set; }
        public string title { get; set; }
        public bool isManyAnswers { get; set; }
        public string picturePath { get; set; }
        public int weight { get; set; }

        public int testId { get; set; }
        public virtual test test { get; set; }

        public virtual ICollection<answer_option> answer_options { get; set; }
    }
}
