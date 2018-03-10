using System;

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
        ServerConfiguration,

        /// <summary>
        /// User doesn't have rights to this account or company
        /// </summary>
        AccountInvalidException,

        /// <summary>
        /// 
        /// </summary>
        CompanyInvalidException,

        /// <summary>
        /// Use this error message when the user is trying to fetch a single object and the object either does not exist or cannot be seen by the current user.
        /// </summary>
        EntityNotFoundError,

        /// <summary>
        /// 
        /// </summary>
        ValueRequiredError,

        /// <summary>
        /// 
        /// </summary>
        RangeError,

        /// <summary>
        /// 
        /// </summary>
        RangeCompareError,

        /// <summary>
        /// 
        /// </summary>
        RangeSetError,

        /// <summary>
        /// 
        /// </summary>
        TaxpayerNumberRequired,

        /// <summary>
        /// 
        /// </summary>
        CommonPassword,

        /// <summary>
        /// 
        /// </summary>
        WeakPassword,

        /// <summary>
        /// 
        /// </summary>
        StringLengthError,

        /// <summary>
        /// 
        /// </summary>
        MaxStringLengthError,

        /// <summary>
        /// 
        /// </summary>
        EmailValidationError,

        /// <summary>
        /// 
        /// </summary>
        EmailMissingError,

        /// <summary>
        /// 
        /// </summary>
        ParserFieldNameError,

        /// <summary>
        /// 
        /// </summary>
        ParserFieldValueError,

        /// <summary>
        /// 
        /// </summary>
        ParserSyntaxError,

        /// <summary>
        /// 
        /// </summary>
        ParserTooManyParametersError,

        /// <summary>
        /// 
        /// </summary>
        ParserUnterminatedValueError,

        /// <summary>
        /// 
        /// </summary>
        DeleteUserSelfError,

        /// <summary>
        /// 
        /// </summary>
        OldPasswordInvalid,

        /// <summary>
        /// 
        /// </summary>
        CannotChangePassword,

        /// <summary>
        /// 
        /// </summary>
        CannotChangeCompanyCode,

        /// <summary>
        /// 
        /// </summary>
        DateFormatError,

        /// <summary>
        /// 
        /// </summary>
        NoDefaultCompany,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationException,

        /// <summary>
        /// 
        /// </summary>
        AuthorizationException,

        /// <summary>
        /// 
        /// </summary>
        ValidationException,

        /// <summary>
        /// 
        /// </summary>
        InactiveUserError,

        /// <summary>
        /// 
        /// </summary>
        AuthenticationIncomplete,

        /// <summary>
        /// 
        /// </summary>
        BasicAuthIncorrect,

        /// <summary>
        /// 
        /// </summary>
        IdentityServerError,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenInvalid,

        /// <summary>
        /// 
        /// </summary>
        ModelRequiredException,

        /// <summary>
        /// 
        /// </summary>
        AccountExpiredException,

        /// <summary>
        /// 
        /// </summary>
        VisibilityError,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenNotSupported,

        /// <summary>
        /// 
        /// </summary>
        InvalidSecurityRole,

        /// <summary>
        /// 
        /// </summary>
        InvalidRegistrarAction,

        /// <summary>
        /// 
        /// </summary>
        RemoteServerError,

        /// <summary>
        /// 
        /// </summary>
        NoFilterCriteriaException,

        /// <summary>
        /// 
        /// </summary>
        OpenClauseException,

        /// <summary>
        /// 
        /// </summary>
        JsonFormatError,

        /// <summary>
        /// 
        /// </summary>
        UnhandledException,

        /// <summary>
        /// 
        /// </summary>
        ReportingCompanyMustHaveContactsError,

        /// <summary>
        /// 
        /// </summary>
        CompanyProfileNotSet,

        /// <summary>
        /// 
        /// </summary>
        CannotAssignUserToCompany,

        /// <summary>
        /// 
        /// </summary>
        MustAssignUserToCompany,

        /// <summary>
        /// 
        /// </summary>
        ModelStateInvalid,

        /// <summary>
        /// 
        /// </summary>
        DateRangeError,

        /// <summary>
        /// 
        /// </summary>
        InvalidDateRangeError,

        /// <summary>
        /// 
        /// </summary>
        DeleteInformation,

        /// <summary>
        /// 
        /// </summary>
        CannotCreateDeletedObjects,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyDeletedObjects,

        /// <summary>
        /// 
        /// </summary>
        ReturnNameNotFound,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTypeAndCategory,

        /// <summary>
        /// 
        /// </summary>
        DefaultCompanyLocation,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountry,

        /// <summary>
        /// 
        /// </summary>
        InvalidCountryRegion,

        /// <summary>
        /// 
        /// </summary>
        BrazilValidationError,

        /// <summary>
        /// 
        /// </summary>
        BrazilExemptValidationError,

        /// <summary>
        /// 
        /// </summary>
        BrazilPisCofinsError,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionNotFoundError,

        /// <summary>
        /// 
        /// </summary>
        MedicalExciseError,

        /// <summary>
        /// 
        /// </summary>
        RateDependsTaxabilityError,

        /// <summary>
        /// 
        /// </summary>
        RateDependsEuropeError,

        /// <summary>
        /// 
        /// </summary>
        InvalidRateTypeCode,

        /// <summary>
        /// 
        /// </summary>
        RateTypeNotSupported,

        /// <summary>
        /// 
        /// </summary>
        CannotUpdateNestedObjects,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidChars,

        /// <summary>
        /// 
        /// </summary>
        UPCCodeInvalidLength,

        /// <summary>
        /// 
        /// </summary>
        IncorrectPathError,

        /// <summary>
        /// 
        /// </summary>
        InvalidJurisdictionType,

        /// <summary>
        /// 
        /// </summary>
        MustConfirmResetLicenseKey,

        /// <summary>
        /// 
        /// </summary>
        DuplicateCompanyCode,

        /// <summary>
        /// 
        /// </summary>
        TINFormatError,

        /// <summary>
        /// 
        /// </summary>
        DuplicateNexusError,

        /// <summary>
        /// 
        /// </summary>
        UnknownNexusError,

        /// <summary>
        /// 
        /// </summary>
        ParentNexusNotFound,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxCodeType,

        /// <summary>
        /// 
        /// </summary>
        CannotActivateCompany,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEntityProperty,

        /// <summary>
        /// 
        /// </summary>
        ReportingEntityError,

        /// <summary>
        /// 
        /// </summary>
        InvalidReturnOperationError,

        /// <summary>
        /// 
        /// </summary>
        CannotDeleteCompany,

        /// <summary>
        /// 
        /// </summary>
        CountryOverridesNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        JurisdictionOverrideMismatch,

        /// <summary>
        /// 
        /// </summary>
        DuplicateSystemTaxCode,

        /// <summary>
        /// 
        /// </summary>
        SSTOverridesNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        NexusDateMismatch,

        /// <summary>
        /// 
        /// </summary>
        TechSupportAuditRequired,

        /// <summary>
        /// 
        /// </summary>
        NexusParentDateMismatch,

        /// <summary>
        /// 
        /// </summary>
        BearerTokenParseUserIdError,

        /// <summary>
        /// 
        /// </summary>
        RetrieveUserError,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationSetting,

        /// <summary>
        /// 
        /// </summary>
        InvalidConfigurationValue,

        /// <summary>
        /// 
        /// </summary>
        InvalidEnumValue,

        /// <summary>
        /// 
        /// </summary>
        TaxCodeAssociatedTaxRule,

        /// <summary>
        /// 
        /// </summary>
        CannotSwitchAccountId,

        /// <summary>
        /// 
        /// </summary>
        RequestIncomplete,

        /// <summary>
        /// 
        /// </summary>
        AccountNotNew,

        /// <summary>
        /// 
        /// </summary>
        PasswordLengthInvalid,

        /// <summary>
        /// 
        /// </summary>
        LocalNexusConflict,

        /// <summary>
        /// 
        /// </summary>
        InvalidEcmsOverrideCode,

        /// <summary>
        /// 
        /// </summary>
        AccountDoesNotExist,

        /// <summary>
        /// 
        /// </summary>
        InvalidTaxType,

        /// <summary>
        /// 
        /// </summary>
        IncorrectFieldValue,

        /// <summary>
        /// 
        /// </summary>
        LeadingOrTrailingException,

        /// <summary>
        /// 
        /// </summary>
        NotEnoughAddressesInfo,

        /// <summary>
        /// 
        /// </summary>
        ReportNotInitiated,

        /// <summary>
        /// 
        /// </summary>
        FailedToBuildReport,

        /// <summary>
        /// 
        /// </summary>
        ReportNotFinished,

        /// <summary>
        /// 
        /// </summary>
        FailedToUploadReport,

        /// <summary>
        /// 
        /// </summary>
        FailedToDownloadReport,

        /// <summary>
        /// 
        /// </summary>
        MalformedFilterException,

        /// <summary>
        /// 
        /// </summary>
        ExpectedConjunctionError,

        /// <summary>
        /// 
        /// </summary>
        CriteriaNotSupportedError,

        /// <summary>
        /// 
        /// </summary>
        CompanyAccountAndParentAccountMismatch,

        /// <summary>
        /// 
        /// </summary>
        InvalidFileContentType,

        /// <summary>
        /// 
        /// </summary>
        EcmsDisabled,

        /// <summary>
        /// 
        /// </summary>
        UnknownConjunctionError,

        /// <summary>
        /// 
        /// </summary>
        NoLinesDiscounted,

        /// <summary>
        /// 
        /// </summary>
        FailedToDelete,

        /// <summary>
        /// 
        /// </summary>
        CircularCompanyHierarchies,

        /// <summary>
        /// 
        /// </summary>
        DuplicateEntry,

        /// <summary>
        /// 
        /// </summary>
        DuplicateFieldNameInOrderBy,

        /// <summary>
        /// 
        /// </summary>
        CannotAdjustDocumentType,

        /// <summary>
        /// 
        /// </summary>
        UserNoAccess,

        /// <summary>
        /// Batch errors
        /// </summary>
        BatchSalesAuditMustBeZippedError,

        /// <summary>
        /// 
        /// </summary>
        BatchZipMustContainOneFileError,

        /// <summary>
        /// 
        /// </summary>
        BatchInvalidFileTypeError,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotSaveBatchFile,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotGetBatchFile,

        /// <summary>
        /// 
        /// </summary>
        BatchCannotDeleteBatchFile,

        /// <summary>
        /// 
        /// </summary>
        BatchMustContainOneFile,

        /// <summary>
        /// 
        /// </summary>
        MissingBatchFileContent,

        /// <summary>
        /// Point Of Sale API exceptions
        /// </summary>
        PointOfSaleFileSize,

        /// <summary>
        /// 
        /// </summary>
        PointOfSaleSetup,

        /// <summary>
        /// 
        /// </summary>
        InvalidInputDate,

        /// <summary>
        /// 
        /// </summary>
        RequestedFileNotExist,

        /// <summary>
        /// Errors in Soap V1 Passthrough / GetTax calls
        /// </summary>
        GetTaxError,

        /// <summary>
        /// 
        /// </summary>
        AddressConflictException,

        /// <summary>
        /// 
        /// </summary>
        DocumentCodeConflict,

        /// <summary>
        /// 
        /// </summary>
        MissingAddress,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameter,

        /// <summary>
        /// 
        /// </summary>
        InvalidParameterValue,

        /// <summary>
        /// 
        /// </summary>
        CompanyCodeConflict,

        /// <summary>
        /// 
        /// </summary>
        DocumentFetchLimit,

        /// <summary>
        /// 
        /// </summary>
        AddressIncomplete,

        /// <summary>
        /// 
        /// </summary>
        AddressLocationNotFound,

        /// <summary>
        /// 
        /// </summary>
        MissingLine,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddressTextCase,

        /// <summary>
        /// 
        /// </summary>
        DocumentNotCommitted,

        /// <summary>
        /// 
        /// </summary>
        MultiDocumentTypesError,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypesToFetch,

        /// <summary>
        /// 
        /// </summary>
        TimeoutRequested,

        /// <summary>
        /// 
        /// </summary>
        InvalidAddress,

        /// <summary>
        /// 
        /// </summary>
        InvalidPostalCode,

        /// <summary>
        /// Represents a malformed document fetch command
        /// </summary>
        BadDocumentFetch,

        /// <summary>
        /// 
        /// </summary>
        CannotChangeFilingStatus,

        /// <summary>
        /// Represents a SQL server timeout error / deadlock error
        /// </summary>
        ServerUnreachable,

        /// <summary>
        /// Partner API error codes
        /// </summary>
        SubscriptionRequired,

        /// <summary>
        /// 
        /// </summary>
        AccountExists,

        /// <summary>
        /// 
        /// </summary>
        InvitationOnly,

        /// <summary>
        /// 
        /// </summary>
        FreeTrialNotAvailable,

        /// <summary>
        /// 
        /// </summary>
        AccountExistsDifferentEmail,

        /// <summary>
        /// 
        /// </summary>
        AvalaraIdentityApiError,

        /// <summary>
        /// 
        /// </summary>
        InvalidIPAddress,

        /// <summary>
        /// Refund API error codes
        /// </summary>
        InvalidDocumentStatusForRefund,

        /// <summary>
        /// 
        /// </summary>
        RefundTypeAndPercentageMismatch,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentTypeForRefund,

        /// <summary>
        /// 
        /// </summary>
        RefundTypeAndLineMismatch,

        /// <summary>
        /// 
        /// </summary>
        RefundLinesRequired,

        /// <summary>
        /// 
        /// </summary>
        InvalidRefundType,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageForTaxOnly,

        /// <summary>
        /// 
        /// </summary>
        LineNoOutOfRange,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageOutOfRange,

        /// <summary>
        /// 
        /// </summary>
        RefundPercentageMissing,

        /// <summary>
        /// Free API error codes
        /// </summary>
        MustUseCreateTransaction,

        /// <summary>
        /// Filing Calendar Error Codes
        /// </summary>
        FilingCalendarCannotBeDeleted,

        /// <summary>
        /// 
        /// </summary>
        InvalidEffectiveDate,

        /// <summary>
        /// 
        /// </summary>
        NonOutletForm,

        /// <summary>
        /// 
        /// </summary>
        OverlappingFilingCalendar,

        /// <summary>
        /// Location error codes
        /// </summary>
        QuestionNotNeededForThisAddress,

        /// <summary>
        /// 
        /// </summary>
        QuestionNotValidForThisAddress,

        /// <summary>
        /// Create or update transaction error codes
        /// </summary>
        CannotModifyLockedTransaction,

        /// <summary>
        /// 
        /// </summary>
        LineAlreadyExists,

        /// <summary>
        /// 
        /// </summary>
        LineDoesNotExist,

        /// <summary>
        /// 
        /// </summary>
        LinesNotSpecified,

        /// <summary>
        /// Exempt cert error codes
        /// </summary>
        InvalidBusinessType,

        /// <summary>
        /// 
        /// </summary>
        CannotModifyExemptCert,

        /// <summary>
        /// 
        /// </summary>
        CertCaptureFieldValidationError,

        /// <summary>
        /// 
        /// </summary>
        CertCaptureError,

        /// <summary>
        /// 
        /// </summary>
        MissingRequiredFields,

        /// <summary>
        /// 
        /// </summary>
        CertCaptureNotConfiguredError,

        /// <summary>
        /// 
        /// </summary>
        AddRelationshipsError,

        /// <summary>
        /// 
        /// </summary>
        MissingExposureZone,

        /// <summary>
        /// 
        /// </summary>
        ConflictingExposureZone,

        /// <summary>
        /// 
        /// </summary>
        MissingFieldToCreateExposureZone,

        /// <summary>
        /// 
        /// </summary>
        MissingExemptReason,

        /// <summary>
        /// 
        /// </summary>
        InvalidExemptReason,

        /// <summary>
        /// 
        /// </summary>
        InvalidCertCaptureOperation,

        /// <summary>
        /// 
        /// </summary>
        ConflictingFields,

        /// <summary>
        /// 
        /// </summary>
        InvalidPdfOrImageFile,

        /// <summary>
        /// 
        /// </summary>
        InvalidCoverLetterTitle,

        /// <summary>
        /// 
        /// </summary>
        AccountNotProvisioned,

        /// <summary>
        /// Multi document error codes
        /// </summary>
        TransactionNotCancelled,

        /// <summary>
        /// 
        /// </summary>
        TooManyTransactions,

        /// <summary>
        /// 
        /// </summary>
        OnlyTaxDateOverrideIsAllowed,

        /// <summary>
        /// 
        /// </summary>
        TransactionAlreadyExists,

        /// <summary>
        /// 
        /// </summary>
        DateMismatch,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentStatusForVerify,

        /// <summary>
        /// 
        /// </summary>
        TotalAmountMismatch,

        /// <summary>
        /// 
        /// </summary>
        TotalTaxMismatch,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentStatusForCommit,

        /// <summary>
        /// 
        /// </summary>
        InvalidDocumentType,

        /// <summary>
        /// 
        /// </summary>
        MultiDocumentPartiallyLocked,

        /// <summary>
        /// 
        /// </summary>
        TransactionIsCommitted,

        /// <summary>
        /// Communications Tax error codes
        /// </summary>
        CommsConfigClientIdMissing,

        /// <summary>
        /// 
        /// </summary>
        CommsConfigClientIdBadValue,

        /// <summary>
        /// BizTech API error codes
        /// </summary>
        BizTechCustomerAccountFailure,

        /// <summary>
        /// 
        /// </summary>
        BizTechOpportunityCreationFailure,

        /// <summary>
        /// Account Activate error codes
        /// </summary>
        AccountInNewStatusException,

        /// <summary>
        /// Worksheet Exception
        /// </summary>
        WorksheetException,

    }
}
