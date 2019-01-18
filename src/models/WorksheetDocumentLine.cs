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
    /// 
    /// </summary>
    public class WorksheetDocumentLine
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? reportingDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String lineNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? lineAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? exemptAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Message> messages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String resultCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String transactionId { get; set; }


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
