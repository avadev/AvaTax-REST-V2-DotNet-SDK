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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// One Universal Product Code object as defined for your company.
    /// </summary>
    public class UPCModel
    {
        /// <summary>
        /// The unique ID number for this UPC.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the company to which this UPC belongs.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The 12-14 character Universal Product Code, European Article Number, or Global Trade Identification Number.
        /// </summary>
        public String upc { get; set; }

        /// <summary>
        /// Legacy Tax Code applied to any product sold with this UPC.
        /// </summary>
        public String legacyTaxCode { get; set; }

        /// <summary>
        /// Description of the product to which this UPC applies.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// If this UPC became effective on a certain date, this contains the first date on which the UPC was effective.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If this UPC expired or will expire on a certain date, this contains the last date on which the UPC was effective.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// A usage identifier for this UPC code.
        /// </summary>
        public Int32? usage { get; set; }

        /// <summary>
        /// A flag indicating whether this UPC code is attached to the AvaTax system or to a company.
        /// </summary>
        public Int32? isSystem { get; set; }

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
