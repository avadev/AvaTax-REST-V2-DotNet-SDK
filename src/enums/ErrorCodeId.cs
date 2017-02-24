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
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// ErrorCodeId
    /// </summary>
    public enum ErrorCodeId
    {
        /// <summary>
        /// 
        /// </summary>
        ServerConfiguration,

        /// <summary>
        /// 
        /// </summary>
        AccountInvalidException,

        /// <summary>
        /// 
        /// </summary>
        CompanyInvalidException,

        /// <summary>
        /// 
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
        PointOfSaleFileSize,

        /// <summary>
        /// 
        /// </summary>
        PointOfSaleSetup,

        /// <summary>
        /// 
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
        BadDocumentFetch,

        /// <summary>
        /// 
        /// </summary>
        ServerUnreachable,

        /// <summary>
        /// 
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
        ZTBListConnectorFail,

        /// <summary>
        /// 
        /// </summary>
        ZTBCreateSubscriptionsFail,

    }
}
