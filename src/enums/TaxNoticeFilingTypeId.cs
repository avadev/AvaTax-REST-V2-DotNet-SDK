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
    /// A list of possible AvaFile filing types for tax notices.
    /// </summary>
    public enum TaxNoticeFilingTypeId
    {
        /// <summary>
        /// Denotes the tax return is being filed via electronic means; excludes SST electronic filing.
        /// </summary>
        ElectronicReturn = 1,

        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        PaperReturn = 2,

        /// <summary>
        /// Denotes the tax return that was not filed.
        /// </summary>
        ReturnNotFiled = 3,

        /// <summary>
        /// Denotes a return is paid via EFT and filed on paper without payment.
        /// </summary>
        EFTPaper = 4,

        /// <summary>
        /// Denotes the tax return is an SST filing.
        /// </summary>
        SER = 5,

        /// <summary>
        /// Denotes the tax return is a Trudsfile-EDI filing.
        /// </summary>
        TrustfileEdi = 6,

        /// <summary>
        /// Denotes the tax return is an uploaded file.
        /// </summary>
        UploadFile = 7,

        /// <summary>
        /// Denotes the tax return was manually filed via paper
        /// </summary>
        PaperManual = 8,

        /// <summary>
        /// Denotes a cert capture return
        /// </summary>
        CertCapture = 9,

        /// <summary>
        /// Denotes a signature ready return
        /// </summary>
        SignatureReady = 10,

    }
}
