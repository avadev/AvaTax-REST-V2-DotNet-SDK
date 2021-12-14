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
 * Swagger name: AvaTaxClient 
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// 
    /// </summary>
    public enum TaxNoticeFilingTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        ElectronicReturn = 1,

        /// <summary>
        /// 
        /// </summary>
        PaperReturn = 2,

        /// <summary>
        /// 
        /// </summary>
        ReturnNotFiled = 3,

        /// <summary>
        /// 
        /// </summary>
        EFTPaper = 4,

        /// <summary>
        /// 
        /// </summary>
        SER = 5,

        /// <summary>
        /// 
        /// </summary>
        TrustfileEdi = 6,

        /// <summary>
        /// 
        /// </summary>
        UploadFile = 7,

        /// <summary>
        /// 
        /// </summary>
        PaperManual = 8,

        /// <summary>
        /// 
        /// </summary>
        CertCapture = 9,

        /// <summary>
        /// 
        /// </summary>
        SignatureReady = 10,

    }
}
