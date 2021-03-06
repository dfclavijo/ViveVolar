using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.IRepository;

namespace Services.IConfiguration
{
    public interface IUnitOfWork
    {
        IUsersRepository Users {get;}
        IBookingsRepository Bookings {get;}
        IFlightsRepository Flights {get;}

        Task CompleteAsync();
    }
}