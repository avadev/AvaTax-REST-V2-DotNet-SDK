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
    /// Identifier for the specific varieties of component behavior.
    ///  The subtype determines the expected format of a component's data property.
    /// </summary>
    public enum DynamicRuleComponentSubtype
    {
        /// <summary>
        /// An unknown or uninitialized subtype.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Unspecified condition.
        /// </summary>
        Condition = 1,

        /// <summary>
        /// Compares two arbitrary expressions.
        /// </summary>
        MatchExpression = 2,

        /// <summary>
        /// Compares a field against one or more specific values.
        /// </summary>
        MatchField = 3,

        /// <summary>
        /// Matches based on the customer code.
        /// </summary>
        MatchCustomerCode = 4,

        /// <summary>
        /// Matches based on the document type.
        /// </summary>
        MatchDocumentType = 5,

        /// <summary>
        /// Matches based on a user-defined field.
        /// </summary>
        MatchUserDefinedField = 6,

        /// <summary>
        /// Matches based on a parameter.
        /// </summary>
        MatchParameter = 7,

        /// <summary>
        /// Matches based on tax override information.
        /// </summary>
        MatchTaxOverride = 8,

        /// <summary>
        /// Matches based on address information.
        /// </summary>
        MatchAddress = 9,

        /// <summary>
        /// Matches based on the tariff code.
        /// </summary>
        MatchTariffCode = 10,

        /// <summary>
        /// Matches based on the tax code.
        /// </summary>
        MatchTaxCode = 11,

        /// <summary>
        /// Matches based on jurisdiction and tax applicability.
        /// </summary>
        MatchTax = 12,

        /// <summary>
        /// Matches based on jurisdiction and a custom tax type and subtype.
        /// </summary>
        CustomTax = 13,

        /// <summary>
        /// Matches based on address jurisdictions.
        /// </summary>
        MatchJurisdiction = 14,

        /// <summary>
        /// Matches based on the entity use code.
        /// </summary>
        MatchEntityUseCode = 15,

        /// <summary>
        /// Unspecified action.
        /// </summary>
        Action = 256,

        /// <summary>
        /// Updates a transaction field with a value.
        /// </summary>
        UpdateField = 257,

        /// <summary>
        /// Copies a value from one field to another.
        /// </summary>
        CopyField = 258,

        /// <summary>
        /// Updates address-related fields.
        /// </summary>
        UpdateAddress = 259,

        /// <summary>
        /// Copies address values between address types.
        /// </summary>
        CopyAddress = 260,

        /// <summary>
        /// Updates a parameter value.
        /// </summary>
        UpdateParameter = 261,

        /// <summary>
        /// Updates a user-defined field value.
        /// </summary>
        UpdateUserDefinedField = 262,

        /// <summary>
        /// Updates a tax override value.
        /// </summary>
        UpdateTaxOverride = 263,

        /// <summary>
        /// Updates the location code.
        /// </summary>
        UpdateLocationCode = 264,

        /// <summary>
        /// Updates the marketplace location code.
        /// </summary>
        UpdateMarketplace = 265,

        /// <summary>
        /// Allocates values based on a field.
        /// </summary>
        AllocateByField = 266,

        /// <summary>
        /// Allocates values based on an address.
        /// </summary>
        AllocateByAddress = 267,

        /// <summary>
        /// Allocates consumer use tax.
        /// </summary>
        AllocateConsumerUse = 268,

        /// <summary>
        /// Aggregates line values post-allocation.
        /// </summary>
        AggregateLines = 269,

        /// <summary>
        /// Overrides the tax rate.
        /// </summary>
        TaxRuleRateOverride = 270,

        /// <summary>
        /// Overrides the taxable base.
        /// </summary>
        TaxRuleBaseOverride = 271,

        /// <summary>
        /// Overrides product taxability.
        /// </summary>
        TaxRuleProductTaxability = 272,

        /// <summary>
        /// Updates an exemption stauts.
        /// </summary>
        TaxRuleExemptEntity = 273,

        /// <summary>
        /// Unspecified variable.
        /// </summary>
        Variable = 512,

        /// <summary>
        /// Named expression.
        /// </summary>
        Expression = 513,

        /// <summary>
        /// Named aggregation computation.
        /// </summary>
        Aggregation = 514,

    }
}
