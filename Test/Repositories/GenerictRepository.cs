using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data;
using Test.Entities;
using Test.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Repositories
{
    public class GenerictRepository<T> : IGenerictRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        public GenerictRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "User";
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "User";
            _context.Set<T>().Add(entity);
            this.Save();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            this.Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "User";
            _context.Set<T>().Update(entity);
            this.Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        //public virtual IQueryable<T> Include(this IQueryable<T> qry, params string[] includes)
        //{
        //    foreach (var inc in includes)
        //        qry = qry.Include(inc);
        //    return qry;
        //}
    }
}
