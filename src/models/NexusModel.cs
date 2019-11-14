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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a declaration of nexus within a particular taxing jurisdiction.
    ///  
    /// To create a nexus declaration for your company, you must first call the Definitions API `ListNexus` to obtain a
    /// list of Avalara-defined nexus. Once you have determined which nexus you wish to declare, you should customize
    /// only the user-selectable fields in this object.
    ///  
    /// The user selectable fields for the nexus object are `companyId`, `effectiveDate`, `endDate`, `localNexusTypeId`,
    /// `taxId`, `nexusTypeId`, `hasPermanentEstablishment`, and `isSellerImporterOfRecord`.
    ///  
    /// When calling `CreateNexus` or `UpdateNexus`, all values in your nexus object except for the user-selectable fields
    /// must match an Avalara-defined system nexus object. You can retrieve a list of Avalara-defined system nexus objects
    /// by calling `ListNexus`. If any data does not match, AvaTax may not recognize your nexus declaration.
    /// </summary>
    public class NexusModel
    {
        /// <summary>
        /// The unique ID number of this declaration of nexus.
        ///  
        /// This field is defined automatically when you declare nexus. You do not need to provide a value for this field.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the company that declared nexus.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the country in which this company declared nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Name or ISO 3166 code identifying the region within the country.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 12/20/2017, Version: 18.1, Message: Please use jurisdictionTypeId instead.
        /// The jurisdiction type of the jurisdiction in which this company declared nexus.
        /// </summary>
        public JurisTypeId? jurisTypeId { get; set; }

        /// <summary>
        /// The type of the jurisdiction in which this company declared nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public JurisdictionType? jurisdictionTypeId { get; set; }

        /// <summary>
        /// The code identifying the jurisdiction in which this company declared nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The common name of the jurisdiction in which this company declared nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The date when this nexus began. If not known, set to null.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// If this nexus will end or has ended on a specific date, set this to the date when this nexus ends.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The short name of the jurisdiction.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String shortName { get; set; }

        /// <summary>
        /// The signature code of the boundary region as defined by Avalara.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String signatureCode { get; set; }

        /// <summary>
        /// The state assigned number of this jurisdiction.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
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
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public NexusTypeId? nexusTypeId { get; set; }

        /// <summary>
        /// Indicates whether this nexus is defined as origin or destination nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// True if you are also declaring local nexus within this jurisdiction.
        /// Many U.S. states have options for declaring nexus in local jurisdictions as well as within the state.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public Boolean? hasLocalNexus { get; set; }

        /// <summary>
        /// If you are declaring local nexus within this jurisdiction, this indicates whether you are declaring only
        /// a specified list of local jurisdictions, all state-administered local jurisdictions, or all local jurisdictions.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public LocalNexusTypeId? localNexusTypeId { get; set; }

        /// <summary>
        /// Set this value to true if your company has a permanent establishment within this jurisdiction.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public Boolean? hasPermanentEstablishment { get; set; }

        /// <summary>
        /// Optional - the tax identification number under which you declared nexus.
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
        /// </summary>
        public String taxId { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 4/29/2017, Version: 19.4, Message: Please use isSSTActive instead.
        /// For the United States, this flag indicates whether this particular nexus falls within a U.S. State that participates
        /// in the Streamlined Sales Tax program. For countries other than the US, this flag is null.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public Boolean? streamlinedSalesTax { get; set; }

        /// <summary>
        /// For the United States, this flag indicates whether this particular nexus falls within a U.S. State that participates
        /// in the Streamlined Sales Tax program and if the account associated with the Nexus has an active AvaTaxCsp subscription.
        /// For countries other than the US, this flag is null.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public Boolean? isSSTActive { get; set; }

        /// <summary>
        /// The date when this record was created.
        ///  
        /// This field is defined automatically when you declare nexus. You do not need to provide a value for this field.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The User ID of the user who created this record.
        ///  
        /// This field is defined automatically when you declare nexus. You do not need to provide a value for this field.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        ///  
        /// This field is defined automatically when you declare nexus. You do not need to provide a value for this field.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        ///  
        /// This field is defined automatically when you declare nexus. You do not need to provide a value for this field.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The type of nexus that this company is declaring.Replaces NexusTypeId.
        /// Use [ListNexusTaxTypeGroups](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListNexusTaxTypeGroups/) API for a list of nexus tax type groups.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
        /// </summary>
        public String nexusTaxTypeGroup { get; set; }

        /// <summary>
        /// A unique ID number of the tax authority that is associated with this nexus.
        ///  
        /// This field is defined by Avalara. All Avalara-defined fields must match an Avalara-defined nexus object found by calling `ListNexus`.
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
        ///  
        /// This field is user-selectable and should be provided when creating or updating a nexus object.
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
