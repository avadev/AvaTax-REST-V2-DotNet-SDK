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
    /// Represents HS Code Duty Details for an item.
    /// </summary>
    public class ItemHSCodeDutyDetailModel
    {
        /// <summary>
        /// The unique ID of the HS Code Duty Detail.
        /// </summary>
        public Int64? id { get; set; }

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
        /// The MFN rate.
        /// </summary>
        public String mfnRate { get; set; }

        /// <summary>
        /// The unit of measure.
        /// </summary>
        public String uom { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// List of FTA details.
        /// </summary>
        public List<ItemHSCodeFTADetailModel> ftaDetails { get; set; }

        /// <summary>
        /// List of CVD/ADD details.
        /// </summary>
        public List<ItemHSCodeCvdAddDetailModel> cvdAddDetails { get; set; }

        /// <summary>
        /// List of punitive rate details.
        /// </summary>
        public List<ItemHSCodePunitiveRateDetailModel> punitiveRateDetails { get; set; }

        /// <summary>
        /// List of restriction details.
        /// </summary>
        public List<ItemHSCodeRestrictionDetailModel> restrictionDetails { get; set; }


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
