using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.IService
{
    public interface IGenericService<T>
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task<T> Put(int id, T entity);
        Task<T> Post(T entity);
        Task<bool> Delete(int id);
    }
}
