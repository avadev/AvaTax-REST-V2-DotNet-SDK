using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
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
    /// Represents an ISO 4217 currency code used for designating the currency of a transaction.
    /// </summary>
    public class CurrencyModel
    {
        /// <summary>
        /// The ISO 4217 currency code for this currency.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// A friendly human-readable name representing this currency.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The number of decimal digits to use when formatting a currency value for display.
        /// </summary>
        public Byte? decimalDigits { get; set; }


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
