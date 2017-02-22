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
    /// Represents a declaration of JurisdictionOverride within a particular taxing jurisdiction.
    /// </summary>
    public class JurisdictionOverrideModel
    {
        /// <summary>
        /// The unique ID number of this declaration of jurisdictionoverride.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number assigned to this account.
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// The summerization of why this jurisdictionoverride is created.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The street address of the JurisdictionOverride intends be created upon
        /// </summary>
        public String address { get; set; }

        /// <summary>
        /// The city of the passed in address which the jurisdictionOverride intends to be created upon
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// The two or three character ISO region code of the region, state, or province in which this company declared nexus.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The two character ISO-3166 country code of the country in which this company declared nexus.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The postal code of the passed in address
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The date when this nexus began. If not known, set to null.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If this nexus will end or has ended on a specific date, set this to the date when this nexus ends.
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
        /// A list of tax authorities contributing to the taxing of this location
        /// </summary>
        public List<JurisdictionModel> jurisdictions { get; set; }


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
