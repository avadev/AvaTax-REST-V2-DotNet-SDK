using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A model for return adjustments.
    /// </summary>
    public class FilingAdjustmentModel
    {
        /// <summary>
        /// The unique ID number for the adjustment.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The adjustment amount.
        /// </summary>
        public Decimal amount { get; set; }

        /// <summary>
        /// The filing period the adjustment is applied to.
        /// </summary>
        public AdjustmentPeriodTypeId period { get; set; }

        /// <summary>
        /// The type of the adjustment.
        /// </summary>
        public AdjustmentTypeId type { get; set; }

        /// <summary>
        /// Whether or not the adjustment has been calculated.
        /// </summary>
        public Boolean? isCalculated { get; set; }

        /// <summary>
        /// The account type of the adjustment.
        /// </summary>
        public PaymentAccountTypeId accountType { get; set; }

        /// <summary>
        /// A descriptive reason for creating this adjustment.
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
