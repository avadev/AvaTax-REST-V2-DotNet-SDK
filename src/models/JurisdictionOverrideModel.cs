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
    /// Represents an override of tax jurisdictions for a specific address.
    ///  
    /// During the time period represented by EffDate through EndDate, all tax decisions for addresses matching
    /// this override object will be assigned to the list of jurisdictions designated in this object.
    /// </summary>
    public class JurisdictionOverrideModel
    {
        /// <summary>
        /// The unique ID number of this override.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number assigned to this account.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// A description of why this jurisdiction override was created.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The street address of the physical location affected by this override.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// The city address of the physical location affected by this override.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country to be affected by this override.
        ///  
        /// Note that only United States addresses are affected by the jurisdiction override system.
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
        /// The two character ISO-3166 country code of the country affected by this override.
        ///  
        /// Note that only United States addresses are affected by the jurisdiction override system.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The postal code of the physical location affected by this override.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The date when this override first takes effect. Set this value to null to affect all dates up to the end date.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// The date when this override will cease to take effect. Set this value to null to never expire.
        /// </summary>
        public DateTime? endDate { get; set; }

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
        /// A list of the tax jurisdictions that will be assigned to this overridden address.
        /// </summary>
        public List<JurisdictionModel> jurisdictions { get; set; }

        /// <summary>
        /// The TaxRegionId of the new location affected by this jurisdiction override.
        /// </summary>
        public Int32 taxRegionId { get; set; }

        /// <summary>
        /// The boundary level of this override
        /// </summary>
        public BoundaryLevel? boundaryLevel { get; set; }

        /// <summary>
        /// True if this is a default boundary
        /// </summary>
        public Boolean? isDefault { get; set; }


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
