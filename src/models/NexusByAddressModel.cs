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
    /// Contains information about nexus jurisdictions that were declared
    /// as a result of a call to `DeclareNexusByAddress`. For each address,
    /// this object model contains a list of the nexus objects that were declared
    /// according to the geocoding that corresponds to this address.
    /// </summary>
    public class NexusByAddressModel
    {
        /// <summary>
        /// The address that was provided by the user in the call to `DeclareNexusByAddress`
        /// </summary>
        public DeclareNexusByAddressModel address { get; set; }

        /// <summary>
        /// List of all nexus objects that were affected by declaring nexus at the address specified
        /// by `address`.
        /// </summary>
        public List<NexusModel> declaredNexus { get; set; }


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
