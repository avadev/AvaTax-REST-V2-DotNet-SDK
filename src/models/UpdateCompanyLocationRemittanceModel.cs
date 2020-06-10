using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Expire a location without restriction then update with new remittance and dates.
    /// </summary>
    public class UpdateCompanyLocationRemittanceModel
    {
        /// <summary>
        /// Indicates whether this location is a physical place of business or a temporary salesperson location.
        /// </summary>
        public AddressCategoryId addressCategoryId { get; set; }

        /// <summary>
        /// The date when this location was opened for business.
        /// </summary>
        public DateTime effectiveDate { get; set; }

        /// <summary>
        /// If this place of business has closed, the date when this location closed business. If null it'll be set to the date of 9998-12-31.
        /// </summary>
        public DateTime? endDate { get; set; }


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
