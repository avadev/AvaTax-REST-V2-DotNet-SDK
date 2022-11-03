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
    /// Request model used as input for Variance API.
    /// </summary>
    public class VarianceRequestModel
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
        public String purchaseOrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String referenceNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? exchangeRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<VarianceLine> lines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VarianceUnit amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VarianceUnit taxableAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VarianceUnit dutyPaid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VarianceUnit taxPaid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VarianceUnit totalTaxPaid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<VarianceDetail> details { get; set; }


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
