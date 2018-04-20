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
    /// Contains information about a company's exemption certificate status.
    /// 
    /// This model can be used to determine if your company is able to use the Customers, Certificates, and
    /// CertExpressInvites APIs within AvaTax.
    /// </summary>
    public class ProvisionStatusModel
    {
        /// <summary>
        /// The status of exemption certificate setup for this company.
        /// 
        /// If this value is `Finished`, this company will then be able to use the Customers, Certificates, and
        /// CertExpressInvites APIs within AvaTax.
        /// </summary>
        public CertCaptureProvisionStatus? status { get; set; }

        /// <summary>
        /// The accountId of the company represented by this status
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The AvaTax company represented by this status
        /// </summary>
        public Int32? companyId { get; set; }


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
