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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class FilingModelFetchResult
    {
        /// <summary>
        /// 
        /// </summary>
        public Int32? @recordsetCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FilingModel> value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String @nextLink { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String pageKey { get; set; }


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
