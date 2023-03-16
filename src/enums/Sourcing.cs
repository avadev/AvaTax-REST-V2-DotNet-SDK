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
    /// Sourcing
    /// </summary>
    public enum Sourcing
    {
        /// <summary>
        /// Mixed sourcing, for states that do both origin and destination calculation
        /// </summary>
        Mixed = 42,

        /// <summary>
        /// Destination
        /// </summary>
        Destination = 68,

        /// <summary>
        /// Origin
        /// </summary>
        Origin = 79,

    }
}
