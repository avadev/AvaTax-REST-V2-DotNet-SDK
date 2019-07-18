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
    /// An input model for executing a report detailed to the document line level
    /// </summary>
    public class ExportDocumentLineModel
    {
        /// <summary>
        /// The file format.
        /// </summary>
        public ReportFormat? format { get; set; }

        /// <summary>
        /// The start date filter for report execution. If no date provided, same date of last month will be used as the startDate.
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// The end date filter for report execution. If no date provided, today's date will be used as the endDate.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The transactions in the country you wish to run a report:
        /// use "ALL" for all countries
        /// use "ALL Non-US" for all international countries
        /// or use a single 2-char ISO country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state associated with the transactions you wish to run a report on: use "ALL" for all states.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The type of date to filter your transactions
        /// </summary>
        public ReportDateFilter? dateFilter { get; set; }

        /// <summary>
        /// The transaction type you want to run a report on
        /// </summary>
        public ReportDocType? docType { get; set; }

        /// <summary>
        /// Format of dates in your rendered report. Example: "MM/dd/yyyy"
        /// </summary>
        public String dateFormat { get; set; }

        /// <summary>
        /// In which culture your report is produced with. Example: "en-US"
        /// </summary>
        public String culture { get; set; }

        /// <summary>
        /// The currency your report is displayed in. Example: "USD"
        /// </summary>
        public String currencyCode { get; set; }


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
