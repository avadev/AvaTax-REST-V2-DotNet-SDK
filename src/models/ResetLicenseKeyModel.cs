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
    /// Represents a license key reset request.
    /// </summary>
    public class ResetLicenseKeyModel
    {
        /// <summary>
        /// The primary key of the account ID to reset
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// Set this value to true to reset the license key for this account.
        /// This license key reset function will only work when called using the credentials of the account administrator of this account.
        /// </summary>
        public Boolean confirmResetLicenseKey { get; set; }


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
