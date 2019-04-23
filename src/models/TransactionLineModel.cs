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
    /// One line item on this transaction.
    /// </summary>
    public class TransactionLineModel
    {
        /// <summary>
        /// The unique ID number of this transaction line item.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the transaction to which this line item belongs.
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The line number or code indicating the line on this invoice or receipt or document.
        /// </summary>
        public String lineNumber { get; set; }

        /// <summary>
        /// The unique ID number of the boundary override applied to this line item.
        /// </summary>
        public Int32? boundaryOverrideId { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 10/16/2017, Version: 17.11, Message: Please use entityUseCode instead.
        /// The customer usage type for this line item. Usage type often affects taxability rules.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// The entity use code for this line item. Usage type often affects taxability rules.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// A description of the item or service represented by this line.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The unique ID number of the destination address where this line was delivered or sold.
        /// In the case of a point-of-sale transaction, the destination address and origin address will be the same.
        /// In the case of a shipped transaction, they will be different.
        /// </summary>
        public Int64? destinationAddressId { get; set; }

        /// <summary>
        /// The unique ID number of the origin address where this line was delivered or sold.
        /// In the case of a point-of-sale transaction, the origin address and destination address will be the same.
        /// In the case of a shipped transaction, they will be different.
        /// </summary>
        public Int64? originAddressId { get; set; }

        /// <summary>
        /// The amount of discount that was applied to this line item. This represents the difference between list price and sale price of the item.
        /// In general, a discount represents money that did not change hands; tax is calculated on only the amount of money that changed hands.
        /// </summary>
        public Decimal? discountAmount { get; set; }

        /// <summary>
        /// The type of discount, if any, that was applied to this line item.
        /// </summary>
        public Int32? discountTypeId { get; set; }

        /// <summary>
        /// The amount of this line item that was exempt.
        /// </summary>
        public Decimal? exemptAmount { get; set; }

        /// <summary>
        /// The unique ID number of the exemption certificate that applied to this line item. It is the calc_id associated with a certificate in CertCapture.
        /// </summary>
        public Int32? exemptCertId { get; set; }

        /// <summary>
        /// The CertCapture Certificate ID
        /// </summary>
        public String certificateId { get; set; }

        /// <summary>
        /// The customer Tax Id Number (tax_number) associated with a certificate - Sales tax calculation requests first determine if there is an applicable 
        /// ECMS entry available, and will utilize it for exemption processing. If no applicable ECMS entry is available, the AvaTax service 
        /// will determine if an Exemption Number field is populated or an Entity/Use Code is included in the sales tax calculation request, 
        /// and will perform exemption processing using either of those two options.
        /// </summary>
        public String exemptNo { get; set; }

        /// <summary>
        /// True if this item is taxable.
        /// </summary>
        public Boolean? isItemTaxable { get; set; }

        /// <summary>
        /// True if this item is a Streamlined Sales Tax line item.
        /// </summary>
        public Boolean? isSSTP { get; set; }

        /// <summary>
        /// The code string of the item represented by this line item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// The total amount of the transaction, including both taxable and exempt. This is the total price for all items.
        /// To determine the individual item price, divide this by quantity.
        /// </summary>
        public Decimal? lineAmount { get; set; }

        /// <summary>
        /// The quantity of products sold on this line item.
        /// </summary>
        public Decimal? quantity { get; set; }

        /// <summary>
        /// A user-defined reference identifier for this transaction line item.
        /// </summary>
        public String ref1 { get; set; }

        /// <summary>
        /// A user-defined reference identifier for this transaction line item.
        /// </summary>
        public String ref2 { get; set; }

        /// <summary>
        /// The date when this transaction should be reported. By default, all transactions are reported on the date when the actual transaction took place.
        /// In some cases, line items may be reported later due to delayed shipments or other business reasons.
        /// </summary>
        public DateTime? reportingDate { get; set; }

        /// <summary>
        /// The revenue account number for this line item.
        /// </summary>
        public String revAccount { get; set; }

        /// <summary>
        /// Indicates whether this line item was taxed according to the origin or destination.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// The tax for this line in this transaction.
        /// 
        /// If you used a `taxOverride` of type `taxAmount` for this line, this value 
        /// will represent the amount of your override. AvaTax will still attempt to calculate the correct tax
        /// for this line and will store that calculated value in the `taxCalculated` field.
        /// 
        /// You can compare the `tax` and `taxCalculated` fields to check for any discrepancies
        /// between an external tax calculation provider and the calculation performed by AvaTax.
        /// </summary>
        public Decimal? tax { get; set; }

        /// <summary>
        /// The taxable amount of this line item.
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// The amount of tax that AvaTax calculated for the transaction.
        /// 
        /// If you used a `taxOverride` of type `taxAmount`, there may be a difference between
        /// the `tax` field which applies your override, and the `taxCalculated` field which
        /// represents the amount of tax that AvaTax calculated without the override.
        /// 
        /// You can compare the `tax` and `taxCalculated` fields to check for any discrepancies
        /// between an external tax calculation provider and the calculation performed by AvaTax.
        /// </summary>
        public Decimal? taxCalculated { get; set; }

        /// <summary>
        /// The code string for the tax code that was used to calculate this line item.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// The unique ID number for the tax code that was used to calculate this line item.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// The date that was used for calculating tax amounts for this line item. By default, this date should be the same as the document date.
        /// In some cases, for example when a consumer returns a product purchased previously, line items may be calculated using a tax date in the past
        /// so that the consumer can receive a refund for the correct tax amount that was charged when the item was originally purchased.
        /// </summary>
        public DateTime? taxDate { get; set; }

        /// <summary>
        /// The tax engine identifier that was used to calculate this line item.
        /// </summary>
        public String taxEngine { get; set; }

        /// <summary>
        /// If a tax override was specified, this indicates the type of tax override.
        /// </summary>
        public TaxOverrideType? taxOverrideType { get; set; }

        /// <summary>
        /// VAT business identification number used for this transaction.
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// If a tax override was specified, this indicates the amount of tax that was requested.
        /// </summary>
        public Decimal? taxOverrideAmount { get; set; }

        /// <summary>
        /// If a tax override was specified, represents the reason for the tax override.
        /// </summary>
        public String taxOverrideReason { get; set; }

        /// <summary>
        /// Indicates whether the `amount` for this line already includes tax.
        /// 
        /// If this value is `true`, the final price of this line including tax will equal the value in `amount`. 
        /// 
        /// If this value is `null` or `false`, the final price will equal `amount` plus whatever taxes apply to this line.
        /// </summary>
        public Boolean? taxIncluded { get; set; }

        /// <summary>
        /// Optional: A list of tax details for this line item. 
        /// 
        /// Tax details represent taxes being charged by various tax authorities. Taxes that appear in the `details` collection are intended to be 
        /// displayed to the customer and charged as a 'tax' on the invoice.
        /// 
        /// To fetch this list, add the query string `?$include=Details` to your URL.
        /// </summary>
        public List<TransactionLineDetailModel> details { get; set; }

        /// <summary>
        /// Optional: A list of non-passthrough tax details for this line item.
        /// 
        /// Tax details represent taxes being charged by various tax authorities. Taxes that appear in the `nonPassthroughDetails` collection are 
        /// taxes that must be paid directly by the company and not shown to the customer.
        /// </summary>
        public List<TransactionLineDetailModel> nonPassthroughDetails { get; set; }

        /// <summary>
        /// Optional: A list of location types for this line item. To fetch this list, add the query string "?$include=LineLocationTypes" to your URL.
        /// </summary>
        public List<TransactionLineLocationTypeModel> lineLocationTypes { get; set; }

        /// <summary>
        /// Contains a list of extra parameters that were set when the transaction was created.
        /// </summary>
        public List<TransactionLineParameterModel> parameters { get; set; }

        /// <summary>
        /// The cross-border harmonized system code (HSCode) used to calculate tariffs and duties for this line item. 
        /// For a full list of HS codes, see `ListCrossBorderCodes()`.
        /// </summary>
        public String hsCode { get; set; }

        /// <summary>
        /// Indicates the cost of insurance and freight for this line.
        /// </summary>
        public Decimal? costInsuranceFreight { get; set; }

        /// <summary>
        /// Indicates the VAT code for this line item.
        /// </summary>
        public String vatCode { get; set; }

        /// <summary>
        /// Indicates the VAT number type for this line item.
        /// </summary>
        public Int32? vatNumberTypeId { get; set; }


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
