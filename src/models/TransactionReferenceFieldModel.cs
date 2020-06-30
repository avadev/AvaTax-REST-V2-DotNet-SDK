using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Represents a fixup change
    /// </summary>
    public class TransactionReferenceFieldModel
    {
        /// <summary>
        /// The id of the transaction
        /// </summary>
        public Int64 documentId { get; set; }

        /// <summary>
        /// Sets the sale location code (Outlet ID) for reporting this document to the tax authority.
        ///  
        /// This value is used by Avalara Managed Returns to group documents together by reporting locations
        /// for tax authorities that require location-based reporting.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// Reference field of the line details
        /// </summary>
        public List<LineDetailSERCodeModel> lineDetailSerCodes { get; set; }


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
