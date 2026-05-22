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
    /// Represents the resolved extraction task information for a given form type.
    /// </summary>
    public class FormTypeMappingModel
    {
        /// <summary>
        /// The extraction task identifier resolved from the form type.
        /// </summary>
        public String taskId { get; set; }

        /// <summary>
        /// The form type that was resolved.
        /// </summary>
        public String formType { get; set; }

        /// <summary>
        /// The mapped key associated with the form type.
        /// </summary>
        public String mappedKey { get; set; }


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
