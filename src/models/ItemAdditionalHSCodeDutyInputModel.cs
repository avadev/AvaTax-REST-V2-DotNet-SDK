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
    /// Represents input model for additional HS Code Duty Details request.
    /// </summary>
    public class ItemAdditionalHSCodeDutyInputModel
    {
        /// <summary>
        /// The unique ID of the item.
        /// </summary>
        public Int64 itemId { get; set; }

        /// <summary>
        /// The unique ID of the company.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The country of import.
        /// </summary>
        public String countryOfImport { get; set; }

        /// <summary>
        /// The country of export.
        /// </summary>
        public String countryOfExport { get; set; }

        /// <summary>
        /// The country of origin.
        /// </summary>
        public String countryOfOrigin { get; set; }

        /// <summary>
        /// The manufacturer name.
        /// </summary>
        public String manufacturerName { get; set; }

        /// <summary>
        /// The country of import.
        /// </summary>
        public String hscode { get; set; }


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
