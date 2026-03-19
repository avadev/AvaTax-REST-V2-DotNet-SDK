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
    /// Represents a single tax rate item
    /// </summary>
    public class RateItemModel
    {
        /// <summary>
        /// The tax rate as a decimal (e.g., 0.20 for 20%)
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// The display name formatted as "<rate> (<taxName>)" (e.g., "20.0% (VAT/GST)")
        /// </summary>
        public String displayName { get; set; }

        /// <summary>
        /// The tax name (e.g., "VAT/GST")
        /// </summary>
        public String taxName { get; set; }

        /// <summary>
        /// The jurisdiction code
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The jurisdiction name
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The jurisdiction type ID
        /// </summary>
        public String jurisdictionTypeId { get; set; }

        /// <summary>
        /// The country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The rate type ID
        /// </summary>
        public String rateTypeId { get; set; }

        /// <summary>
        /// The tax type group ID
        /// </summary>
        public String taxTypeGroupId { get; set; }

        /// <summary>
        /// The tax sub type ID
        /// </summary>
        public String taxSubType { get; set; }


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
