using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
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
        ElectronicReturn,

        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        PaperReturn,

        /// <summary>
        /// Denotes the tax return that was not filed.
        /// </summary>
        ReturnNotFiled,

        /// <summary>
        /// Denotes a return is paid via EFT and filed on paper without payment.
        /// </summary>
        EFTPaper,

        /// <summary>
        /// Denotes the tax return is an SST filing.
        /// </summary>
        SER,

        /// <summary>
        /// Denotes the tax return is a Trudsfile-EDI filing.
        /// </summary>
        TrustfileEdi,

        /// <summary>
        /// Denotes the tax return is an uploaded file.
        /// </summary>
        UploadFile,

        /// <summary>
        /// Denotes the tax return was manually filed via paper
        /// </summary>
        PaperManual,

        /// <summary>
        /// Denotes a cert capture return
        /// </summary>
        CertCapture,

        /// <summary>
        /// Denotes a signature ready return
        /// </summary>
        SignatureReady,

    }
}
