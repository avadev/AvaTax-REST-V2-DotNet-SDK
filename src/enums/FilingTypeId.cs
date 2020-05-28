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
    /// A list of possible AvaFile filing types.
    /// </summary>
    public enum FilingTypeId
    {
        /// <summary>
        /// Denotes the tax return is being filed on paper.
        /// </summary>
        PaperReturn = 0,

        /// <summary>
        /// Denotes the tax return is being filed via electronic means; excludes SST electronic filing.
        /// </summary>
        ElectronicReturn = 1,

        /// <summary>
        /// Denotes the tax return is an SST filing.
        /// </summary>
        SER = 2,

        /// <summary>
        /// Denotes a return is paid via EFT and filed on paper without payment.
        /// </summary>
        EFTPaper = 3,

        /// <summary>
        /// Denotes a return is paid via phone and filed on paper without payment.
        /// </summary>
        PhonePaper = 4,

        /// <summary>
        /// Denotes a return is prepared but delivered to the customer for filing and payment.
        /// </summary>
        SignatureReady = 5,

        /// <summary>
        /// Denotes a return which is filed online but paid by check.
        /// </summary>
        EfileCheck = 6,

    }
}
