using System.Collections.Generic;
using System.Threading.Tasks;
using PaymillWrapper.Net;

namespace PaymillWrapper.Service
{
    public interface IReadService<T>
    {
        Task<T> GetAsync(string id);
        Task<IReadOnlyCollection<T>> GetAsync(Filter filter = null);
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

    public interface ICRService<T> : ICreateService<T>, IReadService<T> { }

    public interface ICRDService<T> : ICRService<T>, IDeleteService { }

    public interface ICRUDService<T> : ICRDService<T>, IUpdateService<T> { }
}