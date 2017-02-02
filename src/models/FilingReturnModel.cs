using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Returns
    /// </summary>
    public class FilingReturnModel
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
        /// The current status of the filing return.
        /// </summary>
        public WorksheetStatusId? status { get; set; }

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
        /// The Adjustments for this return.
        /// </summary>
        public List<FilingAdjustmentModel> adjustments { get; set; }

        /// <summary>
        /// The Augmentations for this return.
        /// </summary>
        public List<FilingAugmentationModel> augmentations { get; set; }


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
