using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCentralLib.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> ListAll(); //in-memory
        IQueryable<T> GetAll(); //out-memory
        Task<T> GetById<P>(P id);
        
        //Create
        Task<T> Create(T entity);

        //Delete
        Task<T> Delete(T entity);
        Task<T> DeleteById(int id);

        //Update
        Task<T> Update(T entity);
    }
}
