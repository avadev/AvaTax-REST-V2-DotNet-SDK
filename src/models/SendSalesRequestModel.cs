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
    /// SendSales Request Model.
    /// </summary>
    public class SendSalesRequestModel
    {
        /// <summary>
        /// The companyId for which the send sales file is being generated.
        /// </summary>
        public Int32 companyId { get; set; }

        /// <summary>
        /// List of taxCodes to be included in send sales file.
        /// </summary>
        public List<String> taxCodes { get; set; }

        /// <summary>
        /// The date for which send sales file is being generated.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// The send sales file format.
        /// </summary>
        public SendSalesOutputFileFormat? format { get; set; }

        /// <summary>
        /// The send sales file type
        /// </summary>
        public SendSalesFileType? type { get; set; }


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
