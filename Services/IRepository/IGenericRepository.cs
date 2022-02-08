using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
     //Get All
     Task<IEnumerable<T>> GetAll();

     //Get By Id
     Task<T> GetById(int id);

     //Add
     Task<bool> Add (T entity);

     //Delete
    Task<bool> Delete (int id, string userId);

    //Update or Insert
    Task<bool> Upsert(T entity);


    }
}