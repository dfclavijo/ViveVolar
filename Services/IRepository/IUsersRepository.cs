using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Services.Dtos.Outgoing;

namespace Services.IRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        Task<IEnumerable<UserOutput>> GetAllWithBookings();
    }
}