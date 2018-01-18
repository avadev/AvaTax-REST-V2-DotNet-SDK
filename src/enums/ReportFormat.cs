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
    /// Different types of formats allowed for exporting a report
    /// </summary>
    public enum ReportFormat
    {
        /// <summary>
        /// The Comma Separated Values file format
        /// </summary>
        CSV,

        /// <summary>
        /// The Extensible Markup Language file format
        /// </summary>
        XML,

    }
}
