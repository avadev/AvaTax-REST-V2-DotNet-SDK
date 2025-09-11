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
    /// Represents a single step in the execution plan of a dynamic rule.
    /// </summary>
    public class DynamicRuleValidationPlanStepModel
    {
        /// <summary>
        /// Describes the stage or phase of calculation this step belongs to.
        /// For example, "BeforeCalc".
        /// </summary>
        public String step { get; set; }

        /// <summary>
        /// The order in which this step will be executed.
        /// </summary>
        public Int32? order { get; set; }

        /// <summary>
        /// A list of node identifiers that are part of this execution step, in the order they will be executed.
        /// These refer to specific conditions or actions.
        /// </summary>
        public List<String> nodes { get; set; }


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
