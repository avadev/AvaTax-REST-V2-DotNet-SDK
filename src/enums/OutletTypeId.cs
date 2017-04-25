using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// A list of possible OutletTypeIds.
    /// </summary>
    public enum OutletTypeId
    {
        /// <summary>
        /// File a single return
        /// </summary>
        None,

        /// <summary>
        /// File a single return with consolidated information about outlets
        /// </summary>
        Schedule,

        /// <summary>
        /// File a separate form for each outlet
        /// </summary>
        Duplicate,

    }
}
