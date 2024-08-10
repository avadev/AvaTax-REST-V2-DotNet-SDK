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
    /// Credit Transaction Detail Lines
    /// </summary>
    public class CreditTransactionDetailLines
    {
        /// <summary>
        /// ReportingDate
        /// </summary>
        public DateTime? reportingDate { get; set; }

        /// <summary>
        /// LineNo
        /// </summary>
        public String lineNo { get; set; }

        /// <summary>
        /// LineAmount
        /// </summary>
        public Decimal? lineAmount { get; set; }

        /// <summary>
        /// ExemptAmount
        /// </summary>
        public Decimal? exemptAmount { get; set; }

        /// <summary>
        /// TaxableAmount
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// TaxAmount
        /// </summary>
        public Decimal? taxAmount { get; set; }


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
