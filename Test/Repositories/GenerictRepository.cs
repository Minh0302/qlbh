using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq.Expressions;
using Test.Data;
using Test.Entities;
using Test.Helpers;
using Test.Paging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Test.Repositories
{
    public class GenerictRepository<T> : IGenerictRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        private readonly ILoggerManager _logger;

        public GenerictRepository(DataContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Create(T entity)
        {
            _logger.LogInfo("GenerictRepository: Create");
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = "User";
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "User";
            _context.Set<T>().Add(entity);
            this.Save();
        }

        public void Delete(T entity)
        {
            _logger.LogInfo("GenerictRepository: Delete");
            _context.Set<T>().Remove(entity);
            this.Save();
        }
        public void DeleteById(int id)
        {
            _logger.LogInfo("GenerictRepository: DeleteById");
            T element = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(element);
            this.Save();
        }

        public IEnumerable<T> GetAll()
        {
            _logger.LogInfo("GenerictRepository: GetAll");
            return _context.Set<T>().AsQueryable();
        }

        public T GetById(int Id)
        {
            _logger.LogInfo("GenerictRepository: GetById");
            return _context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _logger.LogInfo("GenerictRepository: Update");
            entity.ModifiedDate = DateTime.Now;
            entity.ModifiedBy = "User";
            _context.Set<T>().Update(entity);
            this.Save();
        }
        public void Save()
        {
            _logger.LogInfo("GenerictRepository: Save");
            _context.SaveChanges();
        }
        public IQueryable<T> FindAll()
        {
            _logger.LogInfo("GenerictRepository: FindAll");
            return _context.Set<T>().AsNoTracking();
        }

        public PagedList<T> GetPaging(PagingParameters pagingParameters)
        {
            _logger.LogInfo("GenerictRepository: GetPaging");
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
