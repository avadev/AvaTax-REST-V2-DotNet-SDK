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
    /// Jurisdiction boundary precision level found for address. This depends on the accuracy of the address
    ///  as well as the precision level of the state provided jurisdiction boundaries.
    /// </summary>
    public enum BoundaryLevel
    {
        /// <summary>
        /// Street address precision
        /// </summary>
        Address,

        /// <summary>
        /// 9-digit zip precision
        /// </summary>
        Zip9,

        /// <summary>
        /// 5-digit zip precision
        /// </summary>
        Zip5,

    }
}
