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
    /// Represents a classification for a given item.
    /// </summary>
    public class ClassificationModel
    {
        /// <summary>
        /// The unique ID of the classification.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The product code of an item in a given system.
        /// </summary>
        public String productCode { get; set; }

        /// <summary>
        /// The system code in which the product belongs.
        /// </summary>
        public String systemCode { get; set; }

        /// <summary>
        /// The country where the product belongs.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// If there is an premium classification justification present for this classification
        /// </summary>
        public Boolean? isPremium { get; set; }


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
