using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// TODO
    /// </summary>
    public class WorksheetReturnModel
    {
        /// <summary>
        /// TODO
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public WorksheetStatusId? status { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public FilingFrequencyId? filingFrequency { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? filedDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? salesAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public FilingTypeId? filingType { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String formName { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? remitAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String returnName { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? taxDueAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? nonTaxableAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? nonTaxableDueAmount { get; set; }


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
