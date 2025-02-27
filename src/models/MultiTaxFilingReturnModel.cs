using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Filing Returns Model
    /// </summary>
    public class MultiTaxFilingReturnModel
    {
        /// <summary>
        /// The unique ID number of this filing return.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the filing calendar associated with this return.
        /// </summary>
        public Int64? filingCalendarId { get; set; }

        /// <summary>
        /// The registration ID from the return's filing calendar.
        /// </summary>
        public String registrationId { get; set; }

        /// <summary>
        /// The current status of the filing return.
        /// </summary>
        public FilingStatusId? status { get; set; }

        /// <summary>
        /// The filing frequency of the return.
        /// </summary>
        public FilingFrequencyId? filingFrequency { get; set; }

        /// <summary>
        /// The filing type of the return.
        /// </summary>
        public FilingTypeId? filingType { get; set; }

        /// <summary>
        /// The name of the form.
        /// </summary>
        public String formName { get; set; }

        /// <summary>
        /// The unique code of the form.
        /// </summary>
        public String formCode { get; set; }

        /// <summary>
        /// The unique code of the form, prefixed by the country code.
        /// </summary>
        public String taxFormCode { get; set; }

        /// <summary>
        /// A description for the return.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Tax Authority ID of this return
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// The date the return was filed by Avalara.
        /// </summary>
        public DateTime? filedDate { get; set; }

        /// <summary>
        /// Accrual type of the return
        /// </summary>
        public AccrualType? accrualType { get; set; }

        /// <summary>
        /// The start date of this return
        /// </summary>
        public DateTime? startPeriod { get; set; }

        /// <summary>
        /// The end date of this return
        /// </summary>
        public DateTime? endPeriod { get; set; }

        /// <summary>
        /// The FilingTaskType for this return.
        /// </summary>
        public String type { get; set; }

        /// <summary>
        /// The three-character liability currency code.
        /// </summary>
        public String liabilityCurrencyCode { get; set; }

        /// <summary>
        /// The three-character filing calendar currency code for this return. For example if country is 'US' then currency is 'USD'. Similarly, if country is 'CA' then currency is 'CAD', etc.
        /// </summary>
        public String filingCalendarCurrencyCode { get; set; }

        /// <summary>
        /// Can the return be unlocked or not.
        /// </summary>
        public Boolean? canUnlock { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingsTaxSummaryModel returnTaxSummary { get; set; }

        /// <summary>
        /// A detailed breakdown of the taxes in this filing
        /// </summary>
        public List<FilingsTaxDetailsModel> returnTaxDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingReturnCreditModel excludedCarryOverCredits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingReturnCreditModel appliedCarryOverCredits { get; set; }

        /// <summary>
        /// Total amount of adjustments on this return
        /// </summary>
        public Decimal? totalAdjustments { get; set; }

        /// <summary>
        /// The Adjustments for this return.
        /// </summary>
        public List<FilingAdjustmentModel> adjustments { get; set; }

        /// <summary>
        /// Total amount of augmentations on this return
        /// </summary>
        public Decimal? totalAugmentations { get; set; }

        /// <summary>
        /// The Augmentations for this return.
        /// </summary>
        public List<FilingAugmentationModel> augmentations { get; set; }

        /// <summary>
        /// Total amount of payments on this return
        /// </summary>
        public Decimal? totalPayments { get; set; }

        /// <summary>
        /// The payments for this return.
        /// </summary>
        public List<FilingPaymentModel> payments { get; set; }

        /// <summary>
        /// The attachments for this return.
        /// </summary>
        public List<FilingAttachmentModel> attachments { get; set; }


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
