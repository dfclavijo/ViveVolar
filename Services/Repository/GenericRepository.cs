using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Data;
using Services.IRepository;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected ViveVolarDbContext _context;
        internal DbSet<T> dbSet;
        protected ILogger _logger;
        public readonly IMapper _mapper;

        public GenericRepository(ViveVolarDbContext context, ILogger logger,IMapper mapper)
        {
            _context = context;
            dbSet = context.Set<T>(); 
            _logger = logger;
            _mapper = mapper;
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
            
        }

        public Task<bool> Delete(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}