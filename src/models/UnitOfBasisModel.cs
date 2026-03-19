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
    public class UnitOfBasisModel
    {
        /// <summary>
        /// UnitOfBasisId
        /// </summary>
        public Int32? unitOfBasisId { get; set; }

        /// <summary>
        /// UnitOfBasis Name
        /// </summary>
        public String unitOfBasis { get; set; }

        /// <summary>
        /// UnitOfBasis measurement type ID
        /// </summary>
        public Int32? measurementTypeId { get; set; }

        /// <summary>
        /// UnitOfBasis measurement type code
        /// </summary>
        public String measurementTypeCode { get; set; }

        /// <summary>
        /// UnitOfBasis attributes used
        /// </summary>
        public List<String> attributesUsed { get; set; }

        /// <summary>
        /// A boolean value based on the current definition of a Fee in AvaTax
        /// </summary>
        public Boolean? isFee { get; set; }


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
