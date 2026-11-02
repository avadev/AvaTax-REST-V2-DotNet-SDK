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
    /// Response DTO for Custom Security Role that includes associated permissions
    /// This is used for API responses that need the full custom security role with its permissions
    /// </summary>
    public class CustomSecurityRoleResponseDto
    {
        /// <summary>
        /// The unique identifier for the custom security role (as string for OpenAPI spec)
        /// </summary>
        public String customSecurityRoleId { get; set; }

        /// <summary>
        /// Account ID this custom security role belongs to (as string for OpenAPI spec)
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
        /// List of permissions associated with this custom security role
        /// NOTE: This property does NOT exist in the database entity (EntityCustomSecurityRole)
        /// It is populated by joining with the PermissionCustomRoleMatrix table
        /// </summary>
        public List<CustomSecurityRolePermissionDto> permissions { get; set; }


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
