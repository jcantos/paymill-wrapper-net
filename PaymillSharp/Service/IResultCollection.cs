using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymillSharp.Service
{
    public interface IResultCollection<T> : IReadOnlyCollection<T>
    {
        Task<IResultCollection<T>> GetNextResultSetAsync();

        int TotalResults { get; }
    }
}