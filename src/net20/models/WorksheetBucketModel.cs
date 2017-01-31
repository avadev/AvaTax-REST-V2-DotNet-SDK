using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Worksheet Bucket
    /// </summary>
    public class WorksheetBucketModel
    {
        /// <summary>
        /// TODO
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? salesAmount { get; set; }

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
        public Decimal? taxAmountDue { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Decimal? nonTaxableAmount { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? approveDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public Boolean? hasNexus { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public WorksheetStatusId? worksheetStatusId { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public List<WorksheetReturnModel> returns { get; set; }


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
