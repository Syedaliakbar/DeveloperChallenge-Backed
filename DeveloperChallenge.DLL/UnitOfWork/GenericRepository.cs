using DeveloperChallenge.DLL.Exceptions;
using DeveloperChallenge.DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeveloperChallenge.DLL.UnitOfWork
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly ShippersDbContext context;
        private readonly DbSet<TEntity> dbSet;
        public GenericRepository(ShippersDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                var e = new ShippersExceptions(ex.Message, (int)SystemExceptions.Err_SavingDataDBFailure, ex);
                throw e;
            }
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
                return orderBy != null ? orderBy(query).Any() : query.Any();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync();
                }
                else
                {
                    return await query.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter).Distinct();
                }
                return await query.CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByIDAsync(object id)
        {
            try
            {
                return await dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual TEntity GetByIdAsNoTracking(object id)
        {
            try
            {
                var entity = dbSet.Find(id);
                context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<TEntity> GetByIdAsNoTrackingAsync(object id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> GetByIdAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var entity = await dbSet.FirstOrDefaultAsync(filter);
                context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual IEnumerable<TEntity> GetWithDeAttached(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {

                IQueryable<TEntity> query = dbSet.AsNoTracking();

                if (filter != null)
                {
                    query = query.Where(filter).AsNoTracking();
                }

                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty).AsNoTracking();
                }
                return orderBy != null ? orderBy(query).ToList() : query.AsNoTracking().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<long?> GetMaxIdAsync(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, long?>> maxBy)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                return await query.Where(filter).MaxAsync(maxBy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                return query.FirstOrDefault(filter);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                return await query.FirstOrDefaultAsync(filter);
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
                var entityToDelete = dbSet.Find(id);
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            try
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter).Distinct();
                }
                return query.Count();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            catch (NotSupportedException ex)
            {
                throw ex;
            }
            catch (ObjectDisposedException ex)
            {
                throw ex;

            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TEntity Update(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntity Add(TEntity entityToUpdate)
        {
            try
            {
                dbSet.Add(entityToUpdate);
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
