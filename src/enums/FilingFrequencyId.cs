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
    /// Filing Frequency types
    /// </summary>
    public enum FilingFrequencyId
    {
        /// <summary>
        /// File once per month
        /// </summary>
        Monthly = 1,

        /// <summary>
        /// File once per three months
        /// </summary>
        Quarterly = 2,

        /// <summary>
        /// File twice per year
        /// </summary>
        SemiAnnually = 3,

        /// <summary>
        /// File once per year
        /// </summary>
        Annually = 4,

        /// <summary>
        /// File every other month
        /// </summary>
        Bimonthly = 5,

        /// <summary>
        /// File only when there are documents to report
        /// </summary>
        Occasional = 6,

        /// <summary>
        /// File for the first two months of each quarter, then do not file on the quarterly month.
        /// </summary>
        InverseQuarterly = 7,

        /// <summary>
        /// File every week
        /// </summary>
        Weekly = 8,

    }
}
