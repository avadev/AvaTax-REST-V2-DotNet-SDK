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
    /// Jurisdiction Type
    /// </summary>
    public enum JurisdictionType
    {
        /// <summary>
        /// Country
        /// </summary>
        Country,

        /// <summary>
        /// Deprecated
        /// </summary>
        Composite,

        /// <summary>
        /// State
        /// </summary>
        State,

        /// <summary>
        /// County
        /// </summary>
        County,

        /// <summary>
        /// City
        /// </summary>
        City,

        /// <summary>
        /// Special Tax Jurisdiction
        /// </summary>
        Special,

    }
}
