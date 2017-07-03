using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Collections;

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
    [Guid("3a1ce78a-e421-44eb-88c5-b287cd309f7f")]
    [ComVisible(true)]
    /// <summary>
    /// A single transaction - for example, a sales invoice or purchase order.
    /// </summary>
    public class TransactionModel
    {
        [DispId(1)]
        /// <summary>
        /// The unique ID number of this transaction.
        /// </summary>
        public Int64? id { get; set; }

         [DispId(2)]
        /// <summary>
        /// A unique customer-provided code identifying this transaction.
        /// </summary>
        public String code { get; set; }

         [DispId(3)]
        /// <summary>
        /// The unique ID number of the company that recorded this transaction.
        /// </summary>
        public Int32? companyId { get; set; }

        /// <summary>
        /// The date on which this transaction occurred.
        /// </summary>
        public DateTime? date { get; set; }

        /// <summary>
        /// The date when payment was made on this transaction. By default, this should be the same as the date of the transaction.
        /// </summary>
        public DateTime? paymentDate { get; set; }

        /// <summary>
        /// The status of the transaction.
        /// </summary>
        public DocumentStatus? status { get; set; }

        /// <summary>
        /// The type of the transaction. For Returns customers, a transaction type of "Invoice" will be reported to the tax authorities.
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
        /// The customer usage type for this transaction. Customer usage types often affect exemption or taxability rules.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// CustomerVendorCode
        /// </summary>
        public String customerVendorCode { get; set; }

        /// <summary>
        /// If this transaction was exempt, this field will contain the word "Exempt".
        /// </summary>
        public String exemptNo { get; set; }

        /// <summary>
        /// If this transaction has been reconciled against the company's ledger, this value is set to true.
        /// </summary>
        public Boolean? reconciled { get; set; }

        /// <summary>
        /// If this transaction was made from a specific reporting location, this is the code string of the location.
        /// For customers using Returns, this indicates how tax will be reported according to different locations on the tax forms.
        /// </summary>
        public String locationCode { get; set; }

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
        public TaxOverrideTypeId? taxOverrideType { get; set; }

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
        /// The total tax calculated for all lines in this transaction.
        /// </summary>
        public Decimal? totalTax { get; set; }

        /// <summary>
        /// The portion of the total amount of this transaction that was taxable.
        /// </summary>
        public Decimal? totalTaxable { get; set; }

        /// <summary>
        /// If a tax override was applied to this transaction, indicates the amount of tax Avalara calculated for the transaction.
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
        /// If true, this seller was considered the importer of record of a product shipped internationally.
        /// </summary>
        public Boolean? isSellerImporterOfRecord { get; set; }

        /// <summary>
        /// Description of this transaction.
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

         [DispId(100)] // this should be assigned to all properties in the class
        /// <summary>
        /// some consumers do not understand List enumerables, hence we mimic the list using array. Please check implementation
        /// Optional: A list of line items in this transaction. To fetch this list, add the query string "?$include=Lines" or "?$include=Details" to your URL.
        /// </summary>
        public TransactionLinesModel lines { get; set; }

        /// <summary>
        /// Optional: A list of line items in this transaction. To fetch this list, add the query string "?$include=Addresses" to your URL.
        /// </summary>
        public List<TransactionAddressModel> addresses { get; set; }

        /// <summary>
        /// Optional: A list of location types in this transaction. To fetch this list, add the query string "?$include=Addresses" to your URL.
        /// </summary>
        public List<TransactionLocationTypeModel> locationTypes { get; set; }

        /// <summary>
        /// If this transaction has been adjusted, this list contains all the previous versions of the document.
        /// </summary>
        public List<TransactionModel> history { get; set; }

        /// <summary>
        /// Contains a summary of tax on this transaction.
        /// </summary>
        public List<TransactionSummary> summary { get; set; }

        /// <summary>
        /// Contains a list of extra parameters that were set when the transaction was created.
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }

        /// <summary>
        /// List of informational and warning messages regarding this API call. These messages are only relevant to the current API call.
        /// </summary>
        public List<AvaTaxMessage> messages { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }

    [Guid("57c191fc-548c-4161-b42d-6db3bb85ad85")]
    [ComVisible(true)]
    public class TransactionLinesModel : BaseArrayList
    {
        //   public int LineNo { get; set; }

        internal TransactionLinesModel() { }

        /// <include file='TaxSvc.Doc.xml' path='adapter/Lines/members[@name="Add"]/*' />
        [DispId(30)]
        public void Add(TransactionLineModel line)
        {
            //we hide the base member so that we can strongly type our parameter
            try
            {
                base.Add(line);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException("line", "Cannot add a null line to the collection.");
            }

        }

        /// <include file='TaxSvc.Doc.xml' path='adapter/Lines/members[@name="this"]/*' />
        [DispId(0)]
        public new TransactionLineModel this[int index]
        {
            get
            {
                //we hide the base member so that we can strongly type our returned object
                return (TransactionLineModel)base[index];
            }
        }

        /// <include file='TaxSvc.Doc.xml' path='adapter/Lines/members[@name="Clear"]/*' />
        [DispId(31)]
        public new void Clear()
        {
            base.Clear();
        }

        /// <include file='TaxSvc.Doc.xml' path='adapter/Lines/members[@name="GetItemByNo"]/*' />
        [DispId(32)]
        public TransactionLineModel GetItemByNo(string lineNo)
        {
            TransactionLineModel item = null;

            foreach (TransactionLineModel line in base.List)
            {
                if (line.lineNumber == lineNo)
                {
                    item = line;
                    break;
                }
            }

            return item;
        }

    }

    [Guid("e8760780-5b11-4945-923c-57ac3217c616")]
    [ComVisible(true)]
    public class BaseArrayList
    {
        //Wrap an arraylist in our own class to limit the methods available
        //    and control inputs (force to be of strongly typed).
        ArrayList _list = new ArrayList();

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/common/members[@name="InternalConstructor"]/*' />
        internal BaseArrayList()
        {
            //not publicly creatable
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="List"]/*' />
        //no dispatch id because protected
        protected ArrayList List
        {
            get { return _list; }
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="GetEnumerator"]/*' />
        [DispId(-4)]
        public virtual System.Collections.IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="Count"]/*' />
        [DispId(20)]
        public virtual int Count
        {
            get
            {
                return _list.Count;
            }
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="this"]/*' />
        //no dispatch id because protected
        protected virtual Object this[int index]
        {
            get
            {
                return _list[index];
            }
        }

        //Any class derived from BaseCollection must implement its own Add function and invoke this one
        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="Add"]/*' />
        //no dipatch id because protected
        protected virtual void Add(Object item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "A null object cannot be added to a collection.");
            }
            _list.Add(item);
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/BaseCollection/members[@name="Clear"]/*' />
        //no dispatch id because protected
        protected void Clear()
        {
            if (_list != null)
            {
                _list.Clear();
            }
        }

        /// <include file='Avalara.AvaTax.Adapter.Doc.xml' path='adapter/common/members[@name="Finalize"]/*' />
        ~BaseArrayList()
        {
            Clear();
            _list = null;
        }
    }
}
