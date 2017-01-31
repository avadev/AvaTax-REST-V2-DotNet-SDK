using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Tax Authority Info
    /// </summary>
    public class TaxAuthorityInfo
    {
        /// <summary>
        /// Avalara Id
        /// </summary>
        public String avalaraId { get; set; }

        /// <summary>
        /// Jurisdiction Name
        /// </summary>
        public String jurisdictionName { get; set; }

        /// <summary>
        /// Jurisdiction Type
        /// </summary>
        public JurisdictionType? jurisdictionType { get; set; }

        /// <summary>
        /// Signature Code
        /// </summary>
        public String signatureCode { get; set; }


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
