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
    /// The status of a custom rule as returned by the custom rule summary endpoint.
    /// </summary>
    public enum CustomRuleStatus
    {
        /// <summary>
        /// The status of the rule is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The rule is enabled and effective on the current date.
        /// </summary>
        Active = 1,

        /// <summary>
        /// The rule is not enabled.
        /// </summary>
        Inactive = 2,

        /// <summary>
        /// The rule is marked enabled, but it is past the end date of the rule.
        /// </summary>
        Expired = 3,

        /// <summary>
        /// The rule is marked enabled, but it is before the first effective date of the rule.
        /// </summary>
        Future = 4,

    }
}
