using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq.Expressions;
using Test.Data;
using Test.Entities;
using Test.Paging;
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
        public void DeleteById(int id)
        {
            T element = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(element);
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
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        //public IEnumerable<T> GetPaging(PagingParameters pagingParameters)
        //{
        //    var data = _context.Set<T>().AsNoTracking();

        //    var TotalCount = data.Count();
        //    var PageSize = pagingParameters.PageSize;
        //    var TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        //    var items = data.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize).Take(pagingParameters.PageSize).ToList();

        //    return items;
        //}

        public PagedList<T> GetPaging(PagingParameters pagingParameters)
        {
            var data = _context.Set<T>().AsNoTracking();

            var TotalCount = data.Count();
            var PageSize = pagingParameters.PageSize;
            var TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            var items = data.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize).Take(pagingParameters.PageSize).ToList();

            var minh = new PagedList<T>(pagingParameters.PageNumber, TotalPages, items);
            
            return minh;
        }
    }
}
