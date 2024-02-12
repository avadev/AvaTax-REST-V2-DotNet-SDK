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
    /// Represents TaxTypeMapping Model
    /// </summary>
    public class TaxTypeMappingModel
    {
        /// <summary>
        /// TaxTypeMappingId
        /// </summary>
        public Int32? taxTypeMappingId { get; set; }

        /// <summary>
        /// TaxTypeGroupIdSK
        /// </summary>
        public Int32? taxTypeGroupIdSK { get; set; }

        /// <summary>
        /// TaxTypeIdSK
        /// </summary>
        public Int32? taxTypeIdSK { get; set; }

        /// <summary>
        /// TaxSubTypeIdSK
        /// </summary>
        public Int32? taxSubTypeIdSK { get; set; }

        /// <summary>
        /// GeneralOrStandardRateTypeIdSK
        /// </summary>
        public Int32? generalOrStandardRateTypeIdSK { get; set; }

        /// <summary>
        /// TaxTypeGroupId
        /// </summary>
        public String taxTypeGroupId { get; set; }

        /// <summary>
        /// TaxTypeId
        /// </summary>
        public String taxTypeId { get; set; }

        /// <summary>
        /// TaxSubTypeId
        /// </summary>
        public String taxSubTypeId { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// GeneralOrStandardRateTypeId
        /// </summary>
        public String generalOrStandardRateTypeId { get; set; }


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
