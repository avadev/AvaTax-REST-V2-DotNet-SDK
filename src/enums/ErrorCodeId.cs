using System;

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
    /// Represents a error code message
    /// </summary>
    public enum ErrorCodeId
    {
        /// <summary>
        /// Server has a configuration or setup problem
        /// </summary>
        ServerConfiguration = 1,

        /// <summary>
        /// User doesn't have rights to this account or company
        /// </summary>
        AccountInvalidException = 2,

        /// <summary>
        /// 
        /// </summary>
        CompanyInvalidException = 3,

        /// <summary>
        /// Use this error message when the user is trying to fetch a single object and the object either does not exist or cannot be seen by the current user.
        /// </summary>
        EntityNotFoundError = 4,

        /// <summary>
        /// 
        /// </summary>
        ValueRequiredError = 5,

        /// <summary>
        /// 
        /// </summary>
        RangeError = 6,

        /// <summary>
        /// 
        /// </summary>
        RangeCompareError = 7,

        /// <summary>
        /// 
        /// </summary>
        RangeSetError = 8,

        /// <summary>
        /// 
        /// </summary>
        TaxpayerNumberRequired = 9,

        /// <summary>
        /// 
        /// </summary>
        EntityLimitExceeded = 10,

        /// <summary>
        /// 
        /// </summary>
        CommonPassword = 11,

        /// <summary>
        /// 
        /// </summary>
        WeakPassword = 12,

        /// <summary>
        /// 
        /// </summary>
        StringLengthError = 13,

        /// <summary>
        /// 
        /// </summary>
        MaxStringLengthError = 14,

        /// <summary>
        /// 
        /// </summary>
        EmailValidationError = 15,

        /// <summary>
        /// 
        /// </summary>
        EmailMissingError = 16,

        /// <summary>
        /// 
        /// </summary>
        InvalidQueryField = 17,

        /// <summary>
        /// 
        /// </summary>
        InvalidQueryValue = 18,

        /// <summary>
        /// 
        /// </summary>
        SyntaxError = 19,

        /// <summary>
        /// 
        /// </summary>
        TooManyParametersError = 20,

        /// <summary>
        /// 
        /// </summary>
        UnterminatedValueError = 21,

        /// <summary>
        /// 
        /// </summary>
        DeleteUserSelfError = 22,

        /// <summary>
        /// 
        /// </summary>
        OldPasswordInvalid = 23,

        /// <summary>
        /// 
        /// </summary>
        CannotChangePassword = 24,

        /// <summary>
        /// 
        /// </summary>
        ReadOnly = 25,

        /// <summary>
        /// 
        /// </summary>
        DateFormatError = 26,

        /// <summary>
        /// 
        /// </summary>
        NoDefaultCompany = 27,

        /// <summary>
        /// 
        /// </summary>
        AccountTypeNotSupported = 28,

        /// <summary>
        /// 
        /// </summary>
        InvalidAuthenticationType = 29,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationException = 30,

        /// <summary>
        /// 
        /// </summary>
        AuthorizationException = 31,

        /// <summary>
        /// 
        /// </summary>
        ValidationException = 32,

        /// <summary>
        /// 
        /// </summary>
        InactiveUserError = 33,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationIncomplete = 34,

        /// <summary>
        /// 
        /// </summary>
        BasicAuthIncorrect = 35,

        /// <summary>
        /// 
        /// </summary>
        IdentityServerError = 36,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenInvalid = 37,

        /// <summary>
        /// 
        /// </summary>
        ModelRequiredException = 38,

        /// <summary>
        /// 
        /// </summary>
        AccountExpiredException = 39,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenNotSupported = 41,

        /// <summary>
        /// 
        /// </summary>
        InvalidSecurityRole = 42,

        /// <summary>
        /// 
        /// </summary>
        InvalidRegistrarAction = 43,

        /// <summary>
        /// 
        /// </summary>
        RemoteServerError = 44,

        /// <summary>
        /// 
        /// </summary>
        NoFilterCriteriaException = 45,

        /// <summary>
        /// 
        /// </summary>
        OpenClauseException = 46,

        /// <summary>
        /// 
        /// </summary>
        JsonFormatError = 47,

        /// <summary>
        /// 
        /// </summary>
        InvalidDecimalValue = 48,

        /// <summary>
        /// 
        /// </summary>
        PermissionRequired = 49,

        /// <summary>
        /// 
        /// </summary>
        UnhandledException = 50,

        /// <summary>
        /// 
        /// </summary>
        InactiveAccount = 51,

        /// <summary>
        /// 
        /// </summary>
        LinkageNotAllowed = 52,

        /// <summary>
        /// 
        /// </summary>
        LinkageStatusUpdateNotSupported = 53,

        /// <summary>
        /// 
        /// </summary>
        ReportingCompanyMustHaveContactsError = 60,

        /// <summary>
        /// 
        /// </summary>
        CompanyProfileNotSet = 61,

        /// <summary>
        /// 
        /// </summary>
        CannotAssignUserToCompany = 62,

        /// <summary>
        /// 
        /// </summary>
        MustAssignUserToCompany = 63,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxTypeMapping = 64,

        /// <summary>
        /// 
        /// </summary>
        ModelStateInvalid = 70,

        /// <summary>
        /// 
        /// </summary>
        DateRangeError = 80,

        /// <summary>
        /// 
        /// </summary>
        InvalidDateRangeError = 81,

        /// <summary>
        /// 
        /// </summary>
        RuleMustHaveTaxCode = 82,

        /// <summary>
        /// 
        /// </summary>
        RuleTypeRestricted = 83,

        /// <summary>
        /// 
        /// </summary>
        AllJurisRuleLimits = 84,

        /// <summary>
        /// 
        /// </summary>
        InvalidCompanyLocationSetting = 85,

        /// <summary>
        /// 
        /// </summary>
        InvalidAdjustmentType = 99,

        /// <summary>
        /// 
        /// </summary>
        DeleteInformation = 100,

        /// <summary>
        /// 
        /// </summary>
        DisableAuthenticationForSamlBasedAccounts = 101,

        /// <summary>
        /// 
        /// </summary>
        DisableResetPasswordForSamlBasedAccounts = 102,

        /// <summary>
        /// 
        /// </summary>
        OutOfRange = 118,

        /// <summary>
        /// 
        /// </summary>
        UnspecifiedTimeZone = 119,

        /// <summary>
        /// 
        /// </summary>
        CannotCreateDeletedObjects = 120,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyDeletedObjects = 121,

        /// <summary>
        /// 
        /// </summary>
        ReturnNameNotFound = 122,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTypeAndCategory = 123,

        /// <summary>
        /// 
        /// </summary>
        DefaultCompanyLocation = 124,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountry = 125,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountryRegion = 126,

        /// <summary>
        /// 
        /// </summary>
        BrazilValidationError = 127,

        /// <summary>
        /// 
        /// </summary>
        BrazilExemptValidationError = 128,

        /// <summary>
        /// 
        /// </summary>
        BrazilPisCofinsError = 129,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionNotFoundError = 130,

        /// <summary>
        /// 
        /// </summary>
        MedicalExciseError = 131,

        /// <summary>
        /// 
        /// </summary>
        RateDependsTaxabilityError = 132,

        /// <summary>
        /// 
        /// </summary>
        InvalidRateTypeCode = 134,

        /// <summary>
        /// 
        /// </summary>
        RateTypeNotSupported = 135,

        /// <summary>
        /// 
        /// </summary>
        CannotUpdateNestedObjects = 136,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidChars = 137,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidLength = 138,

        /// <summary>
        /// 
        /// </summary>
        IncorrectPathError = 139,

        /// <summary>
        /// 
        /// </summary>
        InvalidJurisdictionType = 140,

        /// <summary>
        /// 
        /// </summary>
        MustConfirmResetLicenseKey = 141,

        /// <summary>
        /// 
        /// </summary>
        DuplicateCompanyCode = 142,

        /// <summary>
        /// 
        /// </summary>
        TINFormatError = 143,

        /// <summary>
        /// 
        /// </summary>
        DuplicateNexusError = 144,

        /// <summary>
        /// 
        /// </summary>
        UnknownNexusError = 145,

        /// <summary>
        /// 
        /// </summary>
        ParentNexusNotFound = 146,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxCodeType = 147,

        /// <summary>
        /// 
        /// </summary>
        CannotActivateCompany = 148,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEntityProperty = 149,

        /// <summary>
        /// 
        /// </summary>
        ReportingEntityError = 150,

        /// <summary>
        /// 
        /// </summary>
        InvalidReturnOperationError = 151,

        /// <summary>
        /// 
        /// </summary>
        CannotDeleteCompany = 152,

        /// <summary>
        /// 
        /// </summary>
        CountryOverridesNotAvailable = 153,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionOverrideMismatch = 154,

        /// <summary>
        /// 
        /// </summary>
        DuplicateSystemTaxCode = 155,

        /// <summary>
        /// 
        /// </summary>
        SSTOverridesNotAvailable = 156,

        /// <summary>
        /// 
        /// </summary>
        NexusDateMismatch = 157,

        /// <summary>
        /// 
        /// </summary>
        NexusParentDateMismatch = 159,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenParseUserIdError = 160,

        /// <summary>
        /// 
        /// </summary>
        RetrieveUserError = 161,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationSetting = 162,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationValue = 163,

        /// <summary>
        /// 
        /// </summary>
        InvalidEnumValue = 164,

        /// <summary>
        /// 
        /// </summary>
        TaxCodeAssociatedTaxRule = 165,

        /// <summary>
        /// 
        /// </summary>
        CannotSwitchAccountId = 166,

        /// <summary>
        /// 
        /// </summary>
        RequestIncomplete = 167,

        /// <summary>
        /// 
        /// </summary>
        AccountNotNew = 168,

        /// <summary>
        /// 
        /// </summary>
        PasswordLengthInvalid = 169,

        /// <summary>
        /// 
        /// </summary>
        InvalidPageKey = 170,

        /// <summary>
        /// 
        /// </summary>
        InvalidEcmsOverrideCode = 171,

        /// <summary>
        /// 
        /// </summary>
        AccountDoesNotExist = 172,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxType = 173,

        /// <summary>
        /// 
        /// </summary>
        IncorrectFieldValue = 174,

        /// <summary>
        /// 
        /// </summary>
        LeadingOrTrailingException = 175,

        /// <summary>
        /// 
        /// </summary>
        NotEnoughAddressesInfo = 176,

        /// <summary>
        /// 
        /// </summary>
        ReportNotInitiated = 177,

        /// <summary>
        /// 
        /// </summary>
        FailedToBuildReport = 178,

        /// <summary>
        /// 
        /// </summary>
        ReportNotFinished = 179,

        /// <summary>
        /// 
        /// </summary>
        FailedToDownloadReport = 181,

        /// <summary>
        /// 
        /// </summary>
        MalformedFilterException = 182,

        /// <summary>
        /// 
        /// </summary>
        ExpectedConjunctionError = 183,

        /// <summary>
        /// 
        /// </summary>
        CriteriaNotSupportedError = 184,

        /// <summary>
        /// 
        /// </summary>
        CompanyAccountAndParentAccountMismatch = 185,

        /// <summary>
        /// 
        /// </summary>
        InvalidFileContentType = 186,

        /// <summary>
        /// 
        /// </summary>
        RequestTooLarge = 187,

        /// <summary>
        /// 
        /// </summary>
        EcmsDisabled = 188,

        /// <summary>
        /// 
        /// </summary>
        UnknownConjunctionError = 189,

        /// <summary>
        /// 
        /// </summary>
        NoLinesDiscounted = 190,

        /// <summary>
        /// 
        /// </summary>
        FailedToDelete = 191,

        /// <summary>
        /// 
        /// </summary>
        CircularCompanyHierarchies = 192,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEntry = 193,

        /// <summary>
        /// 
        /// </summary>
        DuplicateFieldNameInOrderBy = 194,

        /// <summary>
        /// 
        /// </summary>
        CannotAdjustDocumentType = 195,

        /// <summary>
        /// 
        /// </summary>
        UserNoAccess = 196,

        /// <summary>
        /// 
        /// </summary>
        InvalidEntry = 197,

        /// <summary>
        /// 
        /// </summary>
        TransactionAlreadyCancelled = 198,

        /// <summary>
        /// 
        /// </summary>
        QueryParameterOutOfRange = 199,

        /// <summary>
        /// Batch errors
        ///  New batch error codes continue at 2501
        /// </summary>
        BatchSalesAuditMustBeZippedError = 200,

        /// <summary>
        /// 
        /// </summary>
        BatchZipMustContainOneFileError = 201,

        /// <summary>
        /// 
        /// </summary>
        BatchInvalidFileTypeError = 202,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotSaveBatchFile = 203,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotGetBatchFile = 204,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotDeleteBatchFile = 205,

        /// <summary>
        /// 
        /// </summary>
        BatchMustContainOneFile = 206,

        /// <summary>
        /// 
        /// </summary>
        MissingBatchFileContent = 207,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotBeDeletedWhileProcessing = 208,

        /// <summary>
        /// BizTech error
        /// </summary>
        InternalServerError = 209,

        /// <summary>
        /// Point Of Sale API exceptions
        /// </summary>
        PointOfSaleFileSize = 250,

        /// <summary>
        /// 
        /// </summary>
        PointOfSaleSetup = 251,

        /// <summary>
        /// 
        /// </summary>
        InvalidInputDate = 252,

        /// <summary>
        /// Errors in Soap V1 Passthrough / GetTax calls
        /// </summary>
        GetTaxError = 300,

        /// <summary>
        /// 
        /// </summary>
        AddressConflictException = 301,

        /// <summary>
        /// 
        /// </summary>
        DocumentCodeConflict = 303,

        /// <summary>
        /// 
        /// </summary>
        MissingAddress = 304,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameterValue = 306,

        /// <summary>
        /// 
        /// </summary>
        FetchLimit = 308,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddress = 309,

        /// <summary>
        /// 
        /// </summary>
        AddressLocationNotFound = 310,

        /// <summary>
        /// 
        /// </summary>
        MissingLine = 311,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTextCase = 312,

        /// <summary>
        /// 
        /// </summary>
        DocumentNotCommitted = 313,

        /// <summary>
        /// 
        /// </summary>
        LineFetchLimitExceeded = 314,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypesToFetch = 315,

        /// <summary>
        /// 
        /// </summary>
        TimeoutRequested = 316,

        /// <summary>
        /// 
        /// </summary>
        InvalidPostalCode = 317,

        /// <summary>
        /// Subscription error codes
        /// </summary>
        InvalidSubscriptionDescription = 318,

        /// <summary>
        /// 
        /// </summary>
        InvalidSubscriptionTypeId = 319,

        /// <summary>
        /// Represents a malformed document fetch command
        /// </summary>
        CannotChangeFilingStatus = 401,

        /// <summary>
        /// Represents a FEIN in incorrect format.
        /// </summary>
        FEINFormatError = 402,

        /// <summary>
        /// Represents a SQL server timeout error / deadlock error
        /// </summary>
        ServerUnreachable = 500,

        /// <summary>
        /// Partner API error codes
        /// </summary>
        SubscriptionRequired = 600,

        /// <summary>
        /// 
        /// </summary>
        AccountExists = 601,

        /// <summary>
        /// 
        /// </summary>
        InvitationOnly = 602,

        /// <summary>
        /// 
        /// </summary>
        AccountNotWhitelisted = 603,

        /// <summary>
        /// 
        /// </summary>
        FreeTrialNotAvailable = 606,

        /// <summary>
        /// 
        /// </summary>
        AccountExistsDifferentEmail = 607,

        /// <summary>
        /// 
        /// </summary>
        AvalaraIdentityApiError = 608,

        /// <summary>
        /// 
        /// </summary>
        InvalidIPAddress = 609,

        /// <summary>
        /// 
        /// </summary>
        OfferCodeAlreadyApplied = 610,

        /// <summary>
        /// 
        /// </summary>
        AccountAlreadyExists = 611,

        /// <summary>
        /// 
        /// </summary>
        LicenseKeyNameAlreadyExistsForAccount = 612,

        /// <summary>
        /// 
        /// </summary>
        UserAlreadyExist = 613,

        /// <summary>
        /// 
        /// </summary>
        UserNotFound = 614,

        /// <summary>
        /// 
        /// </summary>
        UserManagementException = 615,

        /// <summary>
        /// Refund API error codes
        /// </summary>
        RefundTypeAndPercentageMismatch = 701,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypeForRefund = 702,

        /// <summary>
        /// 
        /// </summary>
        RefundTypeAndLineMismatch = 703,

        /// <summary>
        /// 
        /// </summary>
        RefundLinesRequired = 704,

        /// <summary>
        /// 
        /// </summary>
        InvalidRefundType = 705,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageForTaxOnly = 706,

        /// <summary>
        /// 
        /// </summary>
        LineNoOutOfRange = 707,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageOutOfRange = 708,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageMissing = 709,

        /// <summary>
        /// Free API error codes
        /// </summary>
        MustUseCreateTransaction = 800,

        /// <summary>
        /// 
        /// </summary>
        MustAcceptTermsAndConditions = 801,

        /// <summary>
        /// Filing Calendar Error Codes
        /// </summary>
        FilingCalendarCannotBeDeleted = 900,

        /// <summary>
        /// 
        /// </summary>
        InvalidEffectiveDate = 901,

        /// <summary>
        /// 
        /// </summary>
        NonOutletForm = 902,

        /// <summary>
        /// 
        /// </summary>
        OverlappingFilingCalendar = 903,

        /// <summary>
        /// 
        /// </summary>
        FilingCalendarCannotBeEdited = 904,

        /// <summary>
        /// Create or update transaction error codes
        /// </summary>
        CannotModifyLockedTransaction = 1100,

        /// <summary>
        /// 
        /// </summary>
        LineAlreadyExists = 1101,

        /// <summary>
        /// 
        /// </summary>
        LineDoesNotExist = 1102,

        /// <summary>
        /// 
        /// </summary>
        LinesNotSpecified = 1103,

        /// <summary>
        /// 
        /// </summary>
        LineDetailsDoesNotExist = 1104,

        /// <summary>
        /// 
        /// </summary>
        CannotCreateTransactionWithDeletedDataSource = 1105,

        /// <summary>
        /// 
        /// </summary>
        ShipToRegionRequiredWithDataSource = 1106,

        /// <summary>
        /// Exempt cert error codes
        /// </summary>
        InvalidBusinessType = 1200,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyExemptCert = 1201,

        /// <summary>
        /// 
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
        MultiDocumentTransactionAlreadyExists = 1304,

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
        /// 
        /// </summary>
        InvalidDocumentStatus = 1314,

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
        /// 
        /// </summary>
        CannotModifySstNexus = 1503,

        /// <summary>
        /// 
        /// </summary>
        InvalidLocalNexusTypeId = 1504,

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
        TaxRuleRequiresNexus = 1701,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeNotUnique = 1702,

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
        CannotUpdateAccountTypeId = 1713,

        /// <summary>
        /// 
        /// </summary>
        TaxpayerNumberIsRequired = 1714,

        /// <summary>
        /// 
        /// </summary>
        RequestLimitExceeded = 1715,

        /// <summary>
        /// 
        /// </summary>
        ConcurrentRequestLimitExceeded = 1716,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypeForInspect = 1717,

        /// <summary>
        /// 
        /// </summary>
        ServiceNotReady = 1718,

        /// <summary>
        /// 
        /// </summary>
        UpdateLocationRemittanceMismatchTypeAndCategory = 1719,

        /// <summary>
        /// 
        /// </summary>
        UpdateLocationRemittanceCheckExistingEffectiveDateError = 1720,

        /// <summary>
        /// 
        /// </summary>
        UpdateLocationRemittanceCheckExistingEndDateError = 1721,

        /// <summary>
        /// 
        /// </summary>
        ErrorCountLimitExceededError = 1722,

        /// <summary>
        /// 
        /// </summary>
        RateLimitExceededError = 1723,

        /// <summary>
        /// 
        /// </summary>
        TaxCodeAndTaxCodeIdMissing = 1724,

        /// <summary>
        /// 
        /// </summary>
        NexusAlreadyExists = 1725,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTypeAndMarketPlaceOusideUsaFlag = 1726,

        /// <summary>
        /// 
        /// </summary>
        InvalidSettingSet = 1727,

        /// <summary>
        /// 
        /// </summary>
        InvalidSettingName = 1728,

        /// <summary>
        /// 
        /// </summary>
        InvalidSettingValue = 1729,

        /// <summary>
        /// 
        /// </summary>
        TooManyUserDefinedFields = 1730,

        /// <summary>
        /// 
        /// </summary>
        DuplicateUserDefinedFieldsFound = 1731,

        /// <summary>
        /// 
        /// </summary>
        InvalidNameForUserDefinedField = 1732,

        /// <summary>
        /// 
        /// </summary>
        InvalidRestrictionType = 1733,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameter = 1734,

        /// <summary>
        /// 
        /// </summary>
        InvalidSystemCode = 1735,

        /// <summary>
        /// 
        /// </summary>
        NoItemsForClassification = 1736,

        /// <summary>
        /// 
        /// </summary>
        InvalidFileName = 1737,

        /// <summary>
        /// 
        /// </summary>
        NoClassificationForSameHsCode = 1738,

        /// <summary>
        /// 
        /// </summary>
        InvalidValueError = 1739,

        /// <summary>
        /// 
        /// </summary>
        ItemDualWriteParameterValueMismatchError = 1740,

        /// <summary>
        /// 
        /// </summary>
        DuplicateItemIdsInTaxCodeClassificationRequest = 1741,

        /// <summary>
        /// 
        /// </summary>
        TooManyItemIdsInTaxCodeClassificationRequest = 1742,

        /// <summary>
        /// 
        /// </summary>
        InvalidProductCodeLength = 1743,

        /// <summary>
        /// 
        /// </summary>
        InvalidProductCodeFormat = 1744,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountryAssignment = 1745,

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
        /// Item and Nexus parameter errors
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

        /// <summary>
        /// Accounting Firm errors
        /// </summary>
        InvalidAccountType = 2105,

        /// <summary>
        /// 
        /// </summary>
        InvalidFirmSubscriptions = 2106,

        /// <summary>
        /// Certify Company Errors
        /// </summary>
        GenericTaxCodeForItem = 2200,

        /// <summary>
        /// 
        /// </summary>
        CannotCertifyCompany = 2201,

        /// <summary>
        /// 
        /// </summary>
        NoVoidedDocuments = 2202,

        /// <summary>
        /// 
        /// </summary>
        InadequateCommittedDocuments = 2203,

        /// <summary>
        /// 
        /// </summary>
        DocumentCodeIsGuid = 2204,

        /// <summary>
        /// 
        /// </summary>
        CustomerVendorCodeIsGuid = 2205,

        /// <summary>
        /// 
        /// </summary>
        InadequateDocumentLineCount = 2206,

        /// <summary>
        /// 
        /// </summary>
        SameDocumentDescription = 2207,

        /// <summary>
        /// 
        /// </summary>
        NoExemptionNoOrCustomerUsageType = 2208,

        /// <summary>
        /// 
        /// </summary>
        InadequateUniqueAddresses = 2209,

        /// <summary>
        /// 
        /// </summary>
        ItemCodesAreAllSame = 2210,

        /// <summary>
        /// 
        /// </summary>
        TaxCodesAreAllSame = 2211,

        /// <summary>
        /// 
        /// </summary>
        LocationCodeNotUsed = 2212,

        /// <summary>
        /// 
        /// </summary>
        RepeatedLinesInDocument = 2213,

        /// <summary>
        /// 
        /// </summary>
        TaxDateOverrideAndNegativeLineAmount = 2214,

        /// <summary>
        /// 
        /// </summary>
        AllUSDCurrencyCodes = 2215,

        /// <summary>
        /// 
        /// </summary>
        NoVATBuyerId = 2216,

        /// <summary>
        /// 
        /// </summary>
        AllUSCountryCodes = 2217,

        /// <summary>
        /// 
        /// </summary>
        NoDocumentsToTest = 2218,

        /// <summary>
        /// 
        /// </summary>
        NoShippingCharge = 2219,

        /// <summary>
        /// Company Controller Related Errors
        /// </summary>
        FailedToUpdateCompanyLocation = 2314,

        /// <summary>
        /// 
        /// </summary>
        CompanyLocationDateRangeOverlap = 2315,

        /// <summary>
        /// Generic validation errors
        /// </summary>
        FieldLengthError = 2400,

        /// <summary>
        /// 
        /// </summary>
        InputContainsBlacklistedCharacters = 2401,

        /// <summary>
        /// 
        /// </summary>
        CannotCreateNestedObjects = 2402,

        /// <summary>
        /// 
        /// </summary>
        InvalidUsername = 2403,

        /// <summary>
        /// User's SubjectId not updated by DB query
        /// </summary>
        UserSubjectIdNotUpdated = 2500,

        /// <summary>
        /// Batch errors
        ///  For other batch errors, see: 200 - 208 above
        /// </summary>
        BatchTransactionTypeError = 2501,

        /// <summary>
        /// 
        /// </summary>
        BatchTransactionLineLimitExceeded = 2502,

        /// <summary>
        /// 
        /// </summary>
        BatchCompanyIdAndCompanyCodeMismatch = 2503,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotBeCancelledStatusError = 2504,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotBeCancelledFormatError = 2505,

        /// <summary>
        /// 
        /// </summary>
        BatchTypeNotSupported = 2506,

        /// <summary>
        /// Parameter related errors
        /// </summary>
        InvalidParameterDataType = 2600,

        /// <summary>
        /// Tags related error
        /// </summary>
        TagDoesNotExist = 2620,

        /// <summary>
        /// Object deleted message
        /// </summary>
        ObjectDeleted = 2660,

        /// <summary>
        /// 
        /// </summary>
        AssociatedObjectsDeleted = 2661,

        /// <summary>
        /// Additional report related errors
        /// </summary>
        CannotDownloadReport = 2700,

        /// <summary>
        /// AVT-10699 - Multi-tax custom Tax Rules (Phase 1)
        /// </summary>
        InvalidUnitOfBasis = 2800,

        /// <summary>
        /// 
        /// </summary>
        NotApplicableUnitOfBasis = 2801,

        /// <summary>
        /// 
        /// </summary>
        InvalidRateTypeTaxTypeMapping = 2802,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxTypeGroup = 2803,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxSubType = 2804,

        /// <summary>
        /// 
        /// </summary>
        InvalidProductTypeId = 2805,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxRuleType = 2806,

        /// <summary>
        /// 
        /// </summary>
        InvalidHsCode = 2807,

        /// <summary>
        /// 
        /// </summary>
        NotApplicableTaxType = 2808,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxTypeCode = 2809,

        /// <summary>
        /// 
        /// </summary>
        ContentAccessDenied = 2810,

        /// <summary>
        /// 
        /// </summary>
        ContentNotFound = 2811,

        /// <summary>
        /// 
        /// </summary>
        RegistrationNumberNotFound = 2812,

        /// <summary>
        /// 
        /// </summary>
        InvalidCostCenter = 2813,

        /// <summary>
        /// Sync flow restricts one record for Item model
        /// </summary>
        TooManyItemsInSyncFlowRequest = 2814,

        /// <summary>
        /// IMS-2096: Recommendation status update rule
        /// </summary>
        InvalidTaxCodeIdInRecommendationStatusUpdate = 2815,

        /// <summary>
        /// ECM communication certificates error
        /// </summary>
        CommunicationCertificatesError = 2816,

        /// <summary>
        /// Invalid currency and aggrement type combination
        /// </summary>
        InvalidCurrencyAggrementType = 2817,

        /// <summary>
        /// ItemTaxCodeRecommendation Status can't be set without particular state of recommendation
        /// </summary>
        InvalidTaxCodeRecommendationStatusUpdate = 2818,

        /// <summary>
        /// Filing Request Error Codes
        /// </summary>
        DuplicateFilingRequest = 2819,

        /// <summary>
        /// Occurs when a Header value is incorrect or invalid in some way
        /// </summary>
        InvalidHTTPHeader = 3000,

        /// <summary>
        /// 
        /// </summary>
        SCSServiceUnreachable = 3001,

        /// <summary>
        /// 
        /// </summary>
        DuplicateContactCode = 3002,

        /// <summary>
        /// 
        /// </summary>
        SCSServerError = 3003,

        /// <summary>
        /// Occurs when user reconciliation happens and unable to create user at AvaTax
        /// </summary>
        UserReconciliationError = 3004,

        /// <summary>
        /// Occurs when a patch operation is attempted on a field that is not allowed to be patched
        /// </summary>
        InvalidHttpPatchRequest = 3005,

        /// <summary>
        /// Occurs when a patch operation other than 'given' operation is performed for the fields
        /// </summary>
        UnsupportedPatchOperationError = 3006,

        /// <summary>
        /// Occurs when system code and country code does not have active mapping.
        /// </summary>
        SystemCodeAndCountryCodeMismatch = 3007,

        /// <summary>
        /// Occurs when multiple entries for system code and country code exists.
        /// </summary>
        DuplicateSystemAndCountryForItem = 3008,

        /// <summary>
        /// 
        /// </summary>
        InvalidHsCodeClassificationStatusOverride = 3009,

        /// <summary>
        /// Occurs when the field name provided in the request isn't valid.
        /// </summary>
        InvalidField = 3010,

        /// <summary>
        /// Avalara Gateway errors:
        /// </summary>
        NotFound = 4001,

        /// <summary>
        /// 
        /// </summary>
        Unexpected = 4002,

        /// <summary>
        /// 
        /// </summary>
        NoHostFound = 4003,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedAuth = 4004,

        /// <summary>
        /// 
        /// </summary>
        SiteSelectionFailed = 4006,

        /// <summary>
        /// 
        /// </summary>
        DropDefaultUsername = 4007,

        /// <summary>
        /// 
        /// </summary>
        DropDefaultNotMigrated = 4008,

        /// <summary>
        /// 
        /// </summary>
        DropBearerAuth = 4009,

        /// <summary>
        /// 
        /// </summary>
        SiteSelectionError = 4010,

        /// <summary>
        /// 
        /// </summary>
        RateLimitExceeded = 4011,

        /// <summary>
        /// 
        /// </summary>
        NoHealthySite = 4012,

        /// <summary>
        /// 
        /// </summary>
        ClientDisconnected = 4013,

        /// <summary>
        /// 
        /// </summary>
        ServiceDisconnected = 4014,

        /// <summary>
        /// 
        /// </summary>
        ServiceTimeout = 4015,

        /// <summary>
        /// Error string from the service unknown
        /// </summary>
        UnexpectedError = -1,

    }
}
