using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymillWrapper.Service
{
    public interface IResultCollection<T> : IReadOnlyCollection<T>
    {
        Task<IResultCollection<T>> GetNextResultSetAsync();

        int TotalResults { get; }
    }
}