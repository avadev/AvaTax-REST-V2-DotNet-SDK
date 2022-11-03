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
    /// 
    /// </summary>
    public class VarianceResponseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Int64? documentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String documentCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64? customInvoiceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Int64? varianceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String errorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxableVariance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? dutyVariance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxVariance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? totalTaxVariance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<VarianceDetail> unMappedDetails { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<VarianceResponseLine> varianceLines { get; set; }


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
