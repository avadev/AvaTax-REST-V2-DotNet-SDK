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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public class FundingInitiateModel
    {
        /// <summary>
        /// Set this value to true to request an email to the recipient
        /// </summary>
        public Boolean? requestEmail { get; set; }

        /// <summary>
        /// If you have requested an email for funding setup, this is the recipient who will receive an 
        /// email inviting them to setup funding configuration for Avalara Managed Returns. The recipient can
        /// then click on a link in the email and setup funding configuration for this company.
        /// </summary>
        public String fundingEmailRecipient { get; set; }

        /// <summary>
        /// Set this value to true to request an HTML-based funding widget that can be embedded within an 
        /// existing user interface. A user can then interact with the HTML-based funding widget to set up
        /// funding information for the company.
        /// </summary>
        public Boolean? requestWidget { get; set; }


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
