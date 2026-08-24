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
    /// A currency-rounding-rule model controls how AvaTax rounds calculated tax for a given
    /// account and currency.
    ///  
    /// Each rule is effective-dated: it applies to transactions whose tax date falls within the
    /// `effDate`/`endDate` window. When no account-specific rule applies for a currency on a
    /// transaction's tax date, the tax engine uses standard decimal precision (no rounding).
    ///  
    /// An account may hold several rules for the same currency, and their windows may overlap: for a
    /// given tax date the rule with the latest `effDate` whose window contains that date applies, so
    /// adding a later-dated rule supersedes an earlier one. Two rules sharing a `currencyCode` and
    /// `effDate` are ambiguous and are rejected.
    ///  
    /// A rule can only be created for a currency that already has an Avalara system default (see
    /// the `ListCurrencyRoundingRuleDefaults` definitions API). The rounding method is fixed
    /// (rounds halves away from zero) and is an internal implementation detail, not exposed here;
    /// `precision` - `0` for the whole currency unit, or `2` for standard decimal cents - is the
    /// only control over the rounding behavior.
    /// </summary>
    public class AccountCurrencyRoundingRuleModel
    {
        /// <summary>
        /// A unique ID number representing this currency rounding rule.
        /// </summary>
        public Int32? id { get; set; }

        /// <summary>
        /// The ID number of the account that owns this currency rounding rule.
        /// </summary>
        public Int32? accountId { get; set; }

        /// <summary>
        /// The three-character ISO 4217 currency code this rule applies to, for example `INR`, `TWD`, or `JPY`.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// The number of decimal places the tax is rounded to: `0` for the whole currency unit, or
        /// `2` for standard decimal cents. This is the only control over the rounding method.
        /// </summary>
        public Int32 precision { get; set; }

        /// <summary>
        /// The first tax date, inclusive, for which this rule applies.
        /// </summary>
        public DateTime effDate { get; set; }

        /// <summary>
        /// The last tax date, inclusive, for which this rule applies. If omitted, the rule applies
        /// through `9998-12-31`; a later date is also stored as `9998-12-31`.
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The date when this record was created.
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// The user ID of the user who created this record.
        /// </summary>
        public Int32? createdUserId { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }


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
