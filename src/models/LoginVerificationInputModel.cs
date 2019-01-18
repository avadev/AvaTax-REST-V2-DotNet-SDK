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
    /// Represents a verification request using Skyscraper for a company
    /// </summary>
    public class LoginVerificationInputModel
    {
        /// <summary>
        /// CompanyId that we are verifying the login information for
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// AccountId of the login verification
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// Region of the verification request
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// TaxFormCode for the verification request
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// Username that we are using for verification
        /// </summary>
        public String username { get; set; }

        /// <summary>
        /// Password we are using for verification
        /// </summary>
        public String password { get; set; }

        /// <summary>
        /// Additional options of the verification
        /// </summary>
        public Dictionary<string, string> additionalOptions { get; set; }

        /// <summary>
        /// Bulk Request Id of the verification
        /// </summary>
        public Int32? bulkRequestId { get; set; }

        /// <summary>
        /// Priority of the verification request
        /// </summary>
        public Int32? priority { get; set; }


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
