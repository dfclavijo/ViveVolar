using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Services.IConfiguration;
using Services.IRepository;
using Services.Repository;

namespace Services.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ViveVolarDbContext _context;
        private readonly ILogger _logger;
        public IUsersRepository Users {get; private set;}

        public UnitOfWork(ViveVolarDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Users = new UsersRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}