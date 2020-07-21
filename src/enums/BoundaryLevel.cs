using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2019 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Genevieve Conty
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum BoundaryLevel
    {
        /// <summary>
        /// 
        /// </summary>
        Address = 0,

        /// <summary>
        /// 
        /// </summary>
        Zip9 = 1,

        /// <summary>
        /// 
        /// </summary>
        Zip5 = 2,

    }
}
