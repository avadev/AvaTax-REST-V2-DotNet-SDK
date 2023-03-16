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
    /// 
    /// </summary>
    public class VarianceLine
    {
        /// <summary>
        /// 
        /// </summary>
        public String lineNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String hsCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? dutyRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Decimal? taxRate { get; set; }

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
