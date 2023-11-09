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
    /// Create a transaction
    /// </summary>
    public class CreateTransactionModel
    {
        /// <summary>
        /// The internal reference code used by the client application. This is used for operations such as
        /// Get, Adjust, Settle, and Void. If you leave the transaction code blank, a GUID will be assigned to each transaction.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// A list of line items that will appear on this transaction.
        /// </summary>
        public List<LineItemModel> lines { get; set; }

        /// <summary>
        /// Specifies the type of document to create. A document type ending with `Invoice` is a permanent transaction
        /// that will be recorded in AvaTax. A document type ending with `Order` is a temporary estimate that will not
        /// be preserved.
        ///  
        /// If you omit this value, the API will assume you want to create a `SalesOrder`.
        /// </summary>
        public DocumentType? type { get; set; }

        /// <summary>
        /// Company Code - Specify the code of the company creating this transaction here. If you leave this value null,
        /// your account's default company will be used instead.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Transaction Date - The date on the invoice, purchase order, etc. AvaTax accepts date values in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601)
        /// format and stores the date as `yyyy-MM-dd`.
        ///  
        /// By default, this date will be used to calculate the tax rates for the transaction. If you want to use a
        /// different date to calculate tax rates, please specify a `taxOverride` of type `taxDate`.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Salesperson Code - The client application salesperson reference code.
        /// </summary>
        public String salespersonCode { get; set; }

        /// <summary>
        /// Customer Code - The client application customer reference code.
        /// Note: This field is case sensitive. To have exemption certificates apply, this value should
        /// be the same as the one passed to create a customer.
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 10/16/2017, Version: 17.11, Message: Please use entityUseCode instead.
        /// Customer Usage Type - The client application customer or usage type.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Entity Use Code - The client application customer or usage type. For a list of
        /// available usage types, use [ListEntityUseCodes](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListEntityUseCodes/) API.
        /// </summary>
        public String entityUseCode { get; set; }

        /// <summary>
        /// Discount - The discount amount to apply to the document. This value will be applied only to lines
        /// that have the `discounted` flag set to true. If no lines have `discounted` set to true, this discount
        /// cannot be applied.
        /// </summary>
        public Decimal? discount { get; set; }

        /// <summary>
        /// Purchase Order Number for this document.
        ///  
        /// This is required for single use exemption certificates to match the order and invoice with the certificate.
        /// </summary>
        public String purchaseOrderNo { get; set; }

        /// <summary>
        /// Exemption Number for this document.
        ///  
        /// If you specify an exemption number for this document, this document will be considered exempt, and you
        /// may be asked to provide proof of this exemption certificate in the event that you are asked by an auditor
        /// to verify your exemptions.
        /// Note: This is same as 'exemptNo' in TransactionModel.
        /// </summary>
        public String exemptionNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AddressesModel addresses { get; set; }

        /// <summary>
        /// Special parameters for this transaction.
        ///  
        /// To get a full list of available parameters, please use the [ListParameters](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Definitions/ListParameters/) endpoint.
        /// </summary>
        public List<TransactionParameterModel> parameters { get; set; }

        /// <summary>
        /// Custom user fields/flex fields for this transaction.
        /// </summary>
        public List<TransactionUserDefinedFieldModel> userDefinedFields { get; set; }

        /// <summary>
        /// Customer-provided Reference Code with information about this transaction.
        ///  
        /// This field could be used to reference the original document for a return invoice, or for any other
        /// reference purpose.
        /// </summary>
        public String referenceCode { get; set; }

        /// <summary>
        /// Sets the sale location code (Outlet ID) for reporting this document to the tax authority.
        ///  
        /// This value is used by Avalara Managed Returns to group documents together by reporting locations
        /// for tax authorities that require location-based reporting.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// Causes the document to be committed if true. This option is only applicable for invoice document
        /// types, not orders.
        /// </summary>
        public Boolean? commit { get; set; }

        /// <summary>
        /// BatchCode for batch operations.
        /// </summary>
        public String batchCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TaxOverrideModel taxOverride { get; set; }

        /// <summary>
        /// The three-character ISO 4217 currency code for this transaction.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Specifies whether the tax calculation is handled Local, Remote, or Automatic (default). This only
        /// applies when using an AvaLocal server.
        /// </summary>
        public ServiceMode? serviceMode { get; set; }

        /// <summary>
        /// Currency exchange rate from this transaction to the company base currency.
        ///  
        /// This only needs to be set if the transaction currency is different than the company base currency.
        /// It defaults to 1.0.
        /// </summary>
        public Decimal? exchangeRate { get; set; }

        /// <summary>
        /// Effective date of the exchange rate.
        /// </summary>
        public DateTime? exchangeRateEffectiveDate { get; set; }

        /// <summary>
        /// Optional three-character ISO 4217 reporting exchange rate currency code for this transaction. The default value is USD.
        /// </summary>
        public String exchangeRateCurrencyCode { get; set; }

        /// <summary>
        /// Sets the Point of Sale Lane Code sent by the User for this document.
        /// </summary>
        public String posLaneCode { get; set; }

        /// <summary>
        /// VAT business identification number for the customer for this transaction. This number will be used for all lines
        /// in the transaction, except for those lines where you have defined a different business identification number.
        ///  
        /// If you specify a VAT business identification number for the customer in this transaction and you have also set up
        /// a business identification number for your company during company setup, this transaction will be treated as a
        /// business-to-business transaction for VAT purposes and it will be calculated according to VAT tax rules.
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// Specifies if the transaction should have value-added and cross-border taxes calculated with the seller as the importer of record.
        ///  
        /// Some taxes only apply if the seller is the importer of record for a product. In cases where companies are working together to
        /// ship products, there may be mutual agreement as to which company is the entity designated as importer of record. The importer
        /// of record will then be the company designated to pay taxes marked as being obligated to the importer of record.
        ///  
        /// Set this value to `true` to consider your company as the importer of record and collect these taxes.
        ///  
        /// This value may also be set at the Nexus level. See `NexusModel` for more information.
        /// </summary>
        public Boolean? isSellerImporterOfRecord { get; set; }

        /// <summary>
        /// User-supplied description for this transaction.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// User-supplied email address relevant for this transaction.
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// If the user wishes to request additional debug information from this transaction, specify a level higher than `normal`.
        /// </summary>
        public TaxDebugLevel? debugLevel { get; set; }

        /// <summary>
        /// The name of the supplier / exporter / seller.
        /// For sales doctype enter the name of your own company for which you are reporting.
        /// For purchases doctype enter the name of the supplier you have purchased from.
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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
