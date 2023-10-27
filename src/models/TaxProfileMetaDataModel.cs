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
    /// Tax Profile Service Meta data information
    /// </summary>
    public class TaxProfileMetaDataModel
    {
        /// <summary>
        /// Created By User
        /// </summary>
        public String createdUser { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Modified User
        /// </summary>
        public String modifiedUser { get; set; }

        /// <summary>
        /// Modified Date
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