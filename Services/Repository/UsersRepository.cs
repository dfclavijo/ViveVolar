using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Data;
using Services.IRepository;

namespace Services.Repository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ViveVolarDbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await dbSet.Where(x => x.status == 1)
                                    .AsNoTracking()
                                    .ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(UsersRepository));
                return new List<User>();
            }
        }
    }
}