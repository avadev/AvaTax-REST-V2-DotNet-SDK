using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// This is the output model coming from skyscraper services
    /// </summary>
    public class LoginVerificationOutputModel
    {
        /// <summary>
        /// The job Id returned from skyscraper
        /// </summary>
        public Int32 jobId { get; set; }

        /// <summary>
        /// The operation status of the job
        /// </summary>
        public String operationStatus { get; set; }

        /// <summary>
        /// The message returned from the job
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// Indicates if the login was successful
        /// </summary>
        public Boolean? loginSuccess { get; set; }


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
