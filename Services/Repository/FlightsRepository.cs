using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.Extensions.Logging;
using Services.Data;
using Services.Dtos.Incomming;
using Services.Dtos.Outgoing;
using Services.IRepository;

namespace Services.Repository
{
    public class FlightsRepository : GenericRepository<Flight>, IFlightsRepository
    {
        public FlightsRepository(ViveVolarDbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public async Task<bool> AddFlight(FlightInput flightInput)
        {
            try
            {

                //TODO Check if City the Exist!!
                var Flightmapped = _mapper.Map<Flight>(flightInput);
                Flightmapped.Id = (dbSet.Any()) ? dbSet.Max(x => x.Id) + 1 : 1;
                await dbSet.AddAsync(Flightmapped); 
                return true; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(FlightsRepository));
                return false;
            }
        }
    }
}