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
    /// A list of possible AvaFile filing types.
    /// </summary>
    public enum FilingTypeId
    {
        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        PaperReturn,

        /// <summary>
        /// Denotes the tax return is being filed via electronic means; excludes SST electronic filing.
        /// </summary>
        ElectronicReturn,

        /// <summary>
        /// Denotes the tax return is an SST filing.
        /// </summary>
        SER,

        /// <summary>
        /// Denotes a return is paid via EFT and filed on paper without payment.
        /// </summary>
        EFTPaper,

        /// <summary>
        /// Denotes a return is paid via phone and filed on paper without payment.
        /// </summary>
        PhonePaper,

        /// <summary>
        /// Denotes a return is prepared but delivered to the customer for filing and payment.
        /// </summary>
        SignatureReady,

        /// <summary>
        /// Denotes a return which is filed online but paid by check.
        /// </summary>
        EfileCheck,

    }
}
