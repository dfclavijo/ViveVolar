using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Services.IRepository
{
    public interface IUsersRepository : IGenericRepository<User>
    {
        
    }
}