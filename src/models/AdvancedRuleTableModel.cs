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
    /// Represents an advanced rule table
    /// </summary>
    public class AdvancedRuleTableModel
    {
        /// <summary>
        /// The unique ID of the table
        /// </summary>
        public Int64 id { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The name of the table
        /// </summary>
        public String csvTableName { get; set; }

        /// <summary>
        /// The CSV data
        /// </summary>
        public String csvTable { get; set; }


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
