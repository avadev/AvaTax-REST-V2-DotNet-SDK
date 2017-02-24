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
    /// Company Initialization Model
    /// </summary>
    public class CompanyInitializationModel
    {
        /// <summary>
        /// Company Name
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Company Code - used to distinguish between companies within your accounting system
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Vat Registration Id - leave blank if not known.
        /// </summary>
        public String vatRegistrationId { get; set; }

        /// <summary>
        /// United States Taxpayer ID number, usually your Employer Identification Number if you are a business or your 
        ///Social Security Number if you are an individual.
        ///This value is required if you subscribe to Avalara Managed Returns or the SST Certified Service Provider services, 
        ///but it is optional if you do not subscribe to either of those services.
        /// </summary>
        public String taxpayerIdNumber { get; set; }

        /// <summary>
        /// Address Line1
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Line2
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// Line3
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// Two character ISO 3166 Region code for this company's primary business location.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Postal Code
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Two character ISO 3166 Country code for this company's primary business location.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// First Name
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// Phone Number
        /// </summary>
        public String phoneNumber { get; set; }

        /// <summary>
        /// Mobile Number
        /// </summary>
        public String mobileNumber { get; set; }

        /// <summary>
        /// Fax Number
        /// </summary>
        public String faxNumber { get; set; }


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
