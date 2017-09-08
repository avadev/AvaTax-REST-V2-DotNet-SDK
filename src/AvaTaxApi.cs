using System;
using System.Collections.Generic;
#if PORTABLE
using System.Net.Http;
using System.Threading.Tasks;
#endif

/*
 * AvaTax Software Development Kit for C#
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <ted.spence@avalara.com>
 * @author     Zhenya Frolov <zhenya.frolov@avalara.com>
 * @copyright  2004-2017 Avalara, Inc.
 * @license    https://www.apache.org/licenses/LICENSE-2.0
 * @version    17.8.1-722
 * @link       https://github.com/avadev/AvaTax-REST-V2-DotNet-SDK
 */

namespace Avalara.AvaTax.RestClient
{
    public partial class AvaTaxClient
    {
        /// <summary>
        /// Returns the version number of the API used to generate this class
        /// </summary>
        public static string API_VERSION { get { return "17.8.1-722"; } }

#region Methods

        /// <summary>
        /// Reset this account's license key
        /// </summary>
        /// <remarks>
        /// Resets the existing license key for this account to a new key.
        /// To reset your account, you must specify the ID of the account you wish to reset and confirm the action.
        /// Resetting a license key cannot be undone. Any previous license keys will immediately cease to work when a new key is created.
        /// </remarks>
        /// <param name="id">The ID of the account you wish to update.</param>
        /// <param name="model">A request confirming that you wish to reset the license key of this account.</param>
        public LicenseKeyModel AccountResetLicenseKey(Int32 id, ResetLicenseKeyModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/resetlicensekey");
            path.ApplyField("id", id);
            return RestCall<LicenseKeyModel>("Post", path, model);
        }


        /// <summary>
        /// Activate an account by accepting terms and conditions
        /// </summary>
        /// <remarks>
        /// Activate the account specified by the unique accountId number.
        /// 
        /// This activation request can only be called by account administrators. You must indicate 
        /// that you have read and accepted Avalara's terms and conditions to call this API.
        /// 
        /// If you have not read or accepted the terms and conditions, this API call will return the
        /// unchanged account model.
        /// </remarks>
        /// <param name="id">The ID of the account to activate</param>
        /// <param name="include">Elements to include when fetching the account</param>
        /// <param name="model">The activation request</param>
        public AccountModel ActivateAccount(Int32 id, String include, ActivateAccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/activate");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<AccountModel>("Post", path, model);
        }


        /// <summary>
        /// Retrieve a single account
        /// </summary>
        /// <remarks>
        /// Get the account object identified by this URL.
        /// You may use the '$include' parameter to fetch additional nested data:
        /// 
        /// * Subscriptions
        /// * Users
        /// </remarks>
        /// <param name="id">The ID of the account to retrieve</param>
        /// <param name="include">A comma separated list of special fetch options</param>
        public AccountModel GetAccount(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<AccountModel>("Get", path, null);
        }


        /// <summary>
        /// Get configuration settings for this account
        /// </summary>
        /// <remarks>
        /// Retrieve a list of all configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `TaxServiceConfig` and `AddressServiceConfig` are reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Account settings are permanent settings that cannot be deleted. You can set the value of an
        /// account setting to null if desired.
        /// 
        /// Avalara-based account settings for `TaxServiceConfig` and `AddressServiceConfig` affect your account's
        /// tax calculation and address resolution, and should only be changed with care.
        /// </remarks>
        /// <param name="id"></param>
        public List<AccountConfigurationModel> GetAccountConfiguration(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return RestCall<List<AccountConfigurationModel>>("Get", path, null);
        }


        /// <summary>
        /// Change configuration settings for this account
        /// </summary>
        /// <remarks>
        /// Update configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `TaxServiceConfig` and `AddressServiceConfig` are reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Account settings are permanent settings that cannot be deleted. You can set the value of an
        /// account setting to null if desired.
        /// 
        /// Avalara-based account settings for `TaxServiceConfig` and `AddressServiceConfig` affect your account's
        /// tax calculation and address resolution, and should only be changed with care.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public List<AccountConfigurationModel> SetAccountConfiguration(Int32 id, List<AccountConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return RestCall<List<AccountConfigurationModel>>("Post", path, model);
        }


