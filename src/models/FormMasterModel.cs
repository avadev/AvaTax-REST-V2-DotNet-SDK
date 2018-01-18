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
    /// Represents information about a tax form known to Avalara
    /// </summary>
    public class FormMasterModel
    {
        /// <summary>
        /// Unique ID number of this form master object
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The type of the form being submitted
        /// </summary>
        public Int32? formTypeId { get; set; }

        /// <summary>
        /// Unique tax form code representing this tax form
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// Legacy return name as known in the AvaFileForm table
        /// </summary>
        public String legacyReturnName { get; set; }

        /// <summary>
        /// Human readable form summary name
        /// </summary>
        public String taxFormName { get; set; }

        /// <summary>
        /// Description of this tax form
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// True if this form is available for use
        /// </summary>
        public Boolean? isEffective { get; set; }

        /// <summary>
        /// ISO 3166 code of the country that issued this tax form
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The region within which this form was issued
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Tax authority that issued the form
        /// </summary>
        public String authorityName { get; set; }

        /// <summary>
        /// DEPRECATED
        /// </summary>
        public String shortCode { get; set; }

        /// <summary>
        /// Day of the month when the form is due
        /// </summary>
        public Int32? dueDay { get; set; }

        /// <summary>
        /// Day of the month on which the form is considered delinquent. Almost always the same as DueDay
        /// </summary>
        public Int32? delinquentDay { get; set; }

        /// <summary>
        /// Month of the year the state considers as the first fiscal month
        /// </summary>
        public Int32? fiscalYearStartMonth { get; set; }

        /// <summary>
        /// Can form support multi frequencies
        /// </summary>
        public Boolean? hasMultiFrequencies { get; set; }

        /// <summary>
        /// Does this tax authority require a power of attorney in order to speak to Avalara
        /// </summary>
        public Boolean? isPOARequired { get; set; }

        /// <summary>
        /// True if this form requires that the customer register with the authority
        /// </summary>
        public Boolean? isRegistrationRequired { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasMultiRegistrationMethods { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasSchedules { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasMultiFilingMethods { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasMultiPayMethods { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? isEFTRequired { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? isFilePayMethodLinked { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Int32? mailingReceivedRuleId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Int32? proofOfMailingId { get; set; }

        /// <summary>
        /// True if you can report a negative amount in a single jurisdiction on the form
        /// </summary>
        public Boolean? isNegAmountAllowed { get; set; }

        /// <summary>
        /// True if the form overall can go negative
        /// </summary>
        public Boolean? allowNegativeOverallTax { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? isNettingRequired { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Int32? roundingMethodId { get; set; }

        /// <summary>
        /// Total amount of discounts that can be received by a vendor each year
        /// </summary>
        public Decimal? vendorDiscountAnnualMax { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? versionsRequireAuthorityApproval { get; set; }

        /// <summary>
        /// Type of outlet reporting for this form
        /// </summary>
        public Int32? outletReportingMethodId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasReportingCodes { get; set; }

        /// <summary>
        /// Not sure if used
        /// </summary>
        public Boolean? hasPrepayments { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? grossIncludesInterstateSales { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String grossIncludesTax { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasEfileFee { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasEpayFee { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? hasDependencies { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String requiredEfileTrigger { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String requiredEftTrigger { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? vendorDiscountEfile { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? vendorDiscountPaper { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String peerReviewed { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String peerReviewedId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String peerReviewedDate { get; set; }

        /// <summary>
        /// ID of the Avalara user who created the form
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// Date when form was created
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// ID of the Avalara user who modified the form
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// Date when form was modified
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddressMailTo { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddress1 { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddress2 { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddressCity { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddressRegion { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddressPostalCode { get; set; }

        /// <summary>
        /// Mailing address of the department of revenue
        /// </summary>
        public String dorAddressCountry { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddressMailTo { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddress1 { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddress2 { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddressCity { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddressRegion { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddressPostalCode { get; set; }

        /// <summary>
        /// Mailing address to use when a zero dollar form is filed
        /// </summary>
        public String zeroAddressCountry { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddressMailTo { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddress1 { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddress2 { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddressCity { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddressRegion { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddressPostalCode { get; set; }

        /// <summary>
        /// Mailing address to use when filing an amended return
        /// </summary>
        public String amendedAddressCountry { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? onlineBackFiling { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? onlineAmendedReturns { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public String prepaymentFrequency { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? outletLocationIdentifiersRequired { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public String listingSortOrder { get; set; }

        /// <summary>
        /// Link to the state department of revenue website, if available
        /// </summary>
        public String dorWebsite { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public Boolean? fileForAllOutlets { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public Boolean? paperFormsDoNotHaveDiscounts { get; set; }

        /// <summary>
        /// Internal behavior
        /// </summary>
        public Boolean? stackAggregation { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public String roundingPrecision { get; set; }

        /// <summary>
        /// --Need Further Clarification
        /// </summary>
        public String inconsistencyTolerance { get; set; }

        /// <summary>
        /// Date when this form became effective
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// Date when this form expired
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// True if this form can be shown to customers
        /// </summary>
        public Boolean? visibleToCustomers { get; set; }

        /// <summary>
        /// True if this form requires that you set up outlets in the state
        /// </summary>
        public Boolean? requiresOutletSetup { get; set; }

        /// <summary>
        /// True if this state permits payment by ACH Credit
        /// </summary>
        public Boolean? achCreditAllowed { get; set; }

        /// <summary>
        /// Jurisdiction level of the state
        /// </summary>
        public String reportLevel { get; set; }

        /// <summary>
        /// True if this form is verified filed via email
        /// </summary>
        public Boolean? postOfficeValidated { get; set; }

        /// <summary>
        /// Internal Avalara flag
        /// </summary>
        public String stackAggregationOption { get; set; }

        /// <summary>
        /// Internal Avalara flag
        /// </summary>
        public String sstBehavior { get; set; }

        /// <summary>
        /// Internal Avalara flag
        /// </summary>
        public String nonSstBehavior { get; set; }

        /// <summary>
        /// Phone number of the department of revenue
        /// </summary>
        public String dorPhoneNumber { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String averageCheckClearDays { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? filterZeroRatedLineDetails { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Boolean? allowsBulkFilingAccounts { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String bulkAccountInstructionLink { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String registrationIdFormat { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String thresholdTrigger { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String transactionSortingOption { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public Int32? contentReviewFrequencyId { get; set; }

        /// <summary>
        /// Unused
        /// </summary>
        public String aliasForFormMasterId { get; set; }


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
