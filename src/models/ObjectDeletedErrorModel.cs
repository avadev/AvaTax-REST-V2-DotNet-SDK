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
    /// 
    /// </summary>
    public class ObjectDeletedErrorModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ErrorCodeId? code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? number { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String faultCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String faultSubCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String helpLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String refersTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SeverityLevel? severity { get; set; }


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
