using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents an advanced rule script
    /// </summary>
    public class AdvancedRuleScriptModel
    {
        /// <summary>
        /// The unique ID of the script
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// How to proceed if the rule crashes
        /// </summary>
        public AdvancedRuleCrashBehavior? crashBehavior { get; set; }

        /// <summary>
        /// The type of script - request or response
        /// </summary>
        public AdvancedRuleScriptType? scriptType { get; set; }

        /// <summary>
        /// The JavaScript rule
        /// </summary>
        public String script { get; set; }

        /// <summary>
        /// The rule has been approved
        /// </summary>
        public Boolean? isApproved { get; set; }

        /// <summary>
        /// The rule has been disabled
        /// </summary>
        public Boolean? isDisabled { get; set; }


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
