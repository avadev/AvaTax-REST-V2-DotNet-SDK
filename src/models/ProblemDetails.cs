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
    /// 
    /// </summary>
    public class ProblemDetails
    {
        /// <summary>
        /// 
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String detail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String instance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object extensions { get; set; }


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
