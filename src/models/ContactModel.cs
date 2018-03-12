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
    /// A contact person for a company.
    /// </summary>
    public class ContactModel
    {
        /// <summary>
        /// The unique ID number of this contact.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company to which this contact belongs.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A unique code for this contact.
        /// </summary>
        public String contactCode { get; set; }

        /// <summary>
        /// The first or given name of this contact.
        /// </summary>
        public String firstName { get; set; }

        /// <summary>
        /// The middle name of this contact.
        /// </summary>
        public String middleName { get; set; }

        /// <summary>
        /// The last or family name of this contact.
        /// </summary>
        public String lastName { get; set; }

        /// <summary>
        /// Professional title of this contact.
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// The first line of the postal mailing address of this contact.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// The second line of the postal mailing address of this contact.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// The third line of the postal mailing address of this contact.
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// The city of the postal mailing address of this contact.
        /// </summary>
        public String city { get; set; }

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
        /// The postal code or zip code of the postal mailing address of this contact.
        /// </summary>
        public String postalCode { get; set; }

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
        /// The email address of this contact.
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// The main phone number for this contact.
        /// </summary>
        public String phone { get; set; }

        /// <summary>
        /// The mobile phone number for this contact.
        /// </summary>
        public String mobile { get; set; }

        /// <summary>
        /// The facsimile phone number for this contact.
        /// </summary>
        public String fax { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
