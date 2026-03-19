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
    /// The output model for report parameter definitions
    /// </summary>
    public class ReportParametersModel
    {
        /// <summary>
        /// The start date filter used for your report
        /// </summary>
        public DateTime? startDate { get; set; }

        /// <summary>
        /// The end date filter used for your report
        /// </summary>
        public DateTime? endDate { get; set; }

        /// <summary>
        /// The country filter used for your report
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The state filter used for your report
        /// </summary>
        public String state { get; set; }

        /// <summary>
        /// The date type filter used for your report
        /// </summary>
        public String dateFilter { get; set; }

        /// <summary>
        /// The doc type filter used for your report
        /// </summary>
        public String docType { get; set; }

        /// <summary>
        /// The date format used for your report
        /// </summary>
        public String dateFormat { get; set; }

        /// <summary>
        /// The currency code used for your report
        /// </summary>
        public String currencyCode { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 02/18/2026, Version: 26.3.0, Message: This field is deprecated. Please do not use it. This will be removed from the model on 08/18/2027.
        /// Number of partitions to split the report into.
        /// </summary>
        public Int32? numberOfPartitions { get; set; }

        /// <summary>
        /// DEPRECATED - Date: 02/18/2026, Version: 26.3.0, Message: This field is deprecated. Please do not use it. This will be removed from the model on 08/18/2027.
        /// The zero-based partition number to retrieve in this export request.
        /// </summary>
        public Int32? partition { get; set; }

        /// <summary>
        /// If true, include only documents that are locked.
        /// If false, include only documents that are not locked.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? isLocked { get; set; }

        /// <summary>
        /// If set, include only documents associated with this merchantSellerId.
        /// </summary>
        public String merchantSellerId { get; set; }

        /// <summary>
        /// The Document status filter used for report
        /// For documentStatus, accepted values are: Temporary, Saved, Posted, Committed, Cancelled, Adjusted, Queued, PendingApproval
        /// </summary>
        public String documentStatus { get; set; }

        /// <summary>
        /// If true, modified date will be same as document date
        /// If false, modified date will not be same as document date
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
        /// 
        /// </summary>
        public LiabilityParametersModel liabilityParameters { get; set; }

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
        /// If true, shows all transactions that are in the incorrect currency.
        /// If false, hides all transactions that are in the incorrect currency.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? incorrectCurrencyOnly { get; set; }

        /// <summary>
        /// If true, shows all additional transaction attributes.
        /// If false, hides all additional transaction attributes.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? includeAdditionalAttributes { get; set; }

        /// <summary>
        /// If true, shows all user defined fields.
        /// If false, hides all user defined fields.
        /// Defaults to false if not specified.
        /// </summary>
        public Boolean? includeUserDefinedFields { get; set; }

        /// <summary>
        /// Sets the ImportId for Accounts Payable reports.
        /// Defaults to an empty string if not specified.
        /// </summary>
        public String importId { get; set; }

        /// <summary>
        /// If true, filter using the user-defined field at the document line level.
        /// If false, filter using the user-defined field at the document level.
        /// Defaults to true if not specified.
        /// </summary>
        public Boolean? filterAtLineLevel { get; set; }

        /// <summary>
        /// Sets a user-defined field filter as a name/value pair.
        /// Only one name/value pair is allowed.
        /// Returns null if both name and value are not set.
        /// </summary>
        public object udfFilter { get; set; }

        /// <summary>
        /// The names of the jurisdictions for which document lines are fetched.
        /// Defaults to null if not specified.
        /// </summary>
        public List<String> jurisdictionNames { get; set; }


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
