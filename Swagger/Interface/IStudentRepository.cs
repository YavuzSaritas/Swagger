using EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByName(string name);
    }
}
