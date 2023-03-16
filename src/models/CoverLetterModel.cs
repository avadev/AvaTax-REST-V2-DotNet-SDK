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
    /// The CoverLetter model represents a message sent along with an invitation to use CertExpress to
    /// upload certificates. An invitation allows customers to use CertExpress to upload their exemption
    /// certificates directly; this cover letter explains why the invitation was sent.
    /// </summary>
    public class CoverLetterModel
    {
        /// <summary>
        /// A unique ID number representing a cover letter sent with a CertExpress invitation.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The unique ID number of the AvaTax company that received this certificate.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The title used when sending the cover letter.
        /// </summary>
        public String title { get; set; }

        /// <summary>
        /// The subject message used when sending the cover letter via email.
        /// </summary>
        public String subject { get; set; }

        /// <summary>
        /// A full description of the cover letter's contents and message.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// Is this cover letter active
        /// </summary>
        public Boolean? active { get; set; }

        /// <summary>
        /// How many pages this cover letter encompasses
        /// </summary>
        public Int32? pageCount { get; set; }

        /// <summary>
        /// The file name of the cover letter template
        /// </summary>
        public String templateFilename { get; set; }

        /// <summary>
        /// The version number of the template
        /// </summary>
        public Int32? version { get; set; }


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
