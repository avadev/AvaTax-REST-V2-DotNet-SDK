using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a commitment to file a tax return on a recurring basis.
        /// Only used if you subscribe to Avalara Returns.
    /// </summary>
    public class FilingRequestModel
    {
        /// <summary>
        /// The unique ID number of this filing request.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the company to which this filing request belongs.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingRequestStatus? filingRequestStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingRequestDataModel data { get; set; }

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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
