using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Information about a zone in which this certificate is valid
    /// </summary>
    public class ExposureZoneModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String tag { get; set; }


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
