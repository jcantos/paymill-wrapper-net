using PaymillWrapper.Models;
using System;
using System.Text;
using System.Web;

namespace PaymillWrapper.Internal
{
    class UrlEncoder
    {
        private readonly Encoding _charset;

        public UrlEncoder()
        {
            _charset = Encoding.UTF8;
        }

        public string Encode<T>(Object data)
        {
            var props = typeof(T).GetProperties();

            if (!data.GetType().ToString().StartsWith("PaymillWrapper.Models"))
                throw new PaymillException(
                    String.Format("Unknown object type '{0}'. Only objects in package " +
                    "'PaymillWrapper.Paymill.Model' are supported.", data.GetType())
                    );

            var sb = new StringBuilder();
            foreach (var prop in props)
            {
                var value = prop.GetValue(data, null);
                if (value != null)
                    AddKeyValuePair(sb, prop.Name.ToLower(), value);
            }

            return sb.ToString();
        }

        public string EncodeTransaction(Transaction data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "amount", data.Amount);
            AddKeyValuePair(sb, "currency", data.Currency);

            if (!string.IsNullOrEmpty(data.Token))
                AddKeyValuePair(sb, "token", data.Token);

            if (data.Client != null && !string.IsNullOrEmpty(data.Client.Id))
                AddKeyValuePair(sb, "client", data.Client.Id);

            if (data.Payment != null && !string.IsNullOrEmpty(data.Payment.Id))
                AddKeyValuePair(sb, "payment", data.Payment.Id);

            AddKeyValuePair(sb, "description", data.Description);
            
            return sb.ToString();
        }
        public string EncodePreauthorization(Preauthorization data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "amount", data.Amount);
            AddKeyValuePair(sb, "currency", data.Currency);

            if (!string.IsNullOrEmpty(data.Token))
                AddKeyValuePair(sb, "token", data.Token);

            if (data.Payment != null && !string.IsNullOrEmpty(data.Payment.Id))
                AddKeyValuePair(sb, "payment", data.Payment.Id);

            return sb.ToString();
        }
        public string EncodeRefund(Refund data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "amount", data.Amount);
            AddKeyValuePair(sb, "description", data.Description);

            return sb.ToString();
        }
        public string EncodeOfferAdd(Offer data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "amount", data.Amount);
            AddKeyValuePair(sb, "currency", data.Currency);
            AddKeyValuePair(sb, "interval", data.Interval);
            AddKeyValuePair(sb, "name", data.Name);

            return sb.ToString();
        }
        public string EncodeOfferUpdate(Offer data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "name", data.Name);

            return sb.ToString();
        }
        public string EncodeSubscriptionAdd(Subscription data)
        {
            var sb = new StringBuilder();

            if (data.Client != null)
                AddKeyValuePair(sb, "client", data.Client.Id);
            if (data.Offer != null)
                AddKeyValuePair(sb, "offer", data.Offer.Id);
            if (data.Payment != null)
                AddKeyValuePair(sb, "payment", data.Payment.Id);

            return sb.ToString();
        }
        public string EncodeSubscriptionUpdate(Subscription data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "cancel_at_period_end", data.CancelAtPeriodEnd);

            return sb.ToString();
        }
        public string EncodeClientUpdate(Client data)
        {
            var sb = new StringBuilder();

            AddKeyValuePair(sb, "email", data.Email);
            AddKeyValuePair(sb, "description", data.Description);

            return sb.ToString();
        }

        private void AddKeyValuePair(StringBuilder sb, string key, object value)
        {
            var reply = "";

            if (value == null) return;

            try
            {

                key = HttpUtility.UrlEncode(key.ToLower(), _charset);

                if (value.GetType().IsEnum)
                {
                    reply = value.ToString().ToLower();
                }
                else if (value is DateTime)
                {
                    if (value.Equals(DateTime.MinValue)) reply="";
                }
                else
                {
                    reply = HttpUtility.UrlEncode(value.ToString(), _charset);
                }

                if (!string.IsNullOrEmpty(reply))
                {
                    if (sb.Length > 0)
                        sb.Append("&");

                    sb.Append(String.Format("{0}={1}", key, reply));
                }

            }
            catch
            {
                throw new PaymillException(
                    String.Format("Unsupported or invalid character set encoding '{0}'.", _charset));
            }

        }
    }
}