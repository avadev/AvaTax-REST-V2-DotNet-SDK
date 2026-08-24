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
    /// An Avalara system default currency-rounding-rule. These describe the rounding behavior
    /// AvaTax applies to a currency when an account has no rule of its own, and are the set of
    /// currencies for which an account may create its own Avalara.AvaTax.AccountServices.Models.v2.AccountCurrencyRoundingRuleModel.
    ///  
    /// This is reference data, not account-specific - it never exposes the internal system
    /// account that these defaults are stored against.
    /// </summary>
    public class CurrencyRoundingRuleDefaultModel
    {
        /// <summary>
        /// The three-character ISO 4217 currency code this default applies to, for example `INR`, `TWD`, or `JPY`.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// The number of decimal places tax is rounded to by default: `0` for the whole currency
        /// unit, or `2` for standard decimal cents.
        /// </summary>
        public Int32? precision { get; set; }

        /// <summary>
        /// The first tax date, inclusive, for which this default applies.
        /// </summary>
        public DateTime? effDate { get; set; }

        /// <summary>
        /// The last tax date, inclusive, for which this default applies.
        /// </summary>
        public DateTime? endDate { get; set; }


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
