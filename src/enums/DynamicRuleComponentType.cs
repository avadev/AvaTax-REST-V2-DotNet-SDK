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
    /// Represents the type of component in a dynamic rule.
    /// </summary>
    public enum DynamicRuleComponentType
    {
        /// <summary>
        /// Unknown component type.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// A condition component that evaluates an expression and returns boolean results.
        /// </summary>
        Condition = 1,

        /// <summary>
        /// An action component that executes a specific operation when a rule is triggered.
        /// </summary>
        Action = 2,

        /// <summary>
        /// A variable component that defines a named value that can be referenced within rules.
        /// </summary>
        Variable = 3,

    }
}
