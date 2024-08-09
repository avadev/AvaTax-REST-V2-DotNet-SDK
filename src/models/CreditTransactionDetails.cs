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
    /// Credit Transaction Details
    /// </summary>
    public class CreditTransactionDetails
    {
        /// <summary>
        /// DocCode
        /// </summary>
        public String docCode { get; set; }

        /// <summary>
        /// DocDate
        /// </summary>
        public DateTime? docDate { get; set; }

        /// <summary>
        /// TotalExempt
        /// </summary>
        public Decimal? totalExempt { get; set; }

        /// <summary>
        /// TotalTaxable
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// TotalTax
        /// </summary>
        public Decimal? totalTax { get; set; }

        /// <summary>
        /// Lines
        /// </summary>
        public List<CreditTransactionDetailLines> lines { get; set; }


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
