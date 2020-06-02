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
    /// NoticeRootCause Model
    /// </summary>
    public class NoticeRootCauseModel
    {
        /// <summary>
        /// The unique ID number of this notice RootCause.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The description name of this notice RootCause
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Defines if the RootCause is active
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// The sort order of this RootCause
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
