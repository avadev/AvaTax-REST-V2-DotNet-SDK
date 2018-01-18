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
    /// Choice of rounding level for a transaction
    /// </summary>
    public enum RoundingLevelId
    {
        /// <summary>
        /// Round tax on each line separately
        /// </summary>
        Line,

        /// <summary>
        /// Round tax at the document level
        /// </summary>
        Document,

    }
}
