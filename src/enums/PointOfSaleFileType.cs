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
    /// Type of file request
    /// </summary>
    public enum PointOfSaleFileType
    {
        /// <summary>
        /// File is in Javascript Object Notation format
        /// </summary>
        Json = 0,

        /// <summary>
        /// File is in Comma Separated Values format
        /// </summary>
        Csv = 1,

        /// <summary>
        /// File is in Extended Markup Language format
        /// </summary>
        Xml = 2,

    }
}
