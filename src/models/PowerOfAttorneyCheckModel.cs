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
    /// Response when checking if a company has a POA on file with Avalara
    /// </summary>
    public class PowerOfAttorneyCheckModel
    {
        /// <summary>
        /// companyId of the request
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// Country POA is for
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Region POA is for
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Notes if there is an actice POA
        /// </summary>
        public Boolean? activePoa { get; set; }

        /// <summary>
        /// Effective Date of the POA
        /// </summary>
        public DateTime? effectiveDate { get; set; }

        /// <summary>
        /// End Date of POA
        /// </summary>
        public DateTime? expirationDate { get; set; }

        /// <summary>
        /// POA download
        /// </summary>
        public ResourceFileDownloadResult availablePoa { get; set; }


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
