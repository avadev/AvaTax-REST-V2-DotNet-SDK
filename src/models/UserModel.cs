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
    /// An account user who is permitted to use AvaTax.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// The unique ID number of this user.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the account to which this user belongs.
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// If this user is locked to one company (and its children), this is the unique ID number of the company to which this user belongs.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The username which is used to log on to the AvaTax website, or to authenticate against API calls.
        /// </summary>
        public String userName { get; set; }

        /// <summary>
        /// The first or given name of the user.
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// The last or family name of the user.
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// The email address to be used to contact this user. If the user has forgotten a password, an email can be sent to this email address with information on how to reset this password.
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// The postal code in which this user resides.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The security level for this user.
        /// </summary>
        public SecurityRoleId securityRoleId { get; set; }

        /// <summary>
        /// The status of the user's password. For a new user created, this is always going to be `UserMustChange`
        /// </summary>
        public PasswordStatusId? passwordStatus { get; set; }

        /// <summary>
        /// True if this user is currently active.
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Matches the subjectId of corresponding user record in AI.
        /// </summary>
        public String subjectId { get; set; }


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
