using EFCore.Entities;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IRepository<Course> _courseService;
        private IRepository<StudentCourse> _studentCourse;
        public CourseController(IRepository<Course> courseService, IRepository<StudentCourse> studentCourse)
        {
            _courseService = courseService;
            _studentCourse = studentCourse;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Course API Active";
        }
        [HttpGet("AllCourse")]
        public List<Course> GetAllCourses()
        {
            return _courseService.GetAll();
        }
        [HttpPost("AddCourse")]
        public string AddCourse([FromBody] Course course)
        {
            return _courseService.Insert(course,
                p=>!p.IsDeleted &&
                p.Name == course.Name);
        }
        [HttpPost("AddStudent")]
        public string AddStudentCourse([FromBody] StudentCourse studentCourse)
        {
            return _studentCourse.Insert(studentCourse,
                p=> !p.IsDeleted && 
                p.StudentId == studentCourse.StudentId &&
                p.CourseId == studentCourse.CourseId);
        }
    }
}
