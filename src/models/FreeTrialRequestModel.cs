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
    /// Represents a request for a free trial account for AvaTax.        ///
        ///        ///Free trial accounts are only available on the Sandbox environment.
    /// </summary>
    public class FreeTrialRequestModel
    {
        /// <summary>
        /// The first or given name of the user requesting a free trial.
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// The last or family name of the user requesting a free trial.
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// The email address of the user requesting a free trial.
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// The company or organizational name for this free trial. If this account is for personal use, it is acceptable         ///
        ///        ///to use your full name here.
        /// </summary>
        public String company { get; set; }

        /// <summary>
        /// The phone number of the person requesting the free trial.
        /// </summary>
        public String phone { get; set; }


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
