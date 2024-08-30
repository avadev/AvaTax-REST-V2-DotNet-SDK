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
    /// Encloses communication location details
    /// </summary>
    public class CommunicationLocationResponse
    {
        /// <summary>
        /// Communication tax country
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Communication tax state
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// Communication tax County
        /// </summary>
        public String county { get; set; }

        /// <summary>
        /// Communication tax city
        /// </summary>
        public String city { get; set; }


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
