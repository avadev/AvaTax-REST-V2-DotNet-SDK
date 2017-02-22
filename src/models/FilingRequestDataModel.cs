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
    /// Represents a commitment to file a tax return on a recurring basis.
        ///Only used if you subscribe to Avalara Returns.
    /// </summary>
    public class FilingRequestDataModel
    {
        /// <summary>
        /// The company return ID if requesting an update.
        /// </summary>
        public Int64? companyReturnId { get; set; }

        /// <summary>
        /// The return name of the requested calendar
        /// </summary>
        public String returnName { get; set; }

        /// <summary>
        /// The filing frequency of the request
        /// </summary>
        public FilingFrequencyId filingFrequencyId { get; set; }

        /// <summary>
        /// State registration ID of the company requesting the filing calendar.
        /// </summary>
        public String registrationId { get; set; }

        /// <summary>
        /// The months of the request
        /// </summary>
        public Int16 months { get; set; }

        /// <summary>
        /// The type of tax to report on this return.
        /// </summary>
        public MatchingTaxType? taxTypeId { get; set; }

        /// <summary>
        /// Location code of the request
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// Filing cycle effective date of the request
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// Filing cycle end date of the request
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// Flag if the request is a clone of a current filing calendar
        /// </summary>
        public Boolean? isClone { get; set; }

        /// <summary>
        /// The region this request is for
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The tax authority id of the return
        /// </summary>
        public Int32? taxAuthorityId { get; set; }

        /// <summary>
        /// The tax authority name on the return
        /// </summary>
        public String taxAuthorityName { get; set; }

        /// <summary>
        /// Filing question answers
        /// </summary>
        public List<FilingAnswerModel> answers { get; set; }


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
