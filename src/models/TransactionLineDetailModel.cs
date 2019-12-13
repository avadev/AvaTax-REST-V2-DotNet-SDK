using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// An individual tax detail element. Represents the amount of tax calculated for a particular jurisdiction, for a particular line in an invoice.
    /// </summary>
    public class TransactionLineDetailModel
    {
        /// <summary>
        /// The unique ID number of this tax detail.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the line within this transaction.
        /// </summary>
        public Int64? transactionLineId { get; set; }

        /// <summary>
        /// The unique ID number of this transaction.
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The unique ID number of the address used for this tax detail.
        /// </summary>
        public Int64? addressId { get; set; }

        /// <summary>
        /// The two character ISO 3166 country code of the country where this tax detail is assigned.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The two-or-three character ISO region code for the region where this tax detail is assigned.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// For U.S. transactions, the Federal Information Processing Standard (FIPS) code for the county where this tax detail is assigned.
        /// </summary>
        public String countyFIPS { get; set; }

        /// <summary>
        /// For U.S. transactions, the Federal Information Processing Standard (FIPS) code for the state where this tax detail is assigned.
        /// </summary>
        public String stateFIPS { get; set; }

        /// <summary>
        /// The amount of this line that was considered exempt in this tax detail.
        /// </summary>
        public Decimal? exemptAmount { get; set; }

        /// <summary>
        /// The unique ID number of the exemption reason for this tax detail.
        /// </summary>
        public Int32? exemptReasonId { get; set; }

        /// <summary>
        /// True if this detail element represented an in-state transaction.
        /// </summary>
        public Boolean? inState { get; set; }

        /// <summary>
        /// The code of the jurisdiction to which this tax detail applies.
        /// </summary>
        public String jurisCode { get; set; }

        /// <summary>
        /// The name of the jurisdiction to which this tax detail applies.
        /// </summary>
        public String jurisName { get; set; }

        /// <summary>
        /// The unique ID number of the jurisdiction to which this tax detail applies.
        /// </summary>
        public Int32? jurisdictionId { get; set; }

        /// <summary>
        /// The Avalara-specified signature code of the jurisdiction to which this tax detail applies.
        /// </summary>
        public String signatureCode { get; set; }

        /// <summary>
        /// The state assigned number of the jurisdiction to which this tax detail applies.
        /// </summary>
        public String stateAssignedNo { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 12/20/2017, Version: 18.1, Message: Use jurisdictionTypeId instead.
        /// The type of the jurisdiction to which this tax detail applies.
        /// </summary>
        public JurisTypeId? jurisType { get; set; }

        /// <summary>
        /// The type of the jurisdiction in which this tax detail applies.
        /// </summary>
        public JurisdictionType? jurisdictionType { get; set; }

        /// <summary>
        /// The amount of this line item that was considered nontaxable in this tax detail.
        /// </summary>
        public Decimal? nonTaxableAmount { get; set; }

        /// <summary>
        /// The rule according to which portion of this detail was considered nontaxable.
        /// </summary>
        public Int32? nonTaxableRuleId { get; set; }

        /// <summary>
        /// The type of nontaxability that was applied to this tax detail.
        /// </summary>
        public TaxRuleTypeId? nonTaxableType { get; set; }

        /// <summary>
        /// The rate at which this tax detail was calculated.
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// The unique ID number of the rule according to which this tax detail was calculated.
        /// </summary>
        public Int32? rateRuleId { get; set; }

        /// <summary>
        /// The unique ID number of the source of the rate according to which this tax detail was calculated.
        /// </summary>
        public Int32? rateSourceId { get; set; }

        /// <summary>
        /// For Streamlined Sales Tax customers, the SST Electronic Return code under which this tax detail should be applied.
        /// </summary>
        public String serCode { get; set; }

        /// <summary>
        /// Indicates whether this tax detail applies to the origin or destination of the transaction.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// The amount of tax for this tax detail.
        /// </summary>
        public Decimal? tax { get; set; }

        /// <summary>
        /// The taxable amount of this tax detail.
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// The type of tax that was calculated. Depends on the company's nexus settings as well as the jurisdiction's tax laws.
        /// </summary>
        public String taxType { get; set; }

        /// <summary>
        /// The id of the tax subtype.
        /// </summary>
        public String taxSubTypeId { get; set; }

        /// <summary>
        /// The id of the tax type group.
        /// </summary>
        public String taxTypeGroupId { get; set; }

        /// <summary>
        /// The name of the tax against which this tax amount was calculated.
        /// </summary>
        public String taxName { get; set; }

        /// <summary>
        /// The type of the tax authority to which this tax will be remitted.
        /// </summary>
        public Int32? taxAuthorityTypeId { get; set; }

        /// <summary>
        /// The unique ID number of the tax region.
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// The amount of tax that AvaTax calculated.
        /// If an override for tax amount is used, there may be a difference between the tax
        /// field which applies your override, and the this amount that is calculated without override.
        /// </summary>
        public Decimal? taxCalculated { get; set; }

        /// <summary>
        /// The amount of tax override that was specified for this tax line.
        /// </summary>
        public Decimal? taxOverride { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 12/20/2017, Version: 18.1, Message: Please use rateTypeCode instead.
        /// The rate type for this tax detail.
        /// </summary>
        public RateType? rateType { get; set; }

        /// <summary>
        /// Indicates the code of the rate type that was used to calculate this tax detail. Use [ListRateTypesByCountry](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListRateTypesByCountry/) API for a full list of rate type codes.
        /// </summary>
        public String rateTypeCode { get; set; }

        /// <summary>
        /// Number of units in this line item that were calculated to be taxable according to this rate detail.
        /// </summary>
        public Decimal? taxableUnits { get; set; }

        /// <summary>
        /// Number of units in this line item that were calculated to be nontaxable according to this rate detail.
        /// </summary>
        public Decimal? nonTaxableUnits { get; set; }

        /// <summary>
        /// Number of units in this line item that were calculated to be exempt according to this rate detail.
        /// </summary>
        public Decimal? exemptUnits { get; set; }

        /// <summary>
        /// When calculating units, what basis of measurement did we use for calculating the units?
        /// </summary>
        public String unitOfBasis { get; set; }

        /// <summary>
        /// True if this value is a non-passthrough tax.
        ///  
        /// A non-passthrough tax is a tax that may not be charged to a customer; it must be paid directly by the company.
        /// </summary>
        public Boolean? isNonPassThru { get; set; }

        /// <summary>
        /// The Taxes/Fee component. True if the fee is applied.
        /// </summary>
        public Boolean? isFee { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
