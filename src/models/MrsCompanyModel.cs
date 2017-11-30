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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A company and account
    /// </summary>
    public class MrsCompanyModel
    {
        /// <summary>
        /// The unique ID number of this company.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The name of this company, as shown to customers.
        /// </summary>
        public String companyName { get; set; }

        /// <summary>
        /// The unique ID number of the account this company belongs to.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The name of this account, as shown to customers.
        /// </summary>
        public String accountName { get; set; }

        /// <summary>
        /// The taxpayer identification number for the company
        /// </summary>
        public String tin { get; set; }


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
