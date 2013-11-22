using PaymillSharp.Models;
using PaymillSharp.Internal;

namespace PaymillSharp.Query
{
    public static class QueryTransactionExtensions
    {
        public static Query<Transaction> Status(this Query<Transaction> query, TransactionStatus status)
        {
            query.Add("status", status.ToSnakeCase());
            return query;
        }
    }
}