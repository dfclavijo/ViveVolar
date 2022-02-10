using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public IBookingsRepository Bookings {get; private set;}

        public IFlightsRepository Flights {get; private set;}

        public UnitOfWork(ViveVolarDbContext context, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Users = new UsersRepository(context, _logger, mapper);
            Bookings = new BookingsRepository(context, _logger, mapper);
            Flights = new FlightsRepository(context, _logger, mapper);
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