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
        public Int32? companyId { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country in which this company declared nexus.
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
        /// If the `jurisTypeId` field is set to `CNT` or `Country`, this field can be left blank.
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
        /// (DEPRECATED) The jurisdiction type of the jurisdiction in which this company declared nexus.
        /// NOTE: Use jurisdictionTypeId instead.
        /// </summary>
        public JurisTypeId? jurisTypeId { get; set; }

        /// <summary>
        /// The type of the jurisdiction in which this company declared nexus.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

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
        /// The type of nexus that this company is declaring.
        /// 
        /// If you are voluntarily declaring nexus in a jurisdiction, you should select `SalesOrSellersUseTax` for your
        /// nexus type option. This option allows you to calculate tax correctly whether you are selling in-state or
        /// shipping from an out-of-state location.
        /// 
        /// If you are legally obligated to declare nexus due to physical presence or other sufficient nexus, you
        /// should select `SalesTax`. This indicates that, as a legal requirement, your company must always collect
        /// and remit full sales tax in this jurisdiction.
        /// 
        /// If you are participating in the Streamlined Sales Tax program, your SST administrator will select nexus
        /// settings for you in all SST jurisdictions. Do not select any SST options by yourself.
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
        /// Use [ListNexusTaxTypeGroups](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListNexusTaxTypeGroups/) API for a list of nexus tax type groups.
        /// </summary>
        public String nexusTaxTypeGroup { get; set; }

        /// <summary>
        /// The tax authority id associated with the jurisdiction the nexus is for
        /// </summary>
        public Int64? taxAuthorityId { get; set; }

        /// <summary>
        /// For nexus declarations at the country level, specifies whether this company is considered the importer of record in this nexus region.
        /// 
        /// Some taxes only apply if the seller is the importer of record for a product. In cases where companies are working together to
        /// ship products, there may be mutual agreement as to which company is the entity designated as importer of record. The importer
        /// of record will then be the company designated to pay taxes marked as being obligated to the importer of record.
        /// 
        /// Set this value to `true` to consider your company as the importer of record and collect these taxes. Leave this value as false
        /// or null and taxes will be calculated as if your company is not the importer of record.
        /// 
        /// This value may also be set during each transaction API call. See `CreateTransaction()` for more information.
        /// </summary>
        public Boolean? isSellerImporterOfRecord { get; set; }


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
