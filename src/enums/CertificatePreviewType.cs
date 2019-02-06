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
    /// Type of certificate preview to download
    /// </summary>
    public enum CertificatePreviewType
    {
        /// <summary>
        /// Download a full printable PDF
        /// </summary>
        Pdf = 1,

        /// <summary>
        /// Download a single page of the certificate in JPG format
        /// </summary>
        Jpeg = 2,

    }
}
