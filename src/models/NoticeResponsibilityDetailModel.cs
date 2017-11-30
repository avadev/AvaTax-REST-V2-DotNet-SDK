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
    /// NoticeResponsibility Model
    /// </summary>
    public class NoticeResponsibilityDetailModel
    {
        /// <summary>
        /// The unique ID number of this filing frequency.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// TaxNoticeId
        /// </summary>
        public Int32 noticeId { get; set; }

        /// <summary>
        /// TaxNoticeResponsibilityId
        /// </summary>
        public Int32 taxNoticeResponsibilityId { get; set; }

        /// <summary>
        /// The description name of this filing frequency
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
