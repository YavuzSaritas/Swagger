using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    public class StudentDetail : BaseEntity
    {
        public string Adress { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
