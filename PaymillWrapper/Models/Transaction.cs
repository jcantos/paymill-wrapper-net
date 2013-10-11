using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PaymillWrapper.Models
{
    /// <summary>
    /// A transaction is the charging of a credit card or a direct debit.
    /// </summary>
    public class Transaction : BaseModel, IQueryableAmount, IQueryableClient, IQueryablePayment
    {
        /// <summary>
        /// Amount of this transaction
        /// </summary>
        [DataMember(Name = "Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Formatted amount of this transaction
        /// </summary>
        [IgnoreDataMember]
        public double AmountFormatted
        {
            get
            {
                return Amount / 100;
            }
        }

        /// <summary>
        /// The used amount, smallest possible unit per currency (for euro, we’re calculating the amount in cents)
        /// </summary>
        [DataMember(Name = "Origin_Amount")]
        public double OriginAmount { get; set; }

        /// <summary>
        /// Formatted origin amount
        /// </summary>
        [IgnoreDataMember]
        public double OriginAmountFormatted
        {
            get
            {
                return OriginAmount / 100;
            }
        }

        /// <summary>
        /// Indicates the current status of this transaction, e.g closed means the transaction is sucessfully transfered, refunded means that the amount is fully or in parts refunded
        /// </summary>
        [DataMember(Name = "Status")]
        public TransactionStatus Status { get; set; }

        /// <summary>
        /// Need a additional description for this transaction? Maybe your shopping cart ID or something like that?
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Whether this transaction was issued while being in live mode or not
        /// </summary>
        [DataMember(Name = "Livemode")]
        public bool Livemode { get; set; }

        /// <summary>
        /// List refunds-object
        /// </summary>
        [DataMember(Name = "Refunds")]
        public List<Refund> Refunds { get; set; }

        /// <summary>
        /// Creditcard-object or directdebit-object
        /// </summary>
        [DataMember(Name = "Payment")]
        public Payment Payment { get; set; }

        /// <summary>
        /// Client-object
        /// </summary>
        [DataMember(Name = "Client")]
        public Client Client { get; set; }

        /// <summary>
        /// ISO 4217 formatted currency code
        /// </summary>
        [DataMember(Name = "Currency")]
        public string Currency { get; set; }

        /// <summary>
        /// A token generated through JavaScript-Bridge Paymill
        /// </summary>
        [DataMember(Name = "Token")]
        public string Token { get; set; }

        /// <summary>
        /// Client-object
        /// </summary>
        [DataMember(Name = "Preauthorization")]
        public Preauthorization Preauthorization { get; set; }

        /// <summary>
        /// Response code.
        /// </summary>
        [DataMember(Name = "response_code")]
        public ResponseCode ResponseCode { get; set; }
    }

    public enum TransactionStatus
    {
        PartialRefunded, 
        Refunded, 
        Closed, 
        Failed, 
        Pending,
        Open,
        Preauthorize
    }
}