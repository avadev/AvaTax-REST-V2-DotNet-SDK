using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents information about a newly created account
    /// </summary>
    public class NewAccountModel
    {
        /// <summary>
        /// This is the ID number of the account that was created
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// This is the email address to which credentials were mailed
        /// </summary>
        public String accountDetailsEmailedTo { get; set; }

        /// <summary>
        /// The date and time when this account was created
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date and time when account information was emailed to the user
        /// </summary>
        public DateTime? emailedDate { get; set; }

        /// <summary>
        /// If this account includes any limitations, specify them here
        /// </summary>
        public String limitations { get; set; }

        /// <summary>
        /// The license key of the account that was created
        /// </summary>
        public String licenseKey { get; set; }


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
