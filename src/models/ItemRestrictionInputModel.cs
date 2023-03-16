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
    /// Represents a parameter associated with an item.
    /// </summary>
    public class ItemRestrictionInputModel
    {
        /// <summary>
        /// Item for which this restrictions exists
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// CompanyId associated with the item
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The HsCode for which this restriction is getting created
        /// </summary>
        public String hsCode { get; set; }

        /// <summary>
        /// The Country Of Import for which this restriction is getting created
        /// </summary>
        public String countryOfImport { get; set; }

        /// <summary>
        /// The Country Of Export for which this restriction is getting create
        /// </summary>
        public String countryOfExport { get; set; }

        /// <summary>
        /// The Country Of Manufacture for which this restriction is getting create
        /// </summary>
        public String countryOfManufacture { get; set; }

        /// <summary>
        /// Restriction Type of the Item
        /// </summary>
        public String restrictionType { get; set; }

        /// <summary>
        /// Regulation of the Item
        /// </summary>
        public String regulation { get; set; }

        /// <summary>
        /// Government agency which is related for this restriction
        /// </summary>
        public String governmentAgency { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public String complianceMessage { get; set; }


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
