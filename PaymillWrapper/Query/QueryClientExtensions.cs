using PaymillWrapper.Models;

namespace PaymillWrapper.Query
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