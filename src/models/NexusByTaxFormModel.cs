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
    /// Identifies all nexus that match a particular tax form
    /// </summary>
    public class NexusByTaxFormModel
    {
        /// <summary>
        /// The code of the tax form that was requested
        /// </summary>
        public String formCode { get; set; }

        /// <summary>
        /// The company ID of the company that was used to load the companyNexus array. If this value is null, no company data was loaded.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// A list of all Avalara-defined nexus that are relevant to this tax form
        /// </summary>
        public List<NexusModel> nexusDefinitions { get; set; }

        /// <summary>
        /// A list of all currently-defined company nexus that are related to this tax form
        /// </summary>
        public List<NexusModel> companyNexus { get; set; }


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
