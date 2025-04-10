using foodHub.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodHub.Repository.Implementation
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var record = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(record);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var record = await _context.Set<TEntity>().FindAsync(id);
            return record;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task Update(TEntity entity)
        {
            var record = await _context.Set<TEntity>().FindAsync(entity);
            if (record == null)
            {
                throw new Exception("Record not found");
            }
            _context.Set<TEntity>().Update(entity);
        }
    }
}
