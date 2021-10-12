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
    /// 
    /// </summary>
    public enum FilingTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        PaperReturn = 0,

        /// <summary>
        /// 
        /// </summary>
        ElectronicReturn = 1,

        /// <summary>
        /// 
        /// </summary>
        SER = 2,

        /// <summary>
        /// 
        /// </summary>
        EFTPaper = 3,

        /// <summary>
        /// 
        /// </summary>
        PhonePaper = 4,

        /// <summary>
        /// 
        /// </summary>
        SignatureReady = 5,

        /// <summary>
        /// 
        /// </summary>
        EfileCheck = 6,

    }
}
