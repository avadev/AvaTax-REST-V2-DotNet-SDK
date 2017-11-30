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
    /// Filing worksheet Type
    /// </summary>
    public enum WorksheetTypeId
    {
        /// <summary>
        /// The original filing for a period
        /// </summary>
        Original,

        /// <summary>
        /// Represents an amended filing for a period
        /// </summary>
        Amended,

        /// <summary>
        /// Represents a test filing
        /// </summary>
        Test,

    }
}
