
using BlogCentralApp.Data;
using BlogCentralLib.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext _dbContext;


        public BaseRepository(DataContext ctx)
        {
            _dbContext = ctx;

        }


        public virtual async Task<T> Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return entity;
        }

        public virtual async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return entity;
        }

        public virtual async Task<T> DeleteById(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                return null;
            }
            return await Delete(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            // AsNoTracking geen cache
            return _dbContext.Set<T>().AsNoTracking();
        }
        public virtual async Task<IEnumerable<T>> ListAll()
        {
            return await GetAll().ToListAsync();
        }

        public abstract Task<T> GetById<P>(P id);
        

        public virtual async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return entity;
        }

    }
}
