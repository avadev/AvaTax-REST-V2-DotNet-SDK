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
    /// Information about a field at a specific "level" (Document or Line).
    /// </summary>
    public class DynamicRuleFieldLevelDefinitionModel
    {
        /// <summary>
        /// The JSON type of the field.
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// The internal expression type of the field.
        /// </summary>
        public String expressionType { get; set; }

        /// <summary>
        /// Whether the field is deprecated or not.
        /// </summary>
        public Boolean? deprecated { get; set; }

        /// <summary>
        /// Optional list of enumerated values.
        /// </summary>
        public List<DynamicRuleEnumValueModel> anyOf { get; set; }

        /// <summary>
        /// The execution steps in which the field is readable.
        /// </summary>
        public List<String> readSteps { get; set; }

        /// <summary>
        /// Whether the field is read-only.
        /// </summary>
        public Boolean? readOnly { get; set; }

        /// <summary>
        /// The execution steps in which the field is writable.
        /// </summary>
        public List<String> writeSteps { get; set; }

        /// <summary>
        /// Whether the field is write-only.
        /// </summary>
        public Boolean? writeOnly { get; set; }


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
