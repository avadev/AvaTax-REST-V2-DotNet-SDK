using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Cycle Safe Expiration results.
    /// </summary>
    public class CycleExpireModel
    {
        /// <summary>
        /// Whether or not the filing calendar can be expired.
        /// e.g. if user makes end date of a calendar earlier than latest filing, this would be set to false.
        /// </summary>
        public Boolean? success { get; set; }

        /// <summary>
        /// The message to present to the user if expiration is successful or unsuccessful.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// A list of options for expiring the filing calendar.
        /// </summary>
        public List<CycleExpireOptionModel> cycleExpirationOptions { get; set; }


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
