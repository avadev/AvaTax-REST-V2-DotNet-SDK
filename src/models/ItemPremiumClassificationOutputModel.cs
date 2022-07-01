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
    /// Represents a Premium Classification output model associated with an item's SystemCode..
    /// </summary>
    public class ItemPremiumClassificationOutputModel
    {
        /// <summary>
        /// ItemPremiumClassificationDetailId
        /// </summary>
        public String id { get; set; }

        /// <summary>
        /// Item associated with this premium classification.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// CompanyId with which the Item is associated.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The HS code associated with this item's premium classification.
        /// </summary>
        public String hsCode { get; set; }

        /// <summary>
        /// SystemCode associated with this premium classificaitons.
        /// </summary>
        public String systemCode { get; set; }

        /// <summary>
        /// Justification why this HsCode is attached to this item.
        /// </summary>
        public String justification { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user who created the record.
        /// </summary>
        public Int32? createdUserId { get; set; }


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
