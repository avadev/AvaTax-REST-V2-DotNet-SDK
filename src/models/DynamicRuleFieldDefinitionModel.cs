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
    /// Represents the a field available in the Dynamic Rules interface.
    /// </summary>
    public class DynamicRuleFieldDefinitionModel
    {
        /// <summary>
        /// The internal name of the field. This is also the field's name as it appears in tokens.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Formatted display or "nice" name of the field.
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// A description of the field's usage and purpose.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The category of the field; useful for filtering.
        /// </summary>
        public String category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DynamicRuleFieldLevelDefinitionModel documentLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DynamicRuleFieldLevelDefinitionModel lineLevel { get; set; }


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
