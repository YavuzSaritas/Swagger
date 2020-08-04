using EFCore.Entities;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace EFCore.Services
{
    public class StudentRepositoryService : RepositoryService<Student>, IStudentRepository
    {
        public StudentRepositoryService(ApplicationContext context):base(context)
        {

        }
        public Student GetByName(string name)
        {
            var turkishInfo = new CultureInfo("tr-TR");
            return _entitiy.FirstOrDefault(p => p.Name.ToLower(turkishInfo) == name.ToLower(turkishInfo) && !p.IsDeleted);
        }
        public List<Student> GetAll()
        {
            return _entitiy
                .Include(e => e.StudentDetail)
                .Include(e => e.Evaluation)
                .Include(e => e.StudentCourse)
                .Where(p => !p.IsDeleted).ToList();
        }
        public Student GetById(int Id)
        {
            return _entitiy
                .Include(e => e.StudentDetail)
                .Include(e => e.Evaluation)
                .Include(e => e.StudentCourse)
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
        }
    }
}
