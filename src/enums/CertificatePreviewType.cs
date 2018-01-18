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
    /// Type of certificate preview to download
    /// </summary>
    public enum CertificatePreviewType
    {
        /// <summary>
        /// Download a full printable PDF
        /// </summary>
        Pdf,

        /// <summary>
        /// Download a single page of the certificate in JPG format
        /// </summary>
        Jpeg,

    }
}
