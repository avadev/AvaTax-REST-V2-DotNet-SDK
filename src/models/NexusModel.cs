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
    /// Represents a declaration of nexus within a particular taxing jurisdiction.
    /// </summary>
    public class NexusModel
    {
        /// <summary>
        /// The unique ID number of this declaration of nexus.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the company that declared nexus.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// The two character ISO-3166 country code of the country in which this company declared nexus.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The two or three character ISO region code of the region, state, or province in which this company declared nexus.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The jurisdiction type of the jurisdiction in which this company declared nexus.
        /// </summary>
        public JurisTypeId? jurisTypeId { get; set; }

        /// <summary>
        /// The code identifying the jurisdiction in which this company declared nexus.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The common name of the jurisdiction in which this company declared nexus.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The date when this nexus began. If not known, set to null.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If this nexus will end or has ended on a specific date, set this to the date when this nexus ends.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The short name of the jurisdiction.
        /// </summary>
        public String shortName { get; set; }

        /// <summary>
        /// The signature code of the boundary region as defined by Avalara.
        /// </summary>
        public String signatureCode { get; set; }

        /// <summary>
        /// The state assigned number of this jurisdiction.
        /// </summary>
        public String stateAssignedNo { get; set; }

        /// <summary>
        /// (DEPRECATED) The type of nexus that this company is declaring.
        /// Please use NexusTaxTypeGroupId instead.
        /// </summary>
        public NexusTypeId? nexusTypeId { get; set; }

        /// <summary>
        /// Indicates whether this nexus is defined as origin or destination nexus.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// True if you are also declaring local nexus within this jurisdiction.
        /// Many U.S. states have options for declaring nexus in local jurisdictions as well as within the state.
        /// </summary>
        public Boolean? hasLocalNexus { get; set; }

        /// <summary>
        /// If you are declaring local nexus within this jurisdiction, this indicates whether you are declaring only 
        /// a specified list of local jurisdictions, all state-administered local jurisdictions, or all local jurisdictions.
        /// </summary>
        public LocalNexusTypeId? localNexusTypeId { get; set; }

        /// <summary>
        /// Set this value to true if your company has a permanent establishment within this jurisdiction.
        /// </summary>
        public Boolean? hasPermanentEstablishment { get; set; }

        /// <summary>
        /// Optional - the tax identification number under which you declared nexus.
        /// </summary>
        public String taxId { get; set; }

        /// <summary>
        /// For the United States, this flag indicates whether this particular nexus falls within a U.S. State that participates 
        /// in the Streamlined Sales Tax program. For countries other than the US, this flag is null.
        /// </summary>
        public Boolean? streamlinedSalesTax { get; set; }

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
        /// The type of nexus that this company is declaring.Replaces NexusTypeId.
        /// Use `/api/v2/definitions/taxtypegroups` for a list of tax type groups.
        /// </summary>
        public String nexusTaxTypeGroup { get; set; }

        /// <summary>
        /// The tax authority id associated with the jurisdiction the nexus is for
        /// </summary>
        public Int64? taxAuthorityId { get; set; }


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
