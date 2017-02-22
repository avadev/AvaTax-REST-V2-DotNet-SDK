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
    /// FilingTypeId
    /// </summary>
    public enum FilingTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        PaperReturn,

        /// <summary>
        /// 
        /// </summary>
        ElectronicReturn,

        /// <summary>
        /// 
        /// </summary>
        SER,

        /// <summary>
        /// 
        /// </summary>
        EFTPaper,

        /// <summary>
        /// 
        /// </summary>
        PhonePaper,

        /// <summary>
        /// 
        /// </summary>
        SignatureReady,

        /// <summary>
        /// 
        /// </summary>
        EfileCheck,

    }
}
