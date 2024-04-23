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
    /// Represents RateTypeTaxTypeMappingModel Model
    /// </summary>
    public class RateTypeTaxTypeMappingModel
    {
        /// <summary>
        /// TaxTypeMappingId
        /// </summary>
        public Int32? rateTypeTaxTypeMappingId { get; set; }

        /// <summary>
        /// TaxTypeMappingId
        /// </summary>
        public Int32? taxTypeMappingId { get; set; }

        /// <summary>
        /// RateTypeIdSK
        /// </summary>
        public Int32? rateTypeIdSK { get; set; }

        /// <summary>
        /// RateTypeId
        /// </summary>
        public String rateTypeId { get; set; }


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
