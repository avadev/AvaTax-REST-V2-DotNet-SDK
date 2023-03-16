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
    /// Represents a tax code classification request status output model
    /// </summary>
    public class ItemTaxCodeClassificationRequestStatusOutputModel
    {
        /// <summary>
        /// The unique Request Id of classification request
        /// </summary>
        public Int32? requestId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ClassificationDetailsModel classificationDetails { get; set; }

        /// <summary>
        /// The total number of items for which classification is initiated in request
        /// </summary>
        public Int32? totalItems { get; set; }

        /// <summary>
        /// The status of classification request
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// The date/time when this request was created.
        /// </summary>
        public DateTime? createdDate { get; set; }


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
