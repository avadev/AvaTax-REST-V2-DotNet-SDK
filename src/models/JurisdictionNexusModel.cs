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
    /// Model to represent the detail of NexusTaxTpeGroup and TaxName for Jurisdiction
    /// </summary>
    public class JurisdictionNexusModel
    {
        /// <summary>
        /// TaxTypeGroupId for Nexus of Jurisdiction
        /// </summary>
        public String taxTypeGroupId { get; set; }

        /// <summary>
        /// NexusTaxTypeGroupId for Nexus of Jurisdiction
        /// </summary>
        public String nexusTaxTypeGroupId { get; set; }

        /// <summary>
        /// TaxName for Nexus of Jurisdiction
        /// </summary>
        public String taxName { get; set; }

        /// <summary>
        /// Shows if system nexus records are associated with tax collection
        /// </summary>
        public Boolean? taxableNexus { get; set; }


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
