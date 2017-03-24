using NLayerDepotsApp.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDepotsApp.DAL.Repositories
{
    public abstract class SQLBaseRepository<TEntity> where TEntity : class
    {
        protected DrugsContext db;
        protected DbSet<TEntity> dbSet;

        public SQLBaseRepository(DrugsContext context)
        {
            this.db = context;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public virtual void Update(TEntity item)
        {
            dbSet.Attach(item);
            db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            TEntity item = dbSet.Find(id);
            if (item != null)
            {
                dbSet.Attach(item);
                dbSet.Remove(item);
            }
        }
    }
}
