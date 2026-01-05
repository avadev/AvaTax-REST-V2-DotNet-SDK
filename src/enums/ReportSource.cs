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
    /// Defines report source.
    /// </summary>
    public enum ReportSource
    {
        /// <summary>
        /// snowflake
        /// </summary>
        SNOWFLAKE = 0,

        /// <summary>
        /// mongodb
        /// </summary>
        MONGODB = 1,

        /// <summary>
        /// returns api
        /// </summary>
        RETURNSAPI = 2,

        /// <summary>
        /// tax region and tax type
        /// </summary>
        TAXREGION = 3,

        /// <summary>
        /// accounts payable document
        /// </summary>
        APDOCUMENT = 4,

        /// <summary>
        /// accounts payable document line detail
        /// </summary>
        APDOCUMENTLINEDETAIL = 5,

    }
}
