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
    /// Response DTO for Permission Category that includes associated permissions
    /// This is used for API responses that need the full permission category with its permissions
    /// </summary>
    public class PermissionCategoryResponseDto
    {
        /// <summary>
        /// The unique identifier for the permission category (as string for OpenAPI spec)
        /// </summary>
        public String permissionCategoryId { get; set; }

        /// <summary>
        /// Name of the permission category
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Description of the permission category
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// List of permissions associated with this category
        /// NOTE: This property does NOT exist in the database entity (EntityPermissionCategory)
        /// It is populated by joining with the Permission table where Permission.PermissionCategoryId matches this category's ID
        /// </summary>
        public List<PermissionCategoryPermissionDto> permissions { get; set; }


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
