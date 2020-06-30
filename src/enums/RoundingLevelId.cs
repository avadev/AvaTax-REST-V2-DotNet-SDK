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
    /// Choice of rounding level for a transaction
    /// </summary>
    public enum RoundingLevelId
    {
        /// <summary>
        /// Round tax on each line separately
        /// </summary>
        Line = 0,

        /// <summary>
        /// Round tax at the document level
        /// </summary>
        Document = 1,

    }
}
