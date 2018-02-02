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
    /// This data type is only used when an object must "Match" tax types. By specifying options here,
    ///  you can indicate which tax types will match for the purposes of this object.
    ///  For example, if you specify BothSalesAndUseTax, this value matches with both sales and seller's use tax.
    /// </summary>
    public enum MatchingTaxType
    {
        /// <summary>
        /// Match medical excise type
        /// </summary>
        Excise,

        /// <summary>
        /// Match Lodging tax type
        /// </summary>
        Lodging,

        /// <summary>
        /// Match bottle tax type
        /// </summary>
        Bottle,

        /// <summary>
        /// Match all tax types
        /// </summary>
        All,

        /// <summary>
        /// Match both Sales and Use Tax only
        /// </summary>
        BothSalesAndUseTax,

        /// <summary>
        /// Match Consumer Use Tax only
        /// </summary>
        ConsumerUseTax,

        /// <summary>
        /// Match both Consumer Use and Seller's Use Tax types
        /// </summary>
        ConsumersUseAndSellersUseTax,

        /// <summary>
        /// Match both Consumer Use and Sales Tax types
        /// </summary>
        ConsumerUseAndSalesTax,

        /// <summary>
        /// Match Fee tax types only
        /// </summary>
        Fee,

        /// <summary>
        /// Match VAT Input Tax only
        /// </summary>
        VATInputTax,

        /// <summary>
        /// Match VAT Nonrecoverable Input Tax only
        /// </summary>
        VATNonrecoverableInputTax,

        /// <summary>
        /// Match VAT Output Tax only
        /// </summary>
        VATOutputTax,

        /// <summary>
        /// Match Rental tax types only
        /// </summary>
        Rental,

        /// <summary>
        /// Match Sales Tax only
        /// </summary>
        SalesTax,

        /// <summary>
        /// Match Seller's Use Tax only
        /// </summary>
        UseTax,

    }
}
