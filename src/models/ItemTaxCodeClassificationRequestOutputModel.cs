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
    /// Represents a tax code classification request output model
    /// </summary>
    public class ItemTaxCodeClassificationRequestOutputModel
    {
        /// <summary>
        /// The unique ID of the classification request
        /// </summary>
        public Int32? requestId { get; set; }

        /// <summary>
        /// The unique ID of the company that created the classification request.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The classification request
        /// </summary>
        public String request { get; set; }

        /// <summary>
        /// The status of the classification request
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// The request type of the classification request
        /// </summary>
        public String requestType { get; set; }

        /// <summary>
        /// The User ID of the user who created this classification request.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this request was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }


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
