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
    /// Types of jurisdiction referenced in a transaction
    /// </summary>
    public enum JurisTypeId
    {
        /// <summary>
        /// State
        /// </summary>
        STA,

        /// <summary>
        /// County
        /// </summary>
        CTY,

        /// <summary>
        /// City
        /// </summary>
        CIT,

        /// <summary>
        /// Special
        /// </summary>
        STJ,

        /// <summary>
        /// Country
        /// </summary>
        CNT,

    }
}
