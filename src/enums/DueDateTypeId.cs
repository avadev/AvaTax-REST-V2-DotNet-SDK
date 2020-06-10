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
    /// A list of possible Due Date Types
    /// </summary>
    public enum DueDateTypeId
    {
        /// <summary>
        /// Denotes form is due on the due day
        /// </summary>
        ByDay = 0,

        /// <summary>
        /// Denotes form is due by last day of the month
        /// </summary>
        ByLastDay = 1,

        /// <summary>
        /// Denotes form is due by second to last day of the month
        /// </summary>
        BySecondLastDay = 2,

    }
}
