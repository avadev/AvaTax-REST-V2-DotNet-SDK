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
    /// Tax Notice Priority Model
    /// </summary>
    public class NoticePriorityModel
    {
        /// <summary>
        /// The unique ID number of this tax notice customer Priority.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The description name of this tax authority Priority.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// A flag if the Priority is active
        /// </summary>
        public Boolean? activeFlag { get; set; }

        /// <summary>
        /// sort order of the Prioritys
        /// </summary>
        public Int32? sortOrder { get; set; }


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
