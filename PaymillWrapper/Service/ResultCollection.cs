using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PaymillWrapper.Models;
using PaymillWrapper.Query;

namespace PaymillWrapper.Service
{
    public class ResultCollection<T> : ReadOnlyCollection<T>, IResultCollection<T> 
        where T : BaseModel
    {
        private readonly Query<T> _query;

        internal ResultCollection(IList<T> list, Query<T> query, int totalResults) 
            : base(list)
        {
            _query = query;
            TotalResults = totalResults;
        }

        public async Task<IResultCollection<T>> GetNextResultSetAsync()
        {
            _query.Offset += _query.PerPage;
            return _query.Offset >= TotalResults 
                ? null 
                : await _query.GetAsync();
        }

        public int TotalResults { get; private set; }
    }
}