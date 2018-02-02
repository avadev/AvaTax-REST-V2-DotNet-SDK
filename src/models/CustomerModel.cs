using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Represents a customer to whom you sell products and/or services.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Unique ID number of this customer.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that recorded this customer.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The unique code identifying this customer. Must be unique within your company.
        /// 
        /// This code should be used in the `customerCode` field of any call that creates or adjusts a transaction
        /// in order to ensure that all exemptions that apply to this customer are correctly considered.
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// A customer-configurable alternate ID number for this customer. You may set this value to match any
        /// other system that would like to reference this customer record.
        /// </summary>
        public String alternateId { get; set; }

        /// <summary>
        /// A friendly name identifying this customer.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Indicates the "Attn:" component of the address for this customer, if this customer requires mailings to be shipped 
        /// to the attention of a specific person or department name.
        /// </summary>
        public String attnName { get; set; }

        /// <summary>
        /// First line of the street address of this customer.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Second line of the street address of this customer.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// City component of the street address of this customer.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// Postal Code / Zip Code component of the address of this customer.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The main phone number for this customer.
        /// </summary>
        public String phoneNumber { get; set; }

        /// <summary>
        /// The fax phone number for this customer, if any.
        /// </summary>
        public String faxNumber { get; set; }

        /// <summary>
        /// The main email address for this customer.
        /// </summary>
        public String emailAddress { get; set; }

        /// <summary>
        /// The name of the main contact person for this customer.
        /// </summary>
        public String contactName { get; set; }

        /// <summary>
        /// Date when this customer last executed a transaction.
        /// </summary>
        public DateTime? lastTransaction { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country.
        /// 
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// True if this customer record is specifically used for bill-to purposes.
        /// </summary>
        public Boolean? isBill { get; set; }

        /// <summary>
        /// True if this customer record is specifically used for ship-to purposes.
        /// </summary>
        public Boolean? isShip { get; set; }

        /// <summary>
        /// For customers in the United States, this field is the federal taxpayer ID number. For businesses, this is 
        /// a Federal Employer Identification Number. For individuals, this will be a Social Security Number.
        /// </summary>
        public String taxpayerIdNumber { get; set; }

        /// <summary>
        /// A list of exemption certficates that apply to this customer. You can fetch this data by specifying 
        /// `$include=certificates` when calling a customer fetch API.
        /// </summary>
        public List<CertificateModel> certificates { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
