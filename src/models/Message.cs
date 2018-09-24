using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public String details { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String helpLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String refersTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String summary { get; set; }


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
