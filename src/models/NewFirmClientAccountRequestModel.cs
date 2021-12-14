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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a request for a new account with Avalara for a new Firm client.
    /// </summary>
    public class NewFirmClientAccountRequestModel
    {
        /// <summary>
        /// The name of the account to create
        /// </summary>
        public String accountName { get; set; }

        /// <summary>
        /// First name of the primary contact person for this account
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// Last name of the primary contact person for this account
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// Title of the primary contact person for this account
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// Phone number of the primary contact person for this account
        /// </summary>
        public String phoneNumber { get; set; }

        /// <summary>
        /// Email of the primary contact person for this account
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// Company code to be assigned to the company created for this account.
        ///  
        /// If no company code is provided, this will be defaulted to "DEFAULT" company code.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CompanyAddress companyAddress { get; set; }

        /// <summary>
        /// United States Taxpayer ID number, usually your Employer Identification Number if you are a business or your
        /// Social Security Number if you are an individual.
        /// This value is required if the address provided is inside the US. Otherwise it is optional.
        /// </summary>
        public String taxPayerIdNumber { get; set; }

        /// <summary>
        /// Properties of the primary contact person for this account
        /// </summary>
        public List<String> properties { get; set; }


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
