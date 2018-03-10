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
    /// User Entitlement Model
    /// </summary>
    public class UserEntitlementModel
    {
        /// <summary>
        /// List of API names and categories that this user is permitted to access
        /// </summary>
        public List<String> permissions { get; set; }

        /// <summary>
        /// What access privileges does the current user have to see companies?
        /// </summary>
        public CompanyAccessLevel? accessLevel { get; set; }

        /// <summary>
        /// The identities of all companies this user is permitted to access
        /// </summary>
        public List<Int32> companies { get; set; }


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
