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
    /// TaxOverrideTypeId
    /// </summary>
    public enum TaxOverrideTypeId
    {
        /// <summary>
        /// 
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        TaxAmount,

        /// <summary>
        /// 
        /// </summary>
        Exemption,

        /// <summary>
        /// 
        /// </summary>
        TaxDate,

        /// <summary>
        /// 
        /// </summary>
        AccruedTaxAmount,

    }
}
