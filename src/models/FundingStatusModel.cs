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
    /// Status of an Avalara Managed Returns funding configuration for a company
    /// </summary>
    public class FundingStatusModel
    {
        /// <summary>
        /// The unique ID number of this funding request
        /// </summary>
        public Int64? requestId { get; set; }

        /// <summary>
        /// SubledgerProfileID
        /// </summary>
        public Int32? subledgerProfileID { get; set; }

        /// <summary>
        /// CompanyID
        /// </summary>
        public String companyID { get; set; }

        /// <summary>
        /// Domain
        /// </summary>
        public String domain { get; set; }

        /// <summary>
        /// Recipient
        /// </summary>
        public String recipient { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public String sender { get; set; }

        /// <summary>
        /// DocumentKey
        /// </summary>
        public String documentKey { get; set; }

        /// <summary>
        /// DocumentType
        /// </summary>
        public String documentType { get; set; }

        /// <summary>
        /// DocumentName
        /// </summary>
        public String documentName { get; set; }

        /// <summary>
        /// MethodReturn
        /// </summary>
        public FundingESignMethodReturn methodReturn { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public String errorMessage { get; set; }

        /// <summary>
        /// LastPolled
        /// </summary>
        public DateTime? lastPolled { get; set; }

        /// <summary>
        /// LastSigned
        /// </summary>
        public DateTime? lastSigned { get; set; }

        /// <summary>
        /// LastActivated
        /// </summary>
        public DateTime? lastActivated { get; set; }

        /// <summary>
        /// TemplateRequestId
        /// </summary>
        public Int64? templateRequestId { get; set; }


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
