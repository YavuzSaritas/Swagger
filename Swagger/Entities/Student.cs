using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Entities
{
    [Table("Student")]
    public class Student : BaseEntity
    {
        [Required(ErrorMessage = "Name is Empty")]
        [MaxLength(50,ErrorMessage ="Length must be less than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is Empty!")]
        public string Surname { get; set; }

        [Required(ErrorMessage ="Age is not empty!")]        
        public int Age { get; set; }

        public StudentDetail StudentDetail { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }
        public ICollection<Evaluation> Evaluation { get; set; }
    }
}
