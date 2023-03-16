using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
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
        Login = 1,

        /// <summary>
        /// Indicates that it is a Customer DOR Data type
        /// </summary>
        CustomerDorData = 2,

    }
}
