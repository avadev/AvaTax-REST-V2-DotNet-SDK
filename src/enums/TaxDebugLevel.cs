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
 * @author Greg Hester
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Indicates the level of detail requested from a tax API call
    /// </summary>
    public enum TaxDebugLevel
    {
        /// <summary>
        /// User requests the normal level of debug information when creating a tax transaction
        /// </summary>
        Normal,

        /// <summary>
        /// User requests additional diagnostic information when creating a tax transaction
        /// </summary>
        Diagnostic,

    }
}
