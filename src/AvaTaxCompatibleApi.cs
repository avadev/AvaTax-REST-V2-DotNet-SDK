using System;
using System.Collections.Generic;
#if PORTABLE
using System.Net.Http;
using System.Threading.Tasks;
#endif

/*
 * AvaTax Software Development Kit for C#
 *
 * (c) 2004-2018 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <ted.spence@avalara.com>
 * @author     Zhenya Frolov <zhenya.frolov@avalara.com>
 * @author     Greg Hester <greg.hester@avalara.com>
 * @copyright  2004-2017 Avalara, Inc.
 * @license    https://www.apache.org/licenses/LICENSE-2.0
 * @version    18.1.2-161
 * @link       https://github.com/avadev/AvaTax-REST-V2-DotNet-SDK
 */

namespace Avalara.AvaTax.RestClient
{
    /// <summary>
    /// The AvaTax compatible client always returns a predictable response object, the "AvaTaxCallResult".
    /// The result object contains information about whether the call resulted in an error, and if so, what
    /// data was in its response.  The caller is expected to use the object and determine how to handle
    /// errors.
    /// 
    /// This class may be useful for programmers who prefer to use synchronous code or to not use exceptions.
    /// </summary>
    public partial class AvaTaxCompatibleClient
    {
#region Methods

