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
 */

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
