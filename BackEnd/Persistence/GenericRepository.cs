using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DataAccess;

namespace Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DataContext db;
        public GenericRepository(DataContext db)
        {
            this.db = db;
        }
        public IQueryable<T> GetAll()
             => db.Set<T>();

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }
        public void Update(T entity, int id)
        {
            db.Set<T>().Update(entity);
        }

        public Task Delete(int id)
        => db.Set<T>().Where(x => x.Id == id).ExecuteDeleteAsync();
        
        public Task SaveChangesAsync()
        => db.SaveChangesAsync();
    }
}
