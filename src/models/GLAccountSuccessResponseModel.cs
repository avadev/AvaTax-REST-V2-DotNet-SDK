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
    /// GL account response model
    /// </summary>
    public class GLAccountSuccessResponseModel
    {
        /// <summary>
        /// The GL account ID
        /// </summary>
        public Int64? glAccountId { get; set; }

        /// <summary>
        /// The company ID to which this GL account belongs
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TaxProfileMetaDataModel meta { get; set; }

        /// <summary>
        /// The entity use code
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// The "effective from" date
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The end date
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64TaxProfileObjectReferenceModel defaultItem { get; set; }

        /// <summary>
        /// The GL account code
        /// </summary>
        public String glAccountCode { get; set; }


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
