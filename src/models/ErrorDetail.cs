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
    /// Message object
    /// </summary>
    public class ErrorDetail
    {
        /// <summary>
        /// Name of the error or message.
        /// </summary>
        public ErrorCodeId? code { get; set; }

        /// <summary>
        /// Unique ID number referring to this error or message.
        /// </summary>
        public Int32? number { get; set; }

        /// <summary>
        /// Concise summary of the message, suitable for display in the caption of an alert box.
        /// </summary>
        public String message { get; set; }

        /// <summary>
        /// A more detailed description of the problem referenced by this error message, suitable for display in the contents area of an alert box.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Indicates the SOAP Fault code, if this was related to an error that corresponded to AvaTax SOAP v1 behavior.
        /// </summary>
        public String faultCode { get; set; }

        /// <summary>
        /// URL to help for this message
        /// </summary>
        public String helpLink { get; set; }

        /// <summary>
        /// Item the message refers to, if applicable. This is used to indicate a missing or incorrect value.
        /// </summary>
        public String refersTo { get; set; }

        /// <summary>
        /// Severity of the message
        /// </summary>
        public SeverityLevel? severity { get; set; }


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
