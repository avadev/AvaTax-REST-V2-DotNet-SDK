using System;

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
    /// The type of a custom rule
    /// </summary>
    public enum CustomRuleType
    {
        /// <summary>
        /// An unknown rule type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// A tax rule.
        /// </summary>
        TaxRule = 1,

        /// <summary>
        /// An advanced rule.
        /// </summary>
        AdvancedRule = 2,

        /// <summary>
        /// A dynamic rule.
        /// </summary>
        DynamicRule = 3,

    }
}
