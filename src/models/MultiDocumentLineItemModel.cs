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
    /// Represents one line item in a MultiDocument transaction
    /// </summary>
    public class MultiDocumentLineItemModel
    {
        /// <summary>
        /// Specify the code of the company for this line of transaction.
        ///  
        /// If you leave this value null, the `companyCode` at the root level will be used instead.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Sets the sale location code (Outlet ID) for reporting this document to the tax authority.
        ///  
        /// If you leave this value `null`, the `reportingLocationCode` at the root level will be used instead.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// The line number of this line within the document. This can be any text that is useful to you, such as numeric line numbers, alphabetic line numbers, or other text.
        /// </summary>
        public String number { get; set; }

        /// <summary>
        /// Quantity of items in this line. This quantity value should always be a positive value representing the quantity of product that changed hands, even when handling returns or refunds.
        /// 
        /// If not provided, or if set to zero, the quantity value is assumed to be one (1).
        /// </summary>
        public Decimal? quantity { get; set; }

        /// <summary>
        /// Total amount for this line. The amount represents the net currency value that changed hands from the customer (represented by the `customerCode` field) to the company (represented by the `companyCode`) field.
        /// 
        /// For sale transactions, this value must be positive. It indicates the amount of money paid by the customer to the company.
        /// 
        /// For refund or return transactions, this value must be negative.
        /// </summary>
        public Decimal amount { get; set; }

        /// <summary>
        /// The addresses to use for this transaction line.
        /// 
        /// If you set this value to `null`, or if you omit this element from your API call, then instead the transaction
        /// will use the `addresses` from the document level.
        /// 
        /// If you specify any other value besides `null`, only addresses specified for this line will be used for this line.
        /// </summary>
        public AddressesModel addresses { get; set; }

        /// <summary>
        /// Tax Code - System or Custom Tax Code.
        ///  
        /// You can use your own tax code mapping or standard Avalara tax codes. For a full list of tax codes, see `ListTaxCodes`.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 10/16/2017, Version: 17.11, Message: Please use `entityUseCode` instead.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Entity Use Code - The client application customer or usage type. This field allows you to designate a type of usage that 
        /// may make this transaction considered exempt by reason of exempt usage.
        /// 
        /// For a list of entity use codes, see the Definitions API `ListEntityUseCodes`.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Item Code (SKU). If you provide an `itemCode` field, the AvaTax API will look up the item you created with the `CreateItems` API call
        /// and use all the information available about that item for this transaction.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// The customer Tax Id Number (tax_number) associated with a certificate - Sales tax calculation requests first determine if there is an applicable 
        /// ECMS entry available, and will utilize it for exemption processing. If no applicable ECMS entry is available, the AvaTax service 
        /// will determine if an Exemption Number field is populated or an Entity/Use Code is included in the sales tax calculation request, 
        /// and will perform exemption processing using either of those two options.
        /// Note: This is same as 'exemptNo' in TransactionModel.
        /// </summary>
        public String exemptionCode { get; set; }

        /// <summary>
        /// True if the document discount should be applied to this line. If this value is false, or not provided, discounts will not be 
        /// applied to this line even if they are specified on the root `discount` element.
        /// </summary>
        public Boolean? discounted { get; set; }

        /// <summary>
        /// Indicates whether the `amount` for this line already includes tax.
        /// 
        /// If this value is `true`, the final price of this line including tax will equal the value in `amount`. 
        /// 
        /// If this value is `null` or `false`, the final price will equal `amount` plus whatever taxes apply to this line.
        /// </summary>
        public Boolean? taxIncluded { get; set; }

        /// <summary>
        /// Revenue Account (Customer Defined Field).
        /// 
        /// This field is available for you to use to provide whatever information your implementation requires. It does not affect tax calculation.
        /// </summary>
        public String revenueAccount { get; set; }

        /// <summary>
        /// Ref1 (Customer Defined Field)
        /// 
        /// This field is available for you to use to provide whatever information your implementation requires. It does not affect tax calculation.
        /// </summary>
        public String ref1 { get; set; }

        /// <summary>
        /// Ref2 (Customer Defined Field)
        /// 
        /// This field is available for you to use to provide whatever information your implementation requires. It does not affect tax calculation.
        /// </summary>
        public String ref2 { get; set; }

        /// <summary>
        /// Item description.
        /// 
        /// For Streamlined Sales Tax (SST) customers, this field is required if an unmapped `itemCode` is used.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// VAT business identification number for the customer for this line item. If you leave this field empty,
        /// this line item will use whatever business identification number you provided at the transaction level.
        /// 
        /// If you specify a VAT business identification number for the customer in this transaction and you have also set up
        /// a business identification number for your company during company setup, this transaction will be treated as a 
        /// business-to-business transaction for VAT purposes and it will be calculated according to VAT tax rules.
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// Specifies a tax override for this line.
        /// </summary>
        public TaxOverrideModel taxOverride { get; set; }

        /// <summary>
        /// Special parameters that apply to this line within this transaction.
        /// 
        /// To get a full list of available parameters, please use the `ListParameters` API.
        /// </summary>
        public List<TransactionLineParameterModel> parameters { get; set; }

        /// <summary>
        /// The Item code for Custom Duty / Global Import tax determination
        /// Harmonized Tariff System code for this transaction.
        /// 
        /// For a list of harmonized tariff codes, see the Definitions API for harmonized tariff codes.
        /// </summary>
        public String hsCode { get; set; }


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
