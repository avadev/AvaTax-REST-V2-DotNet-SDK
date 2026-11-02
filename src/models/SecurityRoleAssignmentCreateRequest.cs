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
    /// Security Role Assignment Create Request. Assigns exactly one custom security role to one
    /// user for their company - a single object, not an array, since a user is tied to a single
    /// company. To assign multiple roles to a user, call the endpoint once per role.
    /// </summary>
    public class SecurityRoleAssignmentCreateRequest
    {
        /// <summary>
        /// User Id.
        /// </summary>
        public String userId { get; set; }

        /// <summary>
        /// Security Role Id - must be a CustomSecurityRole id (GUID) belonging to this account.
        /// System SecurityRole ids are not supported here as of now.
        /// </summary>
        public String securityRoleId { get; set; }

        /// <summary>
        /// Account Id.
        /// </summary>
        public String accountId { get; set; }

        /// <summary>
        /// Company Id. Must match the target user's own CompanyId exactly: omit it for an
        /// account-level user (whose CompanyId is null), or provide the user's own CompanyId for
        /// a company-level user. It cannot be used to assign a different company than the user's own.
        /// </summary>
        public String companyId { get; set; }


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
