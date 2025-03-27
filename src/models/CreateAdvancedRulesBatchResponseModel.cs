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
    /// Represents a create advanced rules batch response model.
    /// </summary>
    public class CreateAdvancedRulesBatchResponseModel
    {
        /// <summary>
        /// The unique ID number of this batch.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// Any optional flags provided for this batch
        /// </summary>
        public String options { get; set; }

        /// <summary>
        /// The user-friendly readable name for this batch.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The Account ID number of the account that owns this batch.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The Company ID number of the company that owns this batch.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// This batch's current processing status
        /// </summary>
        public BatchStatus? status { get; set; }

        /// <summary>
        /// The date/time when this batch started processing
        /// </summary>
        public DateTime? startedDate { get; set; }

        /// <summary>
        /// The number of records in this batch; determined by the server
        /// </summary>
        public Int32? recordCount { get; set; }

        /// <summary>
        /// The current record being processed
        /// </summary>
        public Int32? currentRecord { get; set; }

        /// <summary>
        /// The date/time when this batch was completely processed
        /// </summary>
        public DateTime? completedDate { get; set; }

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
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// The list of files contained in this batch.
        /// </summary>
        public List<BatchFileModel> files { get; set; }


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
