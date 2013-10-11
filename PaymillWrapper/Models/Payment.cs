using Newtonsoft.Json;
using PaymillWrapper.Net;
using System.Runtime.Serialization;

namespace PaymillWrapper.Models
{
    /// <summary>
    /// The Payment object represents a payment with a credit card or via direct debit.
    /// </summary>
    [JsonConverter(typeof(JsonParser<Payment>))]
    public class Payment : BaseModel
    {
        public enum TypePayment
        {
            CreditCard, 
            Debit
        }

        /// <summary>
        /// enum(creditcard,debit)
        /// </summary>
        [DataMember(Name = "type")]
        public TypePayment Type { get; set; }

        /// <summary>
        /// The identifier of a client (client-object)
        /// </summary>
        [DataMember(Name = "client")]
        public string Client { get; set; }

        /// <summary>
        /// Visa or Mastercard
        /// </summary>
        [DataMember(Name = "card_type")]
        public string CardType { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; set; }

        /// <summary>
        /// Expiry month of the credit card
        /// </summary>
        [DataMember(Name = "expire_month")]
        public int ExpireMonth { get; set; }

        /// <summary>
        /// Expiry year of the credit card
        /// </summary>
        [DataMember(Name = "expire_year")]
        public int ExpireYear { get; set; }

        /// <summary>
        /// Name of the card holder
        /// </summary>
        [DataMember(Name = "card_holder")]
        public string CardHolder { get; set; }

        /// <summary>
        /// The last four digits of the credit card
        /// </summary>
        [DataMember(Name = "last4")]
        public string Last4 { get; set; }

        /// <summary>
        /// The used Bank Code
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Name of the account holder
        /// </summary>
        [DataMember(Name = "holder")]
        public string Holder { get; set; }

        /// <summary>
        /// The used account number, for security reasons the number is masked
        /// </summary>
        [DataMember(Name = "account")]
        public string Account { get; set; }

        /// <summary>
        /// Unique credit card token
        /// </summary>
        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}