        /// <summary>
        /// Reset this account's license key
        /// </summary>
        /// <remarks>
        /// Resets the existing license key for this account to a new key.
        /// 
        /// To reset your account, you must specify the ID of the account you wish to reset and confirm the action.
        /// 
        /// This API is only available to account administrators for the account in question, and may only be called after
        /// an account has been activated by reading and accepting Avalara's terms and conditions. To activate your account
        /// please log onto the AvaTax website or call the `ActivateAccount` API.
        /// 
        /// Resetting a license key cannot be undone. Any previous license keys will immediately cease to work when a new key is created.
        /// 
        /// When you call this API, all account administrators for this account will receive an email with the newly updated license key.
        /// The email will specify which user reset the license key and it will contain the new key to use to update your connectors.
        /// </remarks>
        /// <param name="id">The ID of the account you wish to update.</param>
        /// <param name="model">A request confirming that you wish to reset the license key of this account.</param>
        public AvaTaxCallResult AccountResetLicenseKey(Int32 id, ResetLicenseKeyModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/resetlicensekey");
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// Once you have activated your account, use the `AccountResetLicenseKey` API to generate
        /// a license key for your account.
        /// 
        /// If you have not read or accepted the terms and conditions, this API call will return the
        /// unchanged account model.
        /// </remarks>
        /// <param name="id">The ID of the account to activate</param>
        /// <param name="include">Elements to include when fetching the account</param>
        /// <param name="model">The activation request</param>
        public AvaTaxCallResult ActivateAccount(Int32 id, String include, ActivateAccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/activate");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult GetAccount(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetAccountConfiguration(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult SetAccountConfiguration(Int32 id, List<AccountConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}/configuration");
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult ResolveAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, TextCase? textCase, Decimal? latitude, Decimal? longitude)
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
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ResolveAddressPost(AddressValidationInfo model)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateBatches(Int32 companyId, List<BatchModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single batch
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this batch.</param>
        /// <param name="id">The ID of the batch you wish to delete.</param>
        public AvaTaxCallResult DeleteBatch(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DownloadBatch(Int32 companyId, Int32 batchId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{batchId}/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("batchId", batchId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetBatch(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListBatchesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/batches");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryBatches(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/batches");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that will record certificates</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="model">the requests to send out to customers</param>
        public AvaTaxCallResult CreateCertExpressInvitation(Int32 companyId, String customerCode, List<CreateCertExpressInvitationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="customerCode">The number of the customer where the request is sent to</param>
        /// <param name="id">The unique ID number of this CertExpress invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. No options are defined at this time.</param>
        public AvaTaxCallResult GetCertExpressInvitation(Int32 companyId, String customerCode, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certexpressinvites/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that issued this invitation</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  
        ///  No options are defined at this time.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListCertExpressInvitations(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certexpressinvites");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The ID number of the company recording this certificate</param>
        /// <param name="model">Certificates to be created</param>
        public AvaTaxCallResult CreateCertificates(Int32 companyId, List<CertificateModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public AvaTaxCallResult DeleteCertificate(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="page">If you choose `$type`=`Jpeg`, you must specify which page number to retrieve.</param>
        /// <param name="type">The data format in which to retrieve the certificate image</param>
        public AvaTaxCallResult DownloadCertificateImage(Int32 companyId, Int32 id, Int32? page, CertificatePreviewType? type)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$page", page);
            path.AddQuery("$type", type);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. You can specify one or more of the following:
        ///  
        ///  * Customers - Retrieves the list of customers linked to the certificate.
        ///  * PoNumbers - Retrieves all PO numbers tied to the certificate.
        ///  * Attributes - Retrieves all attributes applied to the certificate.</param>
        public AvaTaxCallResult GetCertificate(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to link to this certificate.</param>
        public AvaTaxCallResult LinkAttributesToCertificate(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers needed be added to the Certificate for exemption</param>
        public AvaTaxCallResult LinkCustomersToCertificate(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        public AvaTaxCallResult ListAttributesForCertificate(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="include">OPTIONAL: A comma separated list of special fetch options. 
        ///  No options are currently available when fetching customers.</param>
        public AvaTaxCallResult ListCustomersForCertificate(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
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
        public AvaTaxCallResult QueryCertificates(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of attributes to unlink from this certificate.</param>
        public AvaTaxCallResult UnlinkAttributesFromCertificate(Int32 companyId, Int32 id, List<CertificateAttributeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attributes/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The list of customers to unlink from this certificate</param>
        public AvaTaxCallResult UnlinkCustomersFromCertificate(Int32 companyId, Int32 id, LinkCustomersModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/customers/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="model">The new certificate object that will replace the existing one</param>
        public AvaTaxCallResult UpdateCertificate(Int32 companyId, Int32 id, CertificateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this certificate</param>
        /// <param name="id">The unique ID number of this certificate</param>
        /// <param name="file">The exemption certificate file you wanted to upload. Accepted formats are: PDF, JPEG, TIFF, PNG.</param>
        public AvaTaxCallResult UploadCertificateImage(Int32 companyId, Int32 id, FileResult file)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/certificates/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, null);
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
        public AvaTaxCallResult ChangeFilingStatus(Int32 id, FilingStatusChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        /// Please allow 1 minute before making transactions using the company.
        /// </remarks>
        /// <param name="model">Information about the company you wish to create.</param>
        public AvaTaxCallResult CompanyInitialize(CompanyInitializationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/initialize");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateCompanies(List<CompanyModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateFundingRequest(Int32 id, FundingInitiateModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding/setup");
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single company
        /// </summary>
        /// <remarks>
        /// Deleting a company will delete all child companies, and all users attached to this company.
        /// </remarks>
        /// <param name="id">The ID of the company you wish to delete.</param>
        public AvaTaxCallResult DeleteCompany(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
        }


        /// <summary>
        /// Check the funding configuration of a company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// Returns the funding configuration of the requested company.
        /// .
        /// </remarks>
        /// <param name="companyId">The unique identifier of the company</param>
        public AvaTaxCallResult FundingConfigurationByCompany(Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/funding/configuration");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Check the funding configuration of a company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// Returns the funding configuration of the requested company.
        /// .
        /// </remarks>
        /// <param name="companyId">The unique identifier of the company</param>
        /// <param name="currency">The currency of the funding. USD and CAD are the only valid currencies</param>
        public AvaTaxCallResult FundingConfigurationsByCompanyAndCurrency(Int32 companyId, String currency)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/funding/configurations");
            path.ApplyField("companyId", companyId);
            path.AddQuery("currency", currency);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetCompany(Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetCompanyConfiguration(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingStatus(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/filingstatus");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Check managed returns funding status for a company
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// Requires a subscription to Avalara Managed Returns or SST Certified Service Provider.
        /// Returns a list of funding setup requests and their current status.
        /// Each object in the result is a request that was made to setup or adjust funding status for this company.
        /// </remarks>
        /// <param name="id">The unique identifier of the company</param>
        public AvaTaxCallResult ListFundingRequestsByCompany(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/funding");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve a list of MRS Companies with account
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// 
        /// Get a list of companies with an active MRS service.
        /// </remarks>
        public AvaTaxCallResult ListMrsCompanies()
        {
            var path = new AvaTaxPath("/api/v2/companies/mrs");
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryCompanies(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult SetCompanyConfiguration(Int32 id, List<CompanyConfigurationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}/configuration");
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult UpdateCompany(Int32 id, CompanyModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult CreateContacts(Int32 companyId, List<ContactModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single contact
        /// </summary>
        /// <remarks>
        /// Mark the existing contact object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this contact.</param>
        /// <param name="id">The ID of the contact you wish to delete.</param>
        public AvaTaxCallResult DeleteContact(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetContact(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListContactsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryContacts(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/contacts");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateContact(Int32 companyId, Int32 id, ContactModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/contacts/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="model">The list of customer objects to be created</param>
        public AvaTaxCallResult CreateCustomers(Int32 companyId, List<CustomerModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        public AvaTaxCallResult DeleteCustomer(Int32 companyId, String customerCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return _client.RestCall("Delete", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="include">Specify optional additional objects to include in this fetch request</param>
        public AvaTaxCallResult GetCustomer(Int32 companyId, String customerCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public AvaTaxCallResult LinkCertificatesToCustomer(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/link");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
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
        public AvaTaxCallResult ListCertificatesForCustomer(Int32 companyId, String customerCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="country">Search for certificates matching this country. Uses the ISO 3166 two character country code.</param>
        /// <param name="region">Search for certificates matching this region. Uses the ISO 3166 two or three character state, region, or province code.</param>
        public AvaTaxCallResult ListValidCertificatesForCustomer(Int32 companyId, String customerCode, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="include">OPTIONAL - You can specify the value `certificates` to fetch information about certificates linked to the customer.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult QueryCustomers(Int32 companyId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The list of certificates to link to this customer</param>
        public AvaTaxCallResult UnlinkCertificatesFromCustomer(Int32 companyId, String customerCode, LinkCertificatesModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}/certificates/unlink");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return _client.RestCall("Post", path, model);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that recorded this customer</param>
        /// <param name="customerCode">The unique code representing this customer</param>
        /// <param name="model">The new customer model that will replace the existing record at this URL</param>
        public AvaTaxCallResult UpdateCustomer(Int32 companyId, String customerCode, CustomerModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/customers/{customerCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("customerCode", customerCode);
            return _client.RestCall("Put", path, model);
        }


        /// <summary>
        /// Lists all parents of an HS Code.
        /// </summary>
        /// <remarks>
        /// Retrieves the specified HS code and all of its parents, reflecting all sections, chapters, headings, and subheadings
        /// 
        /// a list of HS Codes that are the parents and information branches of the HS Code for the given 
        /// destination country, if lower detail is available. 
        /// 
        /// This API will include information branches if applicable. These do not have HS Codes and cannot be referenced,
        /// but can contain information relevant to deciding the correct HS Code. 
        /// 
        /// This API is intended to be useful to review the descriptive hierarchy of an HS Code, which can be particularly helpful
        /// when HS Codes can have multiple levels of generic descriptions.
        /// </remarks>
        /// <param name="country">The name or code of the destination country.</param>
        /// <param name="hsCode">The partial or full HS Code for which you would like to view all of the parents.</param>
        public AvaTaxCallResult GetCrossBorderCode(String country, String hsCode)
        {
            var path = new AvaTaxPath("/api/v2/definitions/crossborder/{country}/{hsCode}/hierarchy");
            path.ApplyField("country", country);
            path.ApplyField("hsCode", hsCode);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetLoginVerifierByForm(String form, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers/{form}");
            path.ApplyField("form", form);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of the AvaFile Forms available
        /// </summary>
        /// <remarks>
        /// This API is deprecated. 
        /// 
        /// Please use the ListTaxForms API.
        /// 
        /// Returns the full list of Avalara-supported AvaFile Forms
        /// This API is intended to be useful to identify all the different AvaFile Forms
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListAvaFileForms(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/avafileforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List certificate attributes used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate attributes defined by a company.
        /// 
        /// A certificate may have multiple attributes that control its behavior. You may apply or remove attributes to a
        /// certificate at any time.
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListCertificateAttributes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateattributes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List certificate attributes used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate exempt reasons defined by a company.
        /// 
        /// An exemption reason defines why a certificate allows a customer to be exempt
        /// for purposes of tax calculation.
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListCertificateExemptReasons(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexemptreasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List certificate exposure zones used by a company
        /// </summary>
        /// <remarks>
        /// List the certificate exposure zones defined by a company.
        /// 
        /// An exposure zone is a location where a certificate can be valid. Exposure zones may indicate a taxing
        /// authority or other legal entity to which a certificate may apply.
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListCertificateExposureZones(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/certificateexposurezones");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListCommunicationsServiceTypes(Int32 id, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes/{id}/servicetypes");
            path.ApplyField("id", id);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListCommunicationsTransactionTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/transactiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListCommunicationsTSPairs(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/communications/tspairs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListCountries(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// 
        /// You may experience up to a three minute delay on your very first call to the exemption related endpoints 
        /// (as your account gets provisioned). Thank you for your patience.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListCoverLetters(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/coverletters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Lists the next level of HS Codes given a destination country and HS Code prefix.
        /// </summary>
        /// <remarks>
        /// Retrieves a list of HS Codes that are the children of the prefix for the given destination country, if 
        /// additional children are available. 
        /// 
        /// HS Code is interchangeable with "tariff code" and definitions are generally unique to a destination country.
        /// An HS Code describes an item and its eligibility/rate for tariffs. HS Codes are organized by 
        /// Section/Chapter/Heading/Subheading/Classification.
        /// 
        /// This API is intended to be useful to identify the correct HS Code to use for your item.
        /// </remarks>
        /// <param name="country">The name or code of the destination country.</param>
        /// <param name="hsCode">The Section or partial HS Code for which you would like to view the next level of HS Code detail, if more detail is available.</param>
        public AvaTaxCallResult ListCrossBorderCodes(String country, String hsCode)
        {
            var path = new AvaTaxPath("/api/v2/definitions/crossborder/{country}/{hsCode}");
            path.ApplyField("country", country);
            path.ApplyField("hsCode", hsCode);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List top level HS Code Sections.
        /// </summary>
        /// <remarks>
        /// Returns the full list of top level HS Code Sections. Sections are the broadest level of detail for 
        /// classifying tariff codes and the items to which they apply. HS Codes are organized 
        /// by Section/Chapter/Heading/Subheading/Classification.
        /// 
        /// This API is intended to be useful to identify the top level Sections for 
        /// further LandedCost HS Code lookups.
        /// </remarks>
        public AvaTaxCallResult ListCrossBorderSections()
        {
            var path = new AvaTaxPath("/api/v2/definitions/crossborder/sections");
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListEntityUseCodes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/entityusecodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListFilingFrequencies(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingfrequencies");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListJurisdictions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/jurisdictions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListJurisdictionsByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
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
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListLocationQuestionsByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, Decimal? latitude, Decimal? longitude, String filter, Int32? top, Int32? skip, String orderBy)
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
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListLoginVerifiers(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/filingcalendars/loginverifiers");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for all countries and regions.
        /// </summary>
        /// <remarks>
        /// Returns the full list of all Avalara-supported nexus for all countries and regions. 
        /// 
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListNexus(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// <param name="region">Name or ISO 3166 code identifying the region portion of the address.
        ///  
        ///  This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        ///  
        ///  For a full list of all supported codes and names, please see the Definitions API `ListRegions`.</param>
        /// <param name="postalCode">The postal code or zip code portion of this address.</param>
        /// <param name="country">Name or ISO 3166 code identifying the country portion of this address.
        ///  
        ///  This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        ///  
        ///  For a full list of all supported codes and names, please see the Definitions API `ListCountries`.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListNexusByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, String filter, Int32? top, Int32? skip, String orderBy)
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
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country.
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country.
        /// 
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country.
        /// </remarks>
        /// <param name="country">The country in which you want to fetch the system nexus</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListNexusByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported nexus for a country and region.
        /// </summary>
        /// <remarks>
        /// Returns all Avalara-supported nexus for the specified country and region.
        /// 
        /// This API is intended to be useful if your user interface needs to display a selectable list of nexus filtered by country and region.
        /// </remarks>
        /// <param name="country">The two-character ISO-3166 code for the country.</param>
        /// <param name="region">The two or three character region code for the region.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListNexusByCountryAndRegion(String country, String region, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/{country}/{region}");
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNexusByFormCode(String formCode, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexus/byform/{formCode}");
            path.ApplyField("formCode", formCode);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNexusTaxTypeGroups(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/nexustaxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeCustomerFundingOptions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomerfundingoptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeCustomerTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticecustomertypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeFilingtypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticefilingtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticePriorities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticepriorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeReasons(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticereasons");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeResponsibilities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticeresponsibilities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeRootCauses(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticerootcauses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeStatuses(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticestatuses");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticeTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/noticetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListParameters(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/parameters");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListPermissions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/permissions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of Avalara-supported postal codes.
        /// </summary>
        /// <remarks>
        /// Retrieves the list of Avalara-supported postal codes.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListPostalCodes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/postalcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListRateTypesByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/ratetypes");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListRegions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/regions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListRegionsByCountry(String country, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/countries/{country}/regions");
            path.ApplyField("country", country);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListResourceFileTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/resourcefiletypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListSecurityRoles(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/securityroles");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListSubscriptionTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/subscriptiontypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxAuthorities(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorities");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxAuthorityForms(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthorityforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxAuthorityTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxauthoritytypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxCodes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxCodeTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxcodetypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve the full list of the Tax Forms available
        /// </summary>
        /// <remarks>
        /// Returns the full list of Avalara-supported Tax Forms
        /// This API is intended to be useful to identify all the different Tax Forms
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListTaxForms(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxforms");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxSubTypes(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxsubtypes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxTypeGroups(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/taxtypegroups");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List all defined units of measurement
        /// </summary>
        /// <remarks>
        /// List all units of measurement systems defined by Avalara.
        /// 
        /// A unit of measurement system is a method of measuring a quantity, such as distance, mass, or others.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListUnitOfMeasurement(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/definitions/unitofmeasurements");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Create one or more DistanceThreshold objects
        /// </summary>
        /// <remarks>
        /// Create one or more DistanceThreshold objects for this company.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that owns this DistanceThreshold</param>
        /// <param name="model">The DistanceThreshold object or objects you wish to create.</param>
        public AvaTaxCallResult CreateDistanceThreshold(Int32 companyId, List<CompanyDistanceThresholdModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/distancethresholds");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single DistanceThreshold object
        /// </summary>
        /// <remarks>
        /// Marks the DistanceThreshold object identified by this URL as deleted.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that owns this DistanceThreshold</param>
        /// <param name="id">The unique ID number of the DistanceThreshold object you wish to delete.</param>
        public AvaTaxCallResult DeleteDistanceThreshold(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/distancethresholds/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single DistanceThreshold
        /// </summary>
        /// <remarks>
        /// Retrieves a single DistanceThreshold object defined by this URL.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this DistanceThreshold object</param>
        /// <param name="id">The unique ID number referring to this DistanceThreshold object</param>
        public AvaTaxCallResult GetDistanceThreshold(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/distancethresholds/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve all DistanceThresholds for this company.
        /// </summary>
        /// <remarks>
        /// Lists all DistanceThreshold objects that belong to this company.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        /// </remarks>
        /// <param name="companyId">The ID of the company whose DistanceThreshold objects you wish to list.</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListDistanceThresholds(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/distancethresholds");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve all DistanceThreshold objects
        /// </summary>
        /// <remarks>
        /// Lists all DistanceThreshold objects that belong to this company.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult QueryDistanceThresholds(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/distancethresholds");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Update a DistanceThreshold object
        /// </summary>
        /// <remarks>
        /// Replace the existing DistanceThreshold object at this URL with an updated object.
        /// 
        /// A company-distance-threshold model indicates the distance between a company
        /// and the taxing borders of various countries. Distance thresholds are necessary
        /// to correctly calculate some value-added taxes.
        ///  
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company that owns this DistanceThreshold object.</param>
        /// <param name="id">The unique ID number of the DistanceThreshold object to replace.</param>
        /// <param name="model">The new DistanceThreshold object to store.</param>
        public AvaTaxCallResult UpdateDistanceThreshold(Int32 companyId, Int64 id, CompanyDistanceThresholdModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/distancethresholds/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult ApproveFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, null);
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
        public AvaTaxCallResult CancelFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}/cancel");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, null);
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
        public AvaTaxCallResult CancelFilingRequests(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Create a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only and only available for users with Compliance access
        /// A "filing request" represents information that compliance uses to file a return
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that will add the new filing calendar</param>
        /// <param name="model">Filing calendars that will be added</param>
        public AvaTaxCallResult CreateFilingCalendars(Int32 companyId, List<FilingCalendarModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateFilingRequests(Int32 companyId, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/request");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Returns a list of options for adding the specified form.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="formCode">The unique code of the form</param>
        public AvaTaxCallResult CycleSafeAdd(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/add/options");
            path.ApplyField("companyId", companyId);
            path.AddQuery("formCode", formCode);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult CycleSafeEdit(Int32 companyId, Int32 id, List<FilingCalendarEditModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Returns a list of options for expiring a filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing calendar object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        public AvaTaxCallResult CycleSafeExpiration(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/cancel/options");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult DeleteFilingCalendar(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single filing calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this filing calendar</param>
        /// <param name="id">The primary key of this filing calendar</param>
        public AvaTaxCallResult GetFilingCalendar(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingRequest(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListFilingCalendars(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListFilingRequests(Int32 companyId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult LoginVerificationRequest(LoginVerificationInputModel model)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/verify");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult LoginVerificationStatus(Int32 jobId)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars/credentials/{jobId}");
            path.ApplyField("jobId", jobId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryFilingCalendars(String filter, Int32? top, Int32? skip, String orderBy, String returnCountry, String returnRegion)
        {
            var path = new AvaTaxPath("/api/v2/filingcalendars");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            path.AddQuery("returnCountry", returnCountry);
            path.AddQuery("returnRegion", returnRegion);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryFilingRequests(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/filingrequests");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult RequestFilingCalendarUpdate(Int32 companyId, Int32 id, List<FilingRequestModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}/edit/request");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Edit existing Filing Calendar
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The unique ID of the company that owns the filing request object</param>
        /// <param name="id">The unique ID of the filing calendar object</param>
        /// <param name="model">The filing calendar model you are wishing to update with.</param>
        public AvaTaxCallResult UpdateFilingCalendar(Int32 companyId, Int32 id, FilingCalendarModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingcalendars/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult UpdateFilingRequest(Int32 companyId, Int32 id, FilingRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filingrequests/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult ApproveFilings(Int32 companyId, Int16 year, Byte month, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult ApproveFilingsCountry(Int32 companyId, Int16 year, Byte month, String country, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult ApproveFilingsCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region, ApproveFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/approve");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateReturnAdjustment(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAdjustmentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/adjust");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateReturnAugmentation(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingAugmentationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/augment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateReturnPayment(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode, List<FilingPaymentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}/payment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult DeleteReturnAdjustment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteReturnAugmentation(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteReturnPayment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
        }


        /// <summary>
        /// Retrieve worksheet checkup report for company and filing period.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="filingsId">The unique id of the worksheet.</param>
        /// <param name="companyId">The unique ID of the company that owns the worksheet.</param>
        public AvaTaxCallResult FilingsCheckupReport(Int32 filingsId, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingsId}/checkup");
            path.ApplyField("filingsId", filingsId);
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult FilingsCheckupReports(Int32 companyId, Int32 year, Int32 month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/checkup");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single attachment for a filing
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns the filings.</param>
        /// <param name="filingReturnId">The unique id of the worksheet return.</param>
        /// <param name="fileId">The unique id of the document you are downloading</param>
        public AvaTaxCallResult GetFilingAttachment(Int32 companyId, Int64 filingReturnId, Int64? fileId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{filingReturnId}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("filingReturnId", filingReturnId);
            path.AddQuery("fileId", fileId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingAttachments(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingAttachmentsTraceFile(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/attachments/tracefile");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingReturn(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilings(Int32 companyId, Int16 year, Byte month)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingsByCountry(Int32 companyId, Int16 year, Byte month, String country)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingsByCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetFilingsByReturnName(Int32 companyId, Int16 year, Byte month, String country, String region, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            path.ApplyField("formCode", formCode);
            return _client.RestCall("Get", path, null);
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
        /// <param name="filingCalendarId">The filing calendar id of the return you are trying to retrieve</param>
        public AvaTaxCallResult GetFilingsReturns(Int32 companyId, Int32? endPeriodMonth, Int32? endPeriodYear, FilingFrequencyId? frequency, FilingStatusId? status, String country, String region, Int64? filingCalendarId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/returns");
            path.ApplyField("companyId", companyId);
            path.AddQuery("endPeriodMonth", endPeriodMonth);
            path.AddQuery("endPeriodYear", endPeriodYear);
            path.AddQuery("frequency", frequency);
            path.AddQuery("status", status);
            path.AddQuery("country", country);
            path.AddQuery("region", region);
            path.AddQuery("filingCalendarId", filingCalendarId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult RebuildFilings(Int32 companyId, Int16 year, Byte month, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult RebuildFilingsByCountry(Int32 companyId, Int16 year, Byte month, String country, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Rebuild a set of filings for the specified company in the given filing period, country and region.
        /// </summary>
        /// <remarks>
        /// This API is available by invitation only.audit.CheckAuthorizationReturns(null, companyId);
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
        public AvaTaxCallResult RebuildFilingsByCountryRegion(Int32 companyId, Int16 year, Byte month, String country, String region, RebuildFilingsModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/{year}/{month}/{country}/{region}/rebuild");
            path.ApplyField("companyId", companyId);
            path.ApplyField("year", year);
            path.ApplyField("month", month);
            path.ApplyField("country", country);
            path.ApplyField("region", region);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult UpdateReturnAdjustment(Int32 companyId, Int64 id, FilingAdjustmentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/adjust/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult UpdateReturnAugmentation(Int32 companyId, Int64 id, FilingAugmentationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/augment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult UpdateReturnPayment(Int32 companyId, Int64 id, FilingPaymentModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/filings/payment/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult RequestFreeTrial(FreeTrialRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/freetrials/request");
            return _client.RestCall("Post", path, model);
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
        /// <param name="region">Name or ISO 3166 code identifying the region within the country.
        /// 
        /// This field supports many different region identifiers:
        ///  * Two and three character ISO 3166 region codes
        ///  * Fully spelled out names of the region in ISO supported languages
        ///  * Common alternative spellings for many regions
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListRegions`.</param>
        /// <param name="postalCode">The postal code of the location.</param>
        /// <param name="country">Name or ISO 3166 code identifying the country.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.</param>
        public AvaTaxCallResult TaxRatesByAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/byaddress");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// FREE API - Sales tax rates for a specified country and postal code. This API is only available for US postal codes.
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// This API is only available for a US postal codes.
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
        /// <param name="country">Name or ISO 3166 code identifying the country.
        /// 
        /// This field supports many different country identifiers:
        ///  * Two character ISO 3166 codes
        ///  * Three character ISO 3166 codes
        ///  * Fully spelled out names of the country in ISO supported languages
        ///  * Common alternative spellings for many countries
        /// 
        /// For a full list of all supported codes and names, please see the Definitions API `ListCountries`.</param>
        /// <param name="postalCode">The postal code of the location.</param>
        public AvaTaxCallResult TaxRatesByPostalCode(String country, String postalCode)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/bypostalcode");
            path.AddQuery("country", country);
            path.AddQuery("postalCode", postalCode);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ActivateFundingRequest(Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}/widget");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult FundingRequestStatus(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/fundingrequests/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Create a new item
        /// </summary>
        /// <remarks>
        /// Creates one or more new item objects attached to this company.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="model">The item you wish to create.</param>
        public AvaTaxCallResult CreateItems(Int32 companyId, List<ItemModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single item
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item.</param>
        /// <param name="id">The ID of the item you wish to delete.</param>
        public AvaTaxCallResult DeleteItem(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
        }


        /// <summary>
        /// Retrieve a single item
        /// </summary>
        /// <remarks>
        /// Get the item object identified by this URL.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this item object</param>
        /// <param name="id">The primary key of this item</param>
        public AvaTaxCallResult GetItem(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve items for this company
        /// </summary>
        /// <remarks>
        /// List all items defined for the current company.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Attributes
        /// </remarks>
        /// <param name="companyId">The ID of the company that defined these items</param>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListItemsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve all items
        /// </summary>
        /// <remarks>
        /// Get multiple item objects across all companies.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Attributes
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">A comma separated list of additional data to retrieve.</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult QueryItems(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/items");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Update a single item
        /// </summary>
        /// <remarks>
        /// Replace the existing `Item` object at this URL with an updated object.
        /// 
        /// Items are a way of separating your tax calculation process from your tax configuration details. If you choose, you
        /// can provide `itemCode` values for each `CreateTransaction()` API call rather than specifying tax codes, parameters, descriptions,
        /// and other data fields. AvaTax will automatically look up each `itemCode` and apply the correct tax codes and parameters
        /// from the item table instead. This allows your CreateTransaction call to be as simple as possible, and your tax compliance
        /// team can manage your item catalog and adjust the tax behavior of items without having to modify your software.
        /// 
        /// All data from the existing object will be replaced with data in the object you PUT. 
        /// To set a field's value to null, you may either set its value to null or omit that field from the object you post.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this item belongs to.</param>
        /// <param name="id">The ID of the item you wish to update</param>
        /// <param name="model">The item object you wish to update.</param>
        public AvaTaxCallResult UpdateItem(Int32 companyId, Int64 id, ItemModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/items/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult CreateJurisdictionOverrides(Int32 accountId, List<JurisdictionOverrideModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single override
        /// </summary>
        /// <remarks>
        /// Marks the item object at this URL as deleted.
        /// </remarks>
        /// <param name="accountId">The ID of the account that owns this override</param>
        /// <param name="id">The ID of the override you wish to delete</param>
        public AvaTaxCallResult DeleteJurisdictionOverride(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetJurisdictionOverride(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListJurisdictionOverridesByAccount(Int32 accountId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryJurisdictionOverrides(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/jurisdictionoverrides");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateJurisdictionOverride(Int32 accountId, Int32 id, JurisdictionOverrideModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/jurisdictionoverrides/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
        }


        /// <summary>
        /// Create a new location
        /// </summary>
        /// <remarks>
        /// Create one or more new location objects attached to this company.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="model">The location you wish to create.</param>
        public AvaTaxCallResult CreateLocations(Int32 companyId, List<LocationModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single location
        /// </summary>
        /// <remarks>
        /// Mark the location object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this location.</param>
        /// <param name="id">The ID of the location you wish to delete.</param>
        public AvaTaxCallResult DeleteLocation(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetLocation(Int32 companyId, Int32 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListLocationsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryLocations(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/locations");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateLocation(Int32 companyId, Int32 id, LocationModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult ValidateLocation(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/validate");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Adjust a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Adjusts the current MultiDocument transaction uniquely identified by this URL.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// When you adjust a transaction, that transaction's status is recorded as `Adjusted`. 
        /// 
        /// Both the revisions will be available for retrieval based on their code and ID numbers. Only transactions in Committed status can be reported on a tax filing by Avalara's Managed Returns Service.
        /// 
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are considered locked and are no longer available for adjustments.
        /// </remarks>
        /// <param name="code">The transaction code for this MultiDocument transaction</param>
        /// <param name="type">The transaction type for this MultiDocument transaction</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        /// <param name="model">The adjust request you wish to execute</param>
        public AvaTaxCallResult AdjustMultiDocumentTransaction(String code, DocumentType type, String include, AdjustMultiDocumentModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{code}/type/{type}/adjust");
            path.ApplyField("code", code);
            path.ApplyField("type", type);
            path.AddQuery("include", include);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Get audit information about a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a MultiDocument transaction stored in AvaTax.
        ///  
        /// The audit API retrieves audit information related to a specific MultiDocument transaction. This audit 
        /// information includes the following:
        /// 
        /// * The `code` of the MultiDocument transaction
        /// * The `type` of the MultiDocument transaction
        /// * The server timestamp representing the exact server time when the transaction was created
        /// * The server duration - how long it took to process this transaction
        /// * Whether exact API call details were logged
        /// * A reconstructed API call showing what the original create call looked like
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="code">The transaction code for this MultiDocument transaction</param>
        /// <param name="type">The transaction type for this MultiDocument transaction</param>
        public AvaTaxCallResult AuditMultiDocumentTransaction(String code, DocumentType type)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{code}/type/{type}/audit");
            path.ApplyField("code", code);
            path.ApplyField("type", type);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Commit a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Marks a list of transactions by changing its status to `Committed`.
        /// 
        /// Transactions that are committed are available to be reported to a tax authority by Avalara Managed Returns.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// Any changes made to a committed transaction will generate a transaction history.
        /// </remarks>
        /// <param name="model">The commit request you wish to execute</param>
        public AvaTaxCallResult CommitMultiDocumentTransaction(CommitMultiDocumentModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/commit");
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Create a new MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Records a new MultiDocument transaction in AvaTax.
        /// 
        /// A traditional transaction requires exactly two parties: a seller and a buyer. MultiDocument transactions can
        /// involve a marketplace of vendors, each of which contributes some portion of the final transaction. Within
        /// a MultiDocument transaction, each individual buyer and seller pair are matched up and converted to a separate
        /// document. This separation of documents allows each seller to file their taxes separately.
        /// 
        /// This API will report an error if you attempt to create a transaction when one already exists with the specified `code`.
        /// If you would like the API to automatically update the transaction when it already exists, please set the `allowAdjust`
        /// value to `true`.
        /// 
        /// To generate a refund for a transaction, use the `RefundTransaction` API.
        /// 
        /// The field `type` identifies the kind of transaction - for example, a sale, purchase, or refund. If you do not specify
        /// a `type` value, you will receive an estimate of type `SalesOrder`, which will not be recorded.
        /// 
        /// The origin and destination locations for a transaction must be identified by either address or geocode. For address-based transactions, please
        /// provide addresses in the fields `line`, `city`, `region`, `country` and `postalCode`. For geocode-based transactions, please provide the geocode
        /// information in the fields `latitude` and `longitude`. If either `latitude` or `longitude` or both are null, the transaction will be calculated
        /// using the best available address location information.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// * ForceTimeout - Simulates a timeout. This adds a 30 second delay and error to your API call. This can be used to test your code to ensure it can respond correctly in the case of a dropped connection.
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">the multi document transaction model</param>
        public AvaTaxCallResult CreateMultiDocumentTransaction(String include, CreateMultiDocumentModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument");
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Retrieve a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Get the current MultiDocument transaction identified by this URL.
        /// 
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        public AvaTaxCallResult GetMultiDocumentTransactionByCodeAndType(String code, DocumentType type, String include)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{code}/type/{type}");
            path.ApplyField("code", code);
            path.ApplyField("type", type);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve a MultiDocument transaction by ID
        /// </summary>
        /// <remarks>
        /// Get the unique MultiDocument transaction identified by this URL.
        /// 
        /// A traditional transaction requires exactly two parties: a seller and a buyer. MultiDocument transactions can
        /// involve a marketplace of vendors, each of which contributes some portion of the final transaction. Within
        /// a MultiDocument transaction, each individual buyer and seller pair are matched up and converted to a separate
        /// document. This separation of documents allows each seller to file their taxes separately.
        /// 
        /// This endpoint retrieves the exact transaction identified by this ID number even if that transaction was later adjusted
        /// by using the `AdjustTransaction` endpoint.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="id">The unique ID number of the MultiDocument transaction to retrieve</param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        public AvaTaxCallResult GetMultiDocumentTransactionById(Int64 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve all MultiDocument transactions
        /// </summary>
        /// <remarks>
        /// List all MultiDocument transactions within this account.
        /// 
        /// This endpoint is limited to returning 1,000 MultiDocument transactions at a time. To retrieve more than 1,000 MultiDocument
        /// transactions, please use the pagination features of the API.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// </remarks>
        /// <param name="filter">A filter statement to identify specific records to retrieve. For more information on filtering, see [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .</param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="top">If nonzero, return no more than this number of results. Used with $skip to provide pagination for large datasets.</param>
        /// <param name="skip">If nonzero, skip this number of results before returning data. Used with $top to provide pagination for large datasets.</param>
        /// <param name="orderBy">A comma separated list of sort statements in the format `(fieldname) [ASC|DESC]`, for example `id ASC`.</param>
        public AvaTaxCallResult ListMultiDocumentTransactions(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Create a refund for a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Create a refund for a MultiDocument transaction.
        /// 
        /// A traditional transaction requires exactly two parties: a seller and a buyer. MultiDocument transactions can
        /// involve a marketplace of vendors, each of which contributes some portion of the final transaction. Within
        /// a MultiDocument transaction, each individual buyer and seller pair are matched up and converted to a separate
        /// document. This separation of documents allows each seller to file their taxes separately.
        /// 
        /// The `RefundTransaction` API allows you to quickly and easily create a `ReturnInvoice` representing a refund
        /// for a previously created `SalesInvoice` transaction. You can choose to create a full or partial refund, and
        /// specify individual line items from the original sale for refund.
        /// 
        /// The `RefundTransaction` API ensures that the tax amount you refund to the customer exactly matches the tax that
        /// was calculated during the original transaction, regardless of any changes to your company's configuration, rules,
        /// nexus, or any other setting.
        /// 
        /// This API is intended to be a shortcut to allow you to quickly and accurately generate a refund for the following 
        /// common refund scenarios:
        /// 
        /// * A full refund of a previous sale
        /// * Refunding the tax that was charged on a previous sale, when the customer provides an exemption certificate after the purchase
        /// * Refunding one or more items (lines) from a previous sale
        /// * Granting a customer a percentage refund of a previous sale
        /// 
        /// For more complex scenarios than the ones above, please use `CreateTransaction` with document type `ReturnInvoice` to
        /// create a custom refund transaction.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
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
        /// <param name="code">The code of this MultiDocument transaction</param>
        /// <param name="type">The type of this MultiDocument transaction</param>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">Information about the refund to create</param>
        public AvaTaxCallResult RefundMultiDocumentTransaction(String code, DocumentType type, String include, RefundTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{code}/type/{type}/refund");
            path.ApplyField("code", code);
            path.ApplyField("type", type);
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Verify a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Verifies that the MultiDocument transaction uniquely identified by this URL matches certain expected values.
        /// 
        /// If the transaction does not match these expected values, this API will return an error code indicating which value did not match.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="model">Information from your accounting system to verify against this MultiDocument transaction as it is stored in AvaTax</param>
        public AvaTaxCallResult VerifyMultiDocumentTransaction(VerifyMultiDocumentModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/verify");
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Void a MultiDocument transaction
        /// </summary>
        /// <remarks>
        /// Voids the current transaction uniquely identified by this URL.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// When you void a transaction, that transaction's status is recorded as `DocVoided`.
        /// 
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns Service are considered `locked`,
        /// and they are no longer available to be voided.
        /// </remarks>
        /// <param name="code">The transaction code for this MultiDocument transaction</param>
        /// <param name="type">The transaction type for this MultiDocument transaction</param>
        /// <param name="model">The void request you wish to execute</param>
        public AvaTaxCallResult VoidMultiDocumentTransaction(String code, DocumentType type, VoidTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/multidocument/{code}/type/{type}/void");
            path.ApplyField("code", code);
            path.ApplyField("type", type);
            return _client.RestCall("Post", path, model);
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
        /// Please allow 1 minute before start using the created Nexus in your transactions.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="model">The nexus you wish to create.</param>
        public AvaTaxCallResult CreateNexus(Int32 companyId, List<NexusModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single nexus
        /// </summary>
        /// <remarks>
        /// Marks the existing nexus object at this URL as deleted.
        /// Please allow 1 minute to stop collecting tax in your transaction on the deleted Nexus.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this nexus.</param>
        /// <param name="id">The ID of the nexus you wish to delete.</param>
        public AvaTaxCallResult DeleteNexus(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetNexus(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNexusByFormCode(Int32 companyId, String formCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/byform/{formCode}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("formCode", formCode);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNexusByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryNexus(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/nexus");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// Please allow 1 minute to start seeing your updated Nexus taking effect on your transactions.
        /// </remarks>
        /// <param name="companyId">The ID of the company that this nexus belongs to.</param>
        /// <param name="id">The ID of the nexus you wish to update</param>
        /// <param name="model">The nexus object you wish to update.</param>
        public AvaTaxCallResult UpdateNexus(Int32 companyId, Int32 id, NexusModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/nexus/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult CreateNoticeComment(Int32 companyId, Int32 id, List<NoticeCommentModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateNoticeFinanceDetails(Int32 companyId, Int32 id, List<NoticeFinanceModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateNoticeResponsibilities(Int32 companyId, Int32 id, List<NoticeResponsibilityDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateNoticeRootCauses(Int32 companyId, Int32 id, List<NoticeRootCauseDetailModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateNotices(Int32 companyId, List<NoticeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult DeleteNotice(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteResponsibilities(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/responsibilities/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteRootCauses(Int32 companyId, Int32 noticeId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{noticeId}/rootcauses/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("noticeId", noticeId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DownloadNoticeAttachment(Int32 companyId, Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/{id}/attachment");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNotice(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNoticeComments(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/comments");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNoticeFinanceDetails(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/financedetails");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNoticeResponsibilities(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/responsibilities");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetNoticeRootCauses(Int32 id, Int32 companyId)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}/rootcauses");
            path.ApplyField("id", id);
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListNoticesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryNotices(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/notices");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateNotice(Int32 companyId, Int32 id, NoticeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult UploadAttachment(Int32 companyId, ResourceFileUploadRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/notices/files/attachment");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
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
        /// onto the AvaTax website and reviewing terms and conditions online.
        /// </remarks>
        /// <param name="model">Information about the account you wish to create and the selected product offerings.</param>
        public AvaTaxCallResult RequestNewAccount(NewAccountRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/request");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult ChangePassword(PasswordChangeModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords");
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult CreateAccount(AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateSubscriptions(Int32 accountId, List<SubscriptionModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult DeleteAccount(Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteSubscription(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult DeleteUser(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult QueryAccounts(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ResetPassword(Int32 userId, SetPasswordModel model)
        {
            var path = new AvaTaxPath("/api/v2/passwords/{userId}/reset");
            path.ApplyField("userId", userId);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult UpdateAccount(Int32 id, AccountModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult UpdateSubscription(Int32 accountId, Int32 id, SubscriptionModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
        }


        /// <summary>
        /// Download a report
        /// </summary>
        /// <remarks>
        /// This API downloads the file associated with a report.
        /// 
        /// If the report is not yet complete, you will receive a `ReportNotFinished` error. To check if a report is complete,
        /// use the `GetReport` API.
        /// 
        /// Reports are run as asynchronous report tasks on the server. When complete, the report file will be available for download
        /// for up to 30 days after completion. To run an asynchronous report, you should follow these steps:
        /// 
        /// * Begin a report by calling the report's Initiate API. There is a separate initiate API call for each report type.
        /// * In the result of the Initiate API, you receive back a report's `id` value.
        /// * Check the status of a report by calling `GetReport` and passing in the report's `id` value.
        /// * When a report's status is `Completed`, call `DownloadReport` to retrieve the file.
        /// 
        /// This API works for all report types.
        /// </remarks>
        /// <param name="id">The unique ID number of this report</param>
        public AvaTaxCallResult DownloadReport(Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/reports/{id}/attachment");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Intiate and download an ExportDocumentLine report
        /// </summary>
        /// <remarks>
        /// This API is deprecated. 
        /// 
        /// Please use the asynchronous reports APIs:
        /// 
        /// * Begin a report by calling the report's Initiate API. There is a separate initiate API call for each report type.
        /// * In the result of the Initiate API, you receive back a report's `id` value.
        /// * Check the status of a report by calling `GetReport` and passing in the report's `id` value.
        /// * When a report's status is `Completed`, call `DownloadReport` to retrieve the file.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company to report on.</param>
        /// <param name="model">Options that may be configured to customize the report.</param>
        public AvaTaxCallResult ExportDocumentLine(Int32 companyId, ExportDocumentLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/reports/exportdocumentline");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Retrieve a single report
        /// </summary>
        /// <remarks>
        /// Retrieve a single report by its unique ID number.
        /// 
        /// Reports are run as asynchronous report tasks on the server. When complete, the report file will be available for download
        /// for up to 30 days after completion. To run an asynchronous report, you should follow these steps:
        /// 
        /// * Begin a report by calling the report's Initiate API. There is a separate initiate API call for each report type.
        /// * In the result of the Initiate API, you receive back a report's `id` value.
        /// * Check the status of a report by calling `GetReport` and passing in the report's `id` value.
        /// * When a report's status is `Completed`, call `DownloadReport` to retrieve the file.
        /// 
        /// This API call returns information about any report type.
        /// </remarks>
        /// <param name="id">The unique ID number of the report to retrieve</param>
        public AvaTaxCallResult GetReport(Int64 id)
        {
            var path = new AvaTaxPath("/api/v2/reports/{id}");
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Initiate an ExportDocumentLine report task
        /// </summary>
        /// <remarks>
        /// Begins running an `ExportDocumentLine` report task and returns the identity of the report.
        /// 
        /// Reports are run as asynchronous report tasks on the server. When complete, the report file will be available for download
        /// for up to 30 days after completion. To run an asynchronous report, you should follow these steps:
        /// 
        /// * Begin a report by calling the report's Initiate API. There is a separate initiate API call for each report type.
        /// * In the result of the Initiate API, you receive back a report's `id` value.
        /// * Check the status of a report by calling `GetReport` and passing in the report's `id` value.
        /// * When a report's status is `Completed`, call `DownloadReport` to retrieve the file.
        /// 
        /// The `ExportDocumentLine` report produces information about invoice lines recorded within your account.
        /// </remarks>
        /// <param name="companyId">The unique ID number of the company to report on.</param>
        /// <param name="model">Options that may be configured to customize the report.</param>
        public AvaTaxCallResult InitiateExportDocumentLineReport(Int32 companyId, ExportDocumentLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/reports/exportdocumentline/initiate");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// List all report tasks for account
        /// </summary>
        /// <remarks>
        /// List all report tasks for your account.
        /// 
        /// Reports are run as asynchronous report tasks on the server. When complete, the report file will be available for download
        /// for up to 30 days after completion. To run an asynchronous report, you should follow these steps:
        /// 
        /// * Begin a report by calling the report's Initiate API. There is a separate initiate API call for each report type.
        /// * In the result of the Initiate API, you receive back a report's `id` value.
        /// * Check the status of a report by calling `GetReport` and passing in the report's `id` value.
        /// * When a report's status is `Completed`, call `DownloadReport` to retrieve the file.
        /// 
        /// This API call returns information about all report types across your entire account.
        /// </remarks>
        public AvaTaxCallResult ListReports()
        {
            var path = new AvaTaxPath("/api/v2/reports");
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult CreateSettings(Int32 companyId, List<SettingModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single setting
        /// </summary>
        /// <remarks>
        /// Mark the setting object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this setting.</param>
        /// <param name="id">The ID of the setting you wish to delete.</param>
        public AvaTaxCallResult DeleteSetting(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetSetting(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListSettingsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QuerySettings(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/settings");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateSetting(Int32 companyId, Int32 id, SettingModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/settings/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult GetSubscription(Int32 accountId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions/{id}");
            path.ApplyField("accountId", accountId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListSubscriptionsByAccount(Int32 accountId, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/subscriptions");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QuerySubscriptions(String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/subscriptions");
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult CreateTaxCodes(Int32 companyId, List<TaxCodeModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single tax code
        /// </summary>
        /// <remarks>
        /// Marks the existing TaxCode object at this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax code.</param>
        /// <param name="id">The ID of the tax code you wish to delete.</param>
        public AvaTaxCallResult DeleteTaxCode(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetTaxCode(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxCodesByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryTaxCodes(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxcodes");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateTaxCode(Int32 companyId, Int32 id, TaxCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxcodes/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        /// 
        /// NOTE: This API does not work for Tennessee tax holiday scenarios.
        /// </remarks>
        /// <param name="model">Parameters about the desired file format and report format, specifying which company, locations and TaxCodes to include.</param>
        public AvaTaxCallResult BuildTaxContentFile(PointOfSaleDataRequestModel model)
        {
            var path = new AvaTaxPath("/api/v2/pointofsaledata/build");
            return _client.RestCall("Post", path, model);
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
        /// 
        /// NOTE: This API does not work for Tennessee tax holiday scenarios.
        /// </remarks>
        /// <param name="companyId">The ID number of the company that owns this location.</param>
        /// <param name="id">The ID number of the location to retrieve point-of-sale data.</param>
        /// <param name="date">The date for which point-of-sale data would be calculated (today by default)</param>
        /// <param name="format">The format of the file (JSON by default)</param>
        /// <param name="partnerId">If specified, requests a custom partner-formatted version of the file.</param>
        /// <param name="includeJurisCodes">When true, the file will include jurisdiction codes in the result.</param>
        public AvaTaxCallResult BuildTaxContentFileForLocation(Int32 companyId, Int32 id, DateTime? date, PointOfSaleFileType? format, PointOfSalePartnerId? partnerId, Boolean? includeJurisCodes)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/locations/{id}/pointofsaledata");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            path.AddQuery("date", date);
            path.AddQuery("format", format);
            path.AddQuery("partnerId", partnerId);
            path.AddQuery("includeJurisCodes", includeJurisCodes);
            return _client.RestCall("Get", path, null);
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
        /// <param name="date">The date for which point-of-sale data would be calculated (today by default). Example input: 2016-12-31</param>
        public AvaTaxCallResult DownloadTaxRatesByZipCode(DateTime date)
        {
            var path = new AvaTaxPath("/api/v2/taxratesbyzipcode/download/{date}");
            path.ApplyField("date", date);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult CreateTaxRules(Int32 companyId, List<TaxRuleModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single tax rule
        /// </summary>
        /// <remarks>
        /// Mark the TaxRule identified by this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this tax rule.</param>
        /// <param name="id">The ID of the tax rule you wish to delete.</param>
        public AvaTaxCallResult DeleteTaxRule(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetTaxRule(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListTaxRules(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryTaxRules(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/taxrules");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateTaxRule(Int32 companyId, Int32 id, TaxRuleModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/taxrules/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
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
        ///  You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
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
        public AvaTaxCallResult AddLines(String include, AddTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/add");
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult AdjustTransaction(String companyCode, String transactionCode, AdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/adjust");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Get audit information about a transaction
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The `AuditTransaction` API retrieves audit information related to a specific transaction. This audit 
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
        public AvaTaxCallResult AuditTransaction(String companyCode, String transactionCode)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Get audit information about a transaction
        /// </summary>
        /// <remarks>
        /// Retrieve audit information about a transaction stored in AvaTax.
        ///  
        /// The `AuditTransaction` API retrieves audit information related to a specific transaction. This audit 
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
        public AvaTaxCallResult AuditTransactionWithType(String companyCode, String transactionCode, DocumentType documentType)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}/audit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult BulkLockTransaction(BulkLockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/lock");
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Change a transaction's code
        /// </summary>
        /// <remarks>
        /// Renames a transaction uniquely identified by this URL by changing its `code` value.
        /// 
        /// This API is available as long as the transaction is in `saved` or `posted` status. When a transaction
        /// is `committed`, it can be modified by using the [AdjustTransaction](https://developer.avalara.com/api-reference/avatax/rest/v2/methods/Transactions/AdjustTransaction/) method.
        /// 
        /// After this API call succeeds, the transaction will have a new URL matching its new `code`.
        /// 
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to change</param>
        /// <param name="documentType">(Optional): The document type of the transaction to change document code. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The code change request you wish to execute</param>
        public AvaTaxCallResult ChangeTransactionCode(String companyCode, String transactionCode, DocumentType? documentType, ChangeTransactionCodeModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/changecode");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Commit a transaction for reporting
        /// </summary>
        /// <remarks>
        /// Marks a transaction by changing its status to `Committed`.
        /// 
        /// Transactions that are committed are available to be reported to a tax authority by Avalara Managed Returns.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// Any changes made to a committed transaction will generate a transaction history.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to commit</param>
        /// <param name="documentType">(Optional): The document type of the transaction to commit. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The commit request you wish to execute</param>
        public AvaTaxCallResult CommitTransaction(String companyCode, String transactionCode, DocumentType? documentType, CommitTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/commit");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Create or adjust a transaction
        /// </summary>
        /// <remarks>
        /// Records a new transaction or adjust an existing transaction in AvaTax.
        /// 
        /// The `CreateOrAdjustTransaction` endpoint is used to create a new transaction or update an existing one. This API
        /// can help you create an idempotent service that creates transactions 
        /// If there exists a transaction identified by code, the original transaction will be adjusted by using the meta data 
        /// in the input transaction.
        /// 
        /// The `CreateOrAdjustTransaction` API cannot modify any transaction that has been reported to a tax authority using 
        /// the Avalara Managed Returns Service or any other tax filing service. If you call this API to attempt to modify
        /// a transaction that has been reported on a tax filing, you will receive the error `CannotModifyLockedTransaction`.
        /// 
        /// To generate a refund for a transaction, use the `RefundTransaction` API.
        ///  
        /// If you don't specify the field `type` in your request, you will get an estimate of type `SalesOrder`, which will not be recorded in the database.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// * ForceTimeout - Simulates a timeout. This adds a 30 second delay and error to your API call. This can be used to test your code to ensure it can respond correctly in the case of a dropped connection.
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create or adjust</param>
        public AvaTaxCallResult CreateOrAdjustTransaction(String include, CreateOrAdjustTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/createoradjust");
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <remarks>
        /// Records a new transaction in AvaTax.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// The `CreateTransaction` endpoint uses the tax profile of your company to identify the correct tax rules
        /// and rates to apply to all line items in this transaction. The end result will be the total tax calculated by AvaTax based on your
        /// company's configuration and the data provided in this API call.
        /// 
        /// The `CreateTransaction` API will report an error if a committed transaction already exists with the same `code`. To
        /// avoid this error, use the `CreateOrAdjustTransaction` API - it will create the transaction if it does not exist, or
        /// update it if it does exist.
        /// 
        /// To generate a refund for a transaction, use the `RefundTransaction` API.
        /// 
        /// The field `type` identifies the kind of transaction - for example, a sale, purchase, or refund. If you do not specify
        /// a `type` value, you will receive an estimate of type `SalesOrder`, which will not be recorded.
        /// 
        /// The origin and destination locations for a transaction must be identified by either address or geocode. For address-based transactions, please
        /// provide addresses in the fields `line`, `city`, `region`, `country` and `postalCode`. For geocode-based transactions, please provide the geocode
        /// information in the fields `latitude` and `longitude`. If either `latitude` or `longitude` or both are null, the transaction will be calculated
        /// using the best available address location information.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        /// * SummaryOnly (omit lines and details - reduces API response size)
        /// * LinesOnly (omit details - reduces API response size)
        /// * ForceTimeout - Simulates a timeout. This adds a 30 second delay and error to your API call. This can be used to test your code to ensure it can respond correctly in the case of a dropped connection.
        ///  
        /// If you omit the `$include` parameter, the API will assume you want `Summary,Addresses`.
        /// </remarks>
        /// <param name="include">Specifies objects to include in the response after transaction is created</param>
        /// <param name="model">The transaction you wish to create</param>
        public AvaTaxCallResult CreateTransaction(String include, CreateTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/create");
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
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
        ///  You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
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
        public AvaTaxCallResult DeleteLines(String include, RemoveTransactionLineModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/transactions/lines/delete");
            path.AddQuery("$include", include);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Retrieve a single transaction by code
        /// </summary>
        /// <remarks>
        /// Get the current `SalesInvoice` transaction identified by this URL.
        /// 
        /// To fetch other kinds of transactions, use `GetTransactionByCodeAndType`.
        /// 
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code.
        /// 
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
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public AvaTaxCallResult GetTransactionByCode(String companyCode, String transactionCode, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single transaction by code
        /// </summary>
        /// <remarks>
        /// Get the current transaction identified by this URL.
        /// 
        /// If this transaction was adjusted, the return value of this API will be the current transaction with this code.
        /// 
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
        /// <param name="transactionCode">The transaction code to retrieve</param>
        /// <param name="documentType">The transaction type to retrieve</param>
        /// <param name="include">Specifies objects to include in this fetch call</param>
        public AvaTaxCallResult GetTransactionByCodeAndType(String companyCode, String transactionCode, DocumentType documentType, String include)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/types/{documentType}");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.ApplyField("documentType", documentType);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve a single transaction by ID
        /// </summary>
        /// <remarks>
        /// Get the unique transaction identified by this URL.
        /// 
        /// This endpoint retrieves the exact transaction identified by this ID number even if that transaction was later adjusted
        /// by using the `AdjustTransaction` endpoint.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
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
        public AvaTaxCallResult GetTransactionById(Int64 id, String include)
        {
            var path = new AvaTaxPath("/api/v2/transactions/{id}");
            path.ApplyField("id", id);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// Retrieve all transactions
        /// </summary>
        /// <remarks>
        /// List all transactions attached to this company.
        /// 
        /// This endpoint is limited to returning 1,000 transactions at a time maximum.
        /// 
        /// When listing transactions, you must specify a `date` range filter. If you do not specify a `$filter` that includes a `date` field
        /// criteria, the query will default to looking at only those transactions with `date` in the past 30 days.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// Search for specific objects using the criteria in the `$filter` parameter; full documentation is available on [Filtering in REST](http://developer.avalara.com/avatax/filtering-in-rest/) .
        /// Paginate your results using the `$top`, `$skip`, and `$orderby` parameters.
        /// 
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
        public AvaTaxCallResult ListTransactionsByCompany(String companyCode, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions");
            path.ApplyField("companyCode", companyCode);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to lock</param>
        /// <param name="documentType">(Optional): The document type of the transaction to lock. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The lock request you wish to execute</param>
        public AvaTaxCallResult LockTransaction(String companyCode, String transactionCode, DocumentType? documentType, LockTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/lock");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
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
        /// The `RefundTransaction` API ensures that the tax amount you refund to the customer exactly matches the tax that
        /// was calculated during the original transaction, regardless of any changes to your company's configuration, rules,
        /// nexus, or any other setting.
        /// 
        /// This API is intended to be a shortcut to allow you to quickly and accurately generate a refund for the following 
        /// common refund scenarios:
        /// 
        /// * A full refund of a previous sale
        /// * Refunding the tax that was charged on a previous sale, when the customer provides an exemption certificate after the purchase
        /// * Refunding one or more items (lines) from a previous sale
        /// * Granting a customer a percentage refund of a previous sale
        /// 
        /// For more complex scenarios than the ones above, please use `CreateTransaction` with document type `ReturnInvoice` to
        /// create a custom refund transaction.
        /// 
        /// You may specify one or more of the following values in the `$include` parameter to fetch additional nested data, using commas to separate multiple values:
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
        /// <param name="documentType">(Optional): The document type of the transaction to refund. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">Information about the refund to create</param>
        public AvaTaxCallResult RefundTransaction(String companyCode, String transactionCode, String include, DocumentType? documentType, RefundTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/refund");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("$include", include);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Perform multiple actions on a transaction
        /// </summary>
        /// <remarks>
        /// Performs one or more actions against the current transaction uniquely identified by this URL.
        /// 
        /// The `SettleTransaction` API call can perform the work of `ChangeCode`, `VerifyTransaction`, and `CommitTransaction`.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// This API is available for users who want to execute more than one action at a time.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="documentType">(Optional): The document type of the transaction to settle. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The data from an external system to reconcile against AvaTax</param>
        public AvaTaxCallResult SettleTransaction(String companyCode, String transactionCode, DocumentType? documentType, SettleTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/settle");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Verify a transaction
        /// </summary>
        /// <remarks>
        /// Verifies that the transaction uniquely identified by this URL matches certain expected values.
        /// 
        /// If the transaction does not match these expected values, this API will return an error code indicating which value did not match.
        /// 
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to settle</param>
        /// <param name="documentType">(Optional): The document type of the transaction to verify. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The data from an external system to reconcile against AvaTax</param>
        public AvaTaxCallResult VerifyTransaction(String companyCode, String transactionCode, DocumentType? documentType, VerifyTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/verify");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Void a transaction
        /// </summary>
        /// <remarks>
        /// Voids the current transaction uniquely identified by this URL.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// 
        /// When you void a transaction, that transaction's status is recorded as `DocVoided`.
        /// 
        /// If you have more than one document with the same `code`, specify the `documentType` parameter to choose between them.
        /// 
        /// Transactions that have been previously reported to a tax authority by Avalara Managed Returns are no longer available to be voided.
        /// </remarks>
        /// <param name="companyCode">The company code of the company that recorded this transaction</param>
        /// <param name="transactionCode">The transaction code to void</param>
        /// <param name="documentType">(Optional): The document type of the transaction to void. If not provided, the default is SalesInvoice.</param>
        /// <param name="model">The void request you wish to execute</param>
        public AvaTaxCallResult VoidTransaction(String companyCode, String transactionCode, DocumentType? documentType, VoidTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyCode}/transactions/{transactionCode}/void");
            path.ApplyField("companyCode", companyCode);
            path.ApplyField("transactionCode", transactionCode);
            path.AddQuery("documentType", documentType);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult CreateUPCs(Int32 companyId, List<UPCModel> model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            return _client.RestCall("Post", path, model);
        }


        /// <summary>
        /// Delete a single UPC
        /// </summary>
        /// <remarks>
        /// Marks the UPC object identified by this URL as deleted.
        /// </remarks>
        /// <param name="companyId">The ID of the company that owns this UPC.</param>
        /// <param name="id">The ID of the UPC you wish to delete.</param>
        public AvaTaxCallResult DeleteUPC(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Delete", path, null);
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
        public AvaTaxCallResult GetUPC(Int32 companyId, Int32 id)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListUPCsByCompany(Int32 companyId, String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs");
            path.ApplyField("companyId", companyId);
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryUPCs(String filter, String include, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/upcs");
            path.AddQuery("$filter", filter);
            path.AddQuery("$include", include);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateUPC(Int32 companyId, Int32 id, UPCModel model)
        {
            var path = new AvaTaxPath("/api/v2/companies/{companyId}/upcs/{id}");
            path.ApplyField("companyId", companyId);
            path.ApplyField("id", id);
            return _client.RestCall("Put", path, model);
        }


        /// <summary>
        /// Create new users
        /// </summary>
        /// <remarks>
        /// Create one or more new user objects attached to this account.
        /// 
        /// A user represents one person with access privileges to make API calls and work with a specific account.
        /// 
        /// Users who are account administrators or company users are permitted to create user records to invite
        /// additional team members to work with AvaTax.
        /// 
        /// A newly created user will receive an email inviting them to create their password. This means that you
        /// must provide a valid email address for all user accounts created.
        /// </remarks>
        /// <param name="accountId">The unique ID number of the account where these users will be created.</param>
        /// <param name="model">The user or array of users you wish to create.</param>
        public AvaTaxCallResult CreateUsers(Int32 accountId, List<UserModel> model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Post", path, model);
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
        public AvaTaxCallResult GetUser(Int32 id, Int32 accountId, String include)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult GetUserEntitlements(Int32 id, Int32 accountId)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}/entitlements");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult ListUsersByAccount(Int32 accountId, String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users");
            path.ApplyField("accountId", accountId);
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult QueryUsers(String include, String filter, Int32? top, Int32? skip, String orderBy)
        {
            var path = new AvaTaxPath("/api/v2/users");
            path.AddQuery("$include", include);
            path.AddQuery("$filter", filter);
            path.AddQuery("$top", top);
            path.AddQuery("$skip", skip);
            path.AddQuery("$orderBy", orderBy);
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult UpdateUser(Int32 id, Int32 accountId, UserModel model)
        {
            var path = new AvaTaxPath("/api/v2/accounts/{accountId}/users/{id}");
            path.ApplyField("id", id);
            path.ApplyField("accountId", accountId);
            return _client.RestCall("Put", path, model);
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
        public AvaTaxCallResult GetMySubscription(ServiceTypeId serviceTypeId)
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions/{serviceTypeId}");
            path.ApplyField("serviceTypeId", serviceTypeId);
            return _client.RestCall("Get", path, null);
        }


        /// <summary>
        /// List all services to which the current user is subscribed
        /// </summary>
        /// <remarks>
        /// Returns the list of all subscriptions enabled for the current account.
        /// This API is intended to help you determine whether you have the necessary subscription to use certain API calls
        /// within AvaTax.
        /// </remarks>
        public AvaTaxCallResult ListMySubscriptions()
        {
            var path = new AvaTaxPath("/api/v2/utilities/subscriptions");
            return _client.RestCall("Get", path, null);
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
        public AvaTaxCallResult Ping()
        {
            var path = new AvaTaxPath("/api/v2/utilities/ping");
            return _client.RestCall("Get", path, null);
        }

#endregion
    }
}
