using System;
using System.Linq;

namespace TestingSystem.Models
{
    public class answer_option
    {
        public int Id { get; set; }
        public string text { get; set; }
        public bool isRight { get; set; }

        public int questionId { get; set; }
        public virtual question question { get; set; }
    }
}
