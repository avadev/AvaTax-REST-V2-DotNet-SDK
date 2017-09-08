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
    /// An input model for executing a report detailed to the document line level
    /// </summary>
    public class ExportDocumentLineModel
    {
        /// <summary>
        /// The output format: CSV, XML, etc.
        /// </summary>
        public ReportFormat? format { get; set; }

        /// <summary>
        /// The start date filter for report execution
        /// </summary>
        public DateTime startDate { get; set; }

        /// <summary>
        /// The end date filter for report execution
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// The transactions in the country you wish to run a report:
        /// use "ALL" for all countries
        /// use "ALL Non-US" for all international countries
        /// or use a single 2-char ISO country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The transactions in which state you wish to run a report:
        /// use "ALL" for all states
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The way your date filter operates on: "RD" for Reporting Date, "DD" for Document Date, "TD" for Tax Date, "PD" for Payment Date
        /// </summary>
        public String dateFilter { get; set; }

        /// <summary>
        /// The transaction type you want to run a report: "S" for Sales, "C" for Consumer Use
        /// </summary>
        public String docType { get; set; }

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
