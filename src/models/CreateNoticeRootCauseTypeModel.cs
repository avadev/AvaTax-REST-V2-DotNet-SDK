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
    /// Model to create a new tax notice root cause type.
    /// </summary>
    public class CreateNoticeRootCauseTypeModel
    {
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
