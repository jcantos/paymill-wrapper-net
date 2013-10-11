using System.Collections.Generic;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Query;

namespace PaymillWrapper.Service
{
    public interface IReadService<T> 
        where T : BaseModel
    {
        Task<T> GetAsync(string id);
        Task<IReadOnlyCollection<T>> GetAsync();
        Query<T> Query { get; }
    }

    public interface ICreateService<T>
    {
        Task<T> AddAsync(T obj);
    }

    public interface IDeleteService
    {
        Task<bool> RemoveAsync(string id);
    }

    public interface IUpdateService<T>
    {
        Task<T> UpdateAsync(T obj);
    }

    public interface ICRService<T> : ICreateService<T>, IReadService<T> 
        where T : BaseModel
    { }

    public interface ICRDService<T> : ICRService<T>, IDeleteService 
        where T : BaseModel
    { }

    public interface ICRUDService<T> : ICRDService<T>, IUpdateService<T> 
        where T : BaseModel
    { }
}