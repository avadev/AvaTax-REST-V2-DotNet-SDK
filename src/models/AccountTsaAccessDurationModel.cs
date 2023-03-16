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
    /// Specifies a duration for which to grant TSA accounts write access.
    /// See AVT-25316
    /// </summary>
    public class AccountTsaAccessDurationModel
    {
        /// <summary>
        /// Number of minutes
        /// </summary>
        public Int32? minutes { get; set; }

        /// <summary>
        /// Number of hours
        /// </summary>
        public Int32? hours { get; set; }

        /// <summary>
        /// Number of days
        /// </summary>
        public Int32? days { get; set; }


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
