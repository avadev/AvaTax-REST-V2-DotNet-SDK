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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents estimated financial results from responding to a tax notice.
    /// </summary>
    public class NoticeFinanceModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32? noticeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? noticeDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? dueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String noticeNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxDue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? penalty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? interest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? credits { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxAbated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? customerPenalty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? customerInterest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? cspFeeRefund { get; set; }

        /// <summary>
        /// resourceFileId
        /// </summary>
        public String fileName { get; set; }

        /// <summary>
        /// resourceFileId
        /// </summary>
        public Int64? resourceFileId { get; set; }

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
        /// An attachment to the finance detail
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
