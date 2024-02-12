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
    /// Represents estimated financial results from responding to a tax notice.
    /// </summary>
    public class NoticeFinanceModel
    {
        /// <summary>
        /// The Unique Id of the Finance Model
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID of the the tax notice associated with the the finance detail
        /// </summary>
        public Int32? noticeId { get; set; }

        /// <summary>
        /// The date of the notice
        /// </summary>
        public DateTime? noticeDate { get; set; }

        /// <summary>
        /// The due date of the notice
        /// </summary>
        public DateTime? dueDate { get; set; }

        /// <summary>
        /// The sequential number of the notice
        /// </summary>
        public String noticeNumber { get; set; }

        /// <summary>
        /// The amount of tax due on the notice
        /// </summary>
        public Decimal? taxDue { get; set; }

        /// <summary>
        /// The amound of penalty listed on the notice
        /// </summary>
        public Decimal? penalty { get; set; }

        /// <summary>
        /// The amount of interest listed on the notice
        /// </summary>
        public Decimal? interest { get; set; }

        /// <summary>
        /// The amount of credits listed on the notice
        /// </summary>
        public Decimal? credits { get; set; }

        /// <summary>
        /// The amount of tax abated on the notice
        /// </summary>
        public Decimal? taxAbated { get; set; }

        /// <summary>
        /// The amount of customer penalty on the notice
        /// </summary>
        public Decimal? customerPenalty { get; set; }

        /// <summary>
        /// The amount of customer interest on the notice
        /// </summary>
        public Decimal? customerInterest { get; set; }

        /// <summary>
        /// The amount of CSP Fee Refund on the notice
        /// </summary>
        public Decimal? cspFeeRefund { get; set; }

        /// <summary>
        /// The name of the file attached to the finance detail
        /// </summary>
        public String fileName { get; set; }

        /// <summary>
        /// The payment method on the notice
        /// </summary>
        public String paymentMethod { get; set; }

        /// <summary>
        /// The ResourceFileId of the finance detail attachment
        /// </summary>
        public Int64? resourceFileId { get; set; }

        /// <summary>
        /// documentId
        /// </summary>
        public Int64? documentId { get; set; }

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
        /// 
        /// </summary>
        public ResourceFileUploadRequestModel attachmentUploadRequest { get; set; }


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
