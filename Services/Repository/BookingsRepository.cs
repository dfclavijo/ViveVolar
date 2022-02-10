using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.Data;
using Services.Dtos.Incomming;
using Services.Dtos.Outgoing;
using Services.IRepository;

namespace Services.Repository
{
    public class BookingsRepository : GenericRepository<Booking>, IBookingsRepository
    {
        public BookingsRepository(ViveVolarDbContext context, ILogger logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public async Task<bool> AddBooking(BookingInput bookingInput)
        {
            try
            {

                //TODO Check if booking the Exist!!
                var bookingmapped = _mapper.Map<Booking>(bookingInput);
                bookingmapped.Id = (dbSet.Any()) ? dbSet.Max(x => x.Id) + 1 : 1;
                await dbSet.AddAsync(bookingmapped); 
                return true; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(BookingsRepository));
                return false;
            }
        }

        public async Task<IEnumerable<BookingOutput>> GetBookingsByCustomer(int userId)
        {
            try
            {

                 var query =  await dbSet.Where(x => x.UserId == userId)                                
                                    .AsNoTracking()
                                    .ToListAsync();
                var outbookin = query.Select(x => _mapper.Map<BookingOutput>(x));
                return outbookin;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(BookingsRepository));
                return new List<BookingOutput>();
            }
        
      
        }
    }
}