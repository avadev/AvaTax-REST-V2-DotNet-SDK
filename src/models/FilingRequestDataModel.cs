using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a commitment to file a tax return on a recurring basis.
        /// Only used if you subscribe to Avalara Returns.
    /// </summary>
    public class FilingRequestDataModel
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64? companyReturnId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String returnName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public FilingFrequencyId filingFrequencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String registrationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int16 months { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime effDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime endDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FilingAnswer> answers { get; set; }


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
