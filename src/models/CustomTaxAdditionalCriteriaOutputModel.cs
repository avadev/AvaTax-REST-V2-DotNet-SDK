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
    /// Optional additional criteria for when a custom tax should apply. This model is
    /// structurally identical to `CustomRuleDefinitionOutputModel` but is kept as a
    /// distinct type so that the custom tax surface can evolve independently of the underlying
    /// custom rule definition. The nodes defined here are prepended to the main custom tax node
    /// when the custom tax is translated into a custom rule at persistence time.
    /// <br>
    /// This is the output variant returned by Custom Tax read endpoints.
    /// </summary>
    public class CustomTaxAdditionalCriteriaOutputModel
    {
        /// <summary>
        /// Define fixed components with rule-wide scope.
        /// </summary>
        public List<CustomRuleComponentOutputModel> variables { get; set; }

        /// <summary>
        /// Define components which make up the execution graph for custom tax preconditions.
        /// </summary>
        public List<CustomRuleComponentOutputModel> nodes { get; set; }


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
