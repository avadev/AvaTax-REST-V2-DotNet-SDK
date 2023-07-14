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
    /// Represents the coefficient, using which tax rules rates can be modified dynamically while applying tax rules
    /// in order to reduce the variance for all the transactions at country level.
    ///  
    /// Avalara supports a few different types of tax rules. For information about tax rule types, see
    /// [TaxRuleTypeId](https://developer.avalara.com/cofficients)
    /// </summary>
    public class CountryCoefficientsResponseModel
    {
        /// <summary>
        /// Total Number of Country Coefficients records inserted/updated.
        /// </summary>
        public Int32? count { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public String message { get; set; }


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
