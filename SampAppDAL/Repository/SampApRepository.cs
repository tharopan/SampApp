using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ = System.Linq.Expressions;
using System.Data.Entity;
using SampAppDAL.Context;

namespace SampAppDAL.Repository
{
    public class SampApRepository<TEntity> where TEntity : class
    {
        internal SampAppContext context;
        internal DbSet<TEntity> dbSet;

        public SampApRepository(SampAppContext ctx)
        {
            this.context = ctx;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(LINQ.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderby != null)
                {
                    return orderby(query);
                }
                else
                {
                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual TEntity GetById(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                dbSet.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}