using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

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
        /// The filing return id that this applies too
        /// </summary>
        public Int64? filingId { get; set; }

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
        public String type { get; set; }

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
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
