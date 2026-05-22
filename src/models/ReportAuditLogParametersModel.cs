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
    /// The output model for audit log report parameter definitions.
    /// </summary>
    public class ReportAuditLogParametersModel
    {
        /// <summary>
        /// The list of operations for this audit log report.
        /// </summary>
        public List<ReportAuditLogOperationModel> operations { get; set; }

        /// <summary>
        /// The start date for the audit log report.
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// The end date for the audit log report.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The compression type for the report output (e.g., "NONE", "GZIP").
        /// </summary>
        public Compression? compression { get; set; }


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
