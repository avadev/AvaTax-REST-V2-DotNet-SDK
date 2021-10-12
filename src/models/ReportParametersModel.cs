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
    /// The output model for report parameter definitions
    /// </summary>
    public class ReportParametersModel
    {
        /// <summary>
        /// The start date filter used for your report
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// The end date filter used for your report
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The country filter used for your report
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state filter used for your report
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The date type filter used for your report
        /// </summary>
        public String dateFilter { get; set; }

        /// <summary>
        /// The doc type filter used for your report
        /// </summary>
        public String docType { get; set; }

        /// <summary>
        /// The date format used for your report
        /// </summary>
        public String dateFormat { get; set; }

        /// <summary>
        /// The currency code used for your report
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Number of partitions to split the report into.
        /// </summary>
        public Int32? numberOfPartitions { get; set; }

        /// <summary>
        /// The zero-based partition number to retrieve in this export request.
        /// </summary>
        public Int32? partition { get; set; }

        /// <summary>
        /// If true, include only documents that are locked.
        /// If false, include only documents that are not locked.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? isLocked { get; set; }

        /// <summary>
        /// If set, include only documents associated with this merchantSellerId.
        /// </summary>
        public String merchantSellerId { get; set; }

        /// <summary>
        /// The Document status filter used for report
        /// For documentStatus, accepted values are: Temporary, Saved, Posted, Committed, Cancelled, Adjusted, Queued, PendingApproval
        /// </summary>
        public String documentStatus { get; set; }

        /// <summary>
        /// If true, modified date will be same as document date
        /// If false, modified date will not be same as document date
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? isModifiedDateSameAsDocumentDate { get; set; }


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
