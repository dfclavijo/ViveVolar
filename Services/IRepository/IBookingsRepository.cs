using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Services.Dtos.Incomming;
using Services.Dtos.Outgoing;

namespace Services.IRepository
{
    public interface IBookingsRepository : IGenericRepository<Booking> 
    {
        Task<bool> AddBooking(BookingInput bookingInput);
        Task<IEnumerable<BookingOutput>> GetBookingsByCustomer (int userId);
    }
}