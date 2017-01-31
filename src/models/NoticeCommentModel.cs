using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents communication between Avalara and the company regarding the processing of a tax notice.
    /// </summary>
    public class NoticeCommentModel
    {
        /// <summary>
        /// The unique ID number of this notice.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int32 noticeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// TaxNoticeComment
        /// </summary>
        public String comment { get; set; }

        /// <summary>
        /// TaxNoticeCommentUserId
        /// </summary>
        public Int32? commentUserId { get; set; }

        /// <summary>
        /// TaxNoticeCommentUserName
        /// </summary>
        public String commentUserName { get; set; }

        /// <summary>
        /// taxNoticeCommentTypeId
        /// </summary>
        public Int32? commentTypeId { get; set; }

        /// <summary>
        /// taxNoticeCommentType
        /// </summary>
        public String commentType { get; set; }

        /// <summary>
        /// TaxNoticeCommentLink
        /// </summary>
        public String commentLink { get; set; }

        /// <summary>
        /// TaxNoticeFileName
        /// </summary>
        public String taxNoticeFileName { get; set; }

        /// <summary>
        /// resourceFileId
        /// </summary>
        public Int32? resourceFileId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
