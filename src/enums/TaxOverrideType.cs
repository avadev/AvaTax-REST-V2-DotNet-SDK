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
    public enum TaxOverrideType
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// 
        /// </summary>
        TaxAmount = 1,

        /// <summary>
        /// 
        /// </summary>
        Exemption = 2,

        /// <summary>
        /// 
        /// </summary>
        TaxDate = 3,

        /// <summary>
        /// 
        /// </summary>
        AccruedTaxAmount = 4,

        /// <summary>
        /// 
        /// </summary>
        DeriveTaxable = 5,

        /// <summary>
        /// 
        /// </summary>
        OutOfHarbor = 6,

        /// <summary>
        /// 
        /// </summary>
        TaxAmountByTaxType = 7,

    }
}
