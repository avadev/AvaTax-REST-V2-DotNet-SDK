using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * AvaTax API Client Library
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author Ted Spence
 * @author Zhenya Frolov
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// Create a transaction
    /// </summary>
    public class CreateTransactionModel
    {
        /// <summary>
        /// Document Type: if not specified, a document with type of SalesOrder will be created by default
        /// </summary>
        public DocumentType? type { get; set; }

        /// <summary>
        /// Transaction Code - the internal reference code used by the client application. This is used for operations such as        ///
        ///        ///Get, Adjust, Settle, and Void. If you leave the transaction code blank, a GUID will be assigned to each transaction.
        /// </summary>
        public String code { get; set; }

        /// <summary>
        /// Company Code - Specify the code of the company creating this transaction here. If you leave this value null,        ///
        ///        ///your account's default company will be used instead.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Transaction Date - The date on the invoice, purchase order, etc.
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// Salesperson Code - The client application salesperson reference code.
        /// </summary>
        public String salespersonCode { get; set; }

        /// <summary>
        /// Customer Code - The client application customer reference code.
        /// </summary>
        public String customerCode { get; set; }

        /// <summary>
        /// Customer Usage Type - The client application customer or usage type.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Discount - The discount amount to apply to the document.
        /// </summary>
        public Decimal? discount { get; set; }

        /// <summary>
        /// Purchase Order Number for this document
        /// </summary>
        public String purchaseOrderNo { get; set; }

        /// <summary>
        /// Exemption Number for this document
        /// </summary>
        public String exemptionNo { get; set; }

        /// <summary>
        /// Default addresses for all lines in this document
        /// </summary>
        public AddressesModel addresses { get; set; }

        /// <summary>
        /// Document line items list
        /// </summary>
        public List<LineItemModel> lines { get; set; }

        /// <summary>
        /// Special parameters for this transaction.        ///
        ///        ///To get a full list of available parameters, please use the /api/v2/definitions/parameters endpoint.
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }

        /// <summary>
        /// Reference Code used to reference the original document for a return invoice
        /// </summary>
        public String referenceCode { get; set; }

        /// <summary>
        /// Sets the sale location code (Outlet ID) for reporting this document to the tax authority.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// Causes the document to be committed if true.
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
        /// 3 character ISO 4217 currency code.
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Specifies whether the tax calculation is handled Local, Remote, or Automatic (default)
        /// </summary>
        public ServiceMode? serviceMode { get; set; }

        /// <summary>
        /// Currency exchange rate from this transaction to the company base currency.
        /// </summary>
        public Decimal? exchangeRate { get; set; }

        /// <summary>
        /// Effective date of the exchange rate.
        /// </summary>
        public DateTime? exchangeRateEffectiveDate { get; set; }

        /// <summary>
        /// Sets the POS Lane Code sent by the User for this document.
        /// </summary>
        public String posLaneCode { get; set; }

        /// <summary>
        /// BusinessIdentificationNo
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// Specifies if the Transaction has the seller as IsSellerImporterOfRecord
        /// </summary>
        public Boolean? isSellerImporterOfRecord { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String email { get; set; }

        /// <summary>
        /// If the user wishes to request additional debug information from this transaction, specify a level higher than 'normal'
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
