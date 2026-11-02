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
    /// Security Role Assignment Response Model
    /// </summary>
    public class SecurityRoleAssignment
    {
        /// <summary>
        /// Assignment identifier (dbo.UserRoleMatrix.UserRoleMatrixId).
        /// </summary>
        public String userRoleMatrixId { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public String userId { get; set; }

        /// <summary>
        /// Security Role Id - a CustomSecurityRole id (GUID) belonging to this account.
        /// System SecurityRole ids are not supported here as of now.
        /// </summary>
        public String securityRoleId { get; set; }

        /// <summary>
        /// Account Id.
        /// </summary>
        public String accountId { get; set; }

        /// <summary>
        /// Company Id. Optional.
        /// </summary>
        public String companyId { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }


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
