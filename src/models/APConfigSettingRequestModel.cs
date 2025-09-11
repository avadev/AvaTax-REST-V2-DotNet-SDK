using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// AP Config Setting Request Model
    /// </summary>
    public class APConfigSettingRequestModel
    {
        /// <summary>
        /// The Amount Threshold To Ignore Transaction
        /// </summary>
        public Decimal? amount { get; set; }

        /// <summary>
        /// The Amount Threshold To Mark Transaction For Manual Review
        /// </summary>
        public Decimal? amountToMarkForReview { get; set; }

        /// <summary>
        /// The Variance For Ignore
        /// </summary>
        public Decimal? varianceForIgnore { get; set; }

        /// <summary>
        /// The Variance For Accrue
        /// </summary>
        public Decimal? varianceForAccrue { get; set; }

        /// <summary>
        /// The Variance Percent
        /// </summary>
        public Decimal? variancePercent { get; set; }

        /// <summary>
        /// The Ap Config Tolerance Type
        /// BATCH or REALTIME
        /// </summary>
        public ApConfigToleranceType? apConfigToleranceType { get; set; }

        /// <summary>
        /// Pay Billed Do Not Accrue
        /// </summary>
        public Decimal? payAsBilledNoAccrual { get; set; }

        /// <summary>
        /// Pay Billed Accrue
        /// </summary>
        public Decimal? payAsBilledAccrueUndercharge { get; set; }

        /// <summary>
        /// ShortPay Items UnderCharge
        /// </summary>
        public Decimal? shortPayItemsAccrueUndercharge { get; set; }

        /// <summary>
        /// Review UnderCharge
        /// </summary>
        public Decimal? markForReviewUndercharge { get; set; }

        /// <summary>
        /// Reject UnderCharge
        /// </summary>
        public Decimal? rejectUndercharge { get; set; }

        /// <summary>
        /// Pay As BilledOvercharge
        /// </summary>
        public Decimal? payAsBilledOvercharge { get; set; }

        /// <summary>
        /// Short Pay Avalara CalculatedTax
        /// </summary>
        public Decimal? shortPayAvalaraCalculated { get; set; }

        /// <summary>
        /// Short Pay Items
        /// </summary>
        public Decimal? shortPayItemsAccrueOvercharge { get; set; }

        /// <summary>
        /// Review OverCharge
        /// </summary>
        public Decimal? markForReviewOvercharge { get; set; }

        /// <summary>
        /// Reject OverCharge
        /// </summary>
        public Decimal? rejectOvercharge { get; set; }

        /// <summary>
        /// Is Active
        /// </summary>
        public Boolean? isActive { get; set; }


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
