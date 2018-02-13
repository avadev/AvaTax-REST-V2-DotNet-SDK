using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
    /// A MultiDocument transaction represents a sale or purchase that occurred between more than two companies.
    /// 
    /// A traditional transaction requires exactly two parties: a seller and a buyer. MultiDocument transactions can
    /// involve a marketplace of vendors, each of which contributes some portion of the final transaction. Within
    /// a MultiDocument transaction, each individual buyer and seller pair are matched up and converted to a separate
    /// document. This separation of documents allows each seller to file their taxes separately.
    /// </summary>
    public class CreateMultiDocumentModel
    {
        /// <summary>
        /// The transaction code of the MultiDocument transaction.
        /// 
        /// All individual transactions within this MultiDocument object will have this code as a prefix.
        /// 
        /// If you leave the `code` field blank, a GUID will be assigned.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Lines that will appear on the invoice.
        /// 
        /// For a MultiDocument transaction, each line may represent a different company or reporting location code. AvaTax
        /// will separate this MultiDocument transaction object into many different transactions, one for each pair of legal
        /// entities, so that each legal entity can file their transactional taxes correctly.
        /// </summary>
        public List<MultiDocumentLineItemModel> lines { get; set; }

        /// <summary>
        /// Set this value to true to allow this API call to adjust the MultiDocument model if one already exists.
        /// 
        /// If you omit this field, or if the value is `null`, you will receive an error if you try to create two MultiDocument
        /// objects with the same `code`.
        /// </summary>
        public Boolean? allowAdjust { get; set; }

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
        /// Transaction Date - The date on the invoice, purchase order, etc.
        /// 
        /// By default, this date will be used to calculate the tax rates for the transaction. If you wish to use a
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
        /// DEPRECATED - Customer Usage Type - The client application customer or usage type. For a list of 
        /// available usage types, see `/api/v2/definitions/entityusecodes`.
        /// Please use entityUseCode instead.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Entity Use Code - The client application customer or usage type. For a list of 
        /// available usage types, see `/api/v2/definitions/entityusecodes`.
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
        /// </summary>
        public String exemptionNo { get; set; }

        /// <summary>
        /// Default addresses for all lines in this document. 
        /// 
        /// These addresses are the default values that will be used for any lines that do not have their own
        /// address information. If you specify addresses for a line, then no default addresses will be loaded
        /// for that line.
        /// </summary>
        public AddressesModel addresses { get; set; }

        /// <summary>
        /// Special parameters for this transaction.
        /// 
        /// To get a full list of available parameters, please use the `/api/v2/definitions/parameters` endpoint.
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }

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
        /// Specifies a tax override for the entire document
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
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
