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
    /// Represents the type of authentication provided to the API call
    /// </summary>
    public enum AuthenticationTypeId
    {
        /// <summary>
        /// This API call was not authenticated.
        /// </summary>
        None = 0,

        /// <summary>
        /// This API call was authenticated by your username/password.
        /// </summary>
        UsernamePassword = 1,

        /// <summary>
        /// This API call was authenticated by your Avalara Account ID and private license key.
        /// </summary>
        AccountIdLicenseKey = 2,

        /// <summary>
        /// This API call was authenticated by OpenID Bearer Token.
        /// </summary>
        OpenIdBearerToken = 3,

    }
}
