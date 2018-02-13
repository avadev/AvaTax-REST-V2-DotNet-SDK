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
    /// Represents a request to activate an account by reading and accepting its terms and conditions.
    /// </summary>
    public class ActivateAccountModel
    {
        /// <summary>
        /// Set this to true if and only if you accept Avalara's terms and conditions for your account.
        /// </summary>
        public Boolean? acceptAvalaraTermsAndConditions { get; set; }

        /// <summary>
        /// Set this to true if and only if you have fully read Avalara's terms and conditions for your account.
        /// </summary>
        public Boolean? haveReadAvalaraTermsAndConditions { get; set; }


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
