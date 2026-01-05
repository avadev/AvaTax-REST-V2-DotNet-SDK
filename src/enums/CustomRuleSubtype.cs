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
    /// The subtype of a custom rule
    /// </summary>
    public enum CustomRuleSubtype
    {
        /// <summary>
        /// The unknown rule type
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// A product taxability tax rule
        /// </summary>
        ProductTaxabilityRule = 1,

        /// <summary>
        /// An exempt entity tax rule
        /// </summary>
        ExemptEntityRule = 2,

        /// <summary>
        /// A rate override tax rule
        /// </summary>
        RateOverrideRule = 3,

        /// <summary>
        /// A base override tax rule
        /// </summary>
        BaseOverrideRule = 4,

        /// <summary>
        /// A Marketplace advanced rule
        /// </summary>
        Marketplace = 5,

        /// <summary>
        /// A Bundled Items Allocation advanced rule
        /// </summary>
        BundledItemsAllocation = 6,

        /// <summary>
        /// A Multiple Points of Use Allocation advanced rule
        /// </summary>
        MultiplePointsOfUseAllocation = 7,

        /// <summary>
        /// A Find and Replace Before Calculationadvanced rule
        /// </summary>
        FindAndReplaceBeforeCalculation = 8,

        /// <summary>
        /// A Find and Replace After Calculation advanced rule
        /// </summary>
        FindAndReplaceAfterCalculation = 9,

        /// <summary>
        /// A Reporting Location advanced rule
        /// </summary>
        ReportingLocation = 10,

        /// <summary>
        /// A Seller Remits Aggregator advanced rule
        /// </summary>
        SellerRemitsAggregator = 11,

        /// <summary>
        /// A Consumer Use Allocation advanced rule
        /// </summary>
        ConsumerUseAllocation = 12,

        /// <summary>
        /// A Find and Replace Jurisdiction Match advanced rule
        /// </summary>
        FindAndReplaceJurisdictionMatch = 13,

        /// <summary>
        /// Updates a transaction field with a value.
        /// </summary>
        UpdateField = 14,

        /// <summary>
        /// Copies a value from one field to another.
        /// </summary>
        CopyField = 15,

        /// <summary>
        /// Updates address-related fields.
        /// </summary>
        UpdateAddress = 16,

        /// <summary>
        /// Copies address values between address types.
        /// </summary>
        CopyAddress = 17,

        /// <summary>
        /// Updates a parameter value.
        /// </summary>
        UpdateParameter = 18,

        /// <summary>
        /// Updates a user-defined field value.
        /// </summary>
        UpdateUserDefinedField = 19,

        /// <summary>
        /// Updates a tax override value.
        /// </summary>
        UpdateTaxOverride = 20,

        /// <summary>
        /// Updates the location code.
        /// </summary>
        UpdateLocationCode = 21,

        /// <summary>
        /// Updates the marketplace location code.
        /// </summary>
        UpdateMarketplace = 22,

        /// <summary>
        /// Allocates values based on a field.
        /// </summary>
        AllocateByField = 23,

        /// <summary>
        /// Allocates values based on an address.
        /// </summary>
        AllocateByAddress = 24,

        /// <summary>
        /// Allocates consumer use tax.
        /// </summary>
        AllocateConsumerUse = 25,

        /// <summary>
        /// Aggregates line values post-allocation.
        /// </summary>
        AggregateLines = 26,

        /// <summary>
        /// Overrides the tax rate.
        /// </summary>
        TaxRuleRateOverride = 27,

        /// <summary>
        /// Overrides the taxable base.
        /// </summary>
        TaxRuleBaseOverride = 28,

        /// <summary>
        /// Overrides product taxability.
        /// </summary>
        TaxRuleProductTaxability = 29,

        /// <summary>
        /// Updates an exemption stauts.
        /// </summary>
        TaxRuleExemptEntity = 30,

        /// <summary>
        /// Defines one or more custom content rules.
        /// </summary>
        CustomTax = 31,

    }
}
