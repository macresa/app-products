using Domain.Entities;

namespace Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity, int id);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
