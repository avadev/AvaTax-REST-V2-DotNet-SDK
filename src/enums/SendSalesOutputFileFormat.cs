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
    ///	File format for sales output
    /// </summary>
    public enum SendSalesOutputFileFormat
    {
        /// <summary>
        /// Standard CSV file
        /// </summary>
        STANDARD = 1,

        /// <summary>
        /// DMA file
        /// </summary>
        DMA = 2,

    }
}
