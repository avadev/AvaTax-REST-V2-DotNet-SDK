using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a tax override for a transaction
    /// </summary>
    public class TaxOverrideModel
    {
        /// <summary>
        /// Identifies the type of tax override
        /// </summary>
        public TaxOverrideType? type { get; set; }

        /// <summary>
        /// Indicates a total override of the calculated tax on the document. AvaTax will distribute
        /// the override across all the lines.
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// The override tax date to use
        /// </summary>
        public DateTime? taxDate { get; set; }

        /// <summary>
        /// This provides the reason for a tax override for audit purposes. It is required for types 2-4.
        /// </summary>
        public String reason { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
