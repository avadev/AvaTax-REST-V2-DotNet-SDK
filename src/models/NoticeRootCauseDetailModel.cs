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
 * Swagger name: AvaTaxClient
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// NoticeRootCause Model
    /// </summary>
    public class NoticeRootCauseDetailModel
    {
        /// <summary>
        /// The unique ID number of this filing frequency.
        /// </summary>
        public Int32 id { get; set; }

        /// <summary>
        /// TaxNoticeId
        /// </summary>
        public Int32 noticeId { get; set; }

        /// <summary>
        /// TaxNoticeRootCauseId
        /// </summary>
        public Int32 taxNoticeRootCauseId { get; set; }

        /// <summary>
        /// The description name of this root cause
        /// </summary>
        public String description { get; set; }


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
