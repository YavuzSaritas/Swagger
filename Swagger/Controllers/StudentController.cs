using EFCore.Entities;
using EFCore.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController:ControllerBase
    {
        private IStudentRepository _studentRepository;
        private IRepository<StudentDetail> _studentDetailRepository;
        private IRepository<Evaluation> _evaluationRepository;
        public StudentController(IStudentRepository studentRepository, 
            IRepository<StudentDetail> studentDetailRepository, 
            IRepository<Evaluation> evaluationRepository )
        {
            _studentRepository = studentRepository;
            _studentDetailRepository = studentDetailRepository;
            _evaluationRepository = evaluationRepository;
        }
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Student API Active!";
        }
        [HttpGet("GetAll")]
        public List<Student> GetAllStudent()
        {
            return _studentRepository.GetAll();
        }
        [HttpGet("GetById")]
        public Student GetById(int id)
        {
            return _studentRepository.GetById(id);
        }
        [HttpPost("AddStudent")]
        public string AddStudent([FromBody] Student student)
        {
            return _studentRepository.Insert(student, 
                p=>!p.IsDeleted && 
                p.Name == student.Name && 
                p.Surname == student.Surname);
        }
        [HttpPost("UpdateStudent")]
        public string UpdateStudent([FromBody] Student student)
        {
            return _studentRepository.Update(student);
        }
        [HttpPost("RemoveStudent")]
        public string RemoveStudent([FromBody] Student student)
        {
            return _studentRepository.Delete(student);
        }
        [HttpPost("AddStudentDetail")]
        public string AddStudentDetail([FromBody] StudentDetail studentDetail)
        {
            return _studentDetailRepository.Insert(studentDetail,
                p=> !p.IsDeleted && 
                p.StudentId == studentDetail.Id);
        }
        [HttpPost("AddEvaluation")]
        public string AddEvaluation([FromBody] Evaluation evaluation)
        {
            return _evaluationRepository.Insert(evaluation, 
                p=>!p.IsDeleted && 
                p.StudentId == evaluation.StudentId && 
                p.Grade == p.Grade && 
                p.Explanation == evaluation.Explanation);
        }
    }
}
