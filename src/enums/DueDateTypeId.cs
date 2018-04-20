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
    /// A list of possible Due Date Types
    /// </summary>
    public enum DueDateTypeId
    {
        /// <summary>
        /// Denotes form is due on the due day
        /// </summary>
        ByDay,

        /// <summary>
        /// Denotes form is due by last day of the month
        /// </summary>
        ByLastDay,

        /// <summary>
        /// Denotes form is due by second to last day of the month
        /// </summary>
        BySecondLastDay,

    }
}
