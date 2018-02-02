using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
#if NET45 || NETSTANDARD1_6
using System.Threading.Tasks;
#endif

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// TransactionBuilder helps you construct a new transaction using a fluent interface
    /// </summary>
    public class TransactionBuilder
    {
        private CreateTransactionModel _model;
        private int _line_number;
        private AvaTaxCompatibleClient _client;

        #region Constructor
        /// <summary>
        /// TransactionBuilder helps you construct a new transaction using a fluent interface
        /// </summary>
        /// <param name="client">The AvaTaxClient object to use to create this transaction</param>
        /// <param name="companyCode">The code of the company for this transaction</param>
        /// <param name="type">The type of transaction to create</param>
        /// <param name="customerCode">The customer code for this transaction</param>
        public TransactionBuilder(AvaTaxCompatibleClient client, string companyCode, DocumentType type, string customerCode)
        {
            _model = new CreateTransactionModel
            {
                companyCode = companyCode,
                customerCode = customerCode,
                date = DateTime.UtcNow,
                type = type,
                lines = new List<LineItemModel>()
            };
            _line_number = 1;
            _client = client;
        }
        #endregion

        #region Builder Pattern
        /// <summary>
        /// Set the commit flag of the transaction.
        /// </summary>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithCommit()
        {
            _model.commit = true;
            return this;
        }

        /// <summary>
        /// Enable diagnostic information
        /// </summary>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithDiagnostics()
        {
            _model.debugLevel = TaxDebugLevel.Diagnostic;
            return this;
        }

        /// <summary>
        /// Specify a specific usage type for the entire transaction
        /// </summary>
        /// <param name="usageType"></param>
        /// <returns></returns>
        public TransactionBuilder WithUsageType(string usageType)
        {
            _model.customerUsageType = usageType;
            return this;
        }

        /// <summary>
        /// Set a specific discount amount
        /// </summary>
        /// <param name="discount">The amount of the discount to grant</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithDiscountAmount(decimal? discount)
        {
            _model.discount = discount;
            return this;
        }

        /// <summary>
        /// Set if discount is applicable for the current line
        /// </summary>
        /// <param name="discounted">Sets the "discount" flag on the most recently created line</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithItemDiscount(bool? discounted)
        {
            var l = GetMostRecentLine("WithItemDiscount");
            l.discounted = discounted;
            return this;
        }

        /// <summary>
        /// Set a specific transaction code
        /// </summary>
        /// <param name="code">The code to use for this transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithTransactionCode(string code)
        {
            _model.code = code;
            return this;
        }

        /// <summary>
        /// Set the document type
        /// </summary>
        /// <param name="type">The document type of this transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithType(DocumentType type)
        {
            _model.type = type;
            return this;
        }

        /// <summary>
        /// Add a parameter at the document level
        /// </summary>
        /// <param name="name">The parameter name.  For a list of valid parameter names, call AvaTaxClient.ListParameters()</param>
        /// <param name="value">The value for this parameter</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithParameter(string name, string value)
        {
            if (_model.parameters == null) _model.parameters = new Dictionary<string, string>();
            _model.parameters[name] = value;
            return this;
        }

        /// <summary>
        /// Add a parameter to the current line
        /// </summary>
        /// <param name="name">The parameter name.  For a list of valid parameter names, call AvaTaxClient.ListParameters()</param>
        /// <param name="value">The value for this parameter</param>
        /// <returns></returns>
        public TransactionBuilder WithLineParameter(string name, string value)
        {
            var l = GetMostRecentLine("WithLineParameter");
            if (l.parameters == null) l.parameters = new Dictionary<string, string>();
            l.parameters.Add(name, value);
            return this;
        }

        /// <summary>
        /// Add an address to this transaction
        /// </summary>
        /// <param name="type">Address Type. Can be ShipFrom, ShipTo, PointOfOrderAcceptance, PointOfOrderOrigin, SingleLocation.</param>
        /// <param name="line1">The street address, attention line, or business name of the location.</param>
        /// <param name="line2">The street address, business name, or apartment/unit number of the location.</param>
        /// <param name="line3">The street address or apartment/unit number of the location.</param>
        /// <param name="city">City of the location.</param>
        /// <param name="region">State or Region of the location.</param>
        /// <param name="postalCode">Postal/zip code of the location.</param>
        /// <param name="country">The two-letter country code of the location.</param>
        /// <returns></returns>
        public TransactionBuilder WithAddress(TransactionAddressType type, string line1, string line2, string line3, string city, string region, string postalCode, string country)
        {
            if (_model.addresses == null) _model.addresses = new AddressesModel();
            var ai = new AddressLocationInfo
            {
                line1 = line1,
                line2 = line2,
                line3 = line3,
                city = city,
                region = region,
                postalCode = postalCode,
                country = country
            };
            SetAddress(_model.addresses, type, ai);
            return this;
        }

        /// <summary>
        /// Add an address to this transaction using an existing company location code.
        /// 
        /// AvaTax will search for a company location whose code matches the `locationCode` parameter and use the address
        /// of that location.
        /// </summary>
        /// <param name="type">Address Type. Can be ShipFrom, ShipTo, PointOfOrderAcceptance, PointOfOrderOrigin, SingleLocation.</param>
        /// <param name="locationCode">The location code of the location to use as this address.</param>
        /// <returns></returns>
        public TransactionBuilder WithAddress(TransactionAddressType type, string locationCode)
        {
            if (_model.addresses == null) _model.addresses = new AddressesModel();
            var ai = new AddressLocationInfo
            {
                locationCode = locationCode
            };
            SetAddress(_model.addresses, type, ai);
            return this;
        }

        /// <summary>
        /// Set a specific address type for an address object
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="type"></param>
        /// <param name="ai"></param>
        public static void SetAddress(AddressesModel addresses, TransactionAddressType type, AddressLocationInfo ai)
        {
            switch (type)
            {
                case TransactionAddressType.PointOfOrderAcceptance:
                    addresses.pointOfOrderAcceptance = ai;
                    break;
                case TransactionAddressType.PointOfOrderOrigin:
                    addresses.pointOfOrderOrigin = ai;
                    break;
                case TransactionAddressType.ShipFrom:
                    addresses.shipFrom = ai;
                    break;
                case TransactionAddressType.ShipTo:
                    addresses.shipTo = ai;
                    break;
                case TransactionAddressType.SingleLocation:
                    addresses.singleLocation = ai;
                    break;
            }
        }

        /// <summary>
        /// Add a geocoded location address to this transaction
        /// </summary>
        /// <param name="type"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public TransactionBuilder WithLatLong(TransactionAddressType type, decimal latitude, decimal longitude)
        {
            if (_model.addresses == null) _model.addresses = new AddressesModel();
            var ai = new AddressLocationInfo
            {
                latitude = latitude,
                longitude = longitude
            };
            SetAddress(_model.addresses, type, ai);
            return this;
        }

        /// <summary>
        /// Add an address to this line
        /// </summary>
        /// <param name="type">Address Type. Can be ShipFrom, ShipTo, PointOfOrderAcceptance, PointOfOrderOrigin, SingleLocation.</param>
        /// <param name="line1">Street address, attention line, or business name of the location.</param>
        /// <param name="line2">Street address, business name, or apartment/unit number of the location.</param>
        /// <param name="line3">Street address or apartment/unit number of the location.</param>
        /// <param name="city">City of the location.</param>
        /// <param name="region">State or Region of the location.</param>
        /// <param name="postalCode">Postal/zip code of the location.</param>
        /// <param name="country">Two-letter country code of the location.</param>
        /// <returns></returns>
        public TransactionBuilder WithLineAddress(TransactionAddressType type, string line1, string line2, string line3, string city, string region, string postalCode, string country)
        {
            var line = GetMostRecentLine("WithLineAddress");
            if (line.addresses == null) line.addresses = new AddressesModel();
            var ai = new AddressLocationInfo
            {
                line1 = line1,
                line2 = line2,
                line3 = line3,
                city = city,
                region = region,
                postalCode = postalCode,
                country = country
            };
            SetAddress(line.addresses, type, ai);
            return this;
        }

        /// <summary>
        /// Add a document-level Tax Override to the transaction.
        ///  - A TaxDate override requires a valid DateTime object to be passed.
        /// TODO: Verify Tax Override constraints and add exceptions.
        /// </summary>
        /// <param name="type">Type of the Tax Override.</param>
        /// <param name="reason">Reason of the Tax Override.</param>
        /// <param name="taxAmount">Amount of tax to apply. Required for a TaxAmount Override.</param>
        /// <param name="taxDate">Date of a Tax Override. Required for a TaxDate Override.</param>
        /// <returns></returns>
        public TransactionBuilder WithTaxOverride(TaxOverrideType type, string reason, decimal taxAmount = 0, DateTime? taxDate = null)
        {
            _model.taxOverride = new TaxOverrideModel
            {
                type = type,
                reason = reason,
                taxAmount = taxAmount,
                taxDate = taxDate
            };

            // Continue building
            return this;
        }

        /// <summary>
        /// Add a line-level Tax Override to the current line.
        ///  - A TaxDate override requires a valid DateTime object to be passed.
        /// TODO: Verify Tax Override constraints and add exceptions.
        /// </summary>
        /// <param name="type">Type of the Tax Override.</param>
        /// <param name="reason">Reason of the Tax Override.</param>
        /// <param name="taxAmount">Amount of tax to apply. Required for a TaxAmount Override.</param>
        /// <param name="taxDate">Date of a Tax Override. Required for a TaxDate Override.</param>
        /// <returns></returns>
        public TransactionBuilder WithLineTaxOverride(TaxOverrideType type, string reason, decimal taxAmount = 0, DateTime? taxDate = null)
        {
            // Address the DateOverride constraint.
            if (type.Equals(TaxOverrideType.TaxDate) && taxDate == null)
            {
                throw new Exception("A valid date is required for a TaxDate Tax Override.");
            }

            var line = GetMostRecentLine("WithLineTaxOverride");
            line.taxOverride = new TaxOverrideModel
            {
                type = type,
                reason = reason,
                taxAmount = taxAmount,
                taxDate = taxDate
            };

            // Continue building
            return this;
        }

        /// <summary>
        /// Add a line to this transaction
        /// </summary>
        /// <param name="amount">Value of the item.</param>
        /// <param name="quantity">Quantity of the item.</param>
        /// <param name="taxCode">Tax Code of the item. If left blank, the default item (P0000000) is assumed.  Use ListTaxCodes() for a list of values.</param>
        /// <param name="customerUsageType">The intended usage type for this line.  Use ListEntityUseCodes() for a list of values.</param>
        /// <param name="description">A friendly description of this line item.</param>
        /// <param name="itemCode">The item code of this item in your product item definitions.</param>
        /// <returns></returns>
        public TransactionBuilder WithLine(decimal amount, decimal quantity = 1, string taxCode = null, string description = null, string itemCode = null, string customerUsageType = null)
        {
            var l = new LineItemModel
            {
                number = _line_number.ToString(),
                quantity = quantity,
                amount = amount,
                taxCode = taxCode,
                description = description,
                itemCode = itemCode,
                customerUsageType = customerUsageType
            };

            _model.lines.Add(l);
            _line_number++;

            // Continue building
            return this;
        }

        /// <summary>
        /// Add a line to this transaction
        /// </summary>
        /// <param name="amount">Value of the item.</param>
        /// <param name="type">Address Type. Can be ShipFrom, ShipTo, PointOfOrderAcceptance, PointOfOrderOrigin, SingleLocation.</param>
        /// <param name="line1">Street address, attention line, or business name of the location.</param>
        /// <param name="line2">Street address, business name, or apartment/unit number of the location.</param>
        /// <param name="line3">Street address or apartment/unit number of the location.</param>
        /// <param name="city">City of the location.</param>
        /// <param name="region">State or Region of the location.</param>
        /// <param name="postalCode">Postal/zip code of the location.</param>
        /// <param name="country">Two-letter country code of the location.</param>
        /// <returns></returns>
        public TransactionBuilder WithSeparateAddressLine(decimal amount, TransactionAddressType type, string line1, string line2, string line3, string city, string region, string postalCode, string country)
        {
            var l = new LineItemModel
            {
                number = _line_number.ToString(),
                quantity = 1,
                amount = amount,
                addresses = new AddressesModel()
            };

            // Add this address
            var ai = new AddressLocationInfo
            {
                line1 = line1,
                line2 = line2,
                line3 = line3,
                city = city,
                region = region,
                postalCode = postalCode,
                country = country
            };
            SetAddress(l.addresses, type, ai);

            // Put this line in the model
            _model.lines.Add(l);
            _line_number++;

            // Continue building
            return this;
        }

        /// <summary>
        /// Add a line with an exemption to this transaction
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="exemptionCode"></param>
        /// <returns></returns>
        public TransactionBuilder WithExemptLine(decimal amount, string exemptionCode)
        {
            var l = new LineItemModel
            {
                number = _line_number.ToString(),
                quantity = 1,
                amount = amount,
                exemptionCode = exemptionCode
            };
            _model.lines.Add(l);
            _line_number++;

            // Continue building
            return this;
        }

        /// <summary>
        /// Add the Ref1 [and Ref2] field to the current line.
        /// 
        /// Used for user-side reporting.
        /// Does not affect tax calculation.
        /// </summary>
        /// <param name="ref1"></param>
        /// <param name="ref2"></param>
        /// <returns></returns>
        public TransactionBuilder WithLineReference(string ref1, string ref2 = null)
        {
            var line = GetMostRecentLine("WithLineReference");
            line.ref1 = ref1;
            line.ref2 = ref2;

            // Continue building
            return this;
        }

        /// <summary>
        /// Set the transaction date
        /// </summary>
        /// <param name="date">The date of the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithDate(DateTime date)
        {
            _model.date = date;
            return this;
        }

        /// <summary>
        /// Set the salesperson code
        /// </summary>
        /// <param name="salespersonCode">The salesperson code associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithSalespersonCode(string salespersonCode)
        {
            _model.salespersonCode = salespersonCode;
            return this;
        }

        /// <summary>
        /// Set the purchase order number
        /// </summary>
        /// <param name="purchaseOrderNumber">The purchase order number associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithPurchaseOrderNumber(string purchaseOrderNumber)
        {
            _model.purchaseOrderNo = purchaseOrderNumber;
            return this;
        }

        /// <summary>
        /// Set the exemption number
        /// </summary>
        /// <param name="exemptionNumber">Theexemption associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithExemptionNumber(string exemptionNumber)
        {
            _model.exemptionNo = exemptionNumber;
            return this;
        }

        /// <summary>
        /// Set the reference code.
        /// 
        /// Used to reference the original document for a return invoice.
        /// </summary>
        /// <param name="referenceCode">The reference code associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithReferenceCode(string referenceCode)
        {
            _model.referenceCode = referenceCode;
            return this;
        }

        /// <summary>
        /// Set the reporting location code.
        /// 
        /// Used to reference the sale location code (Outlet ID) for reporting purposes.
        /// </summary>
        /// <param name="reportingLocationCode">The reporting location code associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithReportingLocationCode(string reportingLocationCode)
        {
            _model.reportingLocationCode = reportingLocationCode;
            return this;
        }

        /// <summary>
        /// Set the batch code.
        /// 
        /// TODO: Is this something we want/need to expose?
        /// </summary>
        /// <param name="batchCode">The batch code associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithBatchCode(string batchCode)
        {
            _model.batchCode = batchCode;
            return this;
        }

        /// <summary>
        /// Set a 3 character ISO 4217 currency code
        /// </summary>
        /// <param name="currencyCode">The currency code to be used with this transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithCurrencyCode(string currencyCode)
        {
            _model.currencyCode = currencyCode;
            return this;
        }

        /// <summary>
        /// Set the service mode of the transaction.
        /// 
        /// The mode can be set to:
        /// Automatic (default), Local, or Remote. 
        /// </summary>
        /// <param name="serviceMode">The service mode of the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithServiceMode(ServiceMode serviceMode)
        {
            _model.serviceMode = serviceMode;
            return this;
        }

        /// <summary>
        /// Set the exchange rate of the transaction.
        /// 
        /// This is the exchange rate between this transaction's currency to the company's base currency.
        /// </summary>
        /// <param name="exchangeRate">The exchange rate between this transaction and the company base currency</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithExchangeRate(decimal exchangeRate)
        {
            _model.exchangeRate = exchangeRate;
            return this;
        }

        /// <summary>
        /// Set the exchange rate date of the transaction.
        /// 
        /// This specifies the effective date of the exchange rate.
        /// </summary>
        /// <param name="exchangeRateEffectiveDate">The exchange rate effective date of this transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithExchangeRateEffectiveDate(DateTime exchangeRateEffectiveDate)
        {
            _model.exchangeRateEffectiveDate = exchangeRateEffectiveDate;
            return this;
        }

        /// <summary>
        /// Set the point of sale lane code of the transaction
        /// </summary>
        /// <param name="posLaneCode">The point of sale lane code associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithPointOfSaleLaneCode(string posLaneCode)
        {
            _model.posLaneCode = posLaneCode;
            return this;
        }

        /// <summary>
        /// Set the business identification number of the transaction
        /// </summary>
        /// <param name="businessIdentificationNumber">The business identification number associated with the company</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithBusinessIdentificationNumber(string businessIdentificationNumber)
        {
            _model.businessIdentificationNo = businessIdentificationNumber;
            return this;
        }

        /// <summary>
        /// Enable the `seller importer of record` flag
        /// </summary>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithSellerImporterOfRecord()
        {
            _model.isSellerImporterOfRecord = true;
            return this;
        }

        /// <summary>
        /// Set the description of the transaction
        /// </summary>
        /// <param name="description">The desciption of the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithDescription(string description)
        {
            _model.description = description;
            return this;
        }

        /// <summary>
        /// Set the email of the transaction
        /// </summary>
        /// <param name="email">The email associated with the transaction</param>
        /// <returns>The TransactionBuilder object</returns>
        public TransactionBuilder WithEmail(string email)
        {
            _model.email = email;
            return this;
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Checks to see if the current model has a line.
        /// </summary>
        /// <param name="memberName">The name of the method called that needs the line</param>
        /// <returns>The line object</returns>
        private LineItemModel GetMostRecentLine(string memberName = "")
        {
            if (_model.lines.Count <= 0)
            {
                throw new InvalidOperationException($"No lines have been added. The {memberName} method applies to the most recent line." +
                                    " To use this function, first add a line.");
            }

            return _model.lines[_model.lines.Count - 1];
        }
        #endregion

        #region Create 
#if NET45 || NETSTANDARD1_6
        /// <summary>
        /// Create this transaction
        /// </summary>
        /// <returns></returns>
        public async Task<TransactionModel> CreateAsync()
        {
            var r = _client.CreateTransaction(null, _model);
            r.CheckAndThrow();
            return r.Deserialize<TransactionModel>();
        }

        /// <summary>
        /// Create this transaction
        /// </summary>
        /// <returns></returns>
        public TransactionModel Create()
        {
            var r = _client.CreateTransaction(null, _model);
            r.CheckAndThrow();
            return r.Deserialize<TransactionModel>();
        }
#else
        /// <summary>
        /// Create this transaction
        /// </summary>
        /// <returns></returns>
        public TransactionModel Create()
        {
            var r = _client.CreateTransaction(null, _model);
            r.CheckAndThrow();
            return r.Deserialize<TransactionModel>();
        }
#endif

        /// <summary>
        /// Return the current CreateTransactionModel but do not call AvaTax to record the transaction.
        /// 
        /// If you would like to perform additional modifications to this object beyond the fluent 
        /// interface, you can use this function to return the currently assembled model and then make
        /// additional changes to it.
        /// </summary>
        /// <returns></returns>
        public CreateTransactionModel GetCreateTransactionModel()
        {
            return _model;
        }

        /// <summary>
        /// For using this with an adjustment
        /// </summary>
        /// <param name="desc">The descriptive reason why this transaction is being adjusted</param>
        /// <param name="reason">The reason code why this transaction is being adjusted</param>
        /// <returns></returns>
        public AdjustTransactionModel CreateAdjustmentRequest(string desc, AdjustmentReason reason)
        {
            return new AdjustTransactionModel
            {
                newTransaction = _model,
                adjustmentDescription = desc,
                adjustmentReason = reason
            };
        }
        #endregion
    }
}