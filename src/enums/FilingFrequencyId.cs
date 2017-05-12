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
    /// Filing Frequency types
    /// </summary>
    public enum FilingFrequencyId
    {
        /// <summary>
        /// File once per month
        /// </summary>
        Monthly,

        /// <summary>
        /// File once per three months
        /// </summary>
        Quarterly,

        /// <summary>
        /// File twice per year
        /// </summary>
        SemiAnnually,

        /// <summary>
        /// File once per year
        /// </summary>
        Annually,

        /// <summary>
        /// File every other month
        /// </summary>
        Bimonthly,

        /// <summary>
        /// File only when there are documents to report
        /// </summary>
        Occasional,

        /// <summary>
        /// File for the first two months of each quarter, then do not file on the quarterly month.
        /// </summary>
        InverseQuarterly,

    }
}
