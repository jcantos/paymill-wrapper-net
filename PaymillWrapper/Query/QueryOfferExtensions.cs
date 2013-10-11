using PaymillWrapper.Models;

namespace PaymillWrapper.Query
{
    public static class QueryOfferExtensions
    {
        public static Query<Offer> Name(this Query<Offer> query, string name)
        {
            query.Add("name", name);
            return query;
        }

        public static Query<Offer> TrialPeriodDays(this Query<Offer> query, int days)
        {
            query.Add("trial_period_days", days);
            return query;
        }
    }
}