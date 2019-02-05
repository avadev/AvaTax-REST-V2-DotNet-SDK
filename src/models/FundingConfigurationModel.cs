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
    /// Status of an Avalara Managed Returns funding configuration for a company
    /// </summary>
    public class FundingConfigurationModel
    {
        /// <summary>
        /// CompanyID
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Domain
        /// </summary>
        public String systemType { get; set; }

        /// <summary>
        /// Recipient
        /// </summary>
        public String currency { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public Boolean? isFundingSetup { get; set; }

        /// <summary>
        /// DocumentKey
        /// </summary>
        public String fundingMethod { get; set; }

        /// <summary>
        /// LastPolled
        /// </summary>
        public DateTime? lastUpdated { get; set; }


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
