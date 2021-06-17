using Microsoft.EntityFrameworkCore;
using Sample.Domain.SeedWork;
using Sample.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        private readonly SampleDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(SampleDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity, string username)
        {
            entity.CreatedTime = DateTime.Now;
            entity.CreatedBy = username;
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, string username)
        {
            entity.CreatedTime = DateTime.Now;
            entity.CreatedBy = username;
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public TEntity Get(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll(int page = 1, int count = 10)
        {
            return _dbSet.Where(x => !x.IsDeleted).Skip((page - 1) * count).Take(count);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(int page = 1, int count = 10)
        {
            return await _dbSet.Where(x => !x.IsDeleted).Skip((page - 1) * count).Take(count).ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null || entity.IsDeleted != false) entity = null;
            return entity;
        }

        public TEntity Update(TEntity entity, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, string username)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TKey id, string username)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(TKey id, string username)
        {
            TEntity entity = await GetAsync(id);
            if (entity != null)
            {
                entity.ModifiedTime = DateTime.Now;
                entity.ModifiedBy = username;
                entity.IsDeleted = true;
                _context.Update(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            else return false;
        }
    }
}
