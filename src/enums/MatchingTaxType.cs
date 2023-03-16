using System;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2023 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Jonathan Wenger <jonathan.wenger@avalara.com>
 * @author Sachin Baijal <sachin.baijal@avalara.com>
 * Swagger name: AvaTaxClient 
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
        E = 5,

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
        /// BikeTax tax type
        /// </summary>
        BikeTax = 11,

        /// <summary>
        /// LandedCost tax type
        /// </summary>
        LandedCost = 12,

        /// <summary>
        /// CheckoutBag tax type
        /// </summary>
        CheckoutBag = 13,

        /// <summary>
        /// Alcohol tax type
        /// </summary>
        Alcohol = 17,

        /// <summary>
        /// Amusement tax type
        /// </summary>
        Amusement = 20,

        /// <summary>
        /// Hospitality tax type
        /// </summary>
        Hospitality = 21,

        /// <summary>
        /// RentalLeasing tax type
        /// </summary>
        RentalLeasing = 23,

        /// <summary>
        /// GrossReceipts tax type
        /// </summary>
        GrossReceipts = 24,

        /// <summary>
        /// Mattress tax type
        /// </summary>
        Mattress = 25,

        /// <summary>
        /// Lumber tax type
        /// </summary>
        Lumber = 27,

        /// <summary>
        /// Paint tax type
        /// </summary>
        Paint = 28,

        /// <summary>
        /// Tires tax type
        /// </summary>
        Tires = 29,

        /// <summary>
        /// Economic Incentive tax type
        /// </summary>
        EI = 30,

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
        /// LightBulbs tax type
        /// </summary>
        LightBulbs = 76,

        /// <summary>
        /// Meals tax type
        /// </summary>
        Meals = 77,

        /// <summary>
        /// Match VAT Nonrecoverable Input Tax only
        /// </summary>
        VATNonrecoverableInputTax = 78,

        /// <summary>
        /// Match VAT Output Tax only
        /// </summary>
        VATOutputTax = 79,

        /// <summary>
        /// PIF tax type
        /// </summary>
        PIF = 80,

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

        /// <summary>
        /// EWaste tax type
        /// </summary>
        EWaste = 87,

        /// <summary>
        /// Batteries tax type
        /// </summary>
        Batteries = 90,

    }
}
