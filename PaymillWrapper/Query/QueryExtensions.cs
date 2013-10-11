using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using PaymillWrapper.Models;

namespace PaymillWrapper.Query
{
    public enum OrderDirection
    {
        Descending,
        Ascending
    }

    public static class QueryExtensions
    {
        #region Created at
        public static Query<T> CreatedAt<T>(this Query<T> query, DateTime created)
            where T : BaseModel
        {
            query.Add("created_at", created.ToUnixTimestamp());
            return query;
        }

        public static Query<T> CreatedBetween<T>(this Query<T> query, DateTime start, DateTime end)
            where T : BaseModel
        {
            query.Add("created_at", String.Format("{0}-{1}", start.ToUnixTimestamp(), end.ToUnixTimestamp()));
            return query;
        }
        #endregion

        #region Updated at
        public static Query<T> UpdatedAt<T>(this Query<T> query, DateTime created)
            where T : BaseModel
        {
            query.Add("created_at", created.ToUnixTimestamp());
            return query;
        }

        public static Query<T> UpdatedBetween<T>(this Query<T> query, DateTime start, DateTime end)
            where T : BaseModel
        {
            query.Add("created_at", String.Format("{0}-{1}", start.ToUnixTimestamp(), end.ToUnixTimestamp()));
            return query;
        }
        #endregion

        #region Amount
        public static Query<T> ExactAmount<T>(this Query<T> query, int amount)
            where T : BaseModel, IQueryableAmount
        {
            query.Add("amount", amount.ToString(CultureInfo.InvariantCulture));
            return query;
        }

        public static Query<T> AmountGreaterThan<T>(this Query<T> query, int minAmount)
            where T : BaseModel, IQueryableAmount
        {
            query.Add("amount", ">" + minAmount.ToString(CultureInfo.InvariantCulture));
            return query;
        }

        public static Query<T> AmountLessThan<T>(this Query<T> query, int maxAmount)
            where T : BaseModel, IQueryableAmount
        {
            query.Add("amount", "<" + maxAmount.ToString(CultureInfo.InvariantCulture));
            return query;
        }
        #endregion

        public static Query<T> Take<T>(this Query<T> query, int take) 
            where T : BaseModel
        {
            query.Add("count", take);
            return query;
        }

        public static Query<T> Skip<T>(this Query<T> query, int skip)
            where T : BaseModel
        {
            query.Add("offset", skip);
            return query;
        }

        public static Query<T> Client<T>(this Query<T> query, string id)
            where T : BaseModel, IQueryableClient
        {
            query.Add("client", id);
            return query;
        }

        public static Query<T> Payment<T>(this Query<T> query, string id)
            where T : BaseModel, IQueryablePayment
        {
            query.Add("payment", id);
            return query;
        }

        public static Query<T> Transaction<T>(this Query<T> query, string id)
            where T : BaseModel, IQueryableTransaction
        {
            query.Add("transaction", id);
            return query;
        }

        public static Query<T> Description<T>(this Query<T> query, string description)
            where T : BaseModel, IQueryableDescription
        {
            query.Add("description", description);
            return query;
        }

        public static Query<T> Offer<T>(this Query<T> query, string id)
            where T : BaseModel, IQueryableOffer
        {
            query.Add("offer", id);
            return query;
        }

        public static Query<T> Subscription<T>(this Query<T> query, string id)
            where T : BaseModel, IQueryableSubscription
        {
            query.Add("subscription", id);
            return query;
        }

        public static Query<T> OrderBy<T>(this Query<T> query, 
            Expression<Func<T, object>> orderByMember, 
            OrderDirection direction = OrderDirection.Ascending)
            where T : BaseModel
        {
            var memberInfo = ReflectionHelper.FindProperty(orderByMember);
            var dataMember = memberInfo.GetCustomAttribute<DataMemberAttribute>();
            if (dataMember == null)
            {
                throw new ArgumentException("Member property needs to be among the serializable members of a class.", "orderByMember");
            }
            query.Add("order", dataMember.Name + (direction == OrderDirection.Ascending ? "_asc" : "_desc"));
            return query;
        }
    }
}