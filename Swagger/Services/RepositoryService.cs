using EFCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFCore.Services
{
    public class RepositoryService<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        protected DbSet<T> _entitiy;       
        public RepositoryService(ApplicationContext context)
        {
            _context = context;
            _entitiy = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _entitiy.Where(p => !p.IsDeleted).ToList();
        }

        public T GetById(int Id = 0)
        {
            return _entitiy.FirstOrDefault(p => p.Id == Id && !p.IsDeleted);
        }
        
        public string Insert(T entity, Func<T, bool> where)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            if (_entitiy.Any(where))
                return "This Exist!";
            _entitiy.Add(entity);
            return SaveChanges();
        }

        public string Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("newEntity");
            _context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public string Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("newEntity");
            entity.IsDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }
        public string SaveChanges()
        {
            try
            {
                var effectedRows = _context.SaveChanges();
                if (effectedRows > 0)
                    return "Process Successful";
                return "Process Not Successful";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
       
        }

        private bool Exist(T entity)
        {
            var objContext = (_context as IObjectContextAdapter).ObjectContext;
            object existingEntity;
            var exists = objContext.TryGetObjectByKey(GetEntityKey(entity), out existingEntity);
            if (exists) objContext.Detach(existingEntity);

            return exists;
        }
        private EntityKey GetEntityKey(T entity)
        {
            var objContext = ((IObjectContextAdapter)_context).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);
            return entityKey;
        }
        
    }
}
