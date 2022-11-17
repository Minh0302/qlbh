using Test.Entities;

namespace Test.Repositories
{
    public interface IGenerictRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        public IEnumerable<T> GetAll();
        T GetById(int Id);
        void Delete(T entity);
        void DeleteById(int id);
        void Save();
    }
}
