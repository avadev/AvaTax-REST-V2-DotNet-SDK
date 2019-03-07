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
        DateFormatError = 26,

        /// <summary>
        /// 
        /// </summary>
        NoDefaultCompany = 27,

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
        VisibilityError = 40,

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
        UnhandledException = 50,

        /// <summary>
        /// 
        /// </summary>
        InactiveAccount = 51,

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
        RateDependsEuropeError = 133,

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
        LocalNexusConflict = 170,

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
        DocumentFetchLimit = 308,

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
        /// Refund API error codes
        /// </summary>
        InvalidDocumentStatusForRefund = 700,

        /// <summary>
        /// 
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
        AddRelationshipsError = 1206,

        /// <summary>
        /// 
        /// </summary>
        MissingExposureZone = 1207,

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
        AdvancedRuleBadScript = 1600,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleBadCsvTable = 1601,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleRequestRuleError = 1602,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleResponseRuleError = 1603,

        /// <summary>
        /// 
        /// </summary>
        AdvancedRuleNotApproved = 1604,

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
