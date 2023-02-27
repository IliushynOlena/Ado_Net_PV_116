using _07_EF_example;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace data_access_entity.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal AirplaneDbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(AirplaneDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public TEntity GetByID(int Id)
        {
            return dbSet.Find(Id);
        }
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
