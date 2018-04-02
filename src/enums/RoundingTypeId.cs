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
    /// Indicates the rounding behavior of a form
    /// </summary>
    public enum RoundingTypeId
    {
        /// <summary>
        /// There is no rounding on the return
        /// </summary>
        None,

        /// <summary>
        /// Round to the nearest whole number
        /// </summary>
        Nearest,

        /// <summary>
        /// Always round up
        /// </summary>
        Up,

        /// <summary>
        /// Always round down
        /// </summary>
        Down,

    }
}
