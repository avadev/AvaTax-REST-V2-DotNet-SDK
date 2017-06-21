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
    /// Represents one line item in a multi company transaction
    /// </summary>
    public class MultiCompanyLineItemModel
    {
        /// <summary>
        /// Company Code - Specify the code of the company for this line of transaction. If you leave this value null,
        /// the company code at document level will be used instead.
        /// </summary>
        public String companyCode { get; set; }

        /// <summary>
        /// Sets the sale location code (Outlet ID) for reporting this document to the tax authority.
        /// </summary>
        public String reportingLocationCode { get; set; }

        /// <summary>
        /// Line number within this document
        /// </summary>
        public String number { get; set; }

        /// <summary>
        /// Quantity of items in this line
        /// </summary>
        public Decimal quantity { get; set; }

        /// <summary>
        /// Total amount for this line
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
        /// Customer Usage Type - The client application customer or usage type.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// Item Code (SKU)
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// Exemption number for this line
        /// </summary>
        public String exemptionCode { get; set; }

        /// <summary>
        /// True if the document discount should be applied to this line
        /// </summary>
        public Boolean? discounted { get; set; }

        /// <summary>
        /// Indicates if line has Tax Included; defaults to false
        /// </summary>
        public Boolean? taxIncluded { get; set; }

        /// <summary>
        /// Revenue Account
        /// </summary>
        public String revenueAccount { get; set; }

        /// <summary>
        /// Reference 1 - Client specific reference field
        /// </summary>
        public String ref1 { get; set; }

        /// <summary>
        /// Reference 2 - Client specific reference field
        /// </summary>
        public String ref2 { get; set; }

        /// <summary>
        /// Item description. This is required for SST transactions if an unmapped ItemCode is used.
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
        /// Specifies a tax override for this line
        /// </summary>
        public TaxOverrideModel taxOverride { get; set; }

        /// <summary>
        /// Special parameters that apply to this line within this transaction.
        /// To get a full list of available parameters, please use the /api/v2/definitions/parameters endpoint.
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }


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
