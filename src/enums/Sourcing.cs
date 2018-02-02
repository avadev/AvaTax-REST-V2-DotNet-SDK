using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
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
    /// Sourcing
    /// </summary>
    public enum Sourcing
    {
        /// <summary>
        /// Mixed sourcing, for states that do both origin and destination calculation
        /// </summary>
        Mixed,

        /// <summary>
        /// Destination
        /// </summary>
        Destination,

        /// <summary>
        /// Origin
        /// </summary>
        Origin,

    }
}