        /// <summary>
        /// Retrieve geolocation information for a specified address
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the POST /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.
        /// </remarks>
        /// <param name="line1">Line 1</param>
        /// <param name="line2">Line 2</param>
        /// <param name="line3">Line 3</param>
        /// <param name="city">City</param>
        /// <param name="region">State / Province / Region</param>
        /// <param name="postalCode">Postal Code / Zip Code</param>
        /// <param name="country">Two character ISO 3166 Country Code (see /api/v2/definitions/countries for a full list)</param>
        /// <param name="textCase">selectable text case for address validation</param>
        /// <param name="latitude">Geospatial latitude measurement</param>
        /// <param name="longitude">Geospatial longitude measurement</param>
        public AddressResolutionModel ResolveAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, TextCase? textCase, Decimal? latitude, Decimal? longitude)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("textCase", textCase);
            path.AddQuery("latitude", latitude);
            path.AddQuery("longitude", longitude);
            return RestCall<AddressResolutionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve geolocation information for a specified address
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the GET /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.
        /// </remarks>
        /// <param name="model">The address to resolve</param>
        public AddressResolutionModel ResolveAddressPost(AddressValidationInfo model)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            return RestCall<AddressResolutionModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new batch
        /// </summary>
        /// <remarks>
        /// Create one or more new batch objects attached to this company.
        /// When you create a batch, it is added to the AvaTaxBatch.Batch table and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// Each batch object may have one or more file objects (currently only one file is supported).
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch.</param>
        /// <param name="model">The batch you wish to create.</param>
        public List<BatchModel> CreateBatches(Int32 companyId, List<BatchModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            return RestCall<List<BatchModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single batch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch.</param>
        /// <param name="id">The ID of the batch you wish to delete.</param>
        public List<ErrorDetail> DeleteBatch(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Download a single batch file
        /// </summary>
        /// <remarks>
        /// Download a single batch file identified by this URL.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch</param>
        /// <param name="batchId">The ID of the batch object</param>
        /// <param name="id">The primary key of this batch file object</param>
        public FileResult DownloadBatch(Int32 companyId, Int32 batchId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{batchId}/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("batchId", batchId);
            path.ApplyField("id", id);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single batch
        /// </summary>
        /// <remarks>
        /// Get the batch object identified by this URL.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch</param>
        /// <param name="id">The primary key of this batch</param>
        public BatchModel GetBatch(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<BatchModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all batches for this company
        /// </summary>
        /// <remarks>
        /// List all batch objects attached to the specified company.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<BatchModel> ListBatchesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<BatchModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all batches
        /// </summary>
        /// <remarks>
        /// Get multiple batch objects across all companies.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<BatchModel> QueryBatches(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/batches");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<BatchModel>>("Get", path, null);
        }


        /// <summary>
        /// Create a CertExpress invitation
        /// </summary>
        /// <remarks>
        /// Creates an invitation for a customer to self-report certificates using the CertExpress website.
        /// 
        /// This invitation is delivered by your choice of method, or you can present a hyperlink to the user
        /// directly in your connector. Your customer will be redirected to https://app.certexpress.com/ where
        /// they can follow a step-by-step guide to enter information about their exemption certificates. The
        /// certificates entered will be recorded and automatically linked to their customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that will record certificates</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="model">the requests to send out to customers</param>
        public List<CertExpressInvitationStatusModel> CreateCertExpressInvitation(Int32 companyId, String customerCode, List<CreateCertExpressInvitationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return RestCall<List<CertExpressInvitationStatusModel>>("Post", path, model);
        }


        /// <summary>
        /// Retrieve a single CertExpress invitation
        /// </summary>
        /// <remarks>
        /// Retrieve an existing CertExpress invitation sent to a customer.
        /// 
        /// A CertExpression invitation allows a customer to follow a helpful step-by-step guide to provide information
        /// about their certificates. This step by step guide allows the customer to complete and upload the full 
        /// certificate in a convenient, friendly web browser experience. When the customer completes their certificates,
        /// they will automatically be recorded to your company and linked to the customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="id">The unique ID number of this CertExpress invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. No options are defined at this time.</param>
        public CertExpressInvitationModel GetCertExpressInvitation(Int32 companyId, String customerCode, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<CertExpressInvitationModel>("Get", path, null);
        }


        /// <summary>
        /// List CertExpress invitations
        /// </summary>
        /// <remarks>
        /// Retrieve CertExpress invitations sent by this company.
        /// 
        /// A CertExpression invitation allows a customer to follow a helpful step-by-step guide to provide information
        /// about their certificates. This step by step guide allows the customer to complete and upload the full 
        /// certificate in a convenient, friendly web browser experience. When the customer completes their certificates,
        /// they will automatically be recorded to your company and linked to the customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  
        ///  No options are defined at this time.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CertExpressInvitationModel> ListCertExpressInvitations(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CertExpressInvitationModel>>("Get", path, null);
        }


        /// <summary>
        /// Create certificates for this company
        /// </summary>
        /// <remarks>
        /// Record one or more certificates document for this company.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// When you create a certificate, it will be processed by Avalara and will become available for use in
        /// calculating tax exemptions when processing is complete. For a certificate to be used in calculating exemptions,
        /// it must have the following:
        /// 
        /// * A list of exposure zones indicating where the certificate is valid
        /// * A link to the customer that is allowed to use this certificate
        /// * Your tax transaction must contain the correct customer code
        /// </remarks>
        /// <param name="companyId">The ID number of the company recording this certificate</param>
        /// <param name="model">Certificates to be created</param>
        public List<CertificateModel> CreateCertificates(Int32 companyId, List<CertificateModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            return RestCall<List<CertificateModel>>("Post", path, model);
        }


        /// <summary>
        /// Revoke and delete a certificate
        /// </summary>
        /// <remarks>
        /// Revoke the certificate identified by this URL, then delete it.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// Revoked certificates can no longer be used.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public CertificateModel DeleteCertificate(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<CertificateModel>("Delete", path, null);
        }


        /// <summary>
        /// Download an image for this certificate
        /// </summary>
        /// <remarks>
        /// Download an image or PDF file for this certificate.
        /// 
        /// This API can be used to download either a single-page preview of the certificate or a full PDF document.
        /// To retrieve a preview image, set the `$type` parameter to `Jpeg` and the `$page` parameter to `1`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="page">If you choose `$type`=`Jpeg`, you must specify which page number to retrieve.</param>
        /// <param name="type">The data format in which to retrieve the certificate image</param>
        public FileResult DownloadCertificateImage(Int32 companyId, Int32 id, Int32? page, CertificatePreviewType? type)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$page", page);
            path.AddQuery("$type", type);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single certificate
        /// </summary>
        /// <remarks>
        /// Get the current certificate identified by this URL.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Customers - Retrieves the list of customers linked to the certificate.
        /// * PoNumbers - Retrieves all PO numbers tied to the certificate.
        /// * Attributes - Retrieves all attributes applied to the certificate.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        public CertificateModel GetCertificate(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<CertificateModel>("Get", path, null);
        }


        /// <summary>
        /// Link attributes to a certificate
        /// </summary>
        /// <remarks>
        /// Link one or many attributes to a certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `ListCertificateAttributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to link to this certificate.</param>
        public FetchResult<CertificateAttributeModel> LinkAttributesToCertificate(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<CertificateAttributeModel>>("Post", path, model);
        }


        /// <summary>
        /// Link customers to a certificate
        /// </summary>
        /// <remarks>
        /// Link one or more customers to an existing certificate.
        /// 
        /// Customers and certificates must be linked before a customer can make use of a certificate to obtain
        /// a tax exemption in AvaTax. Since some certificates may cover more than one business entity, a certificate
        /// can be connected to multiple customer records using the `LinkCustomersToCertificate` API.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers needed be added to the Certificate for exemption</param>
        public FetchResult<CustomerModel> LinkCustomersToCertificate(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<CustomerModel>>("Post", path, model);
        }


        /// <summary>
        /// List all attributes applied to this certificate
        /// </summary>
        /// <remarks>
        /// Retrieve the list of attributes that are linked to this certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `/api/v2/definitions/certificateattributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public FetchResult<CertificateAttributeModel> ListAttributesForCertificate(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<CertificateAttributeModel>>("Get", path, null);
        }


        /// <summary>
        /// List customers linked to this certificate
        /// </summary>
        /// <remarks>
        /// List all customers linked to this certificate.
        /// 
        /// Customers must be linked to a certificate in order to make use of its tax exemption features. You
        /// can link or unlink customers to a certificate at any time.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  No options are currently available when fetching customers.</param>
        public FetchResult<CustomerModel> ListCustomersForCertificate(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<FetchResult<CustomerModel>>("Get", path, null);
        }


        /// <summary>
        /// List all certificates for a company
        /// </summary>
        /// <remarks>
        /// List all certificates recorded by a company
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Customers - Retrieves the list of customers linked to the certificate.
        /// * PoNumbers - Retrieves all PO numbers tied to the certificate.
        /// * Attributes - Retrieves all attributes applied to the certificate.
        /// </remarks>
        /// <param name="companyId">The ID number of the company to search</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CertificateModel> QueryCertificates(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CertificateModel>>("Get", path, null);
        }


        /// <summary>
        /// Unlink attributes from a certificate
        /// </summary>
        /// <remarks>
        /// Unlink one or many attributes from a certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `ListCertificateAttributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to unlink from this certificate.</param>
        public FetchResult<CertificateAttributeModel> UnlinkAttributesFromCertificate(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<CertificateAttributeModel>>("Post", path, model);
        }


        /// <summary>
        /// Unlink customers from a certificate
        /// </summary>
        /// <remarks>
        /// Unlinks one or more customers from a certificate.
        /// 
        /// Unlinking a certificate from a customer will prevent the certificate from being used to generate
        /// tax exemptions for the customer in the future. If any previous transactions for this customer had
        /// used this linked certificate, those transactions will be unchanged and will still have a link to the
        /// exemption certificate in question.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers to unlink from this certificate</param>
        public FetchResult<CustomerModel> UnlinkCustomersFromCertificate(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<CustomerModel>>("Post", path, model);
        }


        /// <summary>
        /// Update a single certificate
        /// </summary>
        /// <remarks>
        /// Replace the certificate identified by this URL with a new one.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The new certificate object that will replace the existing one</param>
        public CertificateModel UpdateCertificate(Int32 companyId, Int32 id, CertificateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<CertificateModel>("Put", path, model);
        }


        /// <summary>
        /// Upload an image or PDF attachment for this certificate
        /// </summary>
        /// <remarks>
        /// Upload an image or PDF attachment for this certificate.
        /// 
        /// Image attachments can be of the format `PDF`, `JPEG`, `TIFF`, or `PNG`. To upload a multi-page image, please
        /// use the `PDF` data type.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="file">The exemption certificate file you wanted to upload. Accepted formats are: PDF, JPEG, TIFF, PNG.</param>
        public String UploadCertificateImage(Int32 companyId, Int32 id, FileResult file)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCallString("Post", path, null);
        }


        /// <summary>
        /// Change the filing status of this company
        /// </summary>
        /// <remarks>
        /// Changes the current filing status of this company.
        /// 
        /// For customers using Avalara's Managed Returns Service, each company within their account can request
        /// for Avalara to file tax returns on their behalf. Avalara compliance team members will review all
        /// requested filing calendars prior to beginning filing tax returns on behalf of this company.
        /// 
        /// The following changes may be requested through this API:
        /// 
        /// * If a company is in `NotYetFiling` status, the customer may request this be changed to `FilingRequested`.
        /// * Avalara compliance team members may change a company from `FilingRequested` to `FirstFiling`.
        /// * Avalara compliance team members may change a company from `FirstFiling` to `Active`.
        /// 
        /// All other status changes must be requested through the Avalara customer support team.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public String ChangeFilingStatus(Int32 id, FilingStatusChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return RestCallString("Post", path, model);
        }


        /// <summary>
        /// Quick setup for a company with a single physical address
        /// </summary>
        /// <remarks>
        /// Shortcut to quickly setup a single-physical-location company with critical information and activate it.
        /// This API provides quick and simple company setup functionality and does the following things:
        ///  
        /// * Create a company object with its own tax profile
        /// * Add a key contact person for the company
        /// * Set up one physical location for the main office
        /// * Declare nexus in all taxing jurisdictions for that main office address
        /// * Activate the company
        ///  
        /// This API only provides a limited subset of functionality compared to the 'Create Company' API call. 
        /// If you need additional features or options not present in this 'Quick Setup' API call, please use the full 'Create Company' call instead.
        /// </remarks>
        /// <param name="model">Information about the company you wish to create.</param>
        public CompanyModel CompanyInitialize(CompanyInitializationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/initialize");
            return RestCall<CompanyModel>("Post", path, model);
        }


        /// <summary>
        /// Create new companies
        /// </summary>
        /// <remarks>
        /// Create one or more new company objects.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// You may attach nested data objects such as contacts, locations, and nexus with this CREATE call, and those objects will be created with the company.
        /// </remarks>
        /// <param name="model">Either a single company object or an array of companies to create</param>
        public List<CompanyModel> CreateCompanies(List<CompanyModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            return RestCall<List<CompanyModel>>("Post", path, model);
        }


        /// <summary>
        /// Request managed returns funding setup for a company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API records that an ambedded HTML funding setup widget was activated.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// </remarks>
        /// <param name="id">The unique identifier of the company</param>
        /// <param name="model">The funding initialization request</param>
        public FundingStatusModel CreateFundingRequest(Int32 id, FundingInitiateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding/setup");
            path.ApplyField("id", id);
            return RestCall<FundingStatusModel>("Post", path, model);
        }


        /// <summary>
        /// Delete a single company
        /// </summary>
        /// <remarks>
        /// Deleting a company will delete all child companies, and all users attached to this company.
        /// </remarks>
        /// <param name="id">The ID of the company you wish to delete.</param>
        public List<ErrorDetail> DeleteCompany(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single company
        /// </summary>
        /// <remarks>
        /// Get the company object identified by this URL.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Contacts
        ///  * Items
        ///  * Locations
        ///  * Nexus
        ///  * Settings
        ///  * TaxCodes
        ///  * TaxRules
        ///  * UPC
        /// </remarks>
        /// <param name="id">The ID of the company to retrieve.</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  
        ///  * Child objects - Specify one or more of the following to retrieve objects related to each company: "Contacts", "FilingCalendars", "Items", "Locations", "Nexus", "TaxCodes", or "TaxRules".
        ///  * Deleted objects - Specify "FetchDeleted" to retrieve information about previously deleted objects.</param>
        public CompanyModel GetCompany(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<CompanyModel>("Get", path, null);
        }


        /// <summary>
        /// Get configuration settings for this company
        /// </summary>
        /// <remarks>
        /// Retrieve a list of all configuration settings tied to this company.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `AvaCertServiceConfig` is reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Company settings are permanent settings that cannot be deleted. You can set the value of a
        /// company setting to null if desired.
        /// 
        /// Avalara-based account settings for `AvaCertServiceConfig` affect your account's exemption certificate
        /// processing, and should only be changed with care.
        /// </remarks>
        /// <param name="id"></param>
        public List<CompanyConfigurationModel> GetCompanyConfiguration(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return RestCall<List<CompanyConfigurationModel>>("Get", path, null);
        }


        /// <summary>
        /// Get this company's filing status
        /// </summary>
        /// <remarks>
        /// Retrieve the current filing status of this company.
        /// 
        /// For customers using Avalara's Managed Returns Service, each company within their account can request
        /// for Avalara to file tax returns on their behalf. Avalara compliance team members will review all
        /// requested filing calendars prior to beginning filing tax returns on behalf of this company.
        /// 
        /// A company's filing status can be one of the following values:
        /// 
        /// * `NoReporting` - This company is not configured to report tax returns; instead, it reports through a parent company.
        /// * `NotYetFiling` - This company has not yet begun filing tax returns through Avalara's Managed Returns Service.
        /// * `FilingRequested` - The company has requested to begin filing tax returns, but Avalara's compliance team has not yet begun filing.
        /// * `FirstFiling` - The company has recently filing tax returns and is in a new status.
        /// * `Active` - The company is currently active and is filing tax returns via Avalara Managed Returns.
        /// </remarks>
        /// <param name="id"></param>
        public String GetFilingStatus(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return RestCallString("Get", path, null);
        }


        /// <summary>
        /// Check managed returns funding configuration for a company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// Returns a list of funding setup requests and their current status.
        /// Each object in the result is a request that was made to setup or adjust funding configuration for this company.
        /// </remarks>
        /// <param name="id">The unique identifier of the company</param>
        public List<FundingStatusModel> ListFundingRequestsByCompany(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding");
            path.ApplyField("id", id);
            return RestCall<List<FundingStatusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of MRS Companies with account
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// Get a list of companies with an active MRS service.
        /// </remarks>
        public FetchResult<CompanyModel> ListMrsCompanies()
        {
            var path = new AvaTaxPath("/api/v2/companies/mrs");
            return RestCall<FetchResult<CompanyModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all companies
        /// </summary>
        /// <remarks>
        /// Get multiple company objects.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Contacts
        /// * Items
        /// * Locations
        /// * Nexus
        /// * Settings
        /// * TaxCodes
        /// * TaxRules
        /// * UPC
        /// </remarks>
        /// <param name="include">A comma separated list of objects to fetch underneath this company. Any object with a URL path underneath this company can be fetched by specifying its name.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CompanyModel> QueryCompanies(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CompanyModel>>("Get", path, null);
        }


        /// <summary>
        /// Change configuration settings for this account
        /// </summary>
        /// <remarks>
        /// Update configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `AvaCertServiceConfig` is reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Company settings are permanent settings that cannot be deleted. You can set the value of a
        /// company setting to null if desired.
        /// 
        /// Avalara-based account settings for `AvaCertServiceConfig` affect your account's exemption certificate
        /// processing, and should only be changed with care.
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public List<CompanyConfigurationModel> SetCompanyConfiguration(Int32 id, List<CompanyConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return RestCall<List<CompanyConfigurationModel>>("Post", path, model);
        }


        /// <summary>
        /// Update a single company
        /// </summary>
        /// <remarks>
        /// Replace the existing company object at this URL with an updated object.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="id">The ID of the company you wish to update.</param>
        /// <param name="model">The company object you wish to update.</param>
        public CompanyModel UpdateCompany(Int32 id, CompanyModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return RestCall<CompanyModel>("Put", path, model);
        }


        /// <summary>
        /// Create a new contact
        /// </summary>
        /// <remarks>
        /// Create one or more new contact objects.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this contact.</param>
        /// <param name="model">The contacts you wish to create.</param>
        public List<ContactModel> CreateContacts(Int32 companyId, List<ContactModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            return RestCall<List<ContactModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single contact
        /// </summary>
        /// <remarks>
        /// Mark the existing contact object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this contact.</param>
        /// <param name="id">The ID of the contact you wish to delete.</param>
        public List<ErrorDetail> DeleteContact(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single contact
        /// </summary>
        /// <remarks>
        /// Get the contact object identified by this URL.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// </remarks>
        /// <param name="companyId">The ID of the company for this contact</param>
        /// <param name="id">The primary key of this contact</param>
        public ContactModel GetContact(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<ContactModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve contacts for this company
        /// </summary>
        /// <remarks>
        /// List all contact objects assigned to this company.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these contacts</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ContactModel> ListContactsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ContactModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all contacts
        /// </summary>
        /// <remarks>
        /// Get multiple contact objects across all companies.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ContactModel> QueryContacts(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/contacts");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ContactModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single contact
        /// </summary>
        /// <remarks>
        /// Replace the existing contact object at this URL with an updated object.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this contact belongs to.</param>
        /// <param name="id">The ID of the contact you wish to update</param>
        /// <param name="model">The contact you wish to update.</param>
        public ContactModel UpdateContact(Int32 companyId, Int32 id, ContactModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<ContactModel>("Put", path, model);
        }


        /// <summary>
        /// Create customers for this company
        /// </summary>
        /// <remarks>
        /// Create one or more customers for this company.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="model">The list of customer objects to be created</param>
        public List<CustomerModel> CreateCustomers(Int32 companyId, List<CustomerModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            return RestCall<List<CustomerModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a customer record
        /// </summary>
        /// <remarks>
        /// Deletes the customer object referenced by this URL.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        public CustomerModel DeleteCustomer(Int32 companyId, String customerCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return RestCall<CustomerModel>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single customer
        /// </summary>
        /// <remarks>
        /// Retrieve the customer identified by this URL.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this customer object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Certificates - Fetch a list of certificates linked to this customer.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="include">Specify optional additional objects to include in this fetch request</param>
        public CustomerModel GetCustomer(Int32 companyId, String customerCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            return RestCall<CustomerModel>("Get", path, null);
        }


        /// <summary>
        /// Link certificates to a customer
        /// </summary>
        /// <remarks>
        /// Link one or more certificates to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public FetchResult<CertificateModel> LinkCertificatesToCustomer(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return RestCall<FetchResult<CertificateModel>>("Post", path, model);
        }


        /// <summary>
        /// List certificates linked to a customer
        /// </summary>
        /// <remarks>
        /// List all certificates linked to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CertificateModel> ListCertificatesForCustomer(Int32 companyId, String customerCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CertificateModel>>("Get", path, null);
        }


        /// <summary>
        /// List active certificates for a location
        /// </summary>
        /// <remarks>
        /// List valid certificates linked to a customer in a particular country and region.
        /// 
        /// This API is intended to help identify whether a customer has already provided a certificate that
        /// applies to a particular country and region. This API is intended to help you remind a customer
        /// when they have or have not provided copies of their exemption certificates to you during the sales
        /// order process. 
        /// 
        /// If a customer does not have a certificate on file and they wish to provide one, you should send the customer
        /// a CertExpress invitation link so that the customer can upload proof of their exemption certificate. Please
        /// see the `CreateCertExpressInvitation` API to create an invitation link for this customer.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="country">Search for certificates matching this country. Uses the ISO 3166 two character country code.</param>
        /// <param name="region">Search for certificates matching this region. Uses the ISO 3166 two or three character state, region, or province code.</param>
        public ExemptionStatusModel ListValidCertificatesForCustomer(Int32 companyId, String customerCode, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return RestCall<ExemptionStatusModel>("Get", path, null);
        }


        /// <summary>
        /// List all customers for this company
        /// </summary>
        /// <remarks>
        /// List all customers recorded by this company matching the specified criteria.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Certificates - Fetch a list of certificates linked to this customer.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="include">OPTIONAL - You can specify the value `certificates` to fetch information about certificates linked to the customer.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CustomerModel> QueryCustomers(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CustomerModel>>("Get", path, null);
        }


        /// <summary>
        /// Unlink certificates from a customer
        /// </summary>
        /// <remarks>
        /// Remove one or more certificates to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public FetchResult<CertificateModel> UnlinkCertificatesFromCustomer(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return RestCall<FetchResult<CertificateModel>>("Post", path, model);
        }


        /// <summary>
        /// Update a single customer
        /// </summary>
        /// <remarks>
        /// Replace the customer object at this URL with a new record.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The new customer model that will replace the existing record at this URL</param>
        public CustomerModel UpdateCustomer(Int32 companyId, String customerCode, CustomerModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return RestCall<CustomerModel>("Put", path, model);
        }


        /// <summary>
        /// Test whether a form supports online login verification
        /// </summary>
        /// <remarks>
        /// This API is intended to be useful to identify whether the user should be allowed
        /// to automatically verify their login and password.
        /// </remarks>
        /// <param name="form">The name of the form you would like to verify. This can be the tax form code or the legacy return name</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SkyscraperStatusModel> GetLoginVerifierByForm(String form, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers/{form}");
            path.ApplyField("form", form);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SkyscraperStatusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of the AvaFile Forms available
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported AvaFile Forms
        /// This API is intended to be useful to identify all the different AvaFile Forms
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<AvaFileFormModel> ListAvaFileForms(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/avafileforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<AvaFileFormModel>>("Get", path, null);
        }


        /// <summary>
        /// List certificate attributes used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate attributes defined by a company.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may apply or remove attributes to a
        /// certificate at any time.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CertificateAttributeModel> ListCertificateAttributes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateattributes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CertificateAttributeModel>>("Get", path, null);
        }


        /// <summary>
        /// List certificate attributes used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate exempt reasons defined by a company.
        /// 
        /// An exemption reason defines why a certificate allows a customer to be exempt
        /// for purposes of tax calculation.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ExemptionReasonModel> ListCertificateExemptReasons(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexemptreasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ExemptionReasonModel>>("Get", path, null);
        }


        /// <summary>
        /// List certificate exposure zones used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate exposure zones defined by a company.
        /// 
        /// An exposure zone is a location where a certificate can be valid. Exposure zones may indicate a taxing
        /// authority or other legal entity to which a certificate may apply.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ExposureZoneModel> ListCertificateExposureZones(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexposurezones");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ExposureZoneModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of communications transactiontypes
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction types which
        /// are accepted in communication tax calculation requests.
        /// </remarks>
        /// <param name="id">The transaction type ID to examine</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CommunicationsTSPairModel> ListCommunicationsServiceTypes(Int32 id, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes/{id}/servicetypes");
            path.ApplyField("id", id);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CommunicationsTSPairModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of communications transactiontypes
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction types which
        /// are accepted in communication tax calculation requests.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CommunicationsTransactionTypeModel> ListCommunicationsTransactionTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CommunicationsTransactionTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of communications transaction/service type pairs
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction/service type pairs which
        /// are accepted in communication tax calculation requests.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CommunicationsTSPairModel> ListCommunicationsTSPairs(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/tspairs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CommunicationsTSPairModel>>("Get", path, null);
        }


        /// <summary>
        /// List all ISO 3166 countries
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 country codes, and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a country for 
        /// a shipping address.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<IsoCountryModel> ListCountries(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<IsoCountryModel>>("Get", path, null);
        }


        /// <summary>
        /// List certificate exposure zones used by a company
        /// </summary>
        /// <remarks>
        /// List available cover letters that can be used when sending invitation to use CertExpress to upload certificates.
        /// 
        /// The CoverLetter model represents a message sent along with an invitation to use CertExpress to
        /// upload certificates. An invitation allows customers to use CertExpress to upload their exemption 
        /// certificates directly; this cover letter explains why the invitation was sent.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<CoverLetterModel> ListCoverLetters(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/coverletters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<CoverLetterModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported entity use codes
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported entity use codes.
        /// Entity/Use Codes are definitions of the entity who is purchasing something, or the purpose for which the transaction
        /// is occurring. This information is generally used to determine taxability of the product.
        /// In order to facilitate correct reporting of your taxes, you are encouraged to select the proper entity use codes for
        /// all transactions that are exempt.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<EntityUseCodeModel> ListEntityUseCodes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/entityusecodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<EntityUseCodeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported filing frequencies.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported filing frequencies.
        /// This API is intended to be useful to identify all the different filing frequencies that can be used in notices.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<FilingFrequencyModel> ListFilingFrequencies(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingfrequencies");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<FilingFrequencyModel>>("Get", path, null);
        }


        /// <summary>
        /// List jurisdictions based on the filter provided
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions.
        /// 
        /// This API allows you to examine all Avalara-supported jurisdictions. You can filter your search by supplying
        /// SQL-like query for fetching only the ones you concerned about. For example: effectiveDate &gt; '2016-01-01'
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<JurisdictionModel> ListJurisdictions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/jurisdictions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<JurisdictionModel>>("Get", path, null);
        }


        /// <summary>
        /// List jurisdictions near a specific address
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions that apply to this address.
        /// 
        /// This API allows you to identify which jurisdictions are nearby a specific address according to the best available geocoding information.
        /// It is intended to allow you to create a "Jurisdiction Override", which allows an address to be configured as belonging to a nearby 
        /// jurisdiction in AvaTax.
        ///  
        /// The results of this API call can be passed to the `CreateJurisdictionOverride` API call.
        /// </remarks>
        /// <param name="line1">The first address line portion of this address.</param>
        /// <param name="line2">The second address line portion of this address.</param>
        /// <param name="line3">The third address line portion of this address.</param>
        /// <param name="city">The city portion of this address.</param>
        /// <param name="region">The region, state, or province code portion of this address.</param>
        /// <param name="postalCode">The postal code or zip code portion of this address.</param>
        /// <param name="country">The two-character ISO-3166 code of the country portion of this address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<JurisdictionOverrideModel> ListJurisdictionsByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/jurisdictionsnearaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<JurisdictionOverrideModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the list of questions that are required for a tax location
        /// </summary>
        /// <remarks>
        /// Returns the list of additional questions you must answer when declaring a location in certain taxing jurisdictions.
        /// Some tax jurisdictions require that you register or provide additional information to configure each physical place where
        /// your company does business.
        /// This information is not usually required in order to calculate tax correctly, but is almost always required to file your tax correctly.
        /// You can call this API call for any address and obtain information about what questions must be answered in order to properly
        /// file tax in that location.
        /// </remarks>
        /// <param name="line1">The first line of this location's address.</param>
        /// <param name="line2">The second line of this location's address.</param>
        /// <param name="line3">The third line of this location's address.</param>
        /// <param name="city">The city part of this location's address.</param>
        /// <param name="region">The region, state, or province part of this location's address.</param>
        /// <param name="postalCode">The postal code of this location's address.</param>
        /// <param name="country">The country part of this location's address.</param>
        /// <param name="latitude">Optionally identify the location via latitude/longitude instead of via address.</param>
        /// <param name="longitude">Optionally identify the location via latitude/longitude instead of via address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<LocationQuestionModel> ListLocationQuestionsByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, Decimal? latitude, Decimal? longitude, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/locationquestions");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("latitude", latitude);
            path.AddQuery("longitude", longitude);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<LocationQuestionModel>>("Get", path, null);
        }


        /// <summary>
        /// List all forms where logins can be verified automatically
        /// </summary>
        /// <remarks>
        /// List all forms where logins can be verified automatically.
        /// This API is intended to be useful to identify whether the user should be allowed
        /// to automatically verify their login and password.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SkyscraperStatusModel> ListLoginVerifiers(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SkyscraperStatusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for all countries and regions.
        /// </summary>
        /// <remarks>
        /// Returns the full list of all Avalara-supported nexus for all countries and regions. 
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> ListNexus(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// List all nexus that apply to a specific address.
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions that apply to this address.
        /// This API allows you to identify which tax authorities apply to a physical location, salesperson address, or point of sale.
        /// In general, it is usually expected that a company will declare nexus in all the jurisdictions that apply to each physical address
        /// where the company does business.
        /// The results of this API call can be passed to the 'Create Nexus' API call to declare nexus for this address.
        /// </remarks>
        /// <param name="line1">The first address line portion of this address.</param>
        /// <param name="line2">The first address line portion of this address.</param>
        /// <param name="line3">The first address line portion of this address.</param>
        /// <param name="city">The city portion of this address.</param>
        /// <param name="region">The region, state, or province code portion of this address.</param>
        /// <param name="postalCode">The postal code or zip code portion of this address.</param>
        /// <param name="country">The two-character ISO-3166 code of the country portion of this address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> ListNexusByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/byaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country.
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country.
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country.
        /// </remarks>
        /// <param name="country">The country in which you want to fetch the system nexus</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> ListNexusByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country and region.
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country and region.
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country and region.
        /// </remarks>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> ListNexusByCountryAndRegion(String country, String region, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}/{region}");
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// List nexus related to a tax form
        /// </summary>
        /// <remarks>
        /// Retrieves a list of nexus related to a tax form.
        /// 
        /// The concept of `Nexus` indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// 
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// This API is intended to provide useful information when examining a tax form. If you are about to begin filing
        /// a tax form, you may want to know whether you have declared nexus in all the jurisdictions related to that tax 
        /// form in order to better understand how the form will be filled out.
        /// </remarks>
        /// <param name="formCode">The form code that we are looking up the nexus for</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public NexusByTaxFormModel ListNexusByFormCode(String formCode, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/byform/{formCode}");
            path.ApplyField("formCode", formCode);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<NexusByTaxFormModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of nexus tax type groups
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported nexus tax type groups
        /// This API is intended to be useful to identify all the different tax sub-types.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusTaxTypeGroupModel> ListNexusTaxTypeGroups(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexustaxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusTaxTypeGroupModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice customer funding options.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice customer funding options.
        /// This API is intended to be useful to identify all the different notice customer funding options that can be used in notices.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeCustomerFundingOptionModel> ListNoticeCustomerFundingOptions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomerfundingoptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeCustomerFundingOptionModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice customer types.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice customer types.
        /// This API is intended to be useful to identify all the different notice customer types.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeCustomerTypeModel> ListNoticeCustomerTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomertypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeCustomerTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice filing types.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice filing types.
        /// This API is intended to be useful to identify all the different notice filing types that can be used in notices.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeFilingTypeModel> ListNoticeFilingtypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticefilingtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeFilingTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice priorities.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice priorities.
        /// This API is intended to be useful to identify all the different notice priorities that can be used in notices.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticePriorityModel> ListNoticePriorities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticepriorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticePriorityModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice reasons.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice reasons.
        /// This API is intended to be useful to identify all the different tax notice reasons.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeReasonModel> ListNoticeReasons(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticereasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeReasonModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice responsibility ids
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice responsibility ids
        /// This API is intended to be useful to identify all the different tax notice responsibilities.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeResponsibilityModel> ListNoticeResponsibilities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticeresponsibilities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeResponsibilityModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice root causes
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice root causes
        /// This API is intended to be useful to identify all the different tax notice root causes.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeRootCauseModel> ListNoticeRootCauses(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticerootcauses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeRootCauseModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice statuses.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice statuses.
        /// This API is intended to be useful to identify all the different tax notice statuses.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeStatusModel> ListNoticeStatuses(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticestatuses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeStatusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice types.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice types.
        /// This API is intended to be useful to identify all the different notice types that can be used in notices.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeTypeModel> ListNoticeTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported extra parameters for creating transactions.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported extra parameters for the 'Create Transaction' API call.
        /// This list of parameters is available for use when configuring your transaction.
        /// Some parameters are only available for use if you have subscribed to certain features of AvaTax.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ParameterModel> ListParameters(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/parameters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ParameterModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported permissions
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported permission types.
        /// This API is intended to be useful to identify the capabilities of a particular user logon.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<String> ListPermissions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/permissions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<String>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of rate types for each country
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported rate type file types
        /// This API is intended to be useful to identify all the different rate types.
        /// </remarks>
        /// <param name="country">The country to examine for rate types</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<RateTypeModel> ListRateTypesByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/ratetypes");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<RateTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// List all ISO 3166 regions
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 region codes and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a region 
        /// within the country for a shipping addresses.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<IsoRegionModel> ListRegions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/regions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<IsoRegionModel>>("Get", path, null);
        }


        /// <summary>
        /// List all ISO 3166 regions for a country
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 region codes for a specific country code, and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a region 
        /// within the country for a shipping addresses.
        /// </remarks>
        /// <param name="country">The country of which you want to fetch ISO 3166 regions</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<IsoRegionModel> ListRegionsByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/regions");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<IsoRegionModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported resource file types
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported resource file types
        /// This API is intended to be useful to identify all the different resource file types.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ResourceFileTypeModel> ListResourceFileTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/resourcefiletypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ResourceFileTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported permissions
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported permission types.
        /// This API is intended to be useful when designing a user interface for selecting the security role of a user account.
        /// Some security roles are restricted for Avalara internal use.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SecurityRoleModel> ListSecurityRoles(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/securityroles");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SecurityRoleModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported subscription types
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported subscription types.
        /// This API is intended to be useful for identifying which features you have added to your account.
        /// You may always contact Avalara's sales department for information on available products or services.
        /// You cannot change your subscriptions directly through the API.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SubscriptionTypeModel> ListSubscriptionTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/subscriptiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SubscriptionTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax authorities.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax authorities.
        /// This API is intended to be useful to identify all the different authorities that receive tax.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxAuthorityModel> ListTaxAuthorities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxAuthorityModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported forms for each tax authority.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported forms for each tax authority.
        /// This list represents tax forms that Avalara recognizes.
        /// Customers who subscribe to Avalara Managed Returns Service can request these forms to be filed automatically 
        /// based on the customer's AvaTax data.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxAuthorityFormModel> ListTaxAuthorityForms(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorityforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxAuthorityFormModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax authority types.
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax authority types.
        /// This API is intended to be useful to identify all the different authority types.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxAuthorityTypeModel> ListTaxAuthorityTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthoritytypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxAuthorityTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax codes.
        /// </summary>
        /// <remarks>
        /// Retrieves the list of Avalara-supported system tax codes.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxCodeModel> ListTaxCodes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxCodeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax code types.
        /// </summary>
        /// <remarks>
        /// Returns the full list of recognized tax code types.
        /// A 'Tax Code Type' represents a broad category of tax codes, and is less detailed than a single TaxCode.
        /// This API is intended to be useful for broadly searching for tax codes by tax code type.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public TaxCodeTypesModel ListTaxCodeTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<TaxCodeTypesModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of tax sub types
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax sub-types
        /// This API is intended to be useful to identify all the different tax sub-types.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxSubTypeModel> ListTaxSubTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxsubtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxSubTypeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of tax type groups
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax type groups
        /// This API is intended to be useful to identify all the different tax type groups.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxTypeGroupModel> ListTaxTypeGroups(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxTypeGroupModel>>("Get", path, null);
        }


        /// <summary>
        /// Approve existing Filing Request
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// The filing request must be in the "ChangeRequest" status to be approved.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        public FilingRequestModel ApproveFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Post", path, null);
        }


        /// <summary>
        /// Cancel existing Filing Request
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        public FilingRequestModel CancelFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/cancel");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Post", path, null);
        }


        /// <summary>
        /// Create a new filing request to cancel a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID number of the filing calendar to cancel</param>
        /// <param name="model">The cancellation request for this filing calendar</param>
        public FilingRequestModel CancelFilingRequests(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new filing request to create a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that will add the new filing calendar</param>
        /// <param name="model">Information about the proposed new filing calendar</param>
        public FilingRequestModel CreateFilingRequests(Int32 companyId, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/request");
            path.ApplyField("companyId", companyId);
            return RestCall<FilingRequestModel>("Post", path, model);
        }


        /// <summary>
        /// Returns a list of options for adding the specified form.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="formCode">The unique code of the form</param>
        public List<CycleAddOptionModel> CycleSafeAdd(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/options");
            path.ApplyField("companyId", companyId);
            path.AddQuery("formCode", formCode);
            return RestCall<List<CycleAddOptionModel>>("Get", path, null);
        }


        /// <summary>
        /// Indicates when changes are allowed to be made to a filing calendar.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public CycleEditOptionModel CycleSafeEdit(Int32 companyId, Int32 id, List<FilingCalendarEditModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<CycleEditOptionModel>("Post", path, model);
        }


        /// <summary>
        /// Returns a list of options for expiring a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        public CycleExpireModel CycleSafeExpiration(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<CycleExpireModel>("Get", path, null);
        }


        /// <summary>
        /// Delete a single filing calendar.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar.</param>
        /// <param name="id">The ID of the filing calendar you wish to delete.</param>
        public List<ErrorDetail> DeleteFilingCalendar(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar</param>
        /// <param name="id">The primary key of this filing calendar</param>
        public FilingCalendarModel GetFilingCalendar(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingCalendarModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single filing request
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar</param>
        /// <param name="id">The primary key of this filing calendar</param>
        public FilingRequestModel GetFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all filing calendars for this company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        /// <param name="returnCountry">A comma separated list of countries</param>
        /// <param name="returnRegion">A comma separated list of regions</param>
        public FetchResult<FilingCalendarModel> ListFilingCalendars(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return RestCall<FetchResult<FilingCalendarModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all filing requests for this company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<FilingRequestModel> ListFilingRequests(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<FilingRequestModel>>("Get", path, null);
        }


        /// <summary>
        /// New request for getting for validating customer's login credentials
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// This API verifies that a customer has submitted correct login credentials for a tax authority's online filing system.
        /// </remarks>
        /// <param name="model">The model of the login information we are verifying</param>
        public LoginVerificationOutputModel LoginVerificationRequest(LoginVerificationInputModel model)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/verify");
            return RestCall<LoginVerificationOutputModel>("Post", path, model);
        }


        /// <summary>
        /// Gets the request status and Login Result
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// This API checks the status of a login verification request. It may only be called by authorized users from the account 
        /// that initially requested the login verification.
        /// </remarks>
        /// <param name="jobId">The unique ID number of this login request</param>
        public LoginVerificationOutputModel LoginVerificationStatus(Int32 jobId)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/{jobId}");
            path.ApplyField("jobId", jobId);
            return RestCall<LoginVerificationOutputModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all filing calendars
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        /// <param name="returnCountry">If specified, fetches only filing calendars that apply to tax filings in this specific country. Uses ISO 3166 country codes.</param>
        /// <param name="returnRegion">If specified, fetches only filing calendars that apply to tax filings in this specific region. Uses ISO 3166 region codes.</param>
        public FetchResult<FilingCalendarModel> QueryFilingCalendars(String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return RestCall<FetchResult<FilingCalendarModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all filing requests
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<FilingRequestModel> QueryFilingRequests(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/filingrequests");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<FilingRequestModel>>("Get", path, null);
        }


        /// <summary>
        /// Create a new filing request to edit a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// 
        /// Certain users may not update filing calendars directly. Instead, they may submit an edit request
        /// to modify the value of a filing calendar using this API.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID number of the filing calendar to edit</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public FilingRequestModel RequestFilingCalendarUpdate(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Post", path, model);
        }


        /// <summary>
        /// Edit existing Filing Calendar's Notes
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// This API only allows updating of internal notes and company filing instructions.
        /// All other updates must go through a filing request at this time.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        /// <param name="model">The filing calendar model you are wishing to update with.</param>
        public FilingCalendarModel UpdateFilingCalendar(Int32 companyId, Int32 id, FilingCalendarModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingCalendarModel>("Put", path, model);
        }


        /// <summary>
        /// Edit existing Filing Request
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public FilingRequestModel UpdateFilingRequest(Int32 companyId, Int32 id, FilingRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingRequestModel>("Put", path, model);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle.
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public List<FilingModel> ApproveFilings(Int32 companyId, Int16 year, Byte month, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCall<List<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period and country.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle.
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public List<FilingModel> ApproveFilingsCountry(Int32 companyId, Int16 year, Byte month, String country, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return RestCall<List<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period, country and region.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public List<FilingModel> ApproveFilingsCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return RestCall<List<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Add an adjustment to a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API creates a new adjustment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="year">The year of the filing's filing period being adjusted.</param>
        /// <param name="month">The month of the filing's filing period being adjusted.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being adjusted.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form being adjusted.</param>
        /// <param name="model">A list of Adjustments to be created for the specified filing.</param>
        public List<FilingAdjustmentModel> CreateReturnAdjustment(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAdjustmentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/adjust");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return RestCall<List<FilingAdjustmentModel>>("Post", path, model);
        }


        /// <summary>
        /// Add an augmentation for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API creates a new augmentation for an existing tax filing.
        /// This API can only be used when the filing has not been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="year">The month of the filing's filing period being changed.</param>
        /// <param name="month">The month of the filing's filing period being changed.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being changed.</param>
        /// <param name="region">The two or three character region code for the region of the filing being changed.</param>
        /// <param name="formCode">The unique code of the form being changed.</param>
        /// <param name="model">A list of augmentations to be created for the specified filing.</param>
        public List<FilingAugmentationModel> CreateReturnAugmentation(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAugmentationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/augment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return RestCall<List<FilingAugmentationModel>>("Post", path, model);
        }


        /// <summary>
        /// Add an payment to a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API creates a new payment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="year">The year of the filing's filing period being adjusted.</param>
        /// <param name="month">The month of the filing's filing period being adjusted.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being adjusted.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form being adjusted.</param>
        /// <param name="model">A list of Payments to be created for the specified filing.</param>
        public List<FilingPaymentModel> CreateReturnPayment(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingPaymentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/payment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return RestCall<List<FilingPaymentModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete an adjustment for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API deletes an adjustment for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the adjustment being deleted.</param>
        public List<ErrorDetail> DeleteReturnAdjustment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete an augmentation for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API deletes an augmentation for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="id">The ID of the augmentation being added.</param>
        public List<ErrorDetail> DeleteReturnAugmentation(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete an payment for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API deletes an payment for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the payment being deleted.</param>
        public List<ErrorDetail> DeleteReturnPayment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve worksheet checkup report for company and filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="filingsId">The unique id of the worksheet.</param>
        /// <param name="companyId">The unique ID of the company that owns the worksheet.</param>
        public FilingsCheckupModel FilingsCheckupReport(Int32 filingsId, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingsId}/checkup");
            path.ApplyField("filingsId", filingsId);
            path.ApplyField("companyId", companyId);
            return RestCall<FilingsCheckupModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve worksheet checkup report for company and filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the worksheets object.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The month of the filing period.</param>
        public FilingsCheckupModel FilingsCheckupReports(Int32 companyId, Int32 year, Int32 month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/checkup");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCall<FilingsCheckupModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single attachment for a filing
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="filingId">The unique id of the worksheet return.</param>
        /// <param name="fileId">The unique id of the document you are downloading</param>
        public FileResult GetFilingAttachment(Int32 companyId, Int64 filingId, Int64? fileId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingId}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("filingId", filingId);
            path.AddQuery("fileId", fileId);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public FileResult GetFilingAttachments(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single trace file for a company filing period
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public FileResult GetFilingAttachmentsTraceFile(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments/tracefile");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a filing for the specified company and id.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="id">The id of the filing return your retrieving</param>
        public FetchResult<FilingReturnModel> GetFilingReturn(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FetchResult<FilingReturnModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public FetchResult<FilingModel> GetFilings(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCall<FetchResult<FilingModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the given filing period and country.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        public FetchResult<FilingModel> GetFilingsByCountry(Int32 companyId, Int16 year, Byte month, String country)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return RestCall<FetchResult<FilingModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the filing period, country and region.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        public FetchResult<FilingModel> GetFilingsByCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return RestCall<FetchResult<FilingModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the given filing period, country, region and form.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form.</param>
        public FetchResult<FilingModel> GetFilingsByReturnName(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return RestCall<FetchResult<FilingModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period. 
        /// This gets the basic information from the filings and doesn't include anything extra.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="endPeriodMonth">The month of the period you are trying to retrieve</param>
        /// <param name="endPeriodYear">The year of the period you are trying to retrieve</param>
        /// <param name="frequency">The frequency of the return you are trying to retrieve</param>
        /// <param name="status">The status of the return(s) you are trying to retrieve</param>
        /// <param name="country">The country of the return(s) you are trying to retrieve</param>
        /// <param name="region">The region of the return(s) you are trying to retrieve</param>
        public FetchResult<FilingReturnModelBasic> GetFilingsReturns(Int32 companyId, Int32? endPeriodMonth, Int32? endPeriodYear, FilingFrequencyId? frequency, FilingStatusId? status, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns");
            path.ApplyField("companyId", companyId);
            path.AddQuery("endPeriodMonth", endPeriodMonth);
            path.AddQuery("endPeriodYear", endPeriodYear);
            path.AddQuery("frequency", frequency);
            path.AddQuery("status", status);
            path.AddQuery("country", country);
            path.AddQuery("region", region);
            return RestCall<FetchResult<FilingReturnModelBasic>>("Get", path, null);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed (worksheet) for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public FetchResult<FilingModel> RebuildFilings(Int32 companyId, Int16 year, Byte month, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return RestCall<FetchResult<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period and country.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed (worksheet) for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public FetchResult<FilingModel> RebuildFilingsByCountry(Int32 companyId, Int16 year, Byte month, String country, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return RestCall<FetchResult<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period, country and region.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing. 
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public FetchResult<FilingModel> RebuildFilingsByCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return RestCall<FetchResult<FilingModel>>("Post", path, model);
        }


        /// <summary>
        /// Edit an adjustment for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API modifies an adjustment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the adjustment being edited.</param>
        /// <param name="model">The updated Adjustment.</param>
        public FilingAdjustmentModel UpdateReturnAdjustment(Int32 companyId, Int64 id, FilingAdjustmentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingAdjustmentModel>("Put", path, model);
        }


        /// <summary>
        /// Edit an augmentation for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API modifies an augmentation for an existing tax filing.
        /// This API can only be used when the filing has not been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="id">The ID of the augmentation being edited.</param>
        /// <param name="model">The updated Augmentation.</param>
        public FilingModel UpdateReturnAugmentation(Int32 companyId, Int64 id, FilingAugmentationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingModel>("Put", path, model);
        }


        /// <summary>
        /// Edit an payment for a given filing.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API modifies an payment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the payment being edited.</param>
        /// <param name="model">The updated Payment.</param>
        public FilingPaymentModel UpdateReturnPayment(Int32 companyId, Int64 id, FilingPaymentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<FilingPaymentModel>("Put", path, model);
        }


        /// <summary>
        /// FREE API - Request a free trial of AvaTax
        /// </summary>
        /// <remarks>
        /// Call this API to obtain a free AvaTax sandbox account.
        /// 
        /// This API is free to use. No authentication credentials are required to call this API.
        /// The account will grant a full trial version of AvaTax (e.g. AvaTaxPro) for a limited period of time.
        /// After this introductory period, you may continue to use the free TaxRates API.
        /// 
        /// Limitations on free trial accounts:
        ///  
        /// * Only one free trial per company.
        /// * The free trial account does not expire.
        /// * Includes a limited time free trial of AvaTaxPro; after that date, the free TaxRates API will continue to work.
        /// * Each free trial account must have its own valid email address.
        /// </remarks>
        /// <param name="model">Required information to provision a free trial account.</param>
        public NewAccountModel RequestFreeTrial(FreeTrialRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/freetrials/request");
            return RestCall<NewAccountModel>("Post", path, model);
        }


        /// <summary>
        /// FREE API - Sales tax rates for a specified address
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.
        /// </remarks>
        /// <param name="line1">The street address of the location.</param>
        /// <param name="line2">The street address of the location.</param>
        /// <param name="line3">The street address of the location.</param>
        /// <param name="city">The city name of the location.</param>
        /// <param name="region">The state or region of the location</param>
        /// <param name="postalCode">The postal code of the location.</param>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        public TaxRateModel TaxRatesByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/byaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            return RestCall<TaxRateModel>("Get", path, null);
        }


        /// <summary>
        /// FREE API - Sales tax rates for a specified country and postal code
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.
        /// </remarks>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        /// <param name="postalCode">The postal code of the location.</param>
        public TaxRateModel TaxRatesByPostalCode(String country, String postalCode)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/bypostalcode");
            path.AddQuery("country", country);
            path.AddQuery("postalCode", postalCode);
            return RestCall<TaxRateModel>("Get", path, null);
        }


        /// <summary>
        /// Request the javascript for a funding setup widget
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API returns back the actual javascript code to insert into your application to render the 
        /// JavaScript funding setup widget inline.
        /// Use the 'methodReturn.javaScript' return value to insert this widget into your HTML page.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// </remarks>
        /// <param name="id">The unique ID number of this funding request</param>
        public FundingStatusModel ActivateFundingRequest(Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}/widget");
            path.ApplyField("id", id);
            return RestCall<FundingStatusModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve status about a funding setup request
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API checks the status on an existing funding request.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// </remarks>
        /// <param name="id">The unique ID number of this funding request</param>
        public FundingStatusModel FundingRequestStatus(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}");
            path.ApplyField("id", id);
            return RestCall<FundingStatusModel>("Get", path, null);
        }


        /// <summary>
        /// Create a new item
        /// </summary>
        /// <remarks>
        /// Creates one or more new item objects attached to this company.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="model">The item you wish to create.</param>
        public List<ItemModel> CreateItems(Int32 companyId, List<ItemModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            return RestCall<List<ItemModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single item
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="id">The ID of the item you wish to delete.</param>
        public List<ErrorDetail> DeleteItem(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single item
        /// </summary>
        /// <remarks>
        /// Get the item object identified by this URL.
        /// An 'Item' represents a product or service that your company offers for sale.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item object</param>
        /// <param name="id">The primary key of this item</param>
        public ItemModel GetItem(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<ItemModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve items for this company
        /// </summary>
        /// <remarks>
        /// List all items defined for the current company.
        /// 
        /// An 'Item' represents a product or service that your company offers for sale.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that defined these items</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ItemModel> ListItemsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ItemModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all items
        /// </summary>
        /// <remarks>
        /// Get multiple item objects across all companies.
        /// An 'Item' represents a product or service that your company offers for sale.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<ItemModel> QueryItems(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/items");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<ItemModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single item
        /// </summary>
        /// <remarks>
        /// Replace the existing item object at this URL with an updated object.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this item belongs to.</param>
        /// <param name="id">The ID of the item you wish to update</param>
        /// <param name="model">The item object you wish to update.</param>
        public ItemModel UpdateItem(Int32 companyId, Int64 id, ItemModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<ItemModel>("Put", path, model);
        }


        /// <summary>
        /// Create one or more overrides
        /// </summary>
        /// <remarks>
        /// Creates one or more jurisdiction override objects for this account.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="model">The jurisdiction override objects to create</param>
        public List<JurisdictionOverrideModel> CreateJurisdictionOverrides(Int32 accountId, List<JurisdictionOverrideModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            return RestCall<List<JurisdictionOverrideModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single override
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="id">The ID of the override you wish to delete</param>
        public List<ErrorDetail> DeleteJurisdictionOverride(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single override
        /// </summary>
        /// <remarks>
        /// Get the item object identified by this URL.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="id">The primary key of this override</param>
        public JurisdictionOverrideModel GetJurisdictionOverride(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<JurisdictionOverrideModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve overrides for this account
        /// </summary>
        /// <remarks>
        /// List all jurisdiction override objects defined for this account.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<JurisdictionOverrideModel> ListJurisdictionOverridesByAccount(Int32 accountId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<JurisdictionOverrideModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all overrides
        /// </summary>
        /// <remarks>
        /// Get multiple jurisdiction override objects across all companies.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<JurisdictionOverrideModel> QueryJurisdictionOverrides(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/jurisdictionoverrides");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<JurisdictionOverrideModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single jurisdictionoverride
        /// </summary>
        /// <remarks>
        /// Replace the existing jurisdictionoverride object at this URL with an updated object.
        /// </remarks>
        /// <param name="accountId">The ID of the account that this jurisdictionoverride belongs to.</param>
        /// <param name="id">The ID of the jurisdictionoverride you wish to update</param>
        /// <param name="model">The jurisdictionoverride object you wish to update.</param>
        public JurisdictionOverrideModel UpdateJurisdictionOverride(Int32 accountId, Int32 id, JurisdictionOverrideModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<JurisdictionOverrideModel>("Put", path, model);
        }


        /// <summary>
        /// Create a new location
        /// </summary>
        /// <remarks>
        /// Create one or more new location objects attached to this company.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="model">The location you wish to create.</param>
        public List<LocationModel> CreateLocations(Int32 companyId, List<LocationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            return RestCall<List<LocationModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single location
        /// </summary>
        /// <remarks>
        /// Mark the location object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="id">The ID of the location you wish to delete.</param>
        public List<ErrorDetail> DeleteLocation(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single location
        /// </summary>
        /// <remarks>
        /// Get the location object identified by this URL.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location</param>
        /// <param name="id">The primary key of this location</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        public LocationModel GetLocation(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<LocationModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve locations for this company
        /// </summary>
        /// <remarks>
        /// List all location objects defined for this company.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these locations</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<LocationModel> ListLocationsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<LocationModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all locations
        /// </summary>
        /// <remarks>
        /// Get multiple location objects across all companies.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<LocationModel> QueryLocations(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/locations");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<LocationModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single location
        /// </summary>
        /// <remarks>
        /// Replace the existing location object at this URL with an updated object.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this location belongs to.</param>
        /// <param name="id">The ID of the location you wish to update</param>
        /// <param name="model">The location you wish to update.</param>
        public LocationModel UpdateLocation(Int32 companyId, Int32 id, LocationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<LocationModel>("Put", path, model);
        }


        /// <summary>
        /// Validate the location against local requirements
        /// </summary>
        /// <remarks>
        /// Returns validation information for this location.
        /// This API call is intended to compare this location against the currently known taxing authority rules and regulations,
        /// and provide information about what additional work is required to completely setup this location.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location</param>
        /// <param name="id">The primary key of this location</param>
        public LocationValidationModel ValidateLocation(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/validate");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<LocationValidationModel>("Get", path, null);
        }


        /// <summary>
        /// Create a new nexus
        /// </summary>
        /// <remarks>
        /// Creates one or more new nexus objects attached to this company.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// Note that not all fields within a nexus can be updated; Avalara publishes a list of all defined nexus at the
        /// '/api/v2/definitions/nexus' endpoint.
        /// You may only define nexus matching the official list of declared nexus.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="model">The nexus you wish to create.</param>
        public List<NexusModel> CreateNexus(Int32 companyId, List<NexusModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            return RestCall<List<NexusModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single nexus
        /// </summary>
        /// <remarks>
        /// Marks the existing nexus object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="id">The ID of the nexus you wish to delete.</param>
        public List<ErrorDetail> DeleteNexus(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single nexus
        /// </summary>
        /// <remarks>
        /// Get the nexus object identified by this URL.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus object</param>
        /// <param name="id">The primary key of this nexus</param>
        public NexusModel GetNexus(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<NexusModel>("Get", path, null);
        }


        /// <summary>
        /// List company nexus related to a tax form
        /// </summary>
        /// <remarks>
        /// Retrieves a list of nexus related to a tax form.
        /// 
        /// The concept of `Nexus` indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// 
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// This API is intended to provide useful information when examining a tax form. If you are about to begin filing
        /// a tax form, you may want to know whether you have declared nexus in all the jurisdictions related to that tax 
        /// form in order to better understand how the form will be filled out.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus object</param>
        /// <param name="formCode">The form code that we are looking up the nexus for</param>
        public NexusByTaxFormModel GetNexusByFormCode(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/byform/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("formCode", formCode);
            return RestCall<NexusByTaxFormModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve nexus for this company
        /// </summary>
        /// <remarks>
        /// List all nexus objects defined for this company.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these nexus objects</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> ListNexusByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all nexus
        /// </summary>
        /// <remarks>
        /// Get multiple nexus objects across all companies.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NexusModel> QueryNexus(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NexusModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single nexus
        /// </summary>
        /// <remarks>
        /// Replace the existing nexus object at this URL with an updated object.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// Note that not all fields within a nexus can be updated; Avalara publishes a list of all defined nexus at the
        /// '/api/v2/definitions/nexus' endpoint.
        /// You may only define nexus matching the official list of declared nexus.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this nexus belongs to.</param>
        /// <param name="id">The ID of the nexus you wish to update</param>
        /// <param name="model">The nexus object you wish to update.</param>
        public NexusModel UpdateNexus(Int32 companyId, Int32 id, NexusModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<NexusModel>("Put", path, model);
        }


        /// <summary>
        /// Create a new notice comment.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the comment for.</param>
        /// <param name="model">The notice comments you wish to create.</param>
        public List<NoticeCommentModel> CreateNoticeComment(Int32 companyId, Int32 id, List<NoticeCommentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<NoticeCommentModel>>("Post", path, model);
        }


        /// <summary>
        /// Create a new notice finance details.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice finance details' is the categorical breakdown of the total charge levied by the tax authority on our customer,
        /// as broken down in our "notice log" found in Workflow. Main examples of the categories are 'Tax Due', 'Interest', 'Penalty', 'Total Abated'.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the notice added to the finance details.</param>
        /// <param name="model">The notice finance details you wish to create.</param>
        public List<NoticeFinanceModel> CreateNoticeFinanceDetails(Int32 companyId, Int32 id, List<NoticeFinanceModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<NoticeFinanceModel>>("Post", path, model);
        }


        /// <summary>
        /// Create a new notice responsibility.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the responsibility for.</param>
        /// <param name="model">The notice responsibilities you wish to create.</param>
        public List<NoticeResponsibilityDetailModel> CreateNoticeResponsibilities(Int32 companyId, Int32 id, List<NoticeResponsibilityDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<NoticeResponsibilityDetailModel>>("Post", path, model);
        }


        /// <summary>
        /// Create a new notice root cause.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice root causes' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the responsibility for.</param>
        /// <param name="model">The notice root causes you wish to create.</param>
        public List<NoticeRootCauseDetailModel> CreateNoticeRootCauses(Int32 companyId, Int32 id, List<NoticeRootCauseDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<NoticeRootCauseDetailModel>>("Post", path, model);
        }


        /// <summary>
        /// Create a new notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Create one or more new notice objects.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="model">The notice object you wish to create.</param>
        public List<NoticeModel> CreateNotices(Int32 companyId, List<NoticeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            return RestCall<List<NoticeModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the notice you wish to delete.</param>
        public List<ErrorDetail> DeleteNotice(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete a single responsibility
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="noticeId">The ID of the notice you wish to delete.</param>
        /// <param name="id">The ID of the responsibility you wish to delete.</param>
        public List<ErrorDetail> DeleteResponsibilities(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/responsibilities/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete a single root cause.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="noticeId">The ID of the notice you wish to delete.</param>
        /// <param name="id">The ID of the root cause you wish to delete.</param>
        public List<ErrorDetail> DeleteRootCauses(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/rootcauses/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single attachment
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the file attachment identified by this URL.
        /// </remarks>
        /// <param name="companyId">The ID of the company for this attachment.</param>
        /// <param name="id">The ResourceFileId of the attachment to download.</param>
        public FileResult DownloadNoticeAttachment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the tax notice object identified by this URL.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="companyId">The ID of the company for this notice.</param>
        /// <param name="id">The ID of this notice.</param>
        public NoticeModel GetNotice(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<NoticeModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve notice comments for a specific notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public FetchResult<NoticeCommentModel> GetNoticeComments(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return RestCall<FetchResult<NoticeCommentModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve notice finance details for a specific notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice finance details' is the categorical breakdown of the total charge levied by the tax authority on our customer,
        /// as broken down in our "notice log" found in Workflow. Main examples of the categories are 'Tax Due', 'Interest', 'Penalty', 'Total Abated'.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="id">The ID of the company that owns these notices.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public FetchResult<NoticeFinanceModel> GetNoticeFinanceDetails(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return RestCall<FetchResult<NoticeFinanceModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve notice responsibilities for a specific notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice responsibilities' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public FetchResult<NoticeResponsibilityDetailModel> GetNoticeResponsibilities(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return RestCall<FetchResult<NoticeResponsibilityDetailModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve notice root causes for a specific notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice root causes' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public FetchResult<NoticeRootCauseDetailModel> GetNoticeRootCauses(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return RestCall<FetchResult<NoticeRootCauseDetailModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve notices for a company.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// List all tax notice objects assigned to this company.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeModel> ListNoticesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all notices.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get multiple notice objects across all companies.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<NoticeModel> QueryNotices(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/notices");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<NoticeModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single notice.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Replace the existing notice object at this URL with an updated object.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this notice belongs to.</param>
        /// <param name="id">The ID of the notice you wish to update.</param>
        /// <param name="model">The notice object you wish to update.</param>
        public NoticeModel UpdateNotice(Int32 companyId, Int32 id, NoticeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<NoticeModel>("Put", path, model);
        }


        /// <summary>
        /// Retrieve a single attachment
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the file attachment identified by this URL.
        /// </remarks>
        /// <param name="companyId">The ID of the company for this attachment.</param>
        /// <param name="model">The ResourceFileId of the attachment to download.</param>
        public FileResult UploadAttachment(Int32 companyId, ResourceFileUploadRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/attachment");
            path.ApplyField("companyId", companyId);
            return RestCallFile("Post", path, model);
        }


        /// <summary>
        /// Request a new Avalara account
        /// </summary>
        /// <remarks>
        /// This API is for use by partner onboarding services customers only.
        /// 
        /// Avalara invites select partners to refer new customers to the AvaTax service using the onboarding features
        /// of AvaTax. These partners can create accounts for new customers using this API.
        /// 
        /// Calling this API creates an account with the specified product subscriptions, but does not configure billing.
        /// The customer will receive information from Avalara about how to configure billing for their account.
        /// You should call this API when a customer has requested to begin using Avalara services.
        /// 
        /// If the newly created account owner wishes, they can confirm that they have read and agree to the Avalara
        /// terms and conditions. If they do so, they can receive a license key as part of this API and their
        /// API will be created in `Active` status. If the customer has not yet read and accepted these terms and
        /// conditions, the account will be created in `New` status and they can receive a license key by logging
        /// onto AvaTax and reviewing terms and conditions online.
        /// </remarks>
        /// <param name="model">Information about the account you wish to create and the selected product offerings.</param>
        public NewAccountModel RequestNewAccount(NewAccountRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/request");
            return RestCall<NewAccountModel>("Post", path, model);
        }


        /// <summary>
        /// Change Password
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Allows a user to change their password via the API.
        /// This API only allows the currently authenticated user to change their password; it cannot be used to apply to a
        /// different user than the one authenticating the current API call.
        /// </remarks>
        /// <param name="model">An object containing your current password and the new password.</param>
        public String ChangePassword(PasswordChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords");
            return RestCallString("Put", path, model);
        }


        /// <summary>
        /// Create a new account
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create a single new account object. 
        /// When creating an account object you may attach subscriptions and users as part of the 'Create' call.
        /// </remarks>
        /// <param name="model">The account you wish to create.</param>
        public AccountModel CreateAccount(AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            return RestCall<AccountModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new subscription
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create one or more new subscription objects attached to this account.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription.</param>
        /// <param name="model">The subscription you wish to create.</param>
        public List<SubscriptionModel> CreateSubscriptions(Int32 accountId, List<SubscriptionModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            return RestCall<List<SubscriptionModel>>("Post", path, model);
        }


        /// <summary>
        /// Create new users
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create one or more new user objects attached to this account.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// </remarks>
        /// <param name="accountId">The unique ID number of the account where these users will be created.</param>
        /// <param name="model">The user or array of users you wish to create.</param>
        public List<UserModel> CreateUsers(Int32 accountId, List<UserModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            return RestCall<List<UserModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single account
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Delete an account.
        /// Deleting an account will delete all companies and all account level users attached to this account.
        /// </remarks>
        /// <param name="id">The ID of the account you wish to delete.</param>
        public List<ErrorDetail> DeleteAccount(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete a single subscription
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Mark the existing account identified by this URL as deleted.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription.</param>
        /// <param name="id">The ID of the subscription you wish to delete.</param>
        public List<ErrorDetail> DeleteSubscription(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Delete a single user
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Mark the user object identified by this URL as deleted.
        /// </remarks>
        /// <param name="id">The ID of the user you wish to delete.</param>
        /// <param name="accountId">The accountID of the user you wish to delete.</param>
        public List<ErrorDetail> DeleteUser(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve all accounts
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Get multiple account objects.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Subscriptions
        /// * Users
        ///  
        /// For more information about filtering in REST, please see the documentation at http://developer.avalara.com/avatax/filtering-in-rest/ .
        /// </remarks>
        /// <param name="include">A comma separated list of objects to fetch underneath this account. Any object with a URL path underneath this account can be fetched by specifying its name.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<AccountModel> QueryAccounts(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<AccountModel>>("Get", path, null);
        }


        /// <summary>
        /// Reset a user's password programmatically
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Allows a system admin to reset the password for a specific user via the API.
        /// This API is only available for Avalara Registrar Admins, and can be used to reset the password of any
        /// user based on internal Avalara business processes.
        /// </remarks>
        /// <param name="userId">The unique ID of the user whose password will be changed</param>
        /// <param name="model">The new password for this user</param>
        public String ResetPassword(Int32 userId, SetPasswordModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords/{userId}/reset");
            path.ApplyField("userId", userId);
            return RestCallString("Post", path, model);
        }


        /// <summary>
        /// Update a single account
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Replace an existing account object with an updated account object.
        /// </remarks>
        /// <param name="id">The ID of the account you wish to update.</param>
        /// <param name="model">The account object you wish to update.</param>
        public AccountModel UpdateAccount(Int32 id, AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return RestCall<AccountModel>("Put", path, model);
        }


        /// <summary>
        /// Update a single subscription
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Replace the existing subscription object at this URL with an updated object.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="accountId">The ID of the account that this subscription belongs to.</param>
        /// <param name="id">The ID of the subscription you wish to update</param>
        /// <param name="model">The subscription you wish to update.</param>
        public SubscriptionModel UpdateSubscription(Int32 accountId, Int32 id, SubscriptionModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<SubscriptionModel>("Put", path, model);
        }


        /// <summary>
        /// Export a report accurate to the line level
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="companyId"></param>
        /// <param name="model"></param>
        public FileResult ExportDocumentLine(Int32 companyId, ExportDocumentLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/reports/exportdocumentline");
            path.ApplyField("companyId", companyId);
            return RestCallFile("Post", path, model);
        }


        /// <summary>
        /// Create a new setting
        /// </summary>
        /// <remarks>
        /// Create one or more new setting objects attached to this company.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting.</param>
        /// <param name="model">The setting you wish to create.</param>
        public List<SettingModel> CreateSettings(Int32 companyId, List<SettingModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            return RestCall<List<SettingModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single setting
        /// </summary>
        /// <remarks>
        /// Mark the setting object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting.</param>
        /// <param name="id">The ID of the setting you wish to delete.</param>
        public List<ErrorDetail> DeleteSetting(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single setting
        /// </summary>
        /// <remarks>
        /// Get a single setting object by its unique ID.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting</param>
        /// <param name="id">The primary key of this setting</param>
        public SettingModel GetSetting(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<SettingModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all settings for this company
        /// </summary>
        /// <remarks>
        /// List all setting objects attached to this company.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these settings</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SettingModel> ListSettingsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SettingModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all settings
        /// </summary>
        /// <remarks>
        /// Get multiple setting objects across all companies.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SettingModel> QuerySettings(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/settings");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SettingModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single setting
        /// </summary>
        /// <remarks>
        /// Replace the existing setting object at this URL with an updated object.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this setting belongs to.</param>
        /// <param name="id">The ID of the setting you wish to update</param>
        /// <param name="model">The setting you wish to update.</param>
        public SettingModel UpdateSetting(Int32 companyId, Int32 id, SettingModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<SettingModel>("Put", path, model);
        }


        /// <summary>
        /// Retrieve a single subscription
        /// </summary>
        /// <remarks>
        /// Get the subscription object identified by this URL.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription</param>
        /// <param name="id">The primary key of this subscription</param>
        public SubscriptionModel GetSubscription(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return RestCall<SubscriptionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve subscriptions for this account
        /// </summary>
        /// <remarks>
        /// List all subscription objects attached to this account.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns these subscriptions</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SubscriptionModel> ListSubscriptionsByAccount(Int32 accountId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SubscriptionModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all subscriptions
        /// </summary>
        /// <remarks>
        /// Get multiple subscription objects across all accounts.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<SubscriptionModel> QuerySubscriptions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/subscriptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<SubscriptionModel>>("Get", path, null);
        }


        /// <summary>
        /// Create a new tax code
        /// </summary>
        /// <remarks>
        /// Create one or more new taxcode objects attached to this company.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code.</param>
        /// <param name="model">The tax code you wish to create.</param>
        public List<TaxCodeModel> CreateTaxCodes(Int32 companyId, List<TaxCodeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            return RestCall<List<TaxCodeModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single tax code
        /// </summary>
        /// <remarks>
        /// Marks the existing TaxCode object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code.</param>
        /// <param name="id">The ID of the tax code you wish to delete.</param>
        public List<ErrorDetail> DeleteTaxCode(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single tax code
        /// </summary>
        /// <remarks>
        /// Get the taxcode object identified by this URL.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code</param>
        /// <param name="id">The primary key of this tax code</param>
        public TaxCodeModel GetTaxCode(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<TaxCodeModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve tax codes for this company
        /// </summary>
        /// <remarks>
        /// List all taxcode objects attached to this company.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these tax codes</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxCodeModel> ListTaxCodesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxCodeModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all tax codes
        /// </summary>
        /// <remarks>
        /// Get multiple taxcode objects across all companies.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxCodeModel> QueryTaxCodes(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxCodeModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single tax code
        /// </summary>
        /// <remarks>
        /// Replace the existing taxcode object at this URL with an updated object.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this tax code belongs to.</param>
        /// <param name="id">The ID of the tax code you wish to update</param>
        /// <param name="model">The tax code you wish to update.</param>
        public TaxCodeModel UpdateTaxCode(Int32 companyId, Int32 id, TaxCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<TaxCodeModel>("Put", path, model);
        }


        /// <summary>
        /// Build a multi-location tax content file
        /// </summary>
        /// <remarks>
        /// Builds a tax content file containing information useful for a retail point-of-sale solution.
        /// 
        /// This file contains tax rates and rules for items and locations that can be used
        /// to correctly calculate tax in the event a point-of-sale device is not able to reach AvaTax.
        /// 
        /// This data file can be customized for specific partner devices and usage conditions.
        /// 
        /// The result of this API is the file you requested in the format you requested using the `responseType` field.
        /// 
        /// This API builds the file on demand, and is limited to files with no more than 7500 scenarios. To build a tax content
        /// file for a single location at a time, please use `BuildTaxContentFileForLocation`.
        /// </remarks>
        /// <param name="model">Parameters about the desired file format and report format, specifying which company, locations and TaxCodes to include.</param>
        public FileResult BuildTaxContentFile(PointOfSaleDataRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/pointofsaledata/build");
            return RestCallFile("Post", path, model);
        }


        /// <summary>
        /// Build a tax content file for a single location
        /// </summary>
        /// <remarks>
        /// Builds a tax content file containing information useful for a retail point-of-sale solution.
        /// 
        /// This file contains tax rates and rules for all items for a single location. Data from this API
        /// can be used to correctly calculate tax in the event a point-of-sale device is not able to reach AvaTax.
        /// 
        /// This data file can be customized for specific partner devices and usage conditions.
        /// 
        /// The result of this API is the file you requested in the format you requested using the `responseType` field.
        /// 
        /// This API builds the file on demand, and is limited to files with no more than 7500 scenarios. To build a tax content
        /// file for a multiple locations in a single file, please use `BuildTaxContentFile`.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that owns this location.</param>
        /// <param name="id">The ID number of the location to retrieve point-of-sale data.</param>
        /// <param name="date">The date for which point-of-sale data would be calculated (today by default)</param>
        /// <param name="format">The format of the file (JSON by default)</param>
        /// <param name="partnerId">If specified, requests a custom partner-formatted version of the file.</param>
        /// <param name="includeJurisCodes">When true, the file will include jurisdiction codes in the result.</param>
        public FileResult BuildTaxContentFileForLocation(Int32 companyId, Int32 id, DateTime? date, PointOfSaleFileType? format, PointOfSalePartnerId? partnerId, Boolean? includeJurisCodes)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/pointofsaledata");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("date", date);
            path.AddQuery("format", format);
            path.AddQuery("partnerId", partnerId);
            path.AddQuery("includeJurisCodes", includeJurisCodes);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Download a file listing tax rates by postal code
        /// </summary>
        /// <remarks>
        /// Download a CSV file containing all five digit postal codes in the United States and their sales
        /// and use tax rates for tangible personal property.
        /// 
        /// This rates file is intended to be used as a default for tax calculation when your software cannot
        /// call the `CreateTransaction` API call. When using this file, your software will be unable to
        /// handle complex tax rules such as:
        /// 
        /// * Zip+9 - This tax file does not contain 
        /// * Different product types - This tax file contains tangible personal property tax rates only.
        /// * Mixed sourcing - This tax file cannot be used to resolve origin-based taxes.
        /// * Threshold-based taxes - This tax file does not contain information about thresholds.
        /// 
        /// If you use this file to provide default tax rates, please ensure that your software calls `CreateTransaction`
        /// to reconcile the actual transaction and determine the difference between the estimated general tax
        /// rate and the final transaction tax.
        /// </remarks>
        /// <param name="date">The date for which</param>
        public FileResult DownloadTaxRatesByZipCode(DateTime date)
        {
            var path = new AvaTaxPath("/api/v2/taxratesbyzipcode/download/{date}");
            path.ApplyField("date", date);
            return RestCallFile("Get", path, null);
        }


        /// <summary>
        /// Create a new tax rule
        /// </summary>
        /// <remarks>
        /// Create one or more new taxrule objects attached to this company.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule.</param>
        /// <param name="model">The tax rule you wish to create.</param>
        public List<TaxRuleModel> CreateTaxRules(Int32 companyId, List<TaxRuleModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            return RestCall<List<TaxRuleModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single tax rule
        /// </summary>
        /// <remarks>
        /// Mark the TaxRule identified by this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule.</param>
        /// <param name="id">The ID of the tax rule you wish to delete.</param>
        public List<ErrorDetail> DeleteTaxRule(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single tax rule
        /// </summary>
        /// <remarks>
        /// Get the taxrule object identified by this URL.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule</param>
        /// <param name="id">The primary key of this tax rule</param>
        public TaxRuleModel GetTaxRule(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<TaxRuleModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve tax rules for this company
        /// </summary>
        /// <remarks>
        /// List all taxrule objects attached to this company.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these tax rules</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxRuleModel> ListTaxRules(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxRuleModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all tax rules
        /// </summary>
        /// <remarks>
        /// Get multiple taxrule objects across all companies.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TaxRuleModel> QueryTaxRules(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxrules");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TaxRuleModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single tax rule
        /// </summary>
        /// <remarks>
        /// Replace the existing taxrule object at this URL with an updated object.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this tax rule belongs to.</param>
        /// <param name="id">The ID of the tax rule you wish to update</param>
        /// <param name="model">The tax rule you wish to update.</param>
        public TaxRuleModel UpdateTaxRule(Int32 companyId, Int32 id, TaxRuleModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<TaxRuleModel>("Put", path, model);
        }


        /// <summary>
        /// Add lines to an existing unlocked transaction
        /// </summary>
        /// <remarks>
        /// Add lines to an existing unlocked transaction.
        ///  
        ///  The `AddLines` API allows you to add additional transaction lines to existing transaction, so that customer will
        ///  be able to append multiple calls together and form an extremely large transaction. If customer does not specify line number
        ///  in the lines to be added, a new random Guid string will be generated for line number. If customer are not satisfied with
        ///  the line number for the transaction lines, they can turn on the renumber switch to have REST v2 automatically renumber all 
        ///  transaction lines for them, in this case, the line number becomes: "1", "2", "3", ...
        ///  
        ///  A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        ///  sales, purchases, inventory transfer, and returns (also called refunds).
        ///  You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Lines
        ///  * Details (implies lines)
        ///  * Summary (implies details)
        ///  * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// 
        ///  If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">information about the transaction and lines to be added</param>
        public TransactionModel AddLines(String include, AddTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/add");
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Correct a previously created transaction
        /// </summary>
        /// <remarks>
        /// Replaces the current transaction uniquely identified by this URL with a new transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// When you adjust a committed transaction, the original transaction will be updated with the status code `Adjusted`, and
        /// both revisions will be available for retrieval based on their code and ID numbers.
        /// Only transactions in `Committed` status are reported by Avalara Managed Returns.
        /// 
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are considered `locked` and are 
        /// no longer available for adjustments.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to adjust</param>
        /// <param name="model">The adjustment you wish to make</param>
        public TransactionModel AdjustTransaction(String companyCode, String transactionCode, AdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/adjust");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Get audit information about a transaction
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The 'AuditTransaction' endpoint retrieves audit information related to a specific transaction. This audit 
        /// information includes the following:
        /// 
        /// * The `CompanyId` of the company that created the transaction
        /// * The server timestamp representing the exact server time when the transaction was created
        /// * The server duration - how long it took to process this transaction
        /// * Whether exact API call details were logged
        /// * A reconstructed API call showing what the original CreateTransaction call looked like
        /// 
        /// This API can be used to examine information about a previously created transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The code identifying the company that owns this transaction</param>
        /// <param name="transactionCode">The code identifying the transaction</param>
        public AuditTransactionModel AuditTransaction(String companyCode, String transactionCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<AuditTransactionModel>("Get", path, null);
        }


        /// <summary>
        /// Get audit information about a transaction
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The 'AuditTransaction' endpoint retrieves audit information related to a specific transaction. This audit 
        /// information includes the following:
        /// 
        /// * The `CompanyId` of the company that created the transaction
        /// * The server timestamp representing the exact server time when the transaction was created
        /// * The server duration - how long it took to process this transaction
        /// * Whether exact API call details were logged
        /// * A reconstructed API call showing what the original CreateTransaction call looked like
        /// 
        /// This API can be used to examine information about a previously created transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The code identifying the company that owns this transaction</param>
        /// <param name="transactionCode">The code identifying the transaction</param>
        /// <param name="documentType">The document type of the original transaction</param>
        public AuditTransactionModel AuditTransactionWithType(String companyCode, String transactionCode, DocumentType documentType)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            return RestCall<AuditTransactionModel>("Get", path, null);
        }


        /// <summary>
        /// Lock a set of documents
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// Lock a set of transactions uniquely identified by DocumentIds provided. This API allows locking multiple documents at once.
        /// After this API call succeeds, documents will be locked and can't be voided.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="model">bulk lock request</param>
        public BulkLockTransactionResult BulkLockTransaction(BulkLockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/lock");
            return RestCall<BulkLockTransactionResult>("Post", path, model);
        }


        /// <summary>
        /// Change a transaction's code
        /// </summary>
        /// <remarks>
        /// Renames a transaction uniquely identified by this URL by changing its code to a new code.
        /// After this API call succeeds, the transaction will have a new URL matching its new code.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to change</param>
        /// <param name="model">The code change request you wish to execute</param>
        public TransactionModel ChangeTransactionCode(String companyCode, String transactionCode, ChangeTransactionCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/changecode");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Commit a transaction for reporting
        /// </summary>
        /// <remarks>
        /// Marks a transaction by changing its status to 'Committed'.
        /// Transactions that are committed are available to be reported to a tax authority by Avalara Managed Returns.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// Any changes made to a committed transaction will generate a transaction history.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to commit</param>
        /// <param name="model">The commit request you wish to execute</param>
        public TransactionModel CommitTransaction(String companyCode, String transactionCode, CommitTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/commit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <remarks>
        /// Records a new transaction or adjust an existing in AvaTax.
        /// 
        /// The `CreateOrAdjustTransaction` endpoint is used to create a new transaction if the input transaction does not exist
        /// or if there exists a transaction identified by code, the original transaction will be adjusted by using the meta data 
        /// in the input transaction
        /// 
        /// If you don't specify type in the provided data, a new transaction with type of SalesOrder will be recorded by default.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create</param>
        public TransactionModel CreateOrAdjustTransaction(String include, CreateOrAdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/createoradjust");
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <remarks>
        /// Records a new transaction in AvaTax.
        /// 
        /// The `CreateTransaction` endpoint uses the configuration values specified by your company to identify the correct tax rules
        /// and rates to apply to all line items in this transaction, and reports the total tax calculated by AvaTax based on your
        /// company's configuration and the data provided in this API call.
        /// 
        /// If you don't specify type in the provided data, a new transaction with type of SalesOrder will be recorded by default.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create</param>
        public TransactionModel CreateTransaction(String include, CreateTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/create");
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Remove lines from an existing unlocked transaction
        /// </summary>
        /// <remarks>
        /// Remove lines to an existing unlocked transaction.
        ///  
        ///  The `DeleteLines` API allows you to remove transaction lines from existing unlocked transaction, so that customer will
        ///  be able to delete transaction lines and adjust original transaction the way they like
        ///  
        ///  A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        ///  sales, purchases, inventory transfer, and returns (also called refunds).
        ///  You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Lines
        ///  * Details (implies lines)
        ///  * Summary (implies details)
        ///  * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// 
        ///  If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">information about the transaction and lines to be removed</param>
        public TransactionModel DeleteLines(String include, RemoveTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/delete");
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Retrieve a single transaction by code
        /// </summary>
        /// <remarks>
        /// Get the current transaction identified by this URL.
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code, and previous revisions of
        /// the transaction will be attached to the 'history' data field.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public TransactionModel GetTransactionByCode(String companyCode, String transactionCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single transaction by code
        /// </summary>
        /// <remarks>
        /// Get the current transaction identified by this URL.
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code, and previous revisions of
        /// the transaction will be attached to the 'history' data field.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="documentType">The transaction type to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public TransactionModel GetTransactionByCodeAndType(String companyCode, String transactionCode, DocumentType documentType, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single transaction by ID
        /// </summary>
        /// <remarks>
        /// Get the unique transaction identified by this URL.
        /// This endpoint retrieves the exact transaction identified by this ID number even if that transaction was later adjusted
        /// by using the 'Adjust Transaction' endpoint.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="id">The unique ID number of the transaction to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public TransactionModel GetTransactionById(Int64 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/transactions/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all transactions
        /// </summary>
        /// <remarks>
        /// List all transactions attached to this company.
        /// This endpoint is limited to returning 1,000 transactions at a time maximum.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<TransactionModel> ListTransactionsByCompany(String companyCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions");
            path.ApplyField("companyCode", companyCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<TransactionModel>>("Get", path, null);
        }


        /// <summary>
        /// Lock a single transaction
        /// </summary>
        /// <remarks>
        /// Lock a transaction uniquely identified by this URL. 
        /// 
        /// This API is mainly used for connector developer to simulate what happens when Returns product locks a document.
        /// After this API call succeeds, the document will be locked and can't be voided or adjusted.
        /// 
        /// This API is only available to customers in Sandbox with AvaTaxPro subscription. On production servers, this API is available by invitation only.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to lock</param>
        /// <param name="model">The lock request you wish to execute</param>
        public TransactionModel LockTransaction(String companyCode, String transactionCode, LockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/lock");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Create a refund for a transaction
        /// </summary>
        /// <remarks>
        /// Create a refund for a transaction.
        /// 
        /// The `RefundTransaction` API allows you to quickly and easily create a `ReturnInvoice` representing a refund
        /// for a previously created `SalesInvoice` transaction. You can choose to create a full or partial refund, and
        /// specify individual line items from the original sale for refund.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="companyCode">The code of the company that made the original sale</param>
        /// <param name="transactionCode">The transaction code of the original sale</param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">Information about the refund to create</param>
        public TransactionModel RefundTransaction(String companyCode, String transactionCode, String include, RefundTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/refund");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Perform multiple actions on a transaction
        /// </summary>
        /// <remarks>
        /// Performs the same functions as /verify, /changecode, and /commit. You may specify one or many actions in each call to this endpoint.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="model">The settle request containing the actions you wish to execute</param>
        public TransactionModel SettleTransaction(String companyCode, String transactionCode, SettleTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/settle");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <remarks>
        /// Verifies that the transaction uniquely identified by this URL matches certain expected values.
        /// If the transaction does not match these expected values, this API will return an error code indicating which value did not match.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="model">The settle request you wish to execute</param>
        public TransactionModel VerifyTransaction(String companyCode, String transactionCode, VerifyTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/verify");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Void a transaction
        /// </summary>
        /// <remarks>
        /// Voids the current transaction uniquely identified by this URL.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// When you void a transaction, that transaction's status is recorded as 'DocVoided'.
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are no longer available to be voided.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to void</param>
        /// <param name="model">The void request you wish to execute</param>
        public TransactionModel VoidTransaction(String companyCode, String transactionCode, VoidTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/void");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return RestCall<TransactionModel>("Post", path, model);
        }


        /// <summary>
        /// Create a new UPC
        /// </summary>
        /// <remarks>
        /// Create one or more new UPC objects attached to this company.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC.</param>
        /// <param name="model">The UPC you wish to create.</param>
        public List<UPCModel> CreateUPCs(Int32 companyId, List<UPCModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            return RestCall<List<UPCModel>>("Post", path, model);
        }


        /// <summary>
        /// Delete a single UPC
        /// </summary>
        /// <remarks>
        /// Marks the UPC object identified by this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC.</param>
        /// <param name="id">The ID of the UPC you wish to delete.</param>
        public List<ErrorDetail> DeleteUPC(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<List<ErrorDetail>>("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single UPC
        /// </summary>
        /// <remarks>
        /// Get the UPC object identified by this URL.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC</param>
        /// <param name="id">The primary key of this UPC</param>
        public UPCModel GetUPC(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<UPCModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve UPCs for this company
        /// </summary>
        /// <remarks>
        /// List all UPC objects attached to this company.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these UPCs</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<UPCModel> ListUPCsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<UPCModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all UPCs
        /// </summary>
        /// <remarks>
        /// Get multiple UPC objects across all companies.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<UPCModel> QueryUPCs(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/upcs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<UPCModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single UPC
        /// </summary>
        /// <remarks>
        /// Replace the existing UPC object at this URL with an updated object.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this UPC belongs to.</param>
        /// <param name="id">The ID of the UPC you wish to update</param>
        /// <param name="model">The UPC you wish to update.</param>
        public UPCModel UpdateUPC(Int32 companyId, Int32 id, UPCModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return RestCall<UPCModel>("Put", path, model);
        }


        /// <summary>
        /// Retrieve a single user
        /// </summary>
        /// <remarks>
        /// Get the user object identified by this URL.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// </remarks>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <param name="accountId">The accountID of the user you wish to get.</param>
        /// <param name="include">Optional fetch commands.</param>
        public UserModel GetUser(Int32 id, Int32 accountId, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            return RestCall<UserModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all entitlements for a single user
        /// </summary>
        /// <remarks>
        /// Return a list of all entitlements to which this user has rights to access.
        /// Entitlements are a list of specified API calls the user is permitted to make, a list of identifier numbers for companies the user is 
        /// allowed to use, and an access level identifier that indicates what types of access roles the user is allowed to use.
        /// This API call is intended to provide a validation endpoint to determine, before making an API call, whether this call is likely to succeed.
        /// For example, if user 567 within account 999 is attempting to create a new child company underneath company 12345, you could preview the user's
        /// entitlements and predict whether this call would succeed:
        ///  
        /// * Retrieve entitlements by calling '/api/v2/accounts/999/users/567/entitlements' . If the call fails, you do not have accurate 
        ///  credentials for this user.
        /// * If the 'accessLevel' field within entitlements is 'None', the call will fail.
        /// * If the 'accessLevel' field within entitlements is 'SingleCompany' or 'SingleAccount', the call will fail if the companies
        ///  table does not contain the ID number 12345.
        /// * If the 'permissions' array within entitlements does not contain 'AccountSvc.CompanySave', the call will fail.
        ///  
        /// For a full list of defined permissions, please use '/api/v2/definitions/permissions' .
        /// </remarks>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <param name="accountId">The accountID of the user you wish to get.</param>
        public UserEntitlementModel GetUserEntitlements(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}/entitlements");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return RestCall<UserEntitlementModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve users for this account
        /// </summary>
        /// <remarks>
        /// List all user objects attached to this account.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="accountId">The accountID of the user you wish to list.</param>
        /// <param name="include">Optional fetch commands.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<UserModel> ListUsersByAccount(Int32 accountId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<UserModel>>("Get", path, null);
        }


        /// <summary>
        /// Retrieve all users
        /// </summary>
        /// <remarks>
        /// Get multiple user objects across all accounts.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="include">Optional fetch commands.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public FetchResult<UserModel> QueryUsers(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/users");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return RestCall<FetchResult<UserModel>>("Get", path, null);
        }


        /// <summary>
        /// Update a single user
        /// </summary>
        /// <remarks>
        /// Replace the existing user object at this URL with an updated object.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="id">The ID of the user you wish to update.</param>
        /// <param name="accountId">The accountID of the user you wish to update.</param>
        /// <param name="model">The user object you wish to update.</param>
        public UserModel UpdateUser(Int32 id, Int32 accountId, UserModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return RestCall<UserModel>("Put", path, model);
        }


        /// <summary>
        /// Checks if the current user is subscribed to a specific service
        /// </summary>
        /// <remarks>
        /// Returns a subscription object for the current account, or 404 Not Found if this subscription is not enabled for this account.
        /// This API call is intended to allow you to identify whether you have the necessary account configuration to access certain
        /// features of AvaTax, and would be useful in debugging access privilege problems.
        /// </remarks>
        /// <param name="serviceTypeId">The service to check</param>
        public SubscriptionModel GetMySubscription(ServiceTypeId serviceTypeId)
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions/{serviceTypeId}");
            path.ApplyField("serviceTypeId", serviceTypeId);
            return RestCall<SubscriptionModel>("Get", path, null);
        }


        /// <summary>
        /// List all services to which the current user is subscribed
        /// </summary>
        /// <remarks>
        /// Returns the list of all subscriptions enabled for the current account.
        /// This API is intended to help you determine whether you have the necessary subscription to use certain API calls
        /// within AvaTax.
        /// </remarks>
        public FetchResult<SubscriptionModel> ListMySubscriptions()
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions");
            return RestCall<FetchResult<SubscriptionModel>>("Get", path, null);
        }


        /// <summary>
        /// Tests connectivity and version of the service
        /// </summary>
        /// <remarks>
        /// This API helps diagnose connectivity problems between your application and AvaTax; you may call this API even 
        /// if you do not have verified connection credentials.
        /// The results of this API call will help you determine whether your computer can contact AvaTax via the network,
        /// whether your authentication credentials are recognized, and the roundtrip time it takes to communicate with
        /// AvaTax.
        /// </remarks>
        public PingResultModel Ping()
        {
            var path = new AvaTaxPath("/api/v2/utilities/ping");
            return RestCall<PingResultModel>("Get", path, null);
        }

#endregion

#region Asynchronous
#if PORTABLE

        /// <summary>
        /// Reset this account's license key;
        /// </summary>
        /// <remarks>
        /// Resets the existing license key for this account to a new key.
        /// To reset your account, you must specify the ID of the account you wish to reset and confirm the action.
        /// Resetting a license key cannot be undone. Any previous license keys will immediately cease to work when a new key is created.;
        /// </remarks>
        /// <param name="id">The ID of the account you wish to update.</param>
        /// <param name="model">A request confirming that you wish to reset the license key of this account.</param>
        public async Task<LicenseKeyModel> AccountResetLicenseKeyAsync(Int32 id, ResetLicenseKeyModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/resetlicensekey");
            path.ApplyField("id", id);
            return await RestCallAsync<LicenseKeyModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Activate an account by accepting terms and conditions;
        /// </summary>
        /// <remarks>
        /// Activate the account specified by the unique accountId number.
        /// 
        /// This activation request can only be called by account administrators. You must indicate 
        /// that you have read and accepted Avalara's terms and conditions to call this API.
        /// 
        /// If you have not read or accepted the terms and conditions, this API call will return the
        /// unchanged account model.;
        /// </remarks>
        /// <param name="id">The ID of the account to activate</param>
        /// <param name="include">Elements to include when fetching the account</param>
        /// <param name="model">The activation request</param>
        public async Task<AccountModel> ActivateAccountAsync(Int32 id, String include, ActivateAccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/activate");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<AccountModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single account;
        /// </summary>
        /// <remarks>
        /// Get the account object identified by this URL.
        /// You may use the '$include' parameter to fetch additional nested data:
        /// 
        /// * Subscriptions
        /// * Users;
        /// </remarks>
        /// <param name="id">The ID of the account to retrieve</param>
        /// <param name="include">A comma separated list of special fetch options</param>
        public async Task<AccountModel> GetAccountAsync(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<AccountModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Get configuration settings for this account;
        /// </summary>
        /// <remarks>
        /// Retrieve a list of all configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `TaxServiceConfig` and `AddressServiceConfig` are reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Account settings are permanent settings that cannot be deleted. You can set the value of an
        /// account setting to null if desired.
        /// 
        /// Avalara-based account settings for `TaxServiceConfig` and `AddressServiceConfig` affect your account's
        /// tax calculation and address resolution, and should only be changed with care.;
        /// </remarks>
        /// <param name="id"></param>
        public async Task<List<AccountConfigurationModel>> GetAccountConfigurationAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return await RestCallAsync<List<AccountConfigurationModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Change configuration settings for this account;
        /// </summary>
        /// <remarks>
        /// Update configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `TaxServiceConfig` and `AddressServiceConfig` are reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Account settings are permanent settings that cannot be deleted. You can set the value of an
        /// account setting to null if desired.
        /// 
        /// Avalara-based account settings for `TaxServiceConfig` and `AddressServiceConfig` affect your account's
        /// tax calculation and address resolution, and should only be changed with care.;
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public async Task<List<AccountConfigurationModel>> SetAccountConfigurationAsync(Int32 id, List<AccountConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return await RestCallAsync<List<AccountConfigurationModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve geolocation information for a specified address;
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the POST /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.;
        /// </remarks>
        /// <param name="line1">Line 1</param>
        /// <param name="line2">Line 2</param>
        /// <param name="line3">Line 3</param>
        /// <param name="city">City</param>
        /// <param name="region">State / Province / Region</param>
        /// <param name="postalCode">Postal Code / Zip Code</param>
        /// <param name="country">Two character ISO 3166 Country Code (see /api/v2/definitions/countries for a full list)</param>
        /// <param name="textCase">selectable text case for address validation</param>
        /// <param name="latitude">Geospatial latitude measurement</param>
        /// <param name="longitude">Geospatial longitude measurement</param>
        public async Task<AddressResolutionModel> ResolveAddressAsync(String line1, String line2, String line3, String city, String region, String postalCode, String country, TextCase? textCase, Decimal? latitude, Decimal? longitude)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("textCase", textCase);
            path.AddQuery("latitude", latitude);
            path.AddQuery("longitude", longitude);
            return await RestCallAsync<AddressResolutionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve geolocation information for a specified address;
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the GET /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.;
        /// </remarks>
        /// <param name="model">The address to resolve</param>
        public async Task<AddressResolutionModel> ResolveAddressPostAsync(AddressValidationInfo model)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            return await RestCallAsync<AddressResolutionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new batch;
        /// </summary>
        /// <remarks>
        /// Create one or more new batch objects attached to this company.
        /// When you create a batch, it is added to the AvaTaxBatch.Batch table and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// Each batch object may have one or more file objects (currently only one file is supported).;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch.</param>
        /// <param name="model">The batch you wish to create.</param>
        public async Task<List<BatchModel>> CreateBatchesAsync(Int32 companyId, List<BatchModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<BatchModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single batch;
        /// </summary>
        /// <remarks>
        /// ;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch.</param>
        /// <param name="id">The ID of the batch you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteBatchAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Download a single batch file;
        /// </summary>
        /// <remarks>
        /// Download a single batch file identified by this URL.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch</param>
        /// <param name="batchId">The ID of the batch object</param>
        /// <param name="id">The primary key of this batch file object</param>
        public async Task<FileResult> DownloadBatchAsync(Int32 companyId, Int32 batchId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{batchId}/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("batchId", batchId);
            path.ApplyField("id", id);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single batch;
        /// </summary>
        /// <remarks>
        /// Get the batch object identified by this URL.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch</param>
        /// <param name="id">The primary key of this batch</param>
        public async Task<BatchModel> GetBatchAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<BatchModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all batches for this company;
        /// </summary>
        /// <remarks>
        /// List all batch objects attached to the specified company.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<BatchModel>> ListBatchesByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<BatchModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all batches;
        /// </summary>
        /// <remarks>
        /// Get multiple batch objects across all companies.
        /// A batch object is a large collection of API calls stored in a compact file.
        /// When you create a batch, it is added to the AvaTax Batch Queue and will be processed in the order it was received.
        /// You may fetch a batch to check on its status and retrieve the results of the batch operation.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<BatchModel>> QueryBatchesAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/batches");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<BatchModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a CertExpress invitation;
        /// </summary>
        /// <remarks>
        /// Creates an invitation for a customer to self-report certificates using the CertExpress website.
        /// 
        /// This invitation is delivered by your choice of method, or you can present a hyperlink to the user
        /// directly in your connector. Your customer will be redirected to https://app.certexpress.com/ where
        /// they can follow a step-by-step guide to enter information about their exemption certificates. The
        /// certificates entered will be recorded and automatically linked to their customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that will record certificates</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="model">the requests to send out to customers</param>
        public async Task<List<CertExpressInvitationStatusModel>> CreateCertExpressInvitationAsync(Int32 companyId, String customerCode, List<CreateCertExpressInvitationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return await RestCallAsync<List<CertExpressInvitationStatusModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single CertExpress invitation;
        /// </summary>
        /// <remarks>
        /// Retrieve an existing CertExpress invitation sent to a customer.
        /// 
        /// A CertExpression invitation allows a customer to follow a helpful step-by-step guide to provide information
        /// about their certificates. This step by step guide allows the customer to complete and upload the full 
        /// certificate in a convenient, friendly web browser experience. When the customer completes their certificates,
        /// they will automatically be recorded to your company and linked to the customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="id">The unique ID number of this CertExpress invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. No options are defined at this time.</param>
        public async Task<CertExpressInvitationModel> GetCertExpressInvitationAsync(Int32 companyId, String customerCode, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<CertExpressInvitationModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List CertExpress invitations;
        /// </summary>
        /// <remarks>
        /// Retrieve CertExpress invitations sent by this company.
        /// 
        /// A CertExpression invitation allows a customer to follow a helpful step-by-step guide to provide information
        /// about their certificates. This step by step guide allows the customer to complete and upload the full 
        /// certificate in a convenient, friendly web browser experience. When the customer completes their certificates,
        /// they will automatically be recorded to your company and linked to the customer record.
        /// 
        /// The [CertExpress website](https://app.certexpress.com/home) is available for customers to use at any time.
        /// Using CertExpress with this API will ensure that your certificates are automatically linked correctly into
        /// your company so that they can be used for tax exemptions.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  
        ///  No options are defined at this time.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CertExpressInvitationModel>> ListCertExpressInvitationsAsync(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CertExpressInvitationModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create certificates for this company;
        /// </summary>
        /// <remarks>
        /// Record one or more certificates document for this company.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// When you create a certificate, it will be processed by Avalara and will become available for use in
        /// calculating tax exemptions when processing is complete. For a certificate to be used in calculating exemptions,
        /// it must have the following:
        /// 
        /// * A list of exposure zones indicating where the certificate is valid
        /// * A link to the customer that is allowed to use this certificate
        /// * Your tax transaction must contain the correct customer code;
        /// </remarks>
        /// <param name="companyId">The ID number of the company recording this certificate</param>
        /// <param name="model">Certificates to be created</param>
        public async Task<List<CertificateModel>> CreateCertificatesAsync(Int32 companyId, List<CertificateModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<CertificateModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Revoke and delete a certificate;
        /// </summary>
        /// <remarks>
        /// Revoke the certificate identified by this URL, then delete it.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// Revoked certificates can no longer be used.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public async Task<CertificateModel> DeleteCertificateAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<CertificateModel>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Download an image for this certificate;
        /// </summary>
        /// <remarks>
        /// Download an image or PDF file for this certificate.
        /// 
        /// This API can be used to download either a single-page preview of the certificate or a full PDF document.
        /// To retrieve a preview image, set the `$type` parameter to `Jpeg` and the `$page` parameter to `1`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="page">If you choose `$type`=`Jpeg`, you must specify which page number to retrieve.</param>
        /// <param name="type">The data format in which to retrieve the certificate image</param>
        public async Task<FileResult> DownloadCertificateImageAsync(Int32 companyId, Int32 id, Int32? page, CertificatePreviewType? type)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$page", page);
            path.AddQuery("$type", type);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single certificate;
        /// </summary>
        /// <remarks>
        /// Get the current certificate identified by this URL.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Customers - Retrieves the list of customers linked to the certificate.
        /// * PoNumbers - Retrieves all PO numbers tied to the certificate.
        /// * Attributes - Retrieves all attributes applied to the certificate.;
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        public async Task<CertificateModel> GetCertificateAsync(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<CertificateModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Link attributes to a certificate;
        /// </summary>
        /// <remarks>
        /// Link one or many attributes to a certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `ListCertificateAttributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to link to this certificate.</param>
        public async Task<FetchResult<CertificateAttributeModel>> LinkAttributesToCertificateAsync(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<CertificateAttributeModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Link customers to a certificate;
        /// </summary>
        /// <remarks>
        /// Link one or more customers to an existing certificate.
        /// 
        /// Customers and certificates must be linked before a customer can make use of a certificate to obtain
        /// a tax exemption in AvaTax. Since some certificates may cover more than one business entity, a certificate
        /// can be connected to multiple customer records using the `LinkCustomersToCertificate` API.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers needed be added to the Certificate for exemption</param>
        public async Task<FetchResult<CustomerModel>> LinkCustomersToCertificateAsync(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<CustomerModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// List all attributes applied to this certificate;
        /// </summary>
        /// <remarks>
        /// Retrieve the list of attributes that are linked to this certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `/api/v2/definitions/certificateattributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public async Task<FetchResult<CertificateAttributeModel>> ListAttributesForCertificateAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<CertificateAttributeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List customers linked to this certificate;
        /// </summary>
        /// <remarks>
        /// List all customers linked to this certificate.
        /// 
        /// Customers must be linked to a certificate in order to make use of its tax exemption features. You
        /// can link or unlink customers to a certificate at any time.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  No options are currently available when fetching customers.</param>
        public async Task<FetchResult<CustomerModel>> ListCustomersForCertificateAsync(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<FetchResult<CustomerModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all certificates for a company;
        /// </summary>
        /// <remarks>
        /// List all certificates recorded by a company
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Customers - Retrieves the list of customers linked to the certificate.
        /// * PoNumbers - Retrieves all PO numbers tied to the certificate.
        /// * Attributes - Retrieves all attributes applied to the certificate.;
        /// </remarks>
        /// <param name="companyId">The ID number of the company to search</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CertificateModel>> QueryCertificatesAsync(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CertificateModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Unlink attributes from a certificate;
        /// </summary>
        /// <remarks>
        /// Unlink one or many attributes from a certificate.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may link or unlink attributes to a
        /// certificate at any time. The full list of defined attributes may be found using `ListCertificateAttributes`.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to unlink from this certificate.</param>
        public async Task<FetchResult<CertificateAttributeModel>> UnlinkAttributesFromCertificateAsync(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<CertificateAttributeModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Unlink customers from a certificate;
        /// </summary>
        /// <remarks>
        /// Unlinks one or more customers from a certificate.
        /// 
        /// Unlinking a certificate from a customer will prevent the certificate from being used to generate
        /// tax exemptions for the customer in the future. If any previous transactions for this customer had
        /// used this linked certificate, those transactions will be unchanged and will still have a link to the
        /// exemption certificate in question.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers to unlink from this certificate</param>
        public async Task<FetchResult<CustomerModel>> UnlinkCustomersFromCertificateAsync(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<CustomerModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single certificate;
        /// </summary>
        /// <remarks>
        /// Replace the certificate identified by this URL with a new one.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The new certificate object that will replace the existing one</param>
        public async Task<CertificateModel> UpdateCertificateAsync(Int32 companyId, Int32 id, CertificateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<CertificateModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Upload an image or PDF attachment for this certificate;
        /// </summary>
        /// <remarks>
        /// Upload an image or PDF attachment for this certificate.
        /// 
        /// Image attachments can be of the format `PDF`, `JPEG`, `TIFF`, or `PNG`. To upload a multi-page image, please
        /// use the `PDF` data type.
        /// 
        /// A certificate is a document stored in either AvaTax Exemptions or CertCapture. The certificate document
        /// can contain information about a customer's eligibility for exemption from sales or use taxes based on
        /// criteria you specify when you store the certificate. To view or manage your certificates directly, please 
        /// log onto the administrative website for the product you purchased.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="file">The exemption certificate file you wanted to upload. Accepted formats are: PDF, JPEG, TIFF, PNG.</param>
        public async Task<String> UploadCertificateImageAsync(Int32 companyId, Int32 id, FileResult file)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallStringAsync("Post", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Change the filing status of this company;
        /// </summary>
        /// <remarks>
        /// Changes the current filing status of this company.
        /// 
        /// For customers using Avalara's Managed Returns Service, each company within their account can request
        /// for Avalara to file tax returns on their behalf. Avalara compliance team members will review all
        /// requested filing calendars prior to beginning filing tax returns on behalf of this company.
        /// 
        /// The following changes may be requested through this API:
        /// 
        /// * If a company is in `NotYetFiling` status, the customer may request this be changed to `FilingRequested`.
        /// * Avalara compliance team members may change a company from `FilingRequested` to `FirstFiling`.
        /// * Avalara compliance team members may change a company from `FirstFiling` to `Active`.
        /// 
        /// All other status changes must be requested through the Avalara customer support team.;
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public async Task<String> ChangeFilingStatusAsync(Int32 id, FilingStatusChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return await RestCallStringAsync("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Quick setup for a company with a single physical address;
        /// </summary>
        /// <remarks>
        /// Shortcut to quickly setup a single-physical-location company with critical information and activate it.
        /// This API provides quick and simple company setup functionality and does the following things:
        ///  
        /// * Create a company object with its own tax profile
        /// * Add a key contact person for the company
        /// * Set up one physical location for the main office
        /// * Declare nexus in all taxing jurisdictions for that main office address
        /// * Activate the company
        ///  
        /// This API only provides a limited subset of functionality compared to the 'Create Company' API call. 
        /// If you need additional features or options not present in this 'Quick Setup' API call, please use the full 'Create Company' call instead.;
        /// </remarks>
        /// <param name="model">Information about the company you wish to create.</param>
        public async Task<CompanyModel> CompanyInitializeAsync(CompanyInitializationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/initialize");
            return await RestCallAsync<CompanyModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create new companies;
        /// </summary>
        /// <remarks>
        /// Create one or more new company objects.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// You may attach nested data objects such as contacts, locations, and nexus with this CREATE call, and those objects will be created with the company.;
        /// </remarks>
        /// <param name="model">Either a single company object or an array of companies to create</param>
        public async Task<List<CompanyModel>> CreateCompaniesAsync(List<CompanyModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            return await RestCallAsync<List<CompanyModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Request managed returns funding setup for a company;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API records that an ambedded HTML funding setup widget was activated.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.;
        /// </remarks>
        /// <param name="id">The unique identifier of the company</param>
        /// <param name="model">The funding initialization request</param>
        public async Task<FundingStatusModel> CreateFundingRequestAsync(Int32 id, FundingInitiateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding/setup");
            path.ApplyField("id", id);
            return await RestCallAsync<FundingStatusModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single company;
        /// </summary>
        /// <remarks>
        /// Deleting a company will delete all child companies, and all users attached to this company.;
        /// </remarks>
        /// <param name="id">The ID of the company you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteCompanyAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single company;
        /// </summary>
        /// <remarks>
        /// Get the company object identified by this URL.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Contacts
        ///  * Items
        ///  * Locations
        ///  * Nexus
        ///  * Settings
        ///  * TaxCodes
        ///  * TaxRules
        ///  * UPC;
        /// </remarks>
        /// <param name="id">The ID of the company to retrieve.</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  
        ///  * Child objects - Specify one or more of the following to retrieve objects related to each company: "Contacts", "FilingCalendars", "Items", "Locations", "Nexus", "TaxCodes", or "TaxRules".
        ///  * Deleted objects - Specify "FetchDeleted" to retrieve information about previously deleted objects.</param>
        public async Task<CompanyModel> GetCompanyAsync(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<CompanyModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Get configuration settings for this company;
        /// </summary>
        /// <remarks>
        /// Retrieve a list of all configuration settings tied to this company.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `AvaCertServiceConfig` is reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Company settings are permanent settings that cannot be deleted. You can set the value of a
        /// company setting to null if desired.
        /// 
        /// Avalara-based account settings for `AvaCertServiceConfig` affect your account's exemption certificate
        /// processing, and should only be changed with care.;
        /// </remarks>
        /// <param name="id"></param>
        public async Task<List<CompanyConfigurationModel>> GetCompanyConfigurationAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return await RestCallAsync<List<CompanyConfigurationModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Get this company's filing status;
        /// </summary>
        /// <remarks>
        /// Retrieve the current filing status of this company.
        /// 
        /// For customers using Avalara's Managed Returns Service, each company within their account can request
        /// for Avalara to file tax returns on their behalf. Avalara compliance team members will review all
        /// requested filing calendars prior to beginning filing tax returns on behalf of this company.
        /// 
        /// A company's filing status can be one of the following values:
        /// 
        /// * `NoReporting` - This company is not configured to report tax returns; instead, it reports through a parent company.
        /// * `NotYetFiling` - This company has not yet begun filing tax returns through Avalara's Managed Returns Service.
        /// * `FilingRequested` - The company has requested to begin filing tax returns, but Avalara's compliance team has not yet begun filing.
        /// * `FirstFiling` - The company has recently filing tax returns and is in a new status.
        /// * `Active` - The company is currently active and is filing tax returns via Avalara Managed Returns.;
        /// </remarks>
        /// <param name="id"></param>
        public async Task<String> GetFilingStatusAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return await RestCallStringAsync("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Check managed returns funding configuration for a company;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// Returns a list of funding setup requests and their current status.
        /// Each object in the result is a request that was made to setup or adjust funding configuration for this company.;
        /// </remarks>
        /// <param name="id">The unique identifier of the company</param>
        public async Task<List<FundingStatusModel>> ListFundingRequestsByCompanyAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding");
            path.ApplyField("id", id);
            return await RestCallAsync<List<FundingStatusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of MRS Companies with account;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// Get a list of companies with an active MRS service.;
        /// </remarks>
        public async Task<FetchResult<CompanyModel>> ListMrsCompaniesAsync()
        {
            var path = new AvaTaxPath("/api/v2/companies/mrs");
            return await RestCallAsync<FetchResult<CompanyModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all companies;
        /// </summary>
        /// <remarks>
        /// Get multiple company objects.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Contacts
        /// * Items
        /// * Locations
        /// * Nexus
        /// * Settings
        /// * TaxCodes
        /// * TaxRules
        /// * UPC;
        /// </remarks>
        /// <param name="include">A comma separated list of objects to fetch underneath this company. Any object with a URL path underneath this company can be fetched by specifying its name.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CompanyModel>> QueryCompaniesAsync(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CompanyModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Change configuration settings for this account;
        /// </summary>
        /// <remarks>
        /// Update configuration settings tied to this account.
        /// 
        /// Configuration settings provide you with the ability to control features of your account and of your
        /// tax software. The category names `AvaCertServiceConfig` is reserved for
        /// Avalara internal software configuration values; to store your own account-level settings, please
        /// create a new category name that begins with `X-`, for example, `X-MyCustomCategory`.
        /// 
        /// Company settings are permanent settings that cannot be deleted. You can set the value of a
        /// company setting to null if desired.
        /// 
        /// Avalara-based account settings for `AvaCertServiceConfig` affect your account's exemption certificate
        /// processing, and should only be changed with care.;
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="model"></param>
        public async Task<List<CompanyConfigurationModel>> SetCompanyConfigurationAsync(Int32 id, List<CompanyConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return await RestCallAsync<List<CompanyConfigurationModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single company;
        /// </summary>
        /// <remarks>
        /// Replace the existing company object at this URL with an updated object.
        /// A 'company' represents a single corporation or individual that is registered to handle transactional taxes.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="id">The ID of the company you wish to update.</param>
        /// <param name="model">The company object you wish to update.</param>
        public async Task<CompanyModel> UpdateCompanyAsync(Int32 id, CompanyModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return await RestCallAsync<CompanyModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new contact;
        /// </summary>
        /// <remarks>
        /// Create one or more new contact objects.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this contact.</param>
        /// <param name="model">The contacts you wish to create.</param>
        public async Task<List<ContactModel>> CreateContactsAsync(Int32 companyId, List<ContactModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<ContactModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single contact;
        /// </summary>
        /// <remarks>
        /// Mark the existing contact object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this contact.</param>
        /// <param name="id">The ID of the contact you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteContactAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single contact;
        /// </summary>
        /// <remarks>
        /// Get the contact object identified by this URL.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.;
        /// </remarks>
        /// <param name="companyId">The ID of the company for this contact</param>
        /// <param name="id">The primary key of this contact</param>
        public async Task<ContactModel> GetContactAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<ContactModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve contacts for this company;
        /// </summary>
        /// <remarks>
        /// List all contact objects assigned to this company.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these contacts</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ContactModel>> ListContactsByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ContactModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all contacts;
        /// </summary>
        /// <remarks>
        /// Get multiple contact objects across all companies.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ContactModel>> QueryContactsAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/contacts");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ContactModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single contact;
        /// </summary>
        /// <remarks>
        /// Replace the existing contact object at this URL with an updated object.
        /// A 'contact' is a person associated with a company who is designated to handle certain responsibilities of
        /// a tax collecting and filing entity.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this contact belongs to.</param>
        /// <param name="id">The ID of the contact you wish to update</param>
        /// <param name="model">The contact you wish to update.</param>
        public async Task<ContactModel> UpdateContactAsync(Int32 companyId, Int32 id, ContactModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<ContactModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create customers for this company;
        /// </summary>
        /// <remarks>
        /// Create one or more customers for this company.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="model">The list of customer objects to be created</param>
        public async Task<List<CustomerModel>> CreateCustomersAsync(Int32 companyId, List<CustomerModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<CustomerModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a customer record;
        /// </summary>
        /// <remarks>
        /// Deletes the customer object referenced by this URL.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        public async Task<CustomerModel> DeleteCustomerAsync(Int32 companyId, String customerCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return await RestCallAsync<CustomerModel>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single customer;
        /// </summary>
        /// <remarks>
        /// Retrieve the customer identified by this URL.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this customer object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Certificates - Fetch a list of certificates linked to this customer.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="include">Specify optional additional objects to include in this fetch request</param>
        public async Task<CustomerModel> GetCustomerAsync(Int32 companyId, String customerCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            return await RestCallAsync<CustomerModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Link certificates to a customer;
        /// </summary>
        /// <remarks>
        /// Link one or more certificates to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public async Task<FetchResult<CertificateModel>> LinkCertificatesToCustomerAsync(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return await RestCallAsync<FetchResult<CertificateModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// List certificates linked to a customer;
        /// </summary>
        /// <remarks>
        /// List all certificates linked to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CertificateModel>> ListCertificatesForCustomerAsync(Int32 companyId, String customerCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CertificateModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List active certificates for a location;
        /// </summary>
        /// <remarks>
        /// List valid certificates linked to a customer in a particular country and region.
        /// 
        /// This API is intended to help identify whether a customer has already provided a certificate that
        /// applies to a particular country and region. This API is intended to help you remind a customer
        /// when they have or have not provided copies of their exemption certificates to you during the sales
        /// order process. 
        /// 
        /// If a customer does not have a certificate on file and they wish to provide one, you should send the customer
        /// a CertExpress invitation link so that the customer can upload proof of their exemption certificate. Please
        /// see the `CreateCertExpressInvitation` API to create an invitation link for this customer.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="country">Search for certificates matching this country. Uses the ISO 3166 two character country code.</param>
        /// <param name="region">Search for certificates matching this region. Uses the ISO 3166 two or three character state, region, or province code.</param>
        public async Task<ExemptionStatusModel> ListValidCertificatesForCustomerAsync(Int32 companyId, String customerCode, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return await RestCallAsync<ExemptionStatusModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all customers for this company;
        /// </summary>
        /// <remarks>
        /// List all customers recorded by this company matching the specified criteria.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.
        /// 
        /// You can use the `$include` parameter to fetch the following additional objects for expansion:
        /// 
        /// * Certificates - Fetch a list of certificates linked to this customer.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="include">OPTIONAL - You can specify the value `certificates` to fetch information about certificates linked to the customer.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CustomerModel>> QueryCustomersAsync(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CustomerModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Unlink certificates from a customer;
        /// </summary>
        /// <remarks>
        /// Remove one or more certificates to a customer.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public async Task<FetchResult<CertificateModel>> UnlinkCertificatesFromCustomerAsync(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return await RestCallAsync<FetchResult<CertificateModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single customer;
        /// </summary>
        /// <remarks>
        /// Replace the customer object at this URL with a new record.
        /// 
        /// A customer object defines information about a person or business that purchases products from your
        /// company. When you create a tax transaction in AvaTax, you can use the `customerCode` from this
        /// record in your `CreateTransaction` API call. AvaTax will search for this `customerCode` value and
        /// identify any certificates linked to this `customer` object. If any certificate applies to the transaction,
        /// AvaTax will record the appropriate elements of the transaction as exempt and link it to the `certificate`.;
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The new customer model that will replace the existing record at this URL</param>
        public async Task<CustomerModel> UpdateCustomerAsync(Int32 companyId, String customerCode, CustomerModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return await RestCallAsync<CustomerModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Test whether a form supports online login verification;
        /// </summary>
        /// <remarks>
        /// This API is intended to be useful to identify whether the user should be allowed
        /// to automatically verify their login and password.;
        /// </remarks>
        /// <param name="form">The name of the form you would like to verify. This can be the tax form code or the legacy return name</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SkyscraperStatusModel>> GetLoginVerifierByFormAsync(String form, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers/{form}");
            path.ApplyField("form", form);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SkyscraperStatusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of the AvaFile Forms available;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported AvaFile Forms
        /// This API is intended to be useful to identify all the different AvaFile Forms;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<AvaFileFormModel>> ListAvaFileFormsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/avafileforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<AvaFileFormModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List certificate attributes used by a company;
        /// </summary>
        /// <remarks>
        /// List the certificate attributes defined by a company.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may apply or remove attributes to a
        /// certificate at any time.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CertificateAttributeModel>> ListCertificateAttributesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateattributes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CertificateAttributeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List certificate attributes used by a company;
        /// </summary>
        /// <remarks>
        /// List the certificate exempt reasons defined by a company.
        /// 
        /// An exemption reason defines why a certificate allows a customer to be exempt
        /// for purposes of tax calculation.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ExemptionReasonModel>> ListCertificateExemptReasonsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexemptreasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ExemptionReasonModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List certificate exposure zones used by a company;
        /// </summary>
        /// <remarks>
        /// List the certificate exposure zones defined by a company.
        /// 
        /// An exposure zone is a location where a certificate can be valid. Exposure zones may indicate a taxing
        /// authority or other legal entity to which a certificate may apply.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ExposureZoneModel>> ListCertificateExposureZonesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexposurezones");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ExposureZoneModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of communications transactiontypes;
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction types which
        /// are accepted in communication tax calculation requests.;
        /// </remarks>
        /// <param name="id">The transaction type ID to examine</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CommunicationsTSPairModel>> ListCommunicationsServiceTypesAsync(Int32 id, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes/{id}/servicetypes");
            path.ApplyField("id", id);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CommunicationsTSPairModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of communications transactiontypes;
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction types which
        /// are accepted in communication tax calculation requests.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CommunicationsTransactionTypeModel>> ListCommunicationsTransactionTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CommunicationsTransactionTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of communications transaction/service type pairs;
        /// </summary>
        /// <remarks>
        /// Returns full list of communications transaction/service type pairs which
        /// are accepted in communication tax calculation requests.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CommunicationsTSPairModel>> ListCommunicationsTSPairsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/tspairs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CommunicationsTSPairModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all ISO 3166 countries;
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 country codes, and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a country for 
        /// a shipping address.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<IsoCountryModel>> ListCountriesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<IsoCountryModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List certificate exposure zones used by a company;
        /// </summary>
        /// <remarks>
        /// List available cover letters that can be used when sending invitation to use CertExpress to upload certificates.
        /// 
        /// The CoverLetter model represents a message sent along with an invitation to use CertExpress to
        /// upload certificates. An invitation allows customers to use CertExpress to upload their exemption 
        /// certificates directly; this cover letter explains why the invitation was sent.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<CoverLetterModel>> ListCoverLettersAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/coverletters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<CoverLetterModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported entity use codes;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported entity use codes.
        /// Entity/Use Codes are definitions of the entity who is purchasing something, or the purpose for which the transaction
        /// is occurring. This information is generally used to determine taxability of the product.
        /// In order to facilitate correct reporting of your taxes, you are encouraged to select the proper entity use codes for
        /// all transactions that are exempt.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<EntityUseCodeModel>> ListEntityUseCodesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/entityusecodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<EntityUseCodeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported filing frequencies.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported filing frequencies.
        /// This API is intended to be useful to identify all the different filing frequencies that can be used in notices.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<FilingFrequencyModel>> ListFilingFrequenciesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingfrequencies");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<FilingFrequencyModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List jurisdictions based on the filter provided;
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions.
        /// 
        /// This API allows you to examine all Avalara-supported jurisdictions. You can filter your search by supplying
        /// SQL-like query for fetching only the ones you concerned about. For example: effectiveDate &gt; '2016-01-01';
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<JurisdictionModel>> ListJurisdictionsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/jurisdictions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<JurisdictionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List jurisdictions near a specific address;
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions that apply to this address.
        /// 
        /// This API allows you to identify which jurisdictions are nearby a specific address according to the best available geocoding information.
        /// It is intended to allow you to create a "Jurisdiction Override", which allows an address to be configured as belonging to a nearby 
        /// jurisdiction in AvaTax.
        ///  
        /// The results of this API call can be passed to the `CreateJurisdictionOverride` API call.;
        /// </remarks>
        /// <param name="line1">The first address line portion of this address.</param>
        /// <param name="line2">The second address line portion of this address.</param>
        /// <param name="line3">The third address line portion of this address.</param>
        /// <param name="city">The city portion of this address.</param>
        /// <param name="region">The region, state, or province code portion of this address.</param>
        /// <param name="postalCode">The postal code or zip code portion of this address.</param>
        /// <param name="country">The two-character ISO-3166 code of the country portion of this address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<JurisdictionOverrideModel>> ListJurisdictionsByAddressAsync(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/jurisdictionsnearaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<JurisdictionOverrideModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the list of questions that are required for a tax location;
        /// </summary>
        /// <remarks>
        /// Returns the list of additional questions you must answer when declaring a location in certain taxing jurisdictions.
        /// Some tax jurisdictions require that you register or provide additional information to configure each physical place where
        /// your company does business.
        /// This information is not usually required in order to calculate tax correctly, but is almost always required to file your tax correctly.
        /// You can call this API call for any address and obtain information about what questions must be answered in order to properly
        /// file tax in that location.;
        /// </remarks>
        /// <param name="line1">The first line of this location's address.</param>
        /// <param name="line2">The second line of this location's address.</param>
        /// <param name="line3">The third line of this location's address.</param>
        /// <param name="city">The city part of this location's address.</param>
        /// <param name="region">The region, state, or province part of this location's address.</param>
        /// <param name="postalCode">The postal code of this location's address.</param>
        /// <param name="country">The country part of this location's address.</param>
        /// <param name="latitude">Optionally identify the location via latitude/longitude instead of via address.</param>
        /// <param name="longitude">Optionally identify the location via latitude/longitude instead of via address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<LocationQuestionModel>> ListLocationQuestionsByAddressAsync(String line1, String line2, String line3, String city, String region, String postalCode, String country, Decimal? latitude, Decimal? longitude, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/locationquestions");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("latitude", latitude);
            path.AddQuery("longitude", longitude);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<LocationQuestionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all forms where logins can be verified automatically;
        /// </summary>
        /// <remarks>
        /// List all forms where logins can be verified automatically.
        /// This API is intended to be useful to identify whether the user should be allowed
        /// to automatically verify their login and password.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SkyscraperStatusModel>> ListLoginVerifiersAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SkyscraperStatusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for all countries and regions.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of all Avalara-supported nexus for all countries and regions. 
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> ListNexusAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all nexus that apply to a specific address.;
        /// </summary>
        /// <remarks>
        /// Returns a list of all Avalara-supported taxing jurisdictions that apply to this address.
        /// This API allows you to identify which tax authorities apply to a physical location, salesperson address, or point of sale.
        /// In general, it is usually expected that a company will declare nexus in all the jurisdictions that apply to each physical address
        /// where the company does business.
        /// The results of this API call can be passed to the 'Create Nexus' API call to declare nexus for this address.;
        /// </remarks>
        /// <param name="line1">The first address line portion of this address.</param>
        /// <param name="line2">The first address line portion of this address.</param>
        /// <param name="line3">The first address line portion of this address.</param>
        /// <param name="city">The city portion of this address.</param>
        /// <param name="region">The region, state, or province code portion of this address.</param>
        /// <param name="postalCode">The postal code or zip code portion of this address.</param>
        /// <param name="country">The two-character ISO-3166 code of the country portion of this address.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> ListNexusByAddressAsync(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/byaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country.;
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country.
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country.;
        /// </remarks>
        /// <param name="country">The country in which you want to fetch the system nexus</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> ListNexusByCountryAsync(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country and region.;
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country and region.
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country and region.;
        /// </remarks>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> ListNexusByCountryAndRegionAsync(String country, String region, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}/{region}");
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List nexus related to a tax form;
        /// </summary>
        /// <remarks>
        /// Retrieves a list of nexus related to a tax form.
        /// 
        /// The concept of `Nexus` indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// 
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// This API is intended to provide useful information when examining a tax form. If you are about to begin filing
        /// a tax form, you may want to know whether you have declared nexus in all the jurisdictions related to that tax 
        /// form in order to better understand how the form will be filled out.;
        /// </remarks>
        /// <param name="formCode">The form code that we are looking up the nexus for</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<NexusByTaxFormModel> ListNexusByFormCodeAsync(String formCode, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/byform/{formCode}");
            path.ApplyField("formCode", formCode);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<NexusByTaxFormModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of nexus tax type groups;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported nexus tax type groups
        /// This API is intended to be useful to identify all the different tax sub-types.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusTaxTypeGroupModel>> ListNexusTaxTypeGroupsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexustaxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusTaxTypeGroupModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice customer funding options.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice customer funding options.
        /// This API is intended to be useful to identify all the different notice customer funding options that can be used in notices.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeCustomerFundingOptionModel>> ListNoticeCustomerFundingOptionsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomerfundingoptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeCustomerFundingOptionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice customer types.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice customer types.
        /// This API is intended to be useful to identify all the different notice customer types.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeCustomerTypeModel>> ListNoticeCustomerTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomertypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeCustomerTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice filing types.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice filing types.
        /// This API is intended to be useful to identify all the different notice filing types that can be used in notices.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeFilingTypeModel>> ListNoticeFilingtypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticefilingtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeFilingTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice priorities.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice priorities.
        /// This API is intended to be useful to identify all the different notice priorities that can be used in notices.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticePriorityModel>> ListNoticePrioritiesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticepriorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticePriorityModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice reasons.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice reasons.
        /// This API is intended to be useful to identify all the different tax notice reasons.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeReasonModel>> ListNoticeReasonsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticereasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeReasonModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice responsibility ids;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice responsibility ids
        /// This API is intended to be useful to identify all the different tax notice responsibilities.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeResponsibilityModel>> ListNoticeResponsibilitiesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticeresponsibilities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeResponsibilityModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice root causes;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice root causes
        /// This API is intended to be useful to identify all the different tax notice root causes.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeRootCauseModel>> ListNoticeRootCausesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticerootcauses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeRootCauseModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice statuses.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice statuses.
        /// This API is intended to be useful to identify all the different tax notice statuses.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeStatusModel>> ListNoticeStatusesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticestatuses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeStatusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax notice types.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax notice types.
        /// This API is intended to be useful to identify all the different notice types that can be used in notices.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeTypeModel>> ListNoticeTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported extra parameters for creating transactions.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported extra parameters for the 'Create Transaction' API call.
        /// This list of parameters is available for use when configuring your transaction.
        /// Some parameters are only available for use if you have subscribed to certain features of AvaTax.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ParameterModel>> ListParametersAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/parameters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ParameterModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported permissions;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported permission types.
        /// This API is intended to be useful to identify the capabilities of a particular user logon.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<String>> ListPermissionsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/permissions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<String>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of rate types for each country;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported rate type file types
        /// This API is intended to be useful to identify all the different rate types.;
        /// </remarks>
        /// <param name="country">The country to examine for rate types</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<RateTypeModel>> ListRateTypesByCountryAsync(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/ratetypes");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<RateTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all ISO 3166 regions;
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 region codes and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a region 
        /// within the country for a shipping addresses.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<IsoRegionModel>> ListRegionsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/regions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<IsoRegionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all ISO 3166 regions for a country;
        /// </summary>
        /// <remarks>
        /// Returns a list of all ISO 3166 region codes for a specific country code, and their US English friendly names.
        /// This API is intended to be useful when presenting a dropdown box in your website to allow customers to select a region 
        /// within the country for a shipping addresses.;
        /// </remarks>
        /// <param name="country">The country of which you want to fetch ISO 3166 regions</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<IsoRegionModel>> ListRegionsByCountryAsync(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/regions");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<IsoRegionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported resource file types;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported resource file types
        /// This API is intended to be useful to identify all the different resource file types.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ResourceFileTypeModel>> ListResourceFileTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/resourcefiletypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ResourceFileTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported permissions;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported permission types.
        /// This API is intended to be useful when designing a user interface for selecting the security role of a user account.
        /// Some security roles are restricted for Avalara internal use.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SecurityRoleModel>> ListSecurityRolesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/securityroles");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SecurityRoleModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported subscription types;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported subscription types.
        /// This API is intended to be useful for identifying which features you have added to your account.
        /// You may always contact Avalara's sales department for information on available products or services.
        /// You cannot change your subscriptions directly through the API.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SubscriptionTypeModel>> ListSubscriptionTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/subscriptiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SubscriptionTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax authorities.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax authorities.
        /// This API is intended to be useful to identify all the different authorities that receive tax.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxAuthorityModel>> ListTaxAuthoritiesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxAuthorityModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported forms for each tax authority.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported forms for each tax authority.
        /// This list represents tax forms that Avalara recognizes.
        /// Customers who subscribe to Avalara Managed Returns Service can request these forms to be filed automatically 
        /// based on the customer's AvaTax data.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxAuthorityFormModel>> ListTaxAuthorityFormsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorityforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxAuthorityFormModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax authority types.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax authority types.
        /// This API is intended to be useful to identify all the different authority types.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxAuthorityTypeModel>> ListTaxAuthorityTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthoritytypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxAuthorityTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax codes.;
        /// </summary>
        /// <remarks>
        /// Retrieves the list of Avalara-supported system tax codes.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxCodeModel>> ListTaxCodesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxCodeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported tax code types.;
        /// </summary>
        /// <remarks>
        /// Returns the full list of recognized tax code types.
        /// A 'Tax Code Type' represents a broad category of tax codes, and is less detailed than a single TaxCode.
        /// This API is intended to be useful for broadly searching for tax codes by tax code type.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<TaxCodeTypesModel> ListTaxCodeTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<TaxCodeTypesModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of tax sub types;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax sub-types
        /// This API is intended to be useful to identify all the different tax sub-types.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxSubTypeModel>> ListTaxSubTypesAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxsubtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxSubTypeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve the full list of tax type groups;
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported tax type groups
        /// This API is intended to be useful to identify all the different tax type groups.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxTypeGroupModel>> ListTaxTypeGroupsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxTypeGroupModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Approve existing Filing Request;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// The filing request must be in the "ChangeRequest" status to be approved.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        public async Task<FilingRequestModel> ApproveFilingRequestAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Post", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Cancel existing Filing Request;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        public async Task<FilingRequestModel> CancelFilingRequestAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/cancel");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Post", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new filing request to cancel a filing calendar;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID number of the filing calendar to cancel</param>
        /// <param name="model">The cancellation request for this filing calendar</param>
        public async Task<FilingRequestModel> CancelFilingRequestsAsync(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new filing request to create a filing calendar;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that will add the new filing calendar</param>
        /// <param name="model">Information about the proposed new filing calendar</param>
        public async Task<FilingRequestModel> CreateFilingRequestsAsync(Int32 companyId, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/request");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FilingRequestModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Returns a list of options for adding the specified form.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="formCode">The unique code of the form</param>
        public async Task<List<CycleAddOptionModel>> CycleSafeAddAsync(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/options");
            path.ApplyField("companyId", companyId);
            path.AddQuery("formCode", formCode);
            return await RestCallAsync<List<CycleAddOptionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Indicates when changes are allowed to be made to a filing calendar.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public async Task<CycleEditOptionModel> CycleSafeEditAsync(Int32 companyId, Int32 id, List<FilingCalendarEditModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<CycleEditOptionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Returns a list of options for expiring a filing calendar;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        public async Task<CycleExpireModel> CycleSafeExpirationAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<CycleExpireModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single filing calendar.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar.</param>
        /// <param name="id">The ID of the filing calendar you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteFilingCalendarAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single filing calendar;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar</param>
        /// <param name="id">The primary key of this filing calendar</param>
        public async Task<FilingCalendarModel> GetFilingCalendarAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingCalendarModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single filing request;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar</param>
        /// <param name="id">The primary key of this filing calendar</param>
        public async Task<FilingRequestModel> GetFilingRequestAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all filing calendars for this company;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        /// <param name="returnCountry">A comma separated list of countries</param>
        /// <param name="returnRegion">A comma separated list of regions</param>
        public async Task<FetchResult<FilingCalendarModel>> ListFilingCalendarsAsync(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return await RestCallAsync<FetchResult<FilingCalendarModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all filing requests for this company;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<FilingRequestModel>> ListFilingRequestsAsync(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<FilingRequestModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// New request for getting for validating customer's login credentials;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// This API verifies that a customer has submitted correct login credentials for a tax authority's online filing system.;
        /// </remarks>
        /// <param name="model">The model of the login information we are verifying</param>
        public async Task<LoginVerificationOutputModel> LoginVerificationRequestAsync(LoginVerificationInputModel model)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/verify");
            return await RestCallAsync<LoginVerificationOutputModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Gets the request status and Login Result;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// This API checks the status of a login verification request. It may only be called by authorized users from the account 
        /// that initially requested the login verification.;
        /// </remarks>
        /// <param name="jobId">The unique ID number of this login request</param>
        public async Task<LoginVerificationOutputModel> LoginVerificationStatusAsync(Int32 jobId)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/{jobId}");
            path.ApplyField("jobId", jobId);
            return await RestCallAsync<LoginVerificationOutputModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all filing calendars;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        /// <param name="returnCountry">If specified, fetches only filing calendars that apply to tax filings in this specific country. Uses ISO 3166 country codes.</param>
        /// <param name="returnRegion">If specified, fetches only filing calendars that apply to tax filings in this specific region. Uses ISO 3166 region codes.</param>
        public async Task<FetchResult<FilingCalendarModel>> QueryFilingCalendarsAsync(String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return await RestCallAsync<FetchResult<FilingCalendarModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all filing requests;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<FilingRequestModel>> QueryFilingRequestsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/filingrequests");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<FilingRequestModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new filing request to edit a filing calendar;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.
        /// 
        /// Certain users may not update filing calendars directly. Instead, they may submit an edit request
        /// to modify the value of a filing calendar using this API.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID number of the filing calendar to edit</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public async Task<FilingRequestModel> RequestFilingCalendarUpdateAsync(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Edit existing Filing Calendar's Notes;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// This API only allows updating of internal notes and company filing instructions.
        /// All other updates must go through a filing request at this time.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        /// <param name="model">The filing calendar model you are wishing to update with.</param>
        public async Task<FilingCalendarModel> UpdateFilingCalendarAsync(Int32 companyId, Int32 id, FilingCalendarModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingCalendarModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Edit existing Filing Request;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing request" represents a request to change an existing filing calendar. Filing requests
        /// are reviewed and validated by Avalara Compliance before being implemented.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing request object</param>
        /// <param name="model">A list of filing calendar edits to be made</param>
        public async Task<FilingRequestModel> UpdateFilingRequestAsync(Int32 companyId, Int32 id, FilingRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingRequestModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle.
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public async Task<List<FilingModel>> ApproveFilingsAsync(Int32 companyId, Int16 year, Byte month, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<List<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period and country.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle.
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public async Task<List<FilingModel>> ApproveFilingsCountryAsync(Int32 companyId, Int16 year, Byte month, String country, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return await RestCallAsync<List<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Approve all filings for the specified company in the given filing period, country and region.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Approving a return means the customer is ready to let Avalara file that return.
        /// Customer either approves themselves from admin console, 
        /// else system auto-approves the night before the filing cycle
        /// Sometimes Compliance has to manually unapprove and reapprove to modify liability or filing for the customer.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to approve.</param>
        /// <param name="month">The month of the filing period to approve.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="model">The approve request you wish to execute.</param>
        public async Task<List<FilingModel>> ApproveFilingsCountryRegionAsync(Int32 companyId, Int16 year, Byte month, String country, String region, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return await RestCallAsync<List<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Add an adjustment to a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API creates a new adjustment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="year">The year of the filing's filing period being adjusted.</param>
        /// <param name="month">The month of the filing's filing period being adjusted.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being adjusted.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form being adjusted.</param>
        /// <param name="model">A list of Adjustments to be created for the specified filing.</param>
        public async Task<List<FilingAdjustmentModel>> CreateReturnAdjustmentAsync(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAdjustmentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/adjust");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return await RestCallAsync<List<FilingAdjustmentModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Add an augmentation for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API creates a new augmentation for an existing tax filing.
        /// This API can only be used when the filing has not been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="year">The month of the filing's filing period being changed.</param>
        /// <param name="month">The month of the filing's filing period being changed.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being changed.</param>
        /// <param name="region">The two or three character region code for the region of the filing being changed.</param>
        /// <param name="formCode">The unique code of the form being changed.</param>
        /// <param name="model">A list of augmentations to be created for the specified filing.</param>
        public async Task<List<FilingAugmentationModel>> CreateReturnAugmentationAsync(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAugmentationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/augment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return await RestCallAsync<List<FilingAugmentationModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Add an payment to a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API creates a new payment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="year">The year of the filing's filing period being adjusted.</param>
        /// <param name="month">The month of the filing's filing period being adjusted.</param>
        /// <param name="country">The two-character ISO-3166 code for the country of the filing being adjusted.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form being adjusted.</param>
        /// <param name="model">A list of Payments to be created for the specified filing.</param>
        public async Task<List<FilingPaymentModel>> CreateReturnPaymentAsync(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingPaymentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/payment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return await RestCallAsync<List<FilingPaymentModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete an adjustment for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API deletes an adjustment for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the adjustment being deleted.</param>
        public async Task<List<ErrorDetail>> DeleteReturnAdjustmentAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete an augmentation for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API deletes an augmentation for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="id">The ID of the augmentation being added.</param>
        public async Task<List<ErrorDetail>> DeleteReturnAugmentationAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete an payment for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API deletes an payment for an existing tax filing.
        /// This API can only be used when the filing has been unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the payment being deleted.</param>
        public async Task<List<ErrorDetail>> DeleteReturnPaymentAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve worksheet checkup report for company and filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="filingsId">The unique id of the worksheet.</param>
        /// <param name="companyId">The unique ID of the company that owns the worksheet.</param>
        public async Task<FilingsCheckupModel> FilingsCheckupReportAsync(Int32 filingsId, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingsId}/checkup");
            path.ApplyField("filingsId", filingsId);
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FilingsCheckupModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve worksheet checkup report for company and filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the worksheets object.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The month of the filing period.</param>
        public async Task<FilingsCheckupModel> FilingsCheckupReportsAsync(Int32 companyId, Int32 year, Int32 month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/checkup");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<FilingsCheckupModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single attachment for a filing;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="filingId">The unique id of the worksheet return.</param>
        /// <param name="fileId">The unique id of the document you are downloading</param>
        public async Task<FileResult> GetFilingAttachmentAsync(Int32 companyId, Int64 filingId, Int64? fileId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingId}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("filingId", filingId);
            path.AddQuery("fileId", fileId);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public async Task<FileResult> GetFilingAttachmentsAsync(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single trace file for a company filing period;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public async Task<FileResult> GetFilingAttachmentsTraceFileAsync(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments/tracefile");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a filing for the specified company and id.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="id">The id of the filing return your retrieving</param>
        public async Task<FetchResult<FilingReturnModel>> GetFilingReturnAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FetchResult<FilingReturnModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        public async Task<FetchResult<FilingModel>> GetFilingsAsync(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<FetchResult<FilingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the given filing period and country.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        public async Task<FetchResult<FilingModel>> GetFilingsByCountryAsync(Int32 companyId, Int16 year, Byte month, String country)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return await RestCallAsync<FetchResult<FilingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the filing period, country and region.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        public async Task<FetchResult<FilingModel>> GetFilingsByCountryRegionAsync(Int32 companyId, Int16 year, Byte month, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return await RestCallAsync<FetchResult<FilingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the given filing period, country, region and form.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period.</param>
        /// <param name="month">The two digit month of the filing period.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="formCode">The unique code of the form.</param>
        public async Task<FetchResult<FilingModel>> GetFilingsByReturnNameAsync(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return await RestCallAsync<FetchResult<FilingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a list of filings for the specified company in the year and month of a given filing period. 
        /// This gets the basic information from the filings and doesn't include anything extra.;
        /// </summary>
        /// <remarks>
        /// ;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these batches</param>
        /// <param name="endPeriodMonth">The month of the period you are trying to retrieve</param>
        /// <param name="endPeriodYear">The year of the period you are trying to retrieve</param>
        /// <param name="frequency">The frequency of the return you are trying to retrieve</param>
        /// <param name="status">The status of the return(s) you are trying to retrieve</param>
        /// <param name="country">The country of the return(s) you are trying to retrieve</param>
        /// <param name="region">The region of the return(s) you are trying to retrieve</param>
        public async Task<FetchResult<FilingReturnModelBasic>> GetFilingsReturnsAsync(Int32 companyId, Int32? endPeriodMonth, Int32? endPeriodYear, FilingFrequencyId? frequency, FilingStatusId? status, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns");
            path.ApplyField("companyId", companyId);
            path.AddQuery("endPeriodMonth", endPeriodMonth);
            path.AddQuery("endPeriodYear", endPeriodYear);
            path.AddQuery("frequency", frequency);
            path.AddQuery("status", status);
            path.AddQuery("country", country);
            path.AddQuery("region", region);
            return await RestCallAsync<FetchResult<FilingReturnModelBasic>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed (worksheet) for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public async Task<FetchResult<FilingModel>> RebuildFilingsAsync(Int32 companyId, Int16 year, Byte month, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return await RestCallAsync<FetchResult<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period and country.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed (worksheet) for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing.
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public async Task<FetchResult<FilingModel>> RebuildFilingsByCountryAsync(Int32 companyId, Int16 year, Byte month, String country, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return await RestCallAsync<FetchResult<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period, country and region.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Rebuilding a return means re-creating or updating the amounts to be filed for a filing.
        /// Rebuilding has to be done whenever a customer adds transactions to a filing. 
        /// A "filing period" is the year and month of the date of the latest customer transaction allowed to be reported on a filing, 
        /// based on filing frequency of filing.
        /// This API requires filing to be unapproved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="year">The year of the filing period to be rebuilt.</param>
        /// <param name="month">The month of the filing period to be rebuilt.</param>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="model">The rebuild request you wish to execute.</param>
        public async Task<FetchResult<FilingModel>> RebuildFilingsByCountryRegionAsync(Int32 companyId, Int16 year, Byte month, String country, String region, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return await RestCallAsync<FetchResult<FilingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Edit an adjustment for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Adjustment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API modifies an adjustment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the adjustment being edited.</param>
        /// <param name="model">The updated Adjustment.</param>
        public async Task<FilingAdjustmentModel> UpdateReturnAdjustmentAsync(Int32 companyId, Int64 id, FilingAdjustmentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingAdjustmentModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Edit an augmentation for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Augmentation" is a manually added increase or decrease in tax liability, by either customer or Avalara 
        /// usually due to customer wanting to report tax Avatax does not support, e.g. bad debts, rental tax.
        /// This API modifies an augmentation for an existing tax filing.
        /// This API can only be used when the filing has not been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being changed.</param>
        /// <param name="id">The ID of the augmentation being edited.</param>
        /// <param name="model">The updated Augmentation.</param>
        public async Task<FilingModel> UpdateReturnAugmentationAsync(Int32 companyId, Int64 id, FilingAugmentationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Edit an payment for a given filing.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// An "Payment" is usually an increase or decrease to customer funding to Avalara,
        /// such as early filer discount amounts that are refunded to the customer, or efile fees from websites. 
        /// Sometimes may be a manual change in tax liability similar to an augmentation.
        /// This API modifies an payment for an existing tax filing.
        /// This API can only be used when the filing has not yet been approved.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filing being adjusted.</param>
        /// <param name="id">The ID of the payment being edited.</param>
        /// <param name="model">The updated Payment.</param>
        public async Task<FilingPaymentModel> UpdateReturnPaymentAsync(Int32 companyId, Int64 id, FilingPaymentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FilingPaymentModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// FREE API - Request a free trial of AvaTax;
        /// </summary>
        /// <remarks>
        /// Call this API to obtain a free AvaTax sandbox account.
        /// 
        /// This API is free to use. No authentication credentials are required to call this API.
        /// The account will grant a full trial version of AvaTax (e.g. AvaTaxPro) for a limited period of time.
        /// After this introductory period, you may continue to use the free TaxRates API.
        /// 
        /// Limitations on free trial accounts:
        ///  
        /// * Only one free trial per company.
        /// * The free trial account does not expire.
        /// * Includes a limited time free trial of AvaTaxPro; after that date, the free TaxRates API will continue to work.
        /// * Each free trial account must have its own valid email address.;
        /// </remarks>
        /// <param name="model">Required information to provision a free trial account.</param>
        public async Task<NewAccountModel> RequestFreeTrialAsync(FreeTrialRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/freetrials/request");
            return await RestCallAsync<NewAccountModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// FREE API - Sales tax rates for a specified address;
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.;
        /// </remarks>
        /// <param name="line1">The street address of the location.</param>
        /// <param name="line2">The street address of the location.</param>
        /// <param name="line3">The street address of the location.</param>
        /// <param name="city">The city name of the location.</param>
        /// <param name="region">The state or region of the location</param>
        /// <param name="postalCode">The postal code of the location.</param>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        public async Task<TaxRateModel> TaxRatesByAddressAsync(String line1, String line2, String line3, String city, String region, String postalCode, String country)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/byaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            return await RestCallAsync<TaxRateModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// FREE API - Sales tax rates for a specified country and postal code;
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.;
        /// </remarks>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        /// <param name="postalCode">The postal code of the location.</param>
        public async Task<TaxRateModel> TaxRatesByPostalCodeAsync(String country, String postalCode)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/bypostalcode");
            path.AddQuery("country", country);
            path.AddQuery("postalCode", postalCode);
            return await RestCallAsync<TaxRateModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Request the javascript for a funding setup widget;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API returns back the actual javascript code to insert into your application to render the 
        /// JavaScript funding setup widget inline.
        /// Use the 'methodReturn.javaScript' return value to insert this widget into your HTML page.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.;
        /// </remarks>
        /// <param name="id">The unique ID number of this funding request</param>
        public async Task<FundingStatusModel> ActivateFundingRequestAsync(Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}/widget");
            path.ApplyField("id", id);
            return await RestCallAsync<FundingStatusModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve status about a funding setup request;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Companies that use the Avalara Managed Returns or the SST Certified Service Provider services are 
        /// required to setup their funding configuration before Avalara can begin filing tax returns on their 
        /// behalf.
        /// Funding configuration for each company is set up by submitting a funding setup request, which can
        /// be sent either via email or via an embedded HTML widget.
        /// When the funding configuration is submitted to Avalara, it will be reviewed by treasury team members
        /// before approval.
        /// This API checks the status on an existing funding request.
        /// This API requires a subscription to Avalara Managed Returns or SST Certified Service Provider.;
        /// </remarks>
        /// <param name="id">The unique ID number of this funding request</param>
        public async Task<FundingStatusModel> FundingRequestStatusAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}");
            path.ApplyField("id", id);
            return await RestCallAsync<FundingStatusModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new item;
        /// </summary>
        /// <remarks>
        /// Creates one or more new item objects attached to this company.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="model">The item you wish to create.</param>
        public async Task<List<ItemModel>> CreateItemsAsync(Int32 companyId, List<ItemModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<ItemModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single item;
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="id">The ID of the item you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteItemAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single item;
        /// </summary>
        /// <remarks>
        /// Get the item object identified by this URL.
        /// An 'Item' represents a product or service that your company offers for sale.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item object</param>
        /// <param name="id">The primary key of this item</param>
        public async Task<ItemModel> GetItemAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<ItemModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve items for this company;
        /// </summary>
        /// <remarks>
        /// List all items defined for the current company.
        /// 
        /// An 'Item' represents a product or service that your company offers for sale.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that defined these items</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ItemModel>> ListItemsByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ItemModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all items;
        /// </summary>
        /// <remarks>
        /// Get multiple item objects across all companies.
        /// An 'Item' represents a product or service that your company offers for sale.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<ItemModel>> QueryItemsAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/items");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<ItemModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single item;
        /// </summary>
        /// <remarks>
        /// Replace the existing item object at this URL with an updated object.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this item belongs to.</param>
        /// <param name="id">The ID of the item you wish to update</param>
        /// <param name="model">The item object you wish to update.</param>
        public async Task<ItemModel> UpdateItemAsync(Int32 companyId, Int64 id, ItemModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<ItemModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create one or more overrides;
        /// </summary>
        /// <remarks>
        /// Creates one or more jurisdiction override objects for this account.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="model">The jurisdiction override objects to create</param>
        public async Task<List<JurisdictionOverrideModel>> CreateJurisdictionOverridesAsync(Int32 accountId, List<JurisdictionOverrideModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<List<JurisdictionOverrideModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single override;
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="id">The ID of the override you wish to delete</param>
        public async Task<List<ErrorDetail>> DeleteJurisdictionOverrideAsync(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single override;
        /// </summary>
        /// <remarks>
        /// Get the item object identified by this URL.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="id">The primary key of this override</param>
        public async Task<JurisdictionOverrideModel> GetJurisdictionOverrideAsync(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<JurisdictionOverrideModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve overrides for this account;
        /// </summary>
        /// <remarks>
        /// List all jurisdiction override objects defined for this account.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<JurisdictionOverrideModel>> ListJurisdictionOverridesByAccountAsync(Int32 accountId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<JurisdictionOverrideModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all overrides;
        /// </summary>
        /// <remarks>
        /// Get multiple jurisdiction override objects across all companies.
        /// 
        /// A Jurisdiction Override is a configuration setting that allows you to select the taxing
        /// jurisdiction for a specific address. If you encounter an address that is on the boundary
        /// between two different jurisdictions, you can choose to set up a jurisdiction override
        /// to switch this address to use different taxing jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<JurisdictionOverrideModel>> QueryJurisdictionOverridesAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/jurisdictionoverrides");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<JurisdictionOverrideModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single jurisdictionoverride;
        /// </summary>
        /// <remarks>
        /// Replace the existing jurisdictionoverride object at this URL with an updated object.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that this jurisdictionoverride belongs to.</param>
        /// <param name="id">The ID of the jurisdictionoverride you wish to update</param>
        /// <param name="model">The jurisdictionoverride object you wish to update.</param>
        public async Task<JurisdictionOverrideModel> UpdateJurisdictionOverrideAsync(Int32 accountId, Int32 id, JurisdictionOverrideModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<JurisdictionOverrideModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new location;
        /// </summary>
        /// <remarks>
        /// Create one or more new location objects attached to this company.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="model">The location you wish to create.</param>
        public async Task<List<LocationModel>> CreateLocationsAsync(Int32 companyId, List<LocationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<LocationModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single location;
        /// </summary>
        /// <remarks>
        /// Mark the location object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="id">The ID of the location you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteLocationAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single location;
        /// </summary>
        /// <remarks>
        /// Get the location object identified by this URL.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location</param>
        /// <param name="id">The primary key of this location</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        public async Task<LocationModel> GetLocationAsync(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<LocationModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve locations for this company;
        /// </summary>
        /// <remarks>
        /// List all location objects defined for this company.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these locations</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<LocationModel>> ListLocationsByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<LocationModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all locations;
        /// </summary>
        /// <remarks>
        /// Get multiple location objects across all companies.
        /// An 'Location' represents a physical address where a company does business.
        /// Many taxing authorities require that you define a list of all locations where your company does business.
        /// These locations may require additional custom configuration or tax registration with these authorities.
        /// For more information on metadata requirements, see the '/api/v2/definitions/locationquestions' API.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * LocationSettings;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve. You may specify `LocationSettings` to retrieve location settings.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<LocationModel>> QueryLocationsAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/locations");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<LocationModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single location;
        /// </summary>
        /// <remarks>
        /// Replace the existing location object at this URL with an updated object.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this location belongs to.</param>
        /// <param name="id">The ID of the location you wish to update</param>
        /// <param name="model">The location you wish to update.</param>
        public async Task<LocationModel> UpdateLocationAsync(Int32 companyId, Int32 id, LocationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<LocationModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Validate the location against local requirements;
        /// </summary>
        /// <remarks>
        /// Returns validation information for this location.
        /// This API call is intended to compare this location against the currently known taxing authority rules and regulations,
        /// and provide information about what additional work is required to completely setup this location.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location</param>
        /// <param name="id">The primary key of this location</param>
        public async Task<LocationValidationModel> ValidateLocationAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/validate");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<LocationValidationModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new nexus;
        /// </summary>
        /// <remarks>
        /// Creates one or more new nexus objects attached to this company.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// Note that not all fields within a nexus can be updated; Avalara publishes a list of all defined nexus at the
        /// '/api/v2/definitions/nexus' endpoint.
        /// You may only define nexus matching the official list of declared nexus.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="model">The nexus you wish to create.</param>
        public async Task<List<NexusModel>> CreateNexusAsync(Int32 companyId, List<NexusModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<NexusModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single nexus;
        /// </summary>
        /// <remarks>
        /// Marks the existing nexus object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="id">The ID of the nexus you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteNexusAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single nexus;
        /// </summary>
        /// <remarks>
        /// Get the nexus object identified by this URL.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus object</param>
        /// <param name="id">The primary key of this nexus</param>
        public async Task<NexusModel> GetNexusAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<NexusModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List company nexus related to a tax form;
        /// </summary>
        /// <remarks>
        /// Retrieves a list of nexus related to a tax form.
        /// 
        /// The concept of `Nexus` indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// 
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// This API is intended to provide useful information when examining a tax form. If you are about to begin filing
        /// a tax form, you may want to know whether you have declared nexus in all the jurisdictions related to that tax 
        /// form in order to better understand how the form will be filled out.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus object</param>
        /// <param name="formCode">The form code that we are looking up the nexus for</param>
        public async Task<NexusByTaxFormModel> GetNexusByFormCodeAsync(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/byform/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("formCode", formCode);
            return await RestCallAsync<NexusByTaxFormModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve nexus for this company;
        /// </summary>
        /// <remarks>
        /// List all nexus objects defined for this company.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these nexus objects</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> ListNexusByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all nexus;
        /// </summary>
        /// <remarks>
        /// Get multiple nexus objects across all companies.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NexusModel>> QueryNexusAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NexusModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single nexus;
        /// </summary>
        /// <remarks>
        /// Replace the existing nexus object at this URL with an updated object.
        /// The concept of 'Nexus' indicates a place where your company has sufficient physical presence and is obligated
        /// to collect and remit transaction-based taxes.
        /// When defining companies in AvaTax, you must declare nexus for your company in order to correctly calculate tax
        /// in all jurisdictions affected by your transactions.
        /// Note that not all fields within a nexus can be updated; Avalara publishes a list of all defined nexus at the
        /// '/api/v2/definitions/nexus' endpoint.
        /// You may only define nexus matching the official list of declared nexus.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this nexus belongs to.</param>
        /// <param name="id">The ID of the nexus you wish to update</param>
        /// <param name="model">The nexus object you wish to update.</param>
        public async Task<NexusModel> UpdateNexusAsync(Int32 companyId, Int32 id, NexusModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<NexusModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new notice comment.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the comment for.</param>
        /// <param name="model">The notice comments you wish to create.</param>
        public async Task<List<NoticeCommentModel>> CreateNoticeCommentAsync(Int32 companyId, Int32 id, List<NoticeCommentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<NoticeCommentModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new notice finance details.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice finance details' is the categorical breakdown of the total charge levied by the tax authority on our customer,
        /// as broken down in our "notice log" found in Workflow. Main examples of the categories are 'Tax Due', 'Interest', 'Penalty', 'Total Abated'.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the notice added to the finance details.</param>
        /// <param name="model">The notice finance details you wish to create.</param>
        public async Task<List<NoticeFinanceModel>> CreateNoticeFinanceDetailsAsync(Int32 companyId, Int32 id, List<NoticeFinanceModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<NoticeFinanceModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new notice responsibility.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the responsibility for.</param>
        /// <param name="model">The notice responsibilities you wish to create.</param>
        public async Task<List<NoticeResponsibilityDetailModel>> CreateNoticeResponsibilitiesAsync(Int32 companyId, Int32 id, List<NoticeResponsibilityDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<NoticeResponsibilityDetailModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new notice root cause.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice root causes' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the tax notice we are adding the responsibility for.</param>
        /// <param name="model">The notice root causes you wish to create.</param>
        public async Task<List<NoticeRootCauseDetailModel>> CreateNoticeRootCausesAsync(Int32 companyId, Int32 id, List<NoticeRootCauseDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<NoticeRootCauseDetailModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Create one or more new notice objects.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="model">The notice object you wish to create.</param>
        public async Task<List<NoticeModel>> CreateNoticesAsync(Int32 companyId, List<NoticeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<NoticeModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="id">The ID of the notice you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteNoticeAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single responsibility;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="noticeId">The ID of the notice you wish to delete.</param>
        /// <param name="id">The ID of the responsibility you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteResponsibilitiesAsync(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/responsibilities/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single root cause.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Mark the existing notice object at this URL as deleted.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this notice.</param>
        /// <param name="noticeId">The ID of the notice you wish to delete.</param>
        /// <param name="id">The ID of the root cause you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteRootCausesAsync(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/rootcauses/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single attachment;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the file attachment identified by this URL.;
        /// </remarks>
        /// <param name="companyId">The ID of the company for this attachment.</param>
        /// <param name="id">The ResourceFileId of the attachment to download.</param>
        public async Task<FileResult> DownloadNoticeAttachmentAsync(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the tax notice object identified by this URL.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="companyId">The ID of the company for this notice.</param>
        /// <param name="id">The ID of this notice.</param>
        public async Task<NoticeModel> GetNoticeAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<NoticeModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve notice comments for a specific notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice comments' are updates by the notice team on the work to be done and that has been done so far on a notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public async Task<FetchResult<NoticeCommentModel>> GetNoticeCommentsAsync(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FetchResult<NoticeCommentModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve notice finance details for a specific notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice finance details' is the categorical breakdown of the total charge levied by the tax authority on our customer,
        /// as broken down in our "notice log" found in Workflow. Main examples of the categories are 'Tax Due', 'Interest', 'Penalty', 'Total Abated'.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="id">The ID of the company that owns these notices.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public async Task<FetchResult<NoticeFinanceModel>> GetNoticeFinanceDetailsAsync(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FetchResult<NoticeFinanceModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve notice responsibilities for a specific notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice responsibilities' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public async Task<FetchResult<NoticeResponsibilityDetailModel>> GetNoticeResponsibilitiesAsync(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FetchResult<NoticeResponsibilityDetailModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve notice root causes for a specific notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 'Notice root causes' are are those who are responsible for the notice.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.;
        /// </remarks>
        /// <param name="id">The ID of the notice.</param>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        public async Task<FetchResult<NoticeRootCauseDetailModel>> GetNoticeRootCausesAsync(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FetchResult<NoticeRootCauseDetailModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve notices for a company.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// List all tax notice objects assigned to this company.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these notices.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeModel>> ListNoticesByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all notices.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get multiple notice objects across all companies.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<NoticeModel>> QueryNoticesAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/notices");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<NoticeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single notice.;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Replace the existing notice object at this URL with an updated object.
        /// A 'notice' represents a letter sent to a business by a tax authority regarding tax filing issues. Avalara
        /// Returns customers often receive support and assistance from the Compliance Notices team in handling notices received by taxing authorities.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this notice belongs to.</param>
        /// <param name="id">The ID of the notice you wish to update.</param>
        /// <param name="model">The notice object you wish to update.</param>
        public async Task<NoticeModel> UpdateNoticeAsync(Int32 companyId, Int32 id, NoticeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<NoticeModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single attachment;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Get the file attachment identified by this URL.;
        /// </remarks>
        /// <param name="companyId">The ID of the company for this attachment.</param>
        /// <param name="model">The ResourceFileId of the attachment to download.</param>
        public async Task<FileResult> UploadAttachmentAsync(Int32 companyId, ResourceFileUploadRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/attachment");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FileResult>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Request a new Avalara account;
        /// </summary>
        /// <remarks>
        /// This API is for use by partner onboarding services customers only.
        /// 
        /// Avalara invites select partners to refer new customers to the AvaTax service using the onboarding features
        /// of AvaTax. These partners can create accounts for new customers using this API.
        /// 
        /// Calling this API creates an account with the specified product subscriptions, but does not configure billing.
        /// The customer will receive information from Avalara about how to configure billing for their account.
        /// You should call this API when a customer has requested to begin using Avalara services.
        /// 
        /// If the newly created account owner wishes, they can confirm that they have read and agree to the Avalara
        /// terms and conditions. If they do so, they can receive a license key as part of this API and their
        /// API will be created in `Active` status. If the customer has not yet read and accepted these terms and
        /// conditions, the account will be created in `New` status and they can receive a license key by logging
        /// onto AvaTax and reviewing terms and conditions online.;
        /// </remarks>
        /// <param name="model">Information about the account you wish to create and the selected product offerings.</param>
        public async Task<NewAccountModel> RequestNewAccountAsync(NewAccountRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/request");
            return await RestCallAsync<NewAccountModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Change Password;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Allows a user to change their password via the API.
        /// This API only allows the currently authenticated user to change their password; it cannot be used to apply to a
        /// different user than the one authenticating the current API call.;
        /// </remarks>
        /// <param name="model">An object containing your current password and the new password.</param>
        public async Task<String> ChangePasswordAsync(PasswordChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords");
            return await RestCallStringAsync("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new account;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create a single new account object. 
        /// When creating an account object you may attach subscriptions and users as part of the 'Create' call.;
        /// </remarks>
        /// <param name="model">The account you wish to create.</param>
        public async Task<AccountModel> CreateAccountAsync(AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            return await RestCallAsync<AccountModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new subscription;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create one or more new subscription objects attached to this account.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription.</param>
        /// <param name="model">The subscription you wish to create.</param>
        public async Task<List<SubscriptionModel>> CreateSubscriptionsAsync(Int32 accountId, List<SubscriptionModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<List<SubscriptionModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create new users;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Create one or more new user objects attached to this account.
        /// A user represents one person with access privileges to make API calls and work with a specific account.;
        /// </remarks>
        /// <param name="accountId">The unique ID number of the account where these users will be created.</param>
        /// <param name="model">The user or array of users you wish to create.</param>
        public async Task<List<UserModel>> CreateUsersAsync(Int32 accountId, List<UserModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<List<UserModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single account;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Delete an account.
        /// Deleting an account will delete all companies and all account level users attached to this account.;
        /// </remarks>
        /// <param name="id">The ID of the account you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteAccountAsync(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single subscription;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Mark the existing account identified by this URL as deleted.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription.</param>
        /// <param name="id">The ID of the subscription you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteSubscriptionAsync(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single user;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Mark the user object identified by this URL as deleted.;
        /// </remarks>
        /// <param name="id">The ID of the user you wish to delete.</param>
        /// <param name="accountId">The accountID of the user you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteUserAsync(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all accounts;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Get multiple account objects.
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Subscriptions
        /// * Users
        ///  
        /// For more information about filtering in REST, please see the documentation at http://developer.avalara.com/avatax/filtering-in-rest/ .;
        /// </remarks>
        /// <param name="include">A comma separated list of objects to fetch underneath this account. Any object with a URL path underneath this account can be fetched by specifying its name.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<AccountModel>> QueryAccountsAsync(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<AccountModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Reset a user's password programmatically;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Allows a system admin to reset the password for a specific user via the API.
        /// This API is only available for Avalara Registrar Admins, and can be used to reset the password of any
        /// user based on internal Avalara business processes.;
        /// </remarks>
        /// <param name="userId">The unique ID of the user whose password will be changed</param>
        /// <param name="model">The new password for this user</param>
        public async Task<String> ResetPasswordAsync(Int32 userId, SetPasswordModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords/{userId}/reset");
            path.ApplyField("userId", userId);
            return await RestCallStringAsync("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single account;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Replace an existing account object with an updated account object.;
        /// </remarks>
        /// <param name="id">The ID of the account you wish to update.</param>
        /// <param name="model">The account object you wish to update.</param>
        public async Task<AccountModel> UpdateAccountAsync(Int32 id, AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return await RestCallAsync<AccountModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single subscription;
        /// </summary>
        /// <remarks>
        /// # For Registrar Use Only
        /// This API is for use by Avalara Registrar administrative users only.
        /// 
        /// Replace the existing subscription object at this URL with an updated object.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that this subscription belongs to.</param>
        /// <param name="id">The ID of the subscription you wish to update</param>
        /// <param name="model">The subscription you wish to update.</param>
        public async Task<SubscriptionModel> UpdateSubscriptionAsync(Int32 accountId, Int32 id, SubscriptionModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<SubscriptionModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Export a report accurate to the line level;
        /// </summary>
        /// <remarks>
        /// ;
        /// </remarks>
        /// <param name="companyId"></param>
        /// <param name="model"></param>
        public async Task<FileResult> ExportDocumentLineAsync(Int32 companyId, ExportDocumentLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/reports/exportdocumentline");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<FileResult>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new setting;
        /// </summary>
        /// <remarks>
        /// Create one or more new setting objects attached to this company.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting.</param>
        /// <param name="model">The setting you wish to create.</param>
        public async Task<List<SettingModel>> CreateSettingsAsync(Int32 companyId, List<SettingModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<SettingModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single setting;
        /// </summary>
        /// <remarks>
        /// Mark the setting object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting.</param>
        /// <param name="id">The ID of the setting you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteSettingAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single setting;
        /// </summary>
        /// <remarks>
        /// Get a single setting object by its unique ID.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting</param>
        /// <param name="id">The primary key of this setting</param>
        public async Task<SettingModel> GetSettingAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<SettingModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all settings for this company;
        /// </summary>
        /// <remarks>
        /// List all setting objects attached to this company.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these settings</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SettingModel>> ListSettingsByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SettingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all settings;
        /// </summary>
        /// <remarks>
        /// Get multiple setting objects across all companies.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SettingModel>> QuerySettingsAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/settings");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SettingModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single setting;
        /// </summary>
        /// <remarks>
        /// Replace the existing setting object at this URL with an updated object.
        /// A 'setting' is a piece of user-defined data that can be attached to a company, and it provides you the ability to store information
        /// not defined or managed by Avalara.
        /// You may create, update, and delete your own settings objects as required, and there is no mandatory data format for the 'name' and 
        /// 'value' data fields.
        /// To ensure correct operation of other programs or connectors, please create a new GUID for your application and use that value for
        /// the 'set' data field.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this setting belongs to.</param>
        /// <param name="id">The ID of the setting you wish to update</param>
        /// <param name="model">The setting you wish to update.</param>
        public async Task<SettingModel> UpdateSettingAsync(Int32 companyId, Int32 id, SettingModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<SettingModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single subscription;
        /// </summary>
        /// <remarks>
        /// Get the subscription object identified by this URL.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this subscription</param>
        /// <param name="id">The primary key of this subscription</param>
        public async Task<SubscriptionModel> GetSubscriptionAsync(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return await RestCallAsync<SubscriptionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve subscriptions for this account;
        /// </summary>
        /// <remarks>
        /// List all subscription objects attached to this account.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns these subscriptions</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SubscriptionModel>> ListSubscriptionsByAccountAsync(Int32 accountId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SubscriptionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all subscriptions;
        /// </summary>
        /// <remarks>
        /// Get multiple subscription objects across all accounts.
        /// A 'subscription' indicates a licensed subscription to a named Avalara service.
        /// To request or remove subscriptions, please contact Avalara sales or your customer account manager.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<SubscriptionModel>> QuerySubscriptionsAsync(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/subscriptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<SubscriptionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new tax code;
        /// </summary>
        /// <remarks>
        /// Create one or more new taxcode objects attached to this company.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code.</param>
        /// <param name="model">The tax code you wish to create.</param>
        public async Task<List<TaxCodeModel>> CreateTaxCodesAsync(Int32 companyId, List<TaxCodeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<TaxCodeModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single tax code;
        /// </summary>
        /// <remarks>
        /// Marks the existing TaxCode object at this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code.</param>
        /// <param name="id">The ID of the tax code you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteTaxCodeAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single tax code;
        /// </summary>
        /// <remarks>
        /// Get the taxcode object identified by this URL.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code</param>
        /// <param name="id">The primary key of this tax code</param>
        public async Task<TaxCodeModel> GetTaxCodeAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<TaxCodeModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve tax codes for this company;
        /// </summary>
        /// <remarks>
        /// List all taxcode objects attached to this company.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these tax codes</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxCodeModel>> ListTaxCodesByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxCodeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all tax codes;
        /// </summary>
        /// <remarks>
        /// Get multiple taxcode objects across all companies.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxCodeModel>> QueryTaxCodesAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxCodeModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single tax code;
        /// </summary>
        /// <remarks>
        /// Replace the existing taxcode object at this URL with an updated object.
        /// A 'TaxCode' represents a uniquely identified type of product, good, or service.
        /// Avalara supports correct tax rates and taxability rules for all TaxCodes in all supported jurisdictions.
        /// If you identify your products by tax code in your 'Create Transacion' API calls, Avalara will correctly calculate tax rates and
        /// taxability rules for this product in all supported jurisdictions.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this tax code belongs to.</param>
        /// <param name="id">The ID of the tax code you wish to update</param>
        /// <param name="model">The tax code you wish to update.</param>
        public async Task<TaxCodeModel> UpdateTaxCodeAsync(Int32 companyId, Int32 id, TaxCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<TaxCodeModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Build a multi-location tax content file;
        /// </summary>
        /// <remarks>
        /// Builds a tax content file containing information useful for a retail point-of-sale solution.
        /// 
        /// This file contains tax rates and rules for items and locations that can be used
        /// to correctly calculate tax in the event a point-of-sale device is not able to reach AvaTax.
        /// 
        /// This data file can be customized for specific partner devices and usage conditions.
        /// 
        /// The result of this API is the file you requested in the format you requested using the `responseType` field.
        /// 
        /// This API builds the file on demand, and is limited to files with no more than 7500 scenarios. To build a tax content
        /// file for a single location at a time, please use `BuildTaxContentFileForLocation`.;
        /// </remarks>
        /// <param name="model">Parameters about the desired file format and report format, specifying which company, locations and TaxCodes to include.</param>
        public async Task<FileResult> BuildTaxContentFileAsync(PointOfSaleDataRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/pointofsaledata/build");
            return await RestCallAsync<FileResult>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Build a tax content file for a single location;
        /// </summary>
        /// <remarks>
        /// Builds a tax content file containing information useful for a retail point-of-sale solution.
        /// 
        /// This file contains tax rates and rules for all items for a single location. Data from this API
        /// can be used to correctly calculate tax in the event a point-of-sale device is not able to reach AvaTax.
        /// 
        /// This data file can be customized for specific partner devices and usage conditions.
        /// 
        /// The result of this API is the file you requested in the format you requested using the `responseType` field.
        /// 
        /// This API builds the file on demand, and is limited to files with no more than 7500 scenarios. To build a tax content
        /// file for a multiple locations in a single file, please use `BuildTaxContentFile`.;
        /// </remarks>
        /// <param name="companyId">The ID number of the company that owns this location.</param>
        /// <param name="id">The ID number of the location to retrieve point-of-sale data.</param>
        /// <param name="date">The date for which point-of-sale data would be calculated (today by default)</param>
        /// <param name="format">The format of the file (JSON by default)</param>
        /// <param name="partnerId">If specified, requests a custom partner-formatted version of the file.</param>
        /// <param name="includeJurisCodes">When true, the file will include jurisdiction codes in the result.</param>
        public async Task<FileResult> BuildTaxContentFileForLocationAsync(Int32 companyId, Int32 id, DateTime? date, PointOfSaleFileType? format, PointOfSalePartnerId? partnerId, Boolean? includeJurisCodes)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/pointofsaledata");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("date", date);
            path.AddQuery("format", format);
            path.AddQuery("partnerId", partnerId);
            path.AddQuery("includeJurisCodes", includeJurisCodes);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Download a file listing tax rates by postal code;
        /// </summary>
        /// <remarks>
        /// Download a CSV file containing all five digit postal codes in the United States and their sales
        /// and use tax rates for tangible personal property.
        /// 
        /// This rates file is intended to be used as a default for tax calculation when your software cannot
        /// call the `CreateTransaction` API call. When using this file, your software will be unable to
        /// handle complex tax rules such as:
        /// 
        /// * Zip+9 - This tax file does not contain 
        /// * Different product types - This tax file contains tangible personal property tax rates only.
        /// * Mixed sourcing - This tax file cannot be used to resolve origin-based taxes.
        /// * Threshold-based taxes - This tax file does not contain information about thresholds.
        /// 
        /// If you use this file to provide default tax rates, please ensure that your software calls `CreateTransaction`
        /// to reconcile the actual transaction and determine the difference between the estimated general tax
        /// rate and the final transaction tax.;
        /// </remarks>
        /// <param name="date">The date for which</param>
        public async Task<FileResult> DownloadTaxRatesByZipCodeAsync(DateTime date)
        {
            var path = new AvaTaxPath("/api/v2/taxratesbyzipcode/download/{date}");
            path.ApplyField("date", date);
            return await RestCallAsync<FileResult>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new tax rule;
        /// </summary>
        /// <remarks>
        /// Create one or more new taxrule objects attached to this company.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule.</param>
        /// <param name="model">The tax rule you wish to create.</param>
        public async Task<List<TaxRuleModel>> CreateTaxRulesAsync(Int32 companyId, List<TaxRuleModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<TaxRuleModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single tax rule;
        /// </summary>
        /// <remarks>
        /// Mark the TaxRule identified by this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule.</param>
        /// <param name="id">The ID of the tax rule you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteTaxRuleAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single tax rule;
        /// </summary>
        /// <remarks>
        /// Get the taxrule object identified by this URL.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule</param>
        /// <param name="id">The primary key of this tax rule</param>
        public async Task<TaxRuleModel> GetTaxRuleAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<TaxRuleModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve tax rules for this company;
        /// </summary>
        /// <remarks>
        /// List all taxrule objects attached to this company.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these tax rules</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxRuleModel>> ListTaxRulesAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxRuleModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all tax rules;
        /// </summary>
        /// <remarks>
        /// Get multiple taxrule objects across all companies.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TaxRuleModel>> QueryTaxRulesAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxrules");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TaxRuleModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single tax rule;
        /// </summary>
        /// <remarks>
        /// Replace the existing taxrule object at this URL with an updated object.
        /// A tax rule represents a custom taxability rule for a product or service sold by your company.
        /// If you have obtained a custom tax ruling from an auditor that changes the behavior of certain goods or services
        /// within certain taxing jurisdictions, or you have obtained special tax concessions for certain dates or locations,
        /// you may wish to create a TaxRule object to override the AvaTax engine's default behavior in those circumstances.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this tax rule belongs to.</param>
        /// <param name="id">The ID of the tax rule you wish to update</param>
        /// <param name="model">The tax rule you wish to update.</param>
        public async Task<TaxRuleModel> UpdateTaxRuleAsync(Int32 companyId, Int32 id, TaxRuleModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<TaxRuleModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Add lines to an existing unlocked transaction;
        /// </summary>
        /// <remarks>
        /// Add lines to an existing unlocked transaction.
        ///  
        ///  The `AddLines` API allows you to add additional transaction lines to existing transaction, so that customer will
        ///  be able to append multiple calls together and form an extremely large transaction. If customer does not specify line number
        ///  in the lines to be added, a new random Guid string will be generated for line number. If customer are not satisfied with
        ///  the line number for the transaction lines, they can turn on the renumber switch to have REST v2 automatically renumber all 
        ///  transaction lines for them, in this case, the line number becomes: "1", "2", "3", ...
        ///  
        ///  A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        ///  sales, purchases, inventory transfer, and returns (also called refunds).
        ///  You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Lines
        ///  * Details (implies lines)
        ///  * Summary (implies details)
        ///  * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// 
        ///  If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.;
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">information about the transaction and lines to be added</param>
        public async Task<TransactionModel> AddLinesAsync(String include, AddTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/add");
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Correct a previously created transaction;
        /// </summary>
        /// <remarks>
        /// Replaces the current transaction uniquely identified by this URL with a new transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// When you adjust a committed transaction, the original transaction will be updated with the status code `Adjusted`, and
        /// both revisions will be available for retrieval based on their code and ID numbers.
        /// Only transactions in `Committed` status are reported by Avalara Managed Returns.
        /// 
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are considered `locked` and are 
        /// no longer available for adjustments.;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to adjust</param>
        /// <param name="model">The adjustment you wish to make</param>
        public async Task<TransactionModel> AdjustTransactionAsync(String companyCode, String transactionCode, AdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/adjust");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Get audit information about a transaction;
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The 'AuditTransaction' endpoint retrieves audit information related to a specific transaction. This audit 
        /// information includes the following:
        /// 
        /// * The `CompanyId` of the company that created the transaction
        /// * The server timestamp representing the exact server time when the transaction was created
        /// * The server duration - how long it took to process this transaction
        /// * Whether exact API call details were logged
        /// * A reconstructed API call showing what the original CreateTransaction call looked like
        /// 
        /// This API can be used to examine information about a previously created transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="companyCode">The code identifying the company that owns this transaction</param>
        /// <param name="transactionCode">The code identifying the transaction</param>
        public async Task<AuditTransactionModel> AuditTransactionAsync(String companyCode, String transactionCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<AuditTransactionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Get audit information about a transaction;
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The 'AuditTransaction' endpoint retrieves audit information related to a specific transaction. This audit 
        /// information includes the following:
        /// 
        /// * The `CompanyId` of the company that created the transaction
        /// * The server timestamp representing the exact server time when the transaction was created
        /// * The server duration - how long it took to process this transaction
        /// * Whether exact API call details were logged
        /// * A reconstructed API call showing what the original CreateTransaction call looked like
        /// 
        /// This API can be used to examine information about a previously created transaction.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="companyCode">The code identifying the company that owns this transaction</param>
        /// <param name="transactionCode">The code identifying the transaction</param>
        /// <param name="documentType">The document type of the original transaction</param>
        public async Task<AuditTransactionModel> AuditTransactionWithTypeAsync(String companyCode, String transactionCode, DocumentType documentType)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            return await RestCallAsync<AuditTransactionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Lock a set of documents;
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// Lock a set of transactions uniquely identified by DocumentIds provided. This API allows locking multiple documents at once.
        /// After this API call succeeds, documents will be locked and can't be voided.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="model">bulk lock request</param>
        public async Task<BulkLockTransactionResult> BulkLockTransactionAsync(BulkLockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/lock");
            return await RestCallAsync<BulkLockTransactionResult>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Change a transaction's code;
        /// </summary>
        /// <remarks>
        /// Renames a transaction uniquely identified by this URL by changing its code to a new code.
        /// After this API call succeeds, the transaction will have a new URL matching its new code.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to change</param>
        /// <param name="model">The code change request you wish to execute</param>
        public async Task<TransactionModel> ChangeTransactionCodeAsync(String companyCode, String transactionCode, ChangeTransactionCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/changecode");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Commit a transaction for reporting;
        /// </summary>
        /// <remarks>
        /// Marks a transaction by changing its status to 'Committed'.
        /// Transactions that are committed are available to be reported to a tax authority by Avalara Managed Returns.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// Any changes made to a committed transaction will generate a transaction history.;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to commit</param>
        /// <param name="model">The commit request you wish to execute</param>
        public async Task<TransactionModel> CommitTransactionAsync(String companyCode, String transactionCode, CommitTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/commit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new transaction;
        /// </summary>
        /// <remarks>
        /// Records a new transaction or adjust an existing in AvaTax.
        /// 
        /// The `CreateOrAdjustTransaction` endpoint is used to create a new transaction if the input transaction does not exist
        /// or if there exists a transaction identified by code, the original transaction will be adjusted by using the meta data 
        /// in the input transaction
        /// 
        /// If you don't specify type in the provided data, a new transaction with type of SalesOrder will be recorded by default.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.;
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create</param>
        public async Task<TransactionModel> CreateOrAdjustTransactionAsync(String include, CreateOrAdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/createoradjust");
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new transaction;
        /// </summary>
        /// <remarks>
        /// Records a new transaction in AvaTax.
        /// 
        /// The `CreateTransaction` endpoint uses the configuration values specified by your company to identify the correct tax rules
        /// and rates to apply to all line items in this transaction, and reports the total tax calculated by AvaTax based on your
        /// company's configuration and the data provided in this API call.
        /// 
        /// If you don't specify type in the provided data, a new transaction with type of SalesOrder will be recorded by default.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.;
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create</param>
        public async Task<TransactionModel> CreateTransactionAsync(String include, CreateTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/create");
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Remove lines from an existing unlocked transaction;
        /// </summary>
        /// <remarks>
        /// Remove lines to an existing unlocked transaction.
        ///  
        ///  The `DeleteLines` API allows you to remove transaction lines from existing unlocked transaction, so that customer will
        ///  be able to delete transaction lines and adjust original transaction the way they like
        ///  
        ///  A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        ///  sales, purchases, inventory transfer, and returns (also called refunds).
        ///  You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        /// 
        ///  * Lines
        ///  * Details (implies lines)
        ///  * Summary (implies details)
        ///  * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// 
        ///  If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.;
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">information about the transaction and lines to be removed</param>
        public async Task<TransactionModel> DeleteLinesAsync(String include, RemoveTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/delete");
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single transaction by code;
        /// </summary>
        /// <remarks>
        /// Get the current transaction identified by this URL.
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code, and previous revisions of
        /// the transaction will be attached to the 'history' data field.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size);
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public async Task<TransactionModel> GetTransactionByCodeAsync(String companyCode, String transactionCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single transaction by code;
        /// </summary>
        /// <remarks>
        /// Get the current transaction identified by this URL.
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code, and previous revisions of
        /// the transaction will be attached to the 'history' data field.
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size);
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="documentType">The transaction type to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public async Task<TransactionModel> GetTransactionByCodeAndTypeAsync(String companyCode, String transactionCode, DocumentType documentType, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single transaction by ID;
        /// </summary>
        /// <remarks>
        /// Get the unique transaction identified by this URL.
        /// This endpoint retrieves the exact transaction identified by this ID number even if that transaction was later adjusted
        /// by using the 'Adjust Transaction' endpoint.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size);
        /// </remarks>
        /// <param name="id">The unique ID number of the transaction to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public async Task<TransactionModel> GetTransactionByIdAsync(Int64 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/transactions/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all transactions;
        /// </summary>
        /// <remarks>
        /// List all transactions attached to this company.
        /// This endpoint is limited to returning 1,000 transactions at a time maximum.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size);
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<TransactionModel>> ListTransactionsByCompanyAsync(String companyCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions");
            path.ApplyField("companyCode", companyCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<TransactionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Lock a single transaction;
        /// </summary>
        /// <remarks>
        /// Lock a transaction uniquely identified by this URL. 
        /// 
        /// This API is mainly used for connector developer to simulate what happens when Returns product locks a document.
        /// After this API call succeeds, the document will be locked and can't be voided or adjusted.
        /// 
        /// This API is only available to customers in Sandbox with AvaTaxPro subscription. On production servers, this API is available by invitation only.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to lock</param>
        /// <param name="model">The lock request you wish to execute</param>
        public async Task<TransactionModel> LockTransactionAsync(String companyCode, String transactionCode, LockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/lock");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a refund for a transaction;
        /// </summary>
        /// <remarks>
        /// Create a refund for a transaction.
        /// 
        /// The `RefundTransaction` API allows you to quickly and easily create a `ReturnInvoice` representing a refund
        /// for a previously created `SalesInvoice` transaction. You can choose to create a full or partial refund, and
        /// specify individual line items from the original sale for refund.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.;
        /// </remarks>
        /// <param name="companyCode">The code of the company that made the original sale</param>
        /// <param name="transactionCode">The transaction code of the original sale</param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">Information about the refund to create</param>
        public async Task<TransactionModel> RefundTransactionAsync(String companyCode, String transactionCode, String include, RefundTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/refund");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Perform multiple actions on a transaction;
        /// </summary>
        /// <remarks>
        /// Performs the same functions as /verify, /changecode, and /commit. You may specify one or many actions in each call to this endpoint.;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="model">The settle request containing the actions you wish to execute</param>
        public async Task<TransactionModel> SettleTransactionAsync(String companyCode, String transactionCode, SettleTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/settle");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Verify a transaction;
        /// </summary>
        /// <remarks>
        /// Verifies that the transaction uniquely identified by this URL matches certain expected values.
        /// If the transaction does not match these expected values, this API will return an error code indicating which value did not match.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="model">The settle request you wish to execute</param>
        public async Task<TransactionModel> VerifyTransactionAsync(String companyCode, String transactionCode, VerifyTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/verify");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Void a transaction;
        /// </summary>
        /// <remarks>
        /// Voids the current transaction uniquely identified by this URL.
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// When you void a transaction, that transaction's status is recorded as 'DocVoided'.
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are no longer available to be voided.;
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to void</param>
        /// <param name="model">The void request you wish to execute</param>
        public async Task<TransactionModel> VoidTransactionAsync(String companyCode, String transactionCode, VoidTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/void");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return await RestCallAsync<TransactionModel>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Create a new UPC;
        /// </summary>
        /// <remarks>
        /// Create one or more new UPC objects attached to this company.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC.</param>
        /// <param name="model">The UPC you wish to create.</param>
        public async Task<List<UPCModel>> CreateUPCsAsync(Int32 companyId, List<UPCModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            return await RestCallAsync<List<UPCModel>>("Post", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Delete a single UPC;
        /// </summary>
        /// <remarks>
        /// Marks the UPC object identified by this URL as deleted.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC.</param>
        /// <param name="id">The ID of the UPC you wish to delete.</param>
        public async Task<List<ErrorDetail>> DeleteUPCAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<List<ErrorDetail>>("Delete", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single UPC;
        /// </summary>
        /// <remarks>
        /// Get the UPC object identified by this URL.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC</param>
        /// <param name="id">The primary key of this UPC</param>
        public async Task<UPCModel> GetUPCAsync(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<UPCModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve UPCs for this company;
        /// </summary>
        /// <remarks>
        /// List all UPC objects attached to this company.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns these UPCs</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<UPCModel>> ListUPCsByCompanyAsync(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<UPCModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all UPCs;
        /// </summary>
        /// <remarks>
        /// Get multiple UPC objects across all companies.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<UPCModel>> QueryUPCsAsync(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/upcs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<UPCModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single UPC;
        /// </summary>
        /// <remarks>
        /// Replace the existing UPC object at this URL with an updated object.
        /// A UPC represents a single UPC code in your catalog and matches this product to the tax code identified by this UPC.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="companyId">The ID of the company that this UPC belongs to.</param>
        /// <param name="id">The ID of the UPC you wish to update</param>
        /// <param name="model">The UPC you wish to update.</param>
        public async Task<UPCModel> UpdateUPCAsync(Int32 companyId, Int32 id, UPCModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return await RestCallAsync<UPCModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve a single user;
        /// </summary>
        /// <remarks>
        /// Get the user object identified by this URL.
        /// A user represents one person with access privileges to make API calls and work with a specific account.;
        /// </remarks>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <param name="accountId">The accountID of the user you wish to get.</param>
        /// <param name="include">Optional fetch commands.</param>
        public async Task<UserModel> GetUserAsync(Int32 id, Int32 accountId, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            return await RestCallAsync<UserModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all entitlements for a single user;
        /// </summary>
        /// <remarks>
        /// Return a list of all entitlements to which this user has rights to access.
        /// Entitlements are a list of specified API calls the user is permitted to make, a list of identifier numbers for companies the user is 
        /// allowed to use, and an access level identifier that indicates what types of access roles the user is allowed to use.
        /// This API call is intended to provide a validation endpoint to determine, before making an API call, whether this call is likely to succeed.
        /// For example, if user 567 within account 999 is attempting to create a new child company underneath company 12345, you could preview the user's
        /// entitlements and predict whether this call would succeed:
        ///  
        /// * Retrieve entitlements by calling '/api/v2/accounts/999/users/567/entitlements' . If the call fails, you do not have accurate 
        ///  credentials for this user.
        /// * If the 'accessLevel' field within entitlements is 'None', the call will fail.
        /// * If the 'accessLevel' field within entitlements is 'SingleCompany' or 'SingleAccount', the call will fail if the companies
        ///  table does not contain the ID number 12345.
        /// * If the 'permissions' array within entitlements does not contain 'AccountSvc.CompanySave', the call will fail.
        ///  
        /// For a full list of defined permissions, please use '/api/v2/definitions/permissions' .;
        /// </remarks>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <param name="accountId">The accountID of the user you wish to get.</param>
        public async Task<UserEntitlementModel> GetUserEntitlementsAsync(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}/entitlements");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<UserEntitlementModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve users for this account;
        /// </summary>
        /// <remarks>
        /// List all user objects attached to this account.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="accountId">The accountID of the user you wish to list.</param>
        /// <param name="include">Optional fetch commands.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<UserModel>> ListUsersByAccountAsync(Int32 accountId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<UserModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Retrieve all users;
        /// </summary>
        /// <remarks>
        /// Get multiple user objects across all accounts.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.;
        /// </remarks>
        /// <param name="include">Optional fetch commands.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public async Task<FetchResult<UserModel>> QueryUsersAsync(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/users");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return await RestCallAsync<FetchResult<UserModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Update a single user;
        /// </summary>
        /// <remarks>
        /// Replace the existing user object at this URL with an updated object.
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.;
        /// </remarks>
        /// <param name="id">The ID of the user you wish to update.</param>
        /// <param name="accountId">The accountID of the user you wish to update.</param>
        /// <param name="model">The user object you wish to update.</param>
        public async Task<UserModel> UpdateUserAsync(Int32 id, Int32 accountId, UserModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return await RestCallAsync<UserModel>("Put", path, model).ConfigureAwait(false);
        }


        /// <summary>
        /// Checks if the current user is subscribed to a specific service;
        /// </summary>
        /// <remarks>
        /// Returns a subscription object for the current account, or 404 Not Found if this subscription is not enabled for this account.
        /// This API call is intended to allow you to identify whether you have the necessary account configuration to access certain
        /// features of AvaTax, and would be useful in debugging access privilege problems.;
        /// </remarks>
        /// <param name="serviceTypeId">The service to check</param>
        public async Task<SubscriptionModel> GetMySubscriptionAsync(ServiceTypeId serviceTypeId)
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions/{serviceTypeId}");
            path.ApplyField("serviceTypeId", serviceTypeId);
            return await RestCallAsync<SubscriptionModel>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// List all services to which the current user is subscribed;
        /// </summary>
        /// <remarks>
        /// Returns the list of all subscriptions enabled for the current account.
        /// This API is intended to help you determine whether you have the necessary subscription to use certain API calls
        /// within AvaTax.;
        /// </remarks>
        public async Task<FetchResult<SubscriptionModel>> ListMySubscriptionsAsync()
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions");
            return await RestCallAsync<FetchResult<SubscriptionModel>>("Get", path, null).ConfigureAwait(false);
        }


        /// <summary>
        /// Tests connectivity and version of the service;
        /// </summary>
        /// <remarks>
        /// This API helps diagnose connectivity problems between your application and AvaTax; you may call this API even 
        /// if you do not have verified connection credentials.
        /// The results of this API call will help you determine whether your computer can contact AvaTax via the network,
        /// whether your authentication credentials are recognized, and the roundtrip time it takes to communicate with
        /// AvaTax.;
        /// </remarks>
        public async Task<PingResultModel> PingAsync()
        {
            var path = new AvaTaxPath("/api/v2/utilities/ping");
            return await RestCallAsync<PingResultModel>("Get", path, null).ConfigureAwait(false);
        }

#endif
#endregion
    }
}
