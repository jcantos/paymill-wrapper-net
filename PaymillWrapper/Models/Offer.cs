using System.Runtime.Serialization;

namespace PaymillWrapper.Models
{
    /// <summary>
    /// An offer is a recurring plan which a user can subscribe to. 
    /// You can create different offers with different plan attributes e.g. a monthly or a yearly based paid offer/plan.
    /// </summary>
    public class Offer : BaseModel, IQueryableAmount
    {
        public enum TypeInterval
        {
            Week,
            Month,
            Year
        }

        /// <summary>
        /// Your name for this offer
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Every interval the specified amount will be charged. In test mode only even values e.g. 42.00 = 4200 are allowed
        /// </summary>
        [DataMember(Name = "Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Return formatted amount, e.g. 4200 amount value return 42.00
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
        /// Defining how often the client should be charged (week, month, year)
        /// </summary>
        [DataMember(Name = "Interval")]
        public TypeInterval Interval { get; set; }

        /// <summary>
        /// Give it a try or charge directly?
        /// </summary>
        [DataMember(Name = "Trial_Period_Days")]
        public int TrialPeriodDays { get; set; }

        /// <summary>
        /// ISO 4217 formatted currency code
        /// </summary>
        [DataMember(Name = "Currency")]
        public string Currency { get; set; }

    }
}