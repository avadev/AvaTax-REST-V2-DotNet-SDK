using System;

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
    /// Represents a error code message
    /// </summary>
    public enum ErrorCodeId
    {
        /// <summary>
        /// Server configuration problem with one of the servers in cluster
        /// </summary>
        ServerConfiguration = 1,

        /// <summary>
        /// Account that does not exist.
        /// </summary>
        AccountInvalidException = 2,

        /// <summary>
        /// Company that does not exist
        /// </summary>
        CompanyInvalidException = 3,

        /// <summary>
        /// Object does not exist
        /// </summary>
        EntityNotFoundError = 4,

        /// <summary>
        /// Did not provide a value in a required field
        /// </summary>
        ValueRequiredError = 5,

        /// <summary>
        /// Value outside of field's the range
        /// </summary>
        RangeError = 6,

        /// <summary>
        /// Out-of-bounds field value
        /// </summary>
        RangeCompareError = 7,

        /// <summary>
        ///  Value that was not permitted
        /// </summary>
        RangeSetError = 8,

        /// <summary>
        /// United States Taxpayer ID Number (TIN) not given
        /// </summary>
        TaxpayerNumberRequired = 9,

        /// <summary>
        /// The number of entities in the request exceeded the limit
        /// </summary>
        EntityLimitExceeded = 10,

        /// <summary>
        /// The password chosen is a commonly-guessed password and cannot be used
        /// </summary>
        CommonPassword = 11,

        /// <summary>
        /// The password you specified does not meet minimum complexity requirements
        /// </summary>
        WeakPassword = 12,

        /// <summary>
        /// One of the strings uploaded to the server is too long and cannot be saved.
        /// </summary>
        StringLengthError = 13,

        /// <summary>
        /// The string provided was too long for the field.
        /// </summary>
        MaxStringLengthError = 14,

        /// <summary>
        /// The string provided was too long for the field.
        /// </summary>
        EmailValidationError = 15,

        /// <summary>
        /// Must provide an email address with this request
        /// </summary>
        EmailMissingError = 16,

        /// <summary>
        /// A field in the query was not found
        /// </summary>
        InvalidQueryField = 17,

        /// <summary>
        /// The value provided for a query field is invalid
        /// </summary>
        InvalidQueryValue = 18,

        /// <summary>
        /// The filter parameter has a syntax error
        /// </summary>
        SyntaxError = 19,

        /// <summary>
        /// The filter parameter has too many values
        /// </summary>
        TooManyParametersError = 20,

        /// <summary>
        /// The filter parameter has too many values
        /// </summary>
        UnterminatedValueError = 21,

        /// <summary>
        /// A user account may not call DELETE on the user itself
        /// </summary>
        DeleteUserSelfError = 22,

        /// <summary>
        /// Attempted to reset a password but provided incorrect old password value
        /// </summary>
        OldPasswordInvalid = 23,

        /// <summary>
        /// Attempted to change passwords for a user who is not permitted to change their password
        /// </summary>
        CannotChangePassword = 24,

        /// <summary>
        /// Field value cannot be changed
        /// </summary>
        ReadOnly = 25,

        /// <summary>
        /// Date value provided was incorrectly formatted
        /// </summary>
        DateFormatError = 26,

        /// <summary>
        /// Account does not currently have a default company
        /// </summary>
        NoDefaultCompany = 27,

        /// <summary>
        /// TBD
        /// </summary>
        AccountTypeNotSupported = 28,

        /// <summary>
        /// TBD
        /// </summary>
        InvalidFirmClientOffer = 29,

        /// <summary>
        /// Credentials provided to AvaTax could not be validated
        /// </summary>
        AuthenticationException = 30,

        /// <summary>
        /// Account is not authorized to call this API
        /// </summary>
        AuthorizationException = 31,

        /// <summary>
        /// API call contained an incorrectly structured object
        /// </summary>
        ValidationException = 32,

        /// <summary>
        /// User account is currently inactive
        /// </summary>
        InactiveUserError = 33,

        /// <summary>
        /// API call did not contain authentication information
        /// </summary>
        AuthenticationIncomplete = 34,

        /// <summary>
        /// Basic authorization header was not encoded correctly
        /// </summary>
        BasicAuthIncorrect = 35,

        /// <summary>
        /// A problem was detected with Avalara Identity
        /// </summary>
        IdentityServerError = 36,

        /// <summary>
        /// Bearer Token that you used for authentication was not valid
        /// </summary>
        BearerTokenInvalid = 37,

        /// <summary>
        /// Required object not provided
        /// </summary>
        ModelRequiredException = 38,

        /// <summary>
        /// AvaTax account has expired, or is not yet enabled
        /// </summary>
        AccountExpiredException = 39,

        /// <summary>
        /// Attempted to request an object without necessary permissions
        /// </summary>
        VisibilityError = 40,

        /// <summary>
        /// Bearer Token authentication is not yet supported with this API
        /// </summary>
        BearerTokenNotSupported = 41,

        /// <summary>
        /// Security role does not have permission to create or update users
        /// </summary>
        InvalidSecurityRole = 42,

        /// <summary>
        /// The action you attempted is restricted
        /// </summary>
        InvalidRegistrarAction = 43,

        /// <summary>
        /// A remote server AvaTax depends on is not working
        /// </summary>
        RemoteServerError = 44,

        /// <summary>
        /// You provided a filter with your query, but did not specify any criteria
        /// </summary>
        NoFilterCriteriaException = 45,

        /// <summary>
        /// You provided a filter with your query, but did not specify any criteria
        /// </summary>
        OpenClauseException = 46,

        /// <summary>
        /// The JSON you sent with your request was invalid
        /// </summary>
        JsonFormatError = 47,

        /// <summary>
        /// A field in your request has too many decimal places or too many digits over all.
        /// </summary>
        InvalidDecimalValue = 48,

        /// <summary>
        /// TBD
        /// </summary>
        PermissionRequired = 49,

        /// <summary>
        /// The API you attempted to call resulted in an unhandled exception within Avalara AvaTax
        /// </summary>
        UnhandledException = 50,

        /// <summary>
        /// The account is currently inactive.
        /// </summary>
        InactiveAccount = 51,

        /// <summary>
        /// TBD	
        /// </summary>
        LinkageNotAllowed = 52,

        /// <summary>
        /// TBD
        /// </summary>
        LinkageStatusUpdateNotSupported = 53,

        /// <summary>
        /// A company that is designated to report taxes must have at least one designated contact person
        /// </summary>
        ReportingCompanyMustHaveContactsError = 60,

        /// <summary>
        /// This error occurs when you try to modify the tax profile of a company that inherits its tax profile from its parent.
        /// </summary>
        CompanyProfileNotSet = 61,

        /// <summary>
        /// Only Company-level users may be assigned to a company.
        /// </summary>
        CannotAssignUserToCompany = 62,

        /// <summary>
        /// Company level users must be assigned to a company within this account.
        /// </summary>
        MustAssignUserToCompany = 63,

        /// <summary>
        /// TBD
        /// </summary>
        InvalidTaxTypeMapping = 64,

        /// <summary>
        /// You provided an incorrectly structured object to AvaTax.
        /// </summary>
        ModelStateInvalid = 70,

        /// <summary>
        /// This error occurs when you create an object whose end date is before its effective date.
        /// </summary>
        DateRangeError = 80,

        /// <summary>
        /// You specified a date outside of the allowable range.
        /// </summary>
        InvalidDateRangeError = 81,

        /// <summary>
        /// A tax rule with type ProductTaxabilityRule cannot have a null tax code or be assigned to all tax codes.
        /// </summary>
        RuleMustHaveTaxCode = 82,

        /// <summary>
        /// You attempted to use a restricted tax rule type.
        /// </summary>
        RuleTypeRestricted = 83,

        /// <summary>
        /// The field isAllJuris cannot be set to true at this jurisdiction level.
        /// </summary>
        AllJurisRuleLimits = 84,

        /// <summary>
        /// You used a company location that does not exist.
        /// </summary>
        InvalidCompanyLocationSetting = 85,

        /// <summary>
        /// The adjustment type record permits only a specified list of values.
        /// </summary>
        InvalidAdjustmentType = 99,

        /// <summary>
        /// This message represents information provided about an object that was deleted.
        /// </summary>
        DeleteInformation = 100,

        /// <summary>
        /// You attempted to set a value that must be within a range, but your value was outside of the range.
        /// </summary>
        OutOfRange = 118,

        /// <summary>
        /// You specified a date/time value without a timezone.
        /// </summary>
        UnspecifiedTimeZone = 119,

        /// <summary>
        /// You may not create an object with a "Deleted" flag.
        /// </summary>
        CannotCreateDeletedObjects = 120,

        /// <summary>
        /// If an object has been deleted, you may not modify it further after its deletion.
        /// </summary>
        CannotModifyDeletedObjects = 121,

        /// <summary>
        /// You attempted to create a filing calendar for a return that is not recognized by AvaTax.
        /// </summary>
        ReturnNameNotFound = 122,

        /// <summary>
        /// When creating a location, you must specify a compatible AddressType and AddressCategory value.
        /// </summary>
        InvalidAddressTypeAndCategory = 123,

        /// <summary>
        /// The default location for a company must be a physical-type location rather than a salesperson-type location.
        /// </summary>
        DefaultCompanyLocation = 124,

        /// <summary>
        /// The country code you provided is not recognized as a valid ISO 3166 country code.
        /// </summary>
        InvalidCountry = 125,

        /// <summary>
        /// You specified a country/region that was not recognized by the ISO 3166 country/region code system.
        /// </summary>
        InvalidCountryRegion = 126,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        BrazilValidationError = 127,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        BrazilExemptValidationError = 128,

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        BrazilPisCofinsError = 129,

        /// <summary>
        /// The specified jurisdiction could not be found.
        /// </summary>
        JurisdictionNotFoundError = 130,

        /// <summary>
        /// You attempted to create a tax rule that designated a device as medical excise tax for an incorrect jurisdiction.
        /// </summary>
        MedicalExciseError = 131,

        /// <summary>
        /// You created a tax rule with a RateDepends option, but that rule is not a TaxabilityRule.
        /// </summary>
        RateDependsTaxabilityError = 132,

        /// <summary>
        /// The RateDepends option is only valid for countries in the European Union.
        /// </summary>
        RateDependsEuropeError = 133,

        /// <summary>
        /// This rate type is not valid in the country provided.
        /// </summary>
        InvalidRateTypeCode = 134,

        /// <summary>
        /// You attempted to choose a rate type that is not supported for the country you selected.
        /// </summary>
        RateTypeNotSupported = 135,

        /// <summary>
        /// In AvaTax REST, you can create objects with nested children, but you cannot update objects with nested children.
        /// </summary>
        CannotUpdateNestedObjects = 136,

        /// <summary>
        /// Your UPC code contains invalid characters.
        /// </summary>
        UPCCodeInvalidChars = 137,

        /// <summary>
        /// Your UPC code was too long to fit into the standard UPC object field.
        /// </summary>
        UPCCodeInvalidLength = 138,

        /// <summary>
        /// You attempted to modify an object but you provided an object that matches a different URL.
        /// </summary>
        IncorrectPathError = 139,

        /// <summary>
        /// You specified a jurisdiction type that is not recognized.
        /// </summary>
        InvalidJurisdictionType = 140,

        /// <summary>
        /// When resetting a license key for your account, you must provide a flag that indicates that you really want to reset your license key.
        /// </summary>
        MustConfirmResetLicenseKey = 141,

        /// <summary>
        /// You cannot create two companies with the same company code.
        /// </summary>
        DuplicateCompanyCode = 142,

        /// <summary>
        /// The U.S. Taxpayer Identification Number you provided is not in a recognized format.
        /// </summary>
        TINFormatError = 143,

        /// <summary>
        /// Nexus is a concept used to declare that your business is subject to taxation by a particular jurisdiction; you may not declare any one jurisdiction more than once.
        /// </summary>
        DuplicateNexusError = 144,

        /// <summary>
        /// You attempted to declare nexus in a jurisdiction that is not recognized by AvaTax.
        /// </summary>
        UnknownNexusError = 145,

        /// <summary>
        /// You attempted to create a nexus in a tax authority that is underneath a parent tax authority, but you have not yet declared nexus with the parent tax authority.
        /// </summary>
        ParentNexusNotFound = 146,

        /// <summary>
        /// You specified a tax code type that is not recognized by Avalara.
        /// </summary>
        InvalidTaxCodeType = 147,

        /// <summary>
        /// A company can only be activated when it has a valid tax profile.
        /// </summary>
        CannotActivateCompany = 148,

        /// <summary>
        /// You attempted to create an object with a duplicate name or code.
        /// </summary>
        DuplicateEntityProperty = 149,

        /// <summary>
        /// You attempted to use a Returns API on a company not designated to file returns.
        /// </summary>
        ReportingEntityError = 150,

        /// <summary>
        /// You attempted to modify a tax filing return that has been approved.
        /// </summary>
        InvalidReturnOperationError = 151,

        /// <summary>
        /// You attempted to delete a company with committed transactions.
        /// </summary>
        CannotDeleteCompany = 152,

        /// <summary>
        /// The jurisdiction override feature is only available in the United States.
        /// </summary>
        CountryOverridesNotAvailable = 153,

        /// <summary>
        /// An address override cannot be created for this jurisdiction.
        /// </summary>
        JurisdictionOverrideMismatch = 154,

        /// <summary>
        /// You attempted to create a duplicate TaxCode object.
        /// </summary>
        DuplicateSystemTaxCode = 155,

        /// <summary>
        /// Companies participating in Streamlined Sales Tax may not override addresses in SST states.
        /// </summary>
        SSTOverridesNotAvailable = 156,

        /// <summary>
        /// You declared nexus on a date when that nexus was not available.
        /// </summary>
        NexusDateMismatch = 157,

        /// <summary>
        /// You declared nexus on a date when that nexus was not available.
        /// </summary>
        NexusParentDateMismatch = 159,

        /// <summary>
        /// The bearer token you provided could not be parsed.
        /// </summary>
        BearerTokenParseUserIdError = 160,

        /// <summary>
        /// Your bearer token does not have a provisioned AvaTax account.
        /// </summary>
        RetrieveUserError = 161,

        /// <summary>
        /// The configuration setting you specified is invalid.
        /// </summary>
        InvalidConfigurationSetting = 162,

        /// <summary>
        /// The configuration value you supplied was invalid.
        /// </summary>
        InvalidConfigurationValue = 163,

        /// <summary>
        /// You specified an invalid value for a field.
        /// </summary>
        InvalidEnumValue = 164,

        /// <summary>
        /// This tax code cannot be deleted because it is in use.
        /// </summary>
        TaxCodeAssociatedTaxRule = 165,

        /// <summary>
        /// You may not change the accountId value on a company.
        /// </summary>
        CannotSwitchAccountId = 166,

        /// <summary>
        /// Your API request contained unprintable characters or was incomplete.
        /// </summary>
        RequestIncomplete = 167,

        /// <summary>
        /// Only accounts in 'New' status may be activated.
        /// </summary>
        AccountNotNew = 168,

        /// <summary>
        /// Your password did not meet length requirements.
        /// </summary>
        PasswordLengthInvalid = 169,

        /// <summary>
        /// Your nexus has invalid local nexus settings.
        /// </summary>
        LocalNexusConflict = 170,

        /// <summary>
        /// The EcmsOverrideCode value you supplied conflicts with a system-defined code.
        /// </summary>
        InvalidEcmsOverrideCode = 171,

        /// <summary>
        /// You attempted to modify an account that does not exist
        /// </summary>
        AccountDoesNotExist = 172,

        /// <summary>
        /// You specified a tax type that does not exist.
        /// </summary>
        InvalidTaxType = 173,

        /// <summary>
        /// You attempted to call the Reporting API with an incorrect field value.
        /// </summary>
        IncorrectFieldValue = 174,

        /// <summary>
        /// The value you provided in the `$filter` parameter was incorrect.
        /// </summary>
        LeadingOrTrailingException = 175,

        /// <summary>
        /// A tax transaction must have both an origin and a destination address.
        /// </summary>
        NotEnoughAddressesInfo = 176,

        /// <summary>
        /// This report has not yet been created.
        /// </summary>
        ReportNotInitiated = 177,

        /// <summary>
        /// The report request you submitted could not be processed.
        /// </summary>
        FailedToBuildReport = 178,

        /// <summary>
        /// This report is not yet completed.
        /// </summary>
        ReportNotFinished = 179,

        /// <summary>
        /// A server error prevented the report file from being downloaded.
        /// </summary>
        FailedToDownloadReport = 181,

        /// <summary>
        /// The `$filter` parameter could not be parsed.
        /// </summary>
        MalformedFilterException = 182,

        /// <summary>
        /// The `$filter` criteria in your API request was missing a conjunction.
        /// </summary>
        ExpectedConjunctionError = 183,

        /// <summary>
        /// Your `$filter` parameter contains criteria that are not supported.
        /// </summary>
        CriteriaNotSupportedError = 184,

        /// <summary>
        /// This operation is not permitted in technical support.
        /// </summary>
        CompanyAccountAndParentAccountMismatch = 185,

        /// <summary>
        /// The file content type could not be determined correctly.
        /// </summary>
        InvalidFileContentType = 186,

        /// <summary>
        /// The request you submitted was too large to process.
        /// </summary>
        RequestTooLarge = 187,

        /// <summary>
        /// The ECMS configuration value for this account does not permit exemption certificates.
        /// </summary>
        EcmsDisabled = 188,

        /// <summary>
        /// You attempted to use an invalid conjunction in your filter.
        /// </summary>
        UnknownConjunctionError = 189,

        /// <summary>
        /// You attempted to specify a discount, but did not identify any lines to discount.
        /// </summary>
        NoLinesDiscounted = 190,

        /// <summary>
        /// You attempted to delete an object that was in use.
        /// </summary>
        FailedToDelete = 191,

        /// <summary>
        /// Creating this company as submitted would result in a circular hierarchical reference.
        /// </summary>
        CircularCompanyHierarchies = 192,

        /// <summary>
        /// The key or name already exists.
        /// </summary>
        DuplicateEntry = 193,

        /// <summary>
        /// A sort or order filter criteria for this request was repeated.
        /// </summary>
        DuplicateFieldNameInOrderBy = 194,

        /// <summary>
        /// The document type is an immutable property.
        /// </summary>
        CannotAdjustDocumentType = 195,

        /// <summary>
        /// This user has a security role that blocks usage of this service.
        /// </summary>
        UserNoAccess = 196,

        /// <summary>
        /// Invalid entry
        /// </summary>
        InvalidEntry = 197,

        /// <summary>
        /// The transaction has already been cancelled
        /// </summary>
        TransactionAlreadyCancelled = 198,

        /// <summary>
        /// The query parameter is out of range.
        /// </summary>
        QueryParameterOutOfRange = 199,

        /// <summary>
        /// Sales audit files must be uploaded in ZIP or RAR formats.
        /// </summary>
        BatchSalesAuditMustBeZippedError = 200,

        /// <summary>
        /// Compressed files uploaded to the Batch service must contain exactly one file.
        /// </summary>
        BatchZipMustContainOneFileError = 201,

        /// <summary>
        /// You uploaded a batch file with an incorrect file type.
        /// </summary>
        BatchInvalidFileTypeError = 202,

        /// <summary>
        /// AvaTax cannot save the batch file.
        /// </summary>
        BatchCannotSaveBatchFile = 203,

        /// <summary>
        /// Batch file could not be found.
        /// </summary>
        BatchCannotGetBatchFile = 204,

        /// <summary>
        /// Batch file deletion is not allowed.
        /// </summary>
        BatchCannotDeleteBatchFile = 205,

        /// <summary>
        /// This batch object must contain only one file.
        /// </summary>
        BatchMustContainOneFile = 206,

        /// <summary>
        /// The batch object must contain a file to be processed.
        /// </summary>
        MissingBatchFileContent = 207,

        /// <summary>
        /// The Point-Of-Sale API cannot build this file dynamically.
        /// </summary>
        PointOfSaleFileSize = 250,

        /// <summary>
        /// Invalid parameter provided in the Point-Of-Sale file request.
        /// </summary>
        PointOfSaleSetup = 251,

        /// <summary>
        /// You attempted to set a date value that must be within a range, but your value was outside of the range.You attempted to set a date value that must be within a range, but your value was outside of the range.
        /// </summary>
        InvalidInputDate = 252,

        /// <summary>
        /// A problem occurred when you attempted to create a transaction through AvaTax.
        /// </summary>
        GetTaxError = 300,

        /// <summary>
        /// You attempted to add multiple addresses to a transaction that was flagged as a single-address transaction.
        /// </summary>
        AddressConflictException = 301,

        /// <summary>
        /// You attempted to create a document with a code that matches an existing transaction.
        /// </summary>
        DocumentCodeConflict = 303,

        /// <summary>
        /// When creating transactions, you must at a minimum provide an origin and destination address.
        /// </summary>
        MissingAddress = 304,

        /// <summary>
        /// When adding parameters to your CreateTransactionModel, you must specify a parameter of the correct type.
        /// </summary>
        InvalidParameterValue = 306,

        /// <summary>
        /// You attempted to fetch more than 1000 transaction documents at a time.
        /// </summary>
        DocumentFetchLimit = 308,

        /// <summary>
        /// The address you provided was incomplete.
        /// </summary>
        InvalidAddress = 309,

        /// <summary>
        /// The specified location code does not exist.
        /// </summary>
        AddressLocationNotFound = 310,

        /// <summary>
        /// You attempted to create a tax transaction with no lines
        /// </summary>
        MissingLine = 311,

        /// <summary>
        /// You provided an invalid parameter to the address resolution endpoint.
        /// </summary>
        InvalidAddressTextCase = 312,

        /// <summary>
        /// You attempted to lock a transaction (aka Document) that was not committed.
        /// </summary>
        DocumentNotCommitted = 313,

        /// <summary>
        /// Temporary documents cannot be fetched from the API.
        /// </summary>
        InvalidDocumentTypesToFetch = 315,

        /// <summary>
        /// You requested a timeout error from the AvaTax API.
        /// </summary>
        TimeoutRequested = 316,

        /// <summary>
        /// The postal code you provided could not be found
        /// </summary>
        InvalidPostalCode = 317,

        /// <summary>
        /// Subscription description cannot be None when subscriptionTypeId is not provided
        /// </summary>
        InvalidSubscriptionDescription = 318,

        /// <summary>
        /// Invalid subscription TypeId.
        /// </summary>
        InvalidSubscriptionTypeId = 319,

        /// <summary>
        /// The requested filing status change is invalid
        /// </summary>
        CannotChangeFilingStatus = 401,

        /// <summary>
        /// One of the servers in the Avalara AvaTax API cluster is unreachable and your API call could not be completed.
        /// </summary>
        ServerUnreachable = 500,

        /// <summary>
        /// This Avalara API call requires an active subscription to a specific service.
        /// </summary>
        SubscriptionRequired = 600,

        /// <summary>
        /// An account tied to this email address already exists
        /// </summary>
        AccountExists = 601,

        /// <summary>
        /// You attempted to contact an API that is available by invitation only.
        /// </summary>
        InvitationOnly = 602,

        /// <summary>
        /// The Free Trial API is not available on this server.
        /// </summary>
        FreeTrialNotAvailable = 606,

        /// <summary>
        /// An account with this username already exists
        /// </summary>
        AccountExistsDifferentEmail = 607,

        /// <summary>
        /// A server configuration problem has been detected.
        /// </summary>
        AvalaraIdentityApiError = 608,

        /// <summary>
        /// A server configuration problem has been detected.
        /// </summary>
        InvalidIPAddress = 609,

        /// <summary>
        /// The offer code has already been applied to this account.
        /// </summary>
        OfferCodeAlreadyApplied = 610,

        /// <summary>
        /// TBD
        /// </summary>
        AccountAlreadyExists = 611,

        /// <summary>
        /// The AvaTax Refund API is only available on committed documents.
        /// </summary>
        InvalidDocumentStatusForRefund = 700,

        /// <summary>
        /// You specified a `Full` refund, but the percentage parameter was not null.
        /// </summary>
        RefundTypeAndPercentageMismatch = 701,

        /// <summary>
        /// The document you attempted to refund was not a SalesInvoice.

        /// </summary>
        InvalidDocumentTypeForRefund = 702,

        /// <summary>
        /// You specified a `Full` refund, but the lines parameter was not null.
        /// </summary>
        RefundTypeAndLineMismatch = 703,

        /// <summary>
        /// Your RefundTransaction API call was missing necessary information.
        /// </summary>
        RefundLinesRequired = 704,

        /// <summary>
        /// You specified an invalid refund type.
        /// </summary>
        InvalidRefundType = 705,

        /// <summary>
        /// You attempted to create a TaxOnly refund for a partial percentage.
        /// </summary>
        RefundPercentageForTaxOnly = 706,

        /// <summary>
        /// You attempted to refund a line item that did not exist in the original transaction.
        /// </summary>
        LineNoOutOfRange = 707,

        /// <summary>
        /// You submitted a refund percentage lower than 0% or higher than 100%
        /// </summary>
        RefundPercentageOutOfRange = 708,

        /// <summary>
        /// You specified a refund type of percentage, but did not specify the percentage.
        /// </summary>
        RefundPercentageMissing = 709,

        /// <summary>
        /// The free tax rates API applies only to transactions within the United States.
        /// </summary>
        MustUseCreateTransaction = 800,

        /// <summary>
        /// You must read and accept Avalara's terms and conditions to get a FreeTrial Account
        /// </summary>
        MustAcceptTermsAndConditions = 801,

        /// <summary>
        /// A filing calendar cannot be deleted once in use.
        /// </summary>
        FilingCalendarCannotBeDeleted = 900,

        /// <summary>
        /// The effective date for your filing request is not valid.
        /// </summary>
        InvalidEffectiveDate = 901,

        /// <summary>
        /// This form does not permit Outlet or Location-based reporting.
        /// </summary>
        NonOutletForm = 902,

        /// <summary>
        /// This filing calendar overlaps with another calendar.
        /// </summary>
        OverlappingFilingCalendar = 903,

        /// <summary>
        /// The filing calander cannot be edited.
        /// </summary>
        FilingCalendarCannotBeEdited = 904,

        /// <summary>
        /// A locked transaction may not be modified.
        /// </summary>
        CannotModifyLockedTransaction = 1100,

        /// <summary>
        /// You attempted to add a line with a conflicting line number.
        /// </summary>
        LineAlreadyExists = 1101,

        /// <summary>
        /// You attempted to remove a line that did not exist.
        /// </summary>
        LineDoesNotExist = 1102,

        /// <summary>
        /// You attempted to create a transaction with zero lines.
        /// </summary>
        LinesNotSpecified = 1103,

        /// <summary>
        /// The specified line detail ID cannot be found.
        /// </summary>
        LineDetailsDoesNotExist = 1104,

        /// <summary>
        /// The selected DataSource has been deleted and cannot be used for creating a transaction.
        /// </summary>
        CannotCreateTransactionWithDeletedDataSource = 1105,

        /// <summary>
        /// The business type field on the ECMS record is invalid
        /// </summary>
        InvalidBusinessType = 1200,

        /// <summary>
        /// Exemption certificates cannot be modified using the Company API.
        /// </summary>
        CannotModifyExemptCert = 1201,

        /// <summary>
        /// The certificate API has returned an error.
        /// </summary>
        CertificatesError = 1203,

        /// <summary>
        /// 
        /// </summary>
        MissingRequiredFields = 1204,

        /// <summary>
        /// 
        /// </summary>
        CertificatesNotSetup = 1205,

        /// <summary>
        /// 
        /// </summary>
        AddRelationshipsError = 1206,

        /// <summary>
        /// 
        /// </summary>
        ConflictingExposureZone = 1208,

        /// <summary>
        /// 
        /// </summary>
        MissingFieldToCreateExposureZone = 1209,

        /// <summary>
        /// 
        /// </summary>
        MissingExemptReason = 1210,

        /// <summary>
        /// 
        /// </summary>
        InvalidExemptReason = 1211,

        /// <summary>
        /// 
        /// </summary>
        InvalidExemptionOperation = 1212,

        /// <summary>
        /// 
        /// </summary>
        ConflictingFields = 1213,

        /// <summary>
        /// 
        /// </summary>
        InvalidPdfOrImageFile = 1214,

        /// <summary>
        /// 
        /// </summary>
        InvalidCoverLetterTitle = 1215,

        /// <summary>
        /// 
        /// </summary>
        AccountNotProvisioned = 1216,

        /// <summary>
        /// 
        /// </summary>
        InvalidRequestContentType = 1217,

        /// <summary>
        /// 
        /// </summary>
        ExemptionPaginationLimits = 1218,

        /// <summary>
        /// 
        /// </summary>
        ExemptionSortLimits = 1219,

        /// <summary>
        /// 
        /// </summary>
        CustomerCantBeBothShipToAndBillTo = 1220,

        /// <summary>
        /// 
        /// </summary>
        BillToCustomerExpected = 1221,

        /// <summary>
        /// 
        /// </summary>
        ShipToCustomerExpected = 1222,

        /// <summary>
        /// 
        /// </summary>
        EcmsSstCertsRequired = 1223,

        /// <summary>
        /// Multi document error codes
        /// </summary>
        TransactionNotCancelled = 1300,

        /// <summary>
        /// 
        /// </summary>
        TooManyTransactions = 1301,

        /// <summary>
        /// 
        /// </summary>
        OnlyTaxDateOverrideIsAllowed = 1302,

        /// <summary>
        /// 
        /// </summary>
        TransactionAlreadyExists = 1303,

        /// <summary>
        /// 
        /// </summary>
        DateMismatch = 1305,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentStatusForVerify = 1306,

        /// <summary>
        /// 
        /// </summary>
        TotalAmountMismatch = 1307,

        /// <summary>
        /// 
        /// </summary>
        TotalTaxMismatch = 1308,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentStatusForCommit = 1309,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentType = 1310,

        /// <summary>
        /// 
        /// </summary>
        MultiDocumentPartiallyLocked = 1312,

        /// <summary>
        /// 
        /// </summary>
        TransactionIsCommitted = 1313,

        /// <summary>
        /// Communications Tax error codes
        /// </summary>
        CommsConfigClientIdMissing = 1400,

        /// <summary>
        /// 
        /// </summary>
        CommsConfigClientIdBadValue = 1401,

        /// <summary>
        /// Account Activate error codes
        /// </summary>
        AccountInNewStatusException = 1404,

        /// <summary>
        /// Worksheet Exception
        /// </summary>
        WorksheetException = 1405,

        /// <summary>
        /// 
        /// </summary>
        InvalidAccountOverride = 1406,

        /// <summary>
        /// 
        /// </summary>
        AccountOverrideNotAuthorized = 1407,

        /// <summary>
        /// 
        /// </summary>
        FieldNotQueryableError = 1408,

        /// <summary>
        /// 
        /// </summary>
        UsernameRequired = 1409,

        /// <summary>
        /// 
        /// </summary>
        InvalidAuditMessage = 1410,

        /// <summary>
        /// 
        /// </summary>
        FieldNotOrderableError = 1411,

        /// <summary>
        /// Nexus validation error codes
        /// </summary>
        CannotDeleteParentBeforeChildNexus = 1500,

        /// <summary>
        /// 
        /// </summary>
        NexusChildDateMismatch = 1501,

        /// <summary>
        /// Remote validation Error
        /// </summary>
        RemoteValidationError = 1502,

        /// <summary>
        /// Advanced rule errors
        /// </summary>
        AdvancedRuleRequestRuleError = 1602,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleResponseRuleError = 1603,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleError = 1605,

        /// <summary>
        /// Miscellaneous
        /// </summary>
        InvalidDocumentStatusToAddOrDeleteLines = 1700,

        /// <summary>
        /// 
        /// </summary>
        TaxRuleRequiresNexus = 1701,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeNotUnique = 1702,

        /// <summary>
        /// 
        /// </summary>
        CannotUpdateSourceOrInstance = 1703,

        /// <summary>
        /// 
        /// </summary>
        TaxCodeAssociatedWithItemCodeNotFound = 1704,

        /// <summary>
        /// 
        /// </summary>
        DuplicateSystemForItem = 1705,

        /// <summary>
        /// 
        /// </summary>
        CannotDismissGlobalNotification = 1706,

        /// <summary>
        /// 
        /// </summary>
        GenericTaxCodeForItem = 1707,

        /// <summary>
        /// 
        /// </summary>
        CannotCertifyCompany = 1708,

        /// <summary>
        /// SendSales API errors
        /// </summary>
        UnsupportedFileFormat = 1800,

        /// <summary>
        /// 
        /// </summary>
        UnsupportedOutputFileType = 1801,

        /// <summary>
        /// TaxProfile API errors
        /// </summary>
        TaxProfileNotProvided = 1900,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxProfile = 1901,

        /// <summary>
        /// 
        /// </summary>
        CompanyTaxProfileEntryRequired = 1902,

        /// <summary>
        /// 
        /// </summary>
        ErrorReadingTaxProfileEntry = 1903,

        /// <summary>
        /// AuditAccount API errors
        /// </summary>
        TraceDataNotAvailable = 2000,

        /// <summary>
        /// Item parameter errors
        /// </summary>
        InvalidParameterUnitMeasurementType = 2100,

        /// <summary>
        /// 
        /// </summary>
        ParameterUnitRequired = 2101,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameterValueDataType = 2102,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameterAttributeType = 2103,

        /// <summary>
        /// 
        /// </summary>
        SubscriptionRequiredForParameter = 2104,

    }
}
