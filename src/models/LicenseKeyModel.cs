using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a license key for this account.
    /// </summary>
    public class LicenseKeyModel
    {
        /// <summary>
        /// The primary key of the account
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// This is your private license key. You must record this license key for safekeeping.
        /// If you lose this key, you must contact the ResetLicenseKey API in order to request a new one.
        /// Each account can only have one license key at a time.
        /// </summary>
        public String privateLicenseKey { get; set; }

        /// <summary>
        /// If your software allows you to specify the HTTP Authorization header directly, this is the header string you
        /// should use when contacting Avalara to make API calls with this license key.
        /// </summary>
        public String httpRequestHeader { get; set; }


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
