using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Information about a tax authority relevant for an address.
    /// </summary>
    public class TaxAuthorityInfo
    {
        /// <summary>
        /// A unique ID number assigned by Avalara to this tax authority.
        /// </summary>
        public String avalaraId { get; set; }

        /// <summary>
        /// The friendly jurisdiction name for this tax authority.
        /// </summary>
        public String jurisdictionName { get; set; }

        /// <summary>
        /// The type of jurisdiction referenced by this tax authority.
        /// </summary>
        public JurisdictionType? jurisdictionType { get; set; }

        /// <summary>
        /// An Avalara-assigned signature code for this tax authority.
        /// </summary>
        public String signatureCode { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }
    }
}
