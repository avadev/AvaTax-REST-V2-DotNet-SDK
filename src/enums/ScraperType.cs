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
    /// Type of verification task
    /// </summary>
    public enum ScraperType
    {
        /// <summary>
        /// Indicates that is is a login type
        /// </summary>
        Login,

        /// <summary>
        /// Indicates that it is a Customer DOR Data type
        /// </summary>
        CustomerDorData,

    }
}
