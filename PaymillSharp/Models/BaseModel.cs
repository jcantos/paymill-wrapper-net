using System;
using System.Runtime.Serialization;

namespace PaymillSharp.Models
{
    [DataContract]
    public class BaseModel
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Last update
        /// </summary>
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
