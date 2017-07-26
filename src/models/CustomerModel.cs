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
    /// Represents a customer to whom you sell products and/or services.
    /// </summary>
    public class CustomerModel
    {
        /// <summary>
        /// Unique ID number assigned to each company by Avalara.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that maintains this customer record.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Int32? clientId { get; set; }

        /// <summary>
        /// A number by which this customer is known by your system. Must be unique within your company.
        /// </summary>
        public String customerNumber { get; set; }

        /// <summary>
        /// Alternate Id
        /// </summary>
        public String alternateId { get; set; }

        /// <summary>
        /// Customer name
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// Indicates the "Attn:" component of the address for this customer, if this customer requires mailings to be shipped 
        /// to the attention of a specific person or department name.
        /// </summary>
        public String attnName { get; set; }

        /// <summary>
        /// First line of the street address
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Second line of the street address
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// City component of the address
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// Postal Code / Zip Code component of the address.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Customer phone number
        /// </summary>
        public String phoneNumber { get; set; }

        /// <summary>
        /// Customer fax number
        /// </summary>
        public String faxNumber { get; set; }

        /// <summary>
        /// Customer email
        /// </summary>
        public String emailAddress { get; set; }

        /// <summary>
        /// Customer contact name
        /// </summary>
        public String contactName { get; set; }

        /// <summary>
        /// When last transaction was happened,
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
        /// Two character ISO 3166 county code for this country
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Two or three character ISO 3166 region, province, or state name
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? isBill { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? isShip { get; set; }

        /// <summary>
        /// For customers in the United States, this field is the federal taxpayer ID number. For businesses, this is 
        /// a Federal Employer Identification Number. For individuals, this will be a Social Security Number.
        /// </summary>
        public String taxpayerIdNumber { get; set; }

        /// <summary>
        /// A list of exemption certficates that apply to this customer.
        /// </summary>
        public List<CertificateModel> certificates { get; set; }


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
