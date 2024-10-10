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
    /// An input model for executing a report detailed to the document line level
    /// </summary>
    public class ExportDocumentLineModel
    {
        /// <summary>
        /// The file format.
        /// </summary>
        public ReportFormat? format { get; set; }

        /// <summary>
        /// The start date filter for report execution. If no date provided, same date of last month will be used as the startDate.
        /// Accepts date in short format yyyy-mm-dd as well as date time stamp
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// The end date filter for report execution. If no date provided, today's date will be used as the endDate.
        /// Accepts date in short format yyyy-mm-dd as well as date time stamp
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The transactions in the country you wish to run a report.
        /// Use "ALL" for all countries
        /// Use "ALL Non-US" for all international countries
        /// Or use a single 2-char ISO country code
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state associated with the transactions you wish to run a report.
        /// Use "ALL" for all states or 2-char state code.
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The type of date to filter your transactions
        /// </summary>
        public ReportDateFilter? dateFilter { get; set; }

        /// <summary>
        /// The transaction type you want to run a report on
        /// </summary>
        public ReportDocType? docType { get; set; }

        /// <summary>
        /// The currency your report is displayed in.
        /// Accepts "USD" or leave this blank to get all the documents with all the currencies
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// Number of partitions (2 - 250) to split the report into.
        /// If a value is provided for this property, a value must also be provided for the partition property.
        /// </summary>
        public Int32? numberOfPartitions { get; set; }

        /// <summary>
        /// The zero-based partition number to retrieve in this export request.
        /// If a value is provided for this property, a value must also be provided for the numberOfPartitions property.
        /// </summary>
        public Int32? partition { get; set; }

        /// <summary>
        /// If true, include only documents that are locked.
        /// If false, include only documents that are not locked.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? isLocked { get; set; }

        /// <summary>
        /// If set, include only documents associated with these merchantSellerIds.Multiple merchantSellerIds should be sent by comma separated values.
        /// </summary>
        public String merchantSellerIdentifier { get; set; }

        /// <summary>
        /// DocumentStatus
        /// For documentStatus, accepted values are: Saved, Posted, Committed, Cancelled
        /// </summary>
        public DocumentStatus? documentStatus { get; set; }

        /// <summary>
        /// Use this parameter when dateFilter = ModifiedDate.
        /// For dateFilter = DocumentDate, PaymentDate, TaxDate or ReportingDate, the isModifiedDateSameAsDocumentDate parameter is ignored.
        /// Set this parameter to true when you would like to get Documents which have the Document Date same as Modified Date.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? isModifiedDateSameAsDocumentDate { get; set; }

        /// <summary>
        /// TaxGroup is required to support Sales tax (Sales + SellersUse) and VAT (Input+ Output).
        /// TaxTypes, such as Lodging, Bottle, LandedCost, Ewaste, BevAlc, etc
        /// </summary>
        public String taxGroup { get; set; }

        /// <summary>
        /// The description of the tax
        /// </summary>
        public String taxName { get; set; }

        /// <summary>
        /// The AvaTax tax code or customer tax code associated with the item or SKU in the transaction
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// The code your business application uses to identify a customer or vendor
        /// </summary>
        public String customerVendorCode { get; set; }

        /// <summary>
        /// Defines the individual taxes associated with a TaxType category, such as Lodging TaxType which supports numerous TaxSubTypes, including Hotel, Occupancy, ConventionCenter, Accommotations, etc.
        /// </summary>
        public String taxSubType { get; set; }

        /// <summary>
        /// Defines report source.
        /// </summary>
        public ReportSource? reportSource { get; set; }

        /// <summary>
        /// Defines the compression mode of the result file
        /// For compression, the accepted values are: NONE, GZIP
        /// </summary>
        public Compression? compression { get; set; }

        /// <summary>
        /// If true, include document line details in the generated report.
        /// If false, include only document line in the generated report.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? includeDocumentLineDetails { get; set; }

        /// <summary>
        /// If true, include multi tax line details in the generated report.
        /// If false, include document or document line in the generated report based on includeDocumentLineDetails.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? includeMultiTaxLineDetails { get; set; }


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
