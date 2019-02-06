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
    /// This data type is only used when an object must "Match" tax types. By specifying options here,
    ///  you can indicate which tax types will match for the purposes of this object.
    ///  For example, if you specify BothSalesAndUseTax, this value matches with both sales and seller's use tax.
    /// </summary>
    public enum MatchingTaxType
    {
        /// <summary>
        /// Match medical excise type
        /// </summary>
        Excise = 5,

        /// <summary>
        /// Match Lodging tax type
        /// </summary>
        Lodging = 6,

        /// <summary>
        /// Match bottle tax type
        /// </summary>
        Bottle = 7,

        /// <summary>
        /// Match RentToOwn tax type
        /// </summary>
        RentToOwn = 8,

        /// <summary>
        /// Match all tax types
        /// </summary>
        All = 65,

        /// <summary>
        /// Match both Sales and Use Tax only
        /// </summary>
        BothSalesAndUseTax = 66,

        /// <summary>
        /// Match Consumer Use Tax only
        /// </summary>
        ConsumerUseTax = 67,

        /// <summary>
        /// Match both Consumer Use and Seller's Use Tax types
        /// </summary>
        ConsumersUseAndSellersUseTax = 68,

        /// <summary>
        /// Match both Consumer Use and Sales Tax types
        /// </summary>
        ConsumerUseAndSalesTax = 69,

        /// <summary>
        /// Match Fee tax types only
        /// </summary>
        Fee = 70,

        /// <summary>
        /// Match VAT Input Tax only
        /// </summary>
        VATInputTax = 73,

        /// <summary>
        /// Match VAT Nonrecoverable Input Tax only
        /// </summary>
        VATNonrecoverableInputTax = 78,

        /// <summary>
        /// Match VAT Output Tax only
        /// </summary>
        VATOutputTax = 79,

        /// <summary>
        /// Match Rental tax types only
        /// </summary>
        Rental = 82,

        /// <summary>
        /// Match Sales Tax only
        /// </summary>
        SalesTax = 83,

        /// <summary>
        /// Match Seller's Use Tax only
        /// </summary>
        UseTax = 85,

    }
}
