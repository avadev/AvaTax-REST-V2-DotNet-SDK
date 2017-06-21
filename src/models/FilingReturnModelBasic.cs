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
    /// Filing Returns Model
    /// </summary>
    public class FilingReturnModelBasic
    {
        /// <summary>
        /// The unique ID number of the company filing return.
        /// </summary>
        public Int64? companyId { get; set; }

        /// <summary>
        /// The unique ID number of this filing return.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The filing id that this return belongs too
        /// </summary>
        public Int64? filingId { get; set; }

        /// <summary>
        /// The region id that this return belongs too
        /// </summary>
        public Int64? filingRegionId { get; set; }

        /// <summary>
        /// The unique ID number of the filing calendar associated with this return.
        /// </summary>
        public Int64? filingCalendarId { get; set; }

        /// <summary>
        /// The country of the form.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The region of the form.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The month of the filing period for this tax filing. 
        /// The filing period represents the year and month of the last day of taxes being reported on this filing. 
        /// For example, an annual tax filing for Jan-Dec 2015 would have a filing period of Dec 2015.
        /// </summary>
        public Byte? endPeriodMonth { get; set; }

        /// <summary>
        /// The year of the filing period for this tax filing.
        /// The filing period represents the year and month of the last day of taxes being reported on this filing. 
        /// For example, an annual tax filing for Jan-Dec 2015 would have a filing period of Dec 2015.
        /// </summary>
        public Int16? endPeriodYear { get; set; }

        /// <summary>
        /// The current status of the filing return.
        /// </summary>
        public FilingStatusId? status { get; set; }

        /// <summary>
        /// The filing frequency of the return.
        /// </summary>
        public FilingFrequencyId? filingFrequency { get; set; }

        /// <summary>
        /// The date the return was filed by Avalara.
        /// </summary>
        public DateTime? filedDate { get; set; }

        /// <summary>
        /// The sales amount.
        /// </summary>
        public Decimal? salesAmount { get; set; }

        /// <summary>
        /// The filing type of the return.
        /// </summary>
        public FilingTypeId? filingType { get; set; }

        /// <summary>
        /// The name of the form.
        /// </summary>
        public String formName { get; set; }

        /// <summary>
        /// The remittance amount of the return.
        /// </summary>
        public Decimal? remitAmount { get; set; }

        /// <summary>
        /// The unique code of the form.
        /// </summary>
        public String formCode { get; set; }

        /// <summary>
        /// A description for the return.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The taxable amount.
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// The tax amount.
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// The amount collected by avalara for this return
        /// </summary>
        public Decimal? collectAmount { get; set; }

        /// <summary>
        /// The tax due amount.
        /// </summary>
        public Decimal? taxDueAmount { get; set; }

        /// <summary>
        /// The non-taxable amount.
        /// </summary>
        public Decimal? nonTaxableAmount { get; set; }

        /// <summary>
        /// The non-taxable due amount.
        /// </summary>
        public Decimal? nonTaxableDueAmount { get; set; }

        /// <summary>
        /// Consumer use tax liability.
        /// </summary>
        public Decimal? consumerUseTaxAmount { get; set; }

        /// <summary>
        /// Consumer use non-taxable amount.
        /// </summary>
        public Decimal? consumerUseNonTaxableAmount { get; set; }

        /// <summary>
        /// Consumer use taxable amount.
        /// </summary>
        public Decimal? consumerUseTaxableAmount { get; set; }

        /// <summary>
        /// Accrual type of the return
        /// </summary>
        public AccrualType? accrualType { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
