using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    [Table("Course")]
    public class Course : BaseEntity
    {
        [Required(ErrorMessage ="Course name is not empty!")]
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
