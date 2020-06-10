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
    /// A model for displaying report task metadata
    /// </summary>
    public class ReportModel
    {
        /// <summary>
        /// The unique identifier of the report task
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The ID of the account the reported transactions are from
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The ID of the company the reported transactions are from
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The type of the report: ExportDocumentLine, etc.
        /// </summary>
        public String reportType { get; set; }

        /// <summary>
        /// The parametes used to build the report
        /// </summary>
        public ReportParametersModel parameters { get; set; }

        /// <summary>
        /// The current status of the report building task
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// The size of the report file, if available
        /// </summary>
        public Int64? size { get; set; }

        /// <summary>
        /// The format of the report file
        /// </summary>
        public String format { get; set; }

        /// <summary>
        /// The name of the report file, if available
        /// </summary>
        public String file { get; set; }

        /// <summary>
        /// The time when the report task was initiated
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The Id of the user who initiated this task
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The userName of the user who initiated the report task
        /// </summary>
        public String createdUser { get; set; }

        /// <summary>
        /// The time when the report was finished building, if completed
        /// </summary>
        public DateTime? completedDate { get; set; }


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
