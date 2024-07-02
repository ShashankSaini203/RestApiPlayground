﻿using Microsoft.EntityFrameworkCore;
using RestApiPlayground.Domain.Contracts;
using RestApiPlayground.Domain.Repositories.Base;
using RestApiPlayground.Infrastructure.Data;
using System.Linq.Expressions;

namespace RestApiPlayground.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            _dataContext.Set<T>().AsNoTracking();
            return await _dataContext.Set<T>().ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        //public async Task<T> UpdateAsync(int id, Dictionary<string, object> updatedProperties)
        //{
        //    var entity = await _dataContext.Set<T>().FindAsync(id);
        //    if (entity == null)
        //    {
        //        throw new KeyNotFoundException($"{typeof(T).Name} with id {id} not found.");
        //    }

        //    foreach (var property in updatedProperties)
        //    {
        //        _dataContext.Entry(entity).Property(property.Key).CurrentValue = property.Value;
        //        _dataContext.Entry(entity).Property(property.Key).IsModified = true;
        //    }

        //    await _dataContext.SaveChangesAsync();
        //    return entity;
        //}

        public async Task DeleteAsync(long id)
        {
            var entity = await _dataContext.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
