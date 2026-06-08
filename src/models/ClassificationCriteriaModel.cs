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
    /// Tariff classification criteria flags used when mode is `auto_partial`.
    /// </summary>
    public class ClassificationCriteriaModel
    {
        /// <summary>
        /// When true, include items with no tariff code assigned.
        /// </summary>
        public Boolean? NoTariffCodeAssigned { get; set; }

        /// <summary>
        /// When true, include items with an invalid tariff code.
        /// </summary>
        public Boolean? InvalidTariffCode { get; set; }

        /// <summary>
        /// When true, include items whose tariff code needs review.
        /// </summary>
        public Boolean? TariffCodeNeedsReview { get; set; }


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
