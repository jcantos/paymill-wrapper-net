using PaymillSharp.Models;

namespace PaymillSharp.Query
{
    public static class QueryClientExtensions
    {
        public static Query<Client> Email(this Query<Client> query, string email)
        {
            query.Add("email", email);
            return query;
        }
    }
}