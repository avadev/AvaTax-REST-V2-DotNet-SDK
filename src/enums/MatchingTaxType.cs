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
    /// MatchingTaxType
    /// </summary>
    public enum MatchingTaxType
    {
        /// <summary>
        /// 
        /// </summary>
        All,

        /// <summary>
        /// 
        /// </summary>
        BothSalesAndUseTax,

        /// <summary>
        /// 
        /// </summary>
        ConsumerUseTax,

        /// <summary>
        /// 
        /// </summary>
        ConsumersUseAndSellersUseTax,

        /// <summary>
        /// 
        /// </summary>
        ConsumerUseAndSalesTax,

        /// <summary>
        /// 
        /// </summary>
        Fee,

        /// <summary>
        /// 
        /// </summary>
        VATInputTax,

        /// <summary>
        /// 
        /// </summary>
        VATNonrecoverableInputTax,

        /// <summary>
        /// 
        /// </summary>
        VATOutputTax,

        /// <summary>
        /// 
        /// </summary>
        Rental,

        /// <summary>
        /// 
        /// </summary>
        SalesTax,

        /// <summary>
        /// 
        /// </summary>
        UseTax,

    }
}
