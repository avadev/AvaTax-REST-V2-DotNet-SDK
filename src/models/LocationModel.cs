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
    /// A location where this company does business.
    /// Some jurisdictions may require you to list all locations where your company does business.
    /// </summary>
    public class LocationModel
    {
        /// <summary>
        /// The unique ID number of this location.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company that operates at this location.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// A code that identifies this location. Must be unique within your company.
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// A friendly name for this location.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Indicates whether this location is a physical place of business or a temporary salesperson location.
        /// </summary>
        public AddressTypeId addressTypeId { get; set; }

        /// <summary>
        /// Indicates the type of place of business represented by this location.
        /// </summary>
        public AddressCategoryId addressCategoryId { get; set; }

        /// <summary>
        /// The first line of the physical address of this location.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// The second line of the physical address of this location.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// The third line of the physical address of this location.
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// The city of the physical address of this location.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// The county name of the physical address of this location. Not required.
        /// </summary>
        public String county { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country of the physical address of this location.
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
        /// The postal code or zip code of the physical address of this location.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country of the physical address of this location.
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
        /// Set this flag to true to indicate that this is the default location for this company.
        /// </summary>
        public Boolean? isDefault { get; set; }

        /// <summary>
        /// Set this flag to true to indicate that this location has been registered with a tax authority.
        /// </summary>
        public Boolean? isRegistered { get; set; }

        /// <summary>
        /// If this location has a different business name from its legal entity name, specify the "Doing Business As" name for this location.
        /// </summary>
        public String dbaName { get; set; }

        /// <summary>
        /// A friendly name for this location.
        /// </summary>
        public String outletName { get; set; }

        /// <summary>
        /// The date when this location was opened for business, or null if not known.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If this place of business has closed, the date when this location closed business.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The most recent date when a transaction was processed for this location. Set by AvaTax.
        /// </summary>
        public DateTime? lastTransactionDate { get; set; }

        /// <summary>
        /// The date when this location was registered with a tax authority. Not required.
        /// </summary>
        public DateTime? registeredDate { get; set; }

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
        /// Extra information required by certain jurisdictions for filing.
        /// For a list of settings recognized by Avalara, query the endpoint "/api/v2/definitions/locationquestions". 
        /// To determine the list of settings required for this location, query the endpoint "/api/v2/companies/(id)/locations/(id)/validate".
        /// </summary>
        public List<LocationSettingModel> settings { get; set; }


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
