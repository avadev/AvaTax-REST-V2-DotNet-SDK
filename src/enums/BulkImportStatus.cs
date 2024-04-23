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
    public enum BulkImportStatus
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        Success = 1,

        /// <summary>
        /// 
        /// </summary>
        Created = 2,

        /// <summary>
        /// 
        /// </summary>
        Updated = 4,

        /// <summary>
        /// 
        /// </summary>
        NotImported = 8,

        /// <summary>
        /// 
        /// </summary>
        Ignored = 16,

        /// <summary>
        /// 
        /// </summary>
        Error = 32,

        /// <summary>
        /// 
        /// </summary>
        ValidationFailed = 64,

        /// <summary>
        /// 
        /// </summary>
        PartialSuccess = 128,

        /// <summary>
        /// 
        /// </summary>
        Invalid = 256,

    }
}
