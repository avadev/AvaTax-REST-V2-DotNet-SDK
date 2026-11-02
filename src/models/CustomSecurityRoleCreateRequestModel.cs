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
    /// Request model for creating a custom security role
    /// </summary>
    public class CustomSecurityRoleCreateRequestModel
    {
        /// <summary>
        /// Account ID this custom security role belongs to
        /// </summary>
        public String accountId { get; set; }

        /// <summary>
        /// Name of the custom security role
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Description of the custom security role
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// List of permissions for this custom security role
        /// </summary>
        public List<CustomSecurityRolePermissionModel> permissions { get; set; }


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
