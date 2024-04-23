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
    /// Request model for the returns specific nexus fetch API
    /// </summary>
    public class NexusForReturnsRequestModel
    {
        /// <summary>
        /// Description of the desired nexus tax type group (e.g. SalesAndUse, Lodging, etc.)
        /// </summary>
        public String nexusTaxTypeGroup { get; set; }

        /// <summary>
        /// The nexus type id desired (optional)
        /// </summary>
        public NexusTypeId? nexusTypeId { get; set; }

        /// <summary>
        /// The local nexus type id desired (optional)
        /// </summary>
        public LocalNexusTypeId? localNexusTypeId { get; set; }

        /// <summary>
        /// Flag indicating whether the response should include inactive nexus entries (optional)
        /// </summary>
        public Boolean? showHistorical { get; set; }

        /// <summary>
        /// Flag indicating whether to only include SST nexus entries in the response (optional)
        /// </summary>
        public Boolean? showSSTOnly { get; set; }


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
