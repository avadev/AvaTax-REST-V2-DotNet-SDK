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
    /// 
    /// </summary>
    public enum ItemCatalogueResultEvent
    {
        /// <summary>
        /// 
        /// </summary>
        ItemCreated = 0,

        /// <summary>
        /// 
        /// </summary>
        ItemUpdated = 1,

        /// <summary>
        /// 
        /// </summary>
        ItemDeleted = 2,

        /// <summary>
        /// 
        /// </summary>
        Error = 3,

    }
}
