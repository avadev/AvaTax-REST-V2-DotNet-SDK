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
    /// 
    /// </summary>
    public class WorksheetDocument
    {
        /// <summary>
        /// 
        /// </summary>
        public String docCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? docDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? totalExempt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? totalTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<WorksheetDocumentLine> lines { get; set; }

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
