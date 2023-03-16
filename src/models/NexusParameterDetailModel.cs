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
    /// Represents a parameter associated with a nexus.
    /// </summary>
    public class NexusParameterDetailModel
    {
        /// <summary>
        /// The id of the parameter.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The parameter's name.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The value for the parameter.
        /// </summary>
        public String value { get; set; }

        /// <summary>
        /// The unit of measurement code for the parameter.
        /// </summary>
        public String unit { get; set; }

        /// <summary>
        /// The nexus id
        /// </summary>
        public Int32? nexusId { get; set; }


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
