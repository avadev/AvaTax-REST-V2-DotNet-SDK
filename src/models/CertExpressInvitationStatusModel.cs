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
    /// Represent what is the current status of certificate request
    /// </summary>
    public class CertExpressInvitationStatusModel
    {
        /// <summary>
        /// The status of the CertExpress invitation for this customer. If this status says
        /// </summary>
        public CertExpressInvitationStatus? status { get; set; }

        /// <summary>
        /// The CertExpress invitation for the customer. If you specified an email address in the invitation
        /// request, this invitation will be sent via email. Otherwise, you are expected to direct the customer
        /// using a hyperlink directly in your application.
        /// </summary>
        public CertExpressInvitationModel invitation { get; set; }


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
