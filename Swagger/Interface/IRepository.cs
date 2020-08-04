using EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int Id);
        string Update(T entity);
        string Insert(T entity, Func<T, bool> where);
        string Delete(T entity);
        string SaveChanges();

    }
}
