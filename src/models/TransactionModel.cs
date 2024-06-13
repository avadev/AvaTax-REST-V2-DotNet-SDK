using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// This object represents a single transaction; for example, a sales invoice or purchase order.
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// The unique ID number of this transaction.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// A unique customer-provided code identifying this transaction.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// The unique ID number of the company that recorded this transaction.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The date on which this transaction occurred.
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 07/25/2018, Version: 18.7, Message: This field is deprecated and will return null till its removed.
        /// The date when payment was made on this transaction. By default, this should be the same as the date of the transaction.
        /// </summary>
        public DateTime? paymentDate { get; set; }

        /// <summary>
        /// The status of the transaction.
        /// </summary>
        public DocumentStatus? status { get; set; }

        /// <summary>
        /// The type of the transaction.
        ///  
        /// Transactions of type `SalesOrder`, `ReturnOrder`, and so on are temporary estimates and will not be saved.
        ///  
        /// Transactions of type `SalesInvoice, `ReturnInvoice`, and so on are permanent transactions that can be reported to tax authorities
        /// if they are in status `Committed`.
        ///  
        /// A sales transaction represents a sale from the company to a customer. A purchase transaction represents a purchase made by the company.
        /// A return transaction represents a customer who decided to request a refund after purchasing a product from the company. An inventory
        /// transfer transaction represents goods that were moved from one location of the company to another location without changing ownership.
        /// </summary>
        public DocumentType? type { get; set; }

        /// <summary>
        /// If this transaction was created as part of a batch, this code indicates which batch.
        /// </summary>
        public String batchCode { get; set; }

        /// <summary>
        /// The three-character ISO 4217 currency code that was used for payment for this transaction.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// The three-character ISO 4217 exchange rate currency code that was used for payment for this transaction.
        /// </summary>
        public String exchangeRateCurrencyCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 10/16/2017, Version: 17.11, Message: Please use entityUseCode instead.
        /// The customer usage type for this transaction. Customer usage types often affect exemption or taxability rules.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// The entity use code for this transaction. Entity use codes often affect exemption or taxability rules.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 3/1/2018, Version: 18.3, Message: Please use `customerCode`
        /// This field has been renamed to `customerCode` to match documentation for other APIs related to exemption customers.
        /// </summary>
        public String customerVendorCode { get; set; }

        /// <summary>
        /// Unique code identifying the customer that requested this transaction.
        ///  
        /// When you specify a `customerCode`, AvaTax will look to see if a customer exists with this code in the exemption certificate system.
        /// If that customer exists, and if that customer has uploaded an exemption certificate that applies to this transaction, the relevant
        /// parts of this transaction that can use the exemption certificate will be treated as exempt.
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// The customer Tax Id Number (tax_number) associated with a certificate - Sales tax calculation requests first determine if there is an applicable
        /// ECMS entry available, and will utilize it for exemption processing. If no applicable ECMS entry is available, the AvaTax service
        /// will determine if an Exemption Number field is populated or an Entity/Use Code is included in the sales tax calculation request,
        /// and will perform exemption processing using either of those two options.
        /// </summary>
        public String exemptNo { get; set; }

        /// <summary>
        /// If this transaction has been reconciled against the company's ledger, this value is set to true.
        /// </summary>
        public Boolean? reconciled { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 3/1/2018, Version: 18.3, Message: In order to ensure consistency of field names, Please use reportingLocationCode instead.
        /// This field has been replaced by the reportingLocationCode field
        /// </summary>
        public String locationCode { get; set; }

        /// <summary>
        /// For customers who use [location-based tax reporting](https://developer.avalara.com/avatax/dev-guide/locations/location-based-reporting),
        /// this field controls how this transaction will be filed for multi-location tax filings.
        ///  
        /// If you specify a non-null value for this field, AvaTax will ensure that this transaction is reported on the tax return associated
        /// with the [LocationModel](https://developer.avalara.com/api-reference/avatax/rest/v2/models/LocationModel/) identified by this code.
        ///  
        /// This field does not affect any addresses for the transaction. It only controls the tax filing behavior of this transaction.
        ///  
        /// If you are looking for information about how to set up addresses for a transaction, please see [Using Address Types](https://developer.avalara.com/avatax/dev-guide/customizing-transaction/address-types/)
        /// in the AvaTax Developer Guide.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// The customer-supplied purchase order number of this transaction.
        /// </summary>
        public String purchaseOrderNo { get; set; }

        /// <summary>
        /// A user-defined reference code for this transaction.
        /// </summary>
        public String referenceCode { get; set; }

        /// <summary>
        /// The salesperson who provided this transaction. Not required.
        /// </summary>
        public String salespersonCode { get; set; }

        /// <summary>
        /// If a tax override was applied to this transaction, indicates what type of tax override was applied.
        /// </summary>
        public TaxOverrideType? taxOverrideType { get; set; }

        /// <summary>
        /// If a tax override was applied to this transaction, indicates the amount of tax that was requested by the customer.
        /// </summary>
        public Decimal? taxOverrideAmount { get; set; }

        /// <summary>
        /// If a tax override was applied to this transaction, indicates the reason for the tax override.
        /// </summary>
        public String taxOverrideReason { get; set; }

        /// <summary>
        /// The total amount of this transaction.
        /// </summary>
        public Decimal? totalAmount { get; set; }

        /// <summary>
        /// The amount of this transaction that was exempt.
        /// </summary>
        public Decimal? totalExempt { get; set; }

        /// <summary>
        /// The total amount of discounts applied to all lines within this transaction.
        /// </summary>
        public Decimal? totalDiscount { get; set; }

        /// <summary>
        /// The total tax for all lines in this transaction.
        ///  
        /// If you used a `taxOverride` of type `taxAmount` for any lines in this transaction, this value
        /// may be different than the amount of tax calculated by AvaTax. The amount of tax calculated by
        /// AvaTax will be stored in the `totalTaxCalculated` field, whereas this field will contain the
        /// total tax that was charged on the transaction.
        ///  
        /// You can compare the `totalTax` and `totalTaxCalculated` fields to check for any discrepancies
        /// between an external tax calculation provider and the calculation performed by AvaTax.
        /// </summary>
        public Decimal? totalTax { get; set; }

        /// <summary>
        /// The portion of the total amount of this transaction that was taxable.
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// The amount of tax that AvaTax calculated for the transaction.
        ///  
        /// If you used a `taxOverride` of type `taxAmount` for any lines in this transaction, this value
        /// will represent the amount that AvaTax calculated for this transaction without applying the override.
        /// The field `totalTax` will be the total amount of tax after all overrides are applied.
        ///  
        /// You can compare the `totalTax` and `totalTaxCalculated` fields to check for any discrepancies
        /// between an external tax calculation provider and the calculation performed by AvaTax.
        /// </summary>
        public Decimal? totalTaxCalculated { get; set; }

        /// <summary>
        /// If this transaction was adjusted, indicates the unique ID number of the reason why the transaction was adjusted.
        /// </summary>
        public AdjustmentReason? adjustmentReason { get; set; }

        /// <summary>
        /// If this transaction was adjusted, indicates a description of the reason why the transaction was adjusted.
        /// </summary>
        public String adjustmentDescription { get; set; }

        /// <summary>
        /// If this transaction has been reported to a tax authority, this transaction is considered locked and may not be adjusted after reporting.
        /// </summary>
        public Boolean? locked { get; set; }

        /// <summary>
        /// The two-or-three character ISO region code of the region for this transaction.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The two-character ISO 3166 code of the country for this transaction.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// If this transaction was adjusted, this indicates the version number of this transaction. Incremented each time the transaction
        /// is adjusted.
        /// </summary>
        public Int32? version { get; set; }

        /// <summary>
        /// The software version used to calculate this transaction.
        /// </summary>
        public String softwareVersion { get; set; }

        /// <summary>
        /// The unique ID number of the origin address for this transaction.
        /// </summary>
        public Int64? originAddressId { get; set; }

        /// <summary>
        /// The unique ID number of the destination address for this transaction.
        /// </summary>
        public Int64? destinationAddressId { get; set; }

        /// <summary>
        /// If this transaction included foreign currency exchange, this is the date as of which the exchange rate was calculated.
        /// </summary>
        public DateTime? exchangeRateEffectiveDate { get; set; }

        /// <summary>
        /// If this transaction included foreign currency exchange, this is the exchange rate that was used.
        /// </summary>
        public Decimal? exchangeRate { get; set; }

        /// <summary>
        /// By default, the value is null, when the value is null, the value can be set at nexus level and used.
        /// If the value is not null, it will override the value at nexus level.
        ///  
        /// If true, this seller was considered the importer of record of a product shipped internationally.
        ///  
        /// If this transaction is not an international transaction, this field may be left blank.
        ///  
        /// The "importer of record" is liable to pay customs and import duties for products shipped internationally. If
        /// you specify that the seller is the importer of record, then estimates of customs and import duties will be added
        /// as tax details to the transaction. Otherwise, the buyer is considered the importer of record, and customs
        /// and import duties will not be added to the tax details for this transaction.
        /// </summary>
        public Boolean? isSellerImporterOfRecord { get; set; }

        /// <summary>
        /// Description of this transaction. Field permits unicode values.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Email address associated with this transaction.
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// VAT business identification number used for this transaction.
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// The date/time when this record was last modified.
        /// </summary>
        public DateTime? modifiedDate { get; set; }

        /// <summary>
        /// The user ID of the user who last modified this record.
        /// </summary>
        public Int32? modifiedUserId { get; set; }

        /// <summary>
        /// Tax date for this transaction
        /// </summary>
        public DateTime? taxDate { get; set; }

        /// <summary>
        /// A list of line items in this transaction. To fetch this list, add the query string `?$include=Lines` or `?$include=Details` to your URL.
        /// </summary>
        public List<TransactionLineModel> lines { get; set; }

        /// <summary>
        /// A list of line items in this transaction. To fetch this list, add the query string `?$include=Addresses` to your URL.
        ///  
        /// For more information about transaction addresses, please see [Using Address Types](https://developer.avalara.com/avatax/dev-guide/customizing-transaction/address-types/)
        /// in the AvaTax Developer Guide.
        /// </summary>
        public List<TransactionAddressModel> addresses { get; set; }

        /// <summary>
        /// A list of location types in this transaction. To fetch this list, add the query string `?$include=Addresses` to your URL.
        /// </summary>
        public List<TransactionLocationTypeModel> locationTypes { get; set; }

        /// <summary>
        /// Contains a summary of tax on this transaction.
        /// </summary>
        public List<TransactionSummary> summary { get; set; }

        /// <summary>
        /// Contains the tax details per tax type
        /// </summary>
        public List<TaxDetailsByTaxType> taxDetailsByTaxType { get; set; }

        /// <summary>
        /// Contains a list of extra parameters that were set when the transaction was created.
        /// </summary>
        public List<TransactionParameterModel> parameters { get; set; }

        /// <summary>
        /// Custom user fields/flex fields for this transaction.
        /// </summary>
        public List<TransactionUserDefinedFieldModel> userDefinedFields { get; set; }

        /// <summary>
        /// List of informational and warning messages regarding this API call. These messages are only relevant to the current API call.
        /// </summary>
        public List<AvaTaxMessage> messages { get; set; }

        /// <summary>
        /// Invoice messages associated with this document. Currently, this stores legally-required VAT messages.
        /// </summary>
        public List<InvoiceMessageModel> invoiceMessages { get; set; }

        /// <summary>
        /// The name of the supplier / exporter / seller.
        /// For sales doctype this will be the name of your own company for which you are reporting.
        /// For purchases doctype this will be the name of the supplier you have purchased from.
        /// </summary>
        public String customerSupplierName { get; set; }

        /// <summary>
        /// The Id of the datasource from which this transaction originated.
        /// This value will be overridden by the system to take the datasource Id from the call header.
        /// </summary>
        public Int32? dataSourceId { get; set; }

        /// <summary>
        /// Delivery Terms (or Incoterms) refer to agreed-upon conditions between a buyer and a seller for the delivery of goods. They are three-letter 
        /// trade terms that describe the practical arrangements for the delivery of goods from sellers to buyers and set out the obligations, costs, and 
        /// risks between the two parties.
        /// The DeliveryTerms field determines who acts as the Importer of Record and who arranges the Transport of the goods when this 
        /// information is not separately sent to AvaTax in the request. When used in conjunction with isSellerImporterOfRecord, this parameter can also 
        /// influence whether AvaTax includes Import Duty and Tax in the transaction totals. If the fields for transport or isSellerImporterOfRecord are 
        /// passed in the request and conflict with the DeliveryTerms, the values provided in the first will take priority over the DeliveryTerms 
        /// parameter. If neither transport nor isSellerImporterOfRecord is passed in the request and DeliveryTerms is passed, AvaTax will determine who 
        /// acts as Importer of Record and who arranges the Transport of the goods based on the specified DeliveryTerms. If none of these fields is 
        /// passed, AvaTax will keep the current behavior and default transport to "Seller" for goods and isSellerImporterOfRecord to "False" (i.e., the 
        /// AvaTax user does not act as Importer of record)."
        /// Finally, this field is also used for reports.
        /// 
        /// The Delivery Terms that the user can pass are the following:
        /// 1. Ex Works (EXW)
        /// 2. Free Carrier (FCA)
        /// 3. Carrier and Insurance Paid to (CIP)
        /// 4. Carriage Paid To (CPT)
        /// 5. Delivered at Place (DAP)
        /// 6. Delivered at Place Unloaded (DPU)
        /// 7. Delivered Duty Paid (DDP)
        /// 8. Free Alongside Ship (FAS)
        /// 9. Free on Board (FOB)
        /// 10. Cost and Freight (CFR)
        /// 11. Cost, Insurance and Freight (CIF)
        /// 
        /// DAP and DDP are two delivery terms that indicate that Import Duty and Tax should be included in the transaction total.
        /// </summary>
        public DeliveryTerms? deliveryTerms { get; set; }

        /// <summary>
        /// Users can set tolerance or threshold limits on transactions and inform users of appropriate actions to take
        /// if a transaction falls outside of these values. 
        /// An Accounts Payable (AP) status code indicates the action that needs to be taken when the tolerance/threshold 
        /// falls above or below the tolerance/threshold limits.
        ///  
        /// Available AP status codes are:
        /// 1. NoAccrualMatch
        /// 2. NoAccrualUndercharge
        /// 3. NoAccrualOvercharge
        /// 4. NoAccrualAmountThresholdNotMet
        /// 5. NoAccrualTrustedVendor
        /// 6. NoAccrualExemptedCostCenter
        /// 7. NoAccrualExemptedItem
        /// 8. NoAccrualExemptedVendor
        /// 9. AccruedUndercharge
        /// 10. AccruedVendor
        /// 11. NeedReviewUndercharge
        /// 12. NeedReviewVendor
        /// 13. PendingAccrualVendor
        /// 14. PendingAccrualUndercharge
        /// </summary>
        public APStatus? apStatusCode { get; set; }

        /// <summary>
        /// An Accounts Payable (AP) status indicates an action that needs to be taken when the tolerance amount falls 
        /// above or below certain threshold limits.
        /// </summary>
        public String apStatus { get; set; }


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
