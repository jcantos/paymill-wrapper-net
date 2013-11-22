using PaymillSharp.Models;
using PaymillSharp.Internal;

namespace PaymillSharp.Query
{
    public static class QueryPaymentExtensions
    {
        public static Query<Payment> CardType(this Query<Payment> query, CardType cardType)
        {
            query.Add("card_type", cardType.ToSnakeCase());
            return query;
        }
    }
}
