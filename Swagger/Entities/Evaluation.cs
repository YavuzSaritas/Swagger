using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class Evaluation : BaseEntity
    {
        public int Grade { get; set; }
        public string Explanation { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
