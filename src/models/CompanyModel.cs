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
    /// A company or business entity.
    /// </summary>
    public class CompanyModel
    {
        /// <summary>
        /// The unique ID number of this company.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// The unique ID number of the account this company belongs to.
        /// </summary>
        public Int32 accountId { get; set; }

        /// <summary>
        /// If this company is fully owned by another company, this is the unique identity of the parent company.
        /// </summary>
        public Int32? parentCompanyId { get; set; }

        /// <summary>
        /// If this company files Streamlined Sales Tax, this is the PID of this company as defined by the Streamlined Sales Tax governing board.
        /// </summary>
        public String sstPid { get; set; }

        /// <summary>
        /// A unique code that references this company within your account.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// The name of this company, as shown to customers.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// This flag is true if this company is the default company for this account. Only one company may be set as the default.
        /// </summary>
        public Boolean? isDefault { get; set; }

        /// <summary>
        /// If set, this is the unique ID number of the default location for this company.
        /// </summary>
        public Int32? defaultLocationId { get; set; }

        /// <summary>
        /// This flag indicates whether tax activity can occur for this company. Set this flag to true to permit the company to process transactions.
        /// </summary>
        public Boolean? isActive { get; set; }

        /// <summary>
        /// For United States companies, this field contains your Taxpayer Identification Number. 
        ///This is a nine digit number that is usually called an EIN for an Employer Identification Number if this company is a corporation, 
        ///or SSN for a Social Security Number if this company is a person.
        ///This value is required if you subscribe to Avalara Managed Returns or the SST Certified Service Provider services, 
        ///but it is optional if you do not subscribe to either of those services.
        /// </summary>
        public String taxpayerIdNumber { get; set; }

        /// <summary>
        /// Set this flag to true to give this company its own unique tax profile.
        ///If this flag is true, this company will have its own Nexus, TaxRule, TaxCode, and Item definitions.
        ///If this flag is false, this company will inherit all profile values from its parent.
        /// </summary>
        public Boolean? hasProfile { get; set; }

        /// <summary>
        /// Set this flag to true if this company must file its own tax returns.
        ///For users who have Returns enabled, this flag turns on monthly Worksheet generation for the company.
        /// </summary>
        public Boolean? isReportingEntity { get; set; }

        /// <summary>
        /// If this company participates in Streamlined Sales Tax, this is the date when the company joined the SST program.
        /// </summary>
        public DateTime? sstEffectiveDate { get; set; }

        /// <summary>
        /// The two character ISO-3166 country code of the default country for this company.
        /// </summary>
        public String defaultCountry { get; set; }

        /// <summary>
        /// This is the three character ISO-4217 currency code of the default currency used by this company.
        /// </summary>
        public String baseCurrencyCode { get; set; }

        /// <summary>
        /// Indicates whether this company prefers to round amounts at the document level or line level.
        /// </summary>
        public RoundingLevelId? roundingLevelId { get; set; }

        /// <summary>
        /// Set this value to true to receive warnings in API calls via SOAP.
        /// </summary>
        public Boolean? warningsEnabled { get; set; }

        /// <summary>
        /// Set this flag to true to indicate that this company is a test company.
        ///If you have Returns enabled, Test companies will not file tax returns and can be used for validation purposes.
        /// </summary>
        public Boolean? isTest { get; set; }

        /// <summary>
        /// Used to apply tax detail dependency at a jurisdiction level.
        /// </summary>
        public TaxDependencyLevelId? taxDependencyLevelId { get; set; }

        /// <summary>
        /// Set this value to true to indicate that you are still working to finish configuring this company.
        ///While this value is true, no tax reporting will occur and the company will not be usable for transactions.
        /// </summary>
        public Boolean? inProgress { get; set; }

        /// <summary>
        /// Business Identification No
        /// </summary>
        public String businessIdentificationNo { get; set; }

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
        /// Optional: A list of contacts defined for this company. To fetch this list, add the query string "?$include=Contacts" to your URL.
        /// </summary>
        public List<ContactModel> contacts { get; set; }

        /// <summary>
        /// Optional: A list of items defined for this company. To fetch this list, add the query string "?$include=Items" to your URL.
        /// </summary>
        public List<ItemModel> items { get; set; }

        /// <summary>
        /// Optional: A list of locations defined for this company. To fetch this list, add the query string "?$include=Locations" to your URL.
        /// </summary>
        public List<LocationModel> locations { get; set; }

        /// <summary>
        /// Optional: A list of nexus defined for this company. To fetch this list, add the query string "?$include=Nexus" to your URL.
        /// </summary>
        public List<NexusModel> nexus { get; set; }

        /// <summary>
        /// Optional: A list of settings defined for this company. To fetch this list, add the query string "?$include=Settings" to your URL.
        /// </summary>
        public List<SettingModel> settings { get; set; }

        /// <summary>
        /// Optional: A list of tax codes defined for this company. To fetch this list, add the query string "?$include=TaxCodes" to your URL.
        /// </summary>
        public List<TaxCodeModel> taxCodes { get; set; }

        /// <summary>
        /// Optional: A list of tax rules defined for this company. To fetch this list, add the query string "?$include=TaxRules" to your URL.
        /// </summary>
        public List<TaxRuleModel> taxRules { get; set; }

        /// <summary>
        /// Optional: A list of UPCs defined for this company. To fetch this list, add the query string "?$include=UPCs" to your URL.
        /// </summary>
        public List<UPCModel> upcs { get; set; }


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
