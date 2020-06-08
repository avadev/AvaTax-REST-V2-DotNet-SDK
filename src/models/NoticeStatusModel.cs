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
    /// Tax Notice Status Model
    /// </summary>
    public class NoticeStatusModel
    {
        /// <summary>
        /// The unique ID number of this tax authority type.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The description name of this tax authority type.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// True if a tax notice in this status is considered 'open' and has more work expected to be done before it is closed.
        /// </summary>
        public Boolean? isOpen { get; set; }

        /// <summary>
        /// If a list of status values is to be displayed in a dropdown, they should be displayed in this numeric order.
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